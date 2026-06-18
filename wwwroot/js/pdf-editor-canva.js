/**
 * RatPDF Canva Editor — simple, unified PDF editing.
 * Click select · Double-click edit text · Drag to move · One-click export
 */
window.PdfCanvaEditor = (function () {
    'use strict';

    const SCALE_DEFAULT = 1.2;
    const LAZY_MARGIN = '400px';
    const LINE_Y_TOLERANCE = 5;
    const THUMB_CANVAS_LIMIT = 50;
    const DRAG_SNAP_THRESHOLD = 2;

    const state = {
        sessionId: null,
        fileName: 'document.pdf',
        model: null,
        pdfDoc: null,
        scale: SCALE_DEFAULT,
        renderScale: SCALE_DEFAULT,
        edits: [],
        undoStack: [],
        redoStack: [],
        pageOrder: [],
        pageOps: [],
        pageRotations: {},
        deletedPages: new Set(),
        pageViews: {},
        observer: null,
        selection: null,
        editing: null,
        drag: null,
        draw: null,
        pending: null,
        commitTimer: null,
        rendering: false,
        savedEditRange: null,
        _colorPickActive: false,
        _deferEditBlur: false,
    };

    const $ = id => document.getElementById(id);

    function setStatus(msg, isError) {
        const el = $('editorStatus');
        if (el) {
            el.textContent = msg || '';
            el.classList.toggle('is-error', !!isError);
        }
    }

    function updateBadge() {
        const badge = $('editCountBadge');
        if (!badge) return;
        const n = state.edits.length + state.pageOps.length;
        badge.textContent = n ? `${n} change${n === 1 ? '' : 's'}` : 'No changes';
        badge.classList.toggle('has-edits', n > 0);
    }

    function pdfToScreen(r, scale) {
        return {
            left: r.x * scale,
            top: r.y * scale,
            width: r.width * scale,
            height: r.height * scale,
        };
    }

    function screenToPdf(x, y, scale) {
        return { x: x / scale, y: y / scale };
    }

    function overlayScale() {
        return state.renderScale;
    }

    function displayScaleFactor() {
        return state.scale / state.renderScale;
    }

    function pointerDeltaToPdf(dxPx, dyPx) {
        const factor = displayScaleFactor();
        return { dx: dxPx / (overlayScale() * factor), dy: dyPx / (overlayScale() * factor) };
    }

    function applyViewZoom() {
        const factor = displayScaleFactor();
        document.querySelectorAll('.cv-page, .cv-page-placeholder').forEach(el => {
            const idx = parseInt(el.dataset.page, 10);
            const pg = state.model?.pages?.[idx];
            if (!pg) return;
            const baseH = pg.height * state.renderScale;
            el.style.transformOrigin = 'top center';
            el.style.transform = Math.abs(factor - 1) < 0.001 ? '' : `scale(${factor})`;
            el.style.marginBottom = factor > 1 ? `${baseH * (factor - 1)}px` : '';
        });
        const label = $('zoomLabel');
        if (label) label.textContent = Math.round(state.scale * 100) + '%';
    }

    function setZoom(newScale) {
        if (!state.pdfDoc || Math.abs(newScale - state.scale) < 0.001) return;
        finishTextEdit();
        state.scale = Math.round(newScale * 100) / 100;
        applyViewZoom();
    }

    async function fetchModelSummary(sessionId) {
        const res = await fetch(`/pdf/edit/${sessionId}/model?summary=true`);
        if (!res.ok) throw new Error((await res.json().catch(() => ({}))).error || 'Could not load document model');
        return res.json();
    }

    async function ensurePageSpans(pageIdx) {
        const pg = state.model?.pages?.[pageIdx];
        if (!pg || pg.spansLoaded) return pg;
        const res = await fetch(`/pdf/edit/${state.sessionId}/model?page=${pageIdx}`);
        if (!res.ok) throw new Error('Could not load page text');
        const data = await res.json();
        pg.spans = data.spans || [];
        pg.spanCount = data.spanCount ?? pg.spans.length;
        pg.spansTruncated = !!data.spansTruncated;
        pg.spansLoaded = true;
        return pg;
    }

    function buildModelFromSummary(summary) {
        let pages = summary.pages || [];
        if (!pages.length && summary.pageCount > 0) {
            pages = Array.from({ length: summary.pageCount }, (_, i) => ({
                pageNum: i, width: 612, height: 792, spanCount: 0, spansTruncated: false,
            }));
        }
        return {
            pageCount: summary.pageCount,
            totalSpans: summary.totalSpans || 0,
            pages: pages.map(p => ({
                pageNum: p.pageNum,
                width: p.width,
                height: p.height,
                spanCount: p.spanCount || 0,
                spansTruncated: !!p.spansTruncated,
                spans: [],
                spansLoaded: false,
            })),
        };
    }

    function normalizeColor(c) {
        if (!c) return '#000000';
        if (c.startsWith('#')) return c.toLowerCase();
        if (c.startsWith('rgb')) return rgbToHex(c).toLowerCase();
        return c.toLowerCase();
    }

    function isTextUnchanged(span, el, plain) {
        const payload = buildTextPayload(state.editing?.pageIdx ?? 0, span, el);
        const prev = state.edits.find(e => e.type === 'text_replace' && e.spanId === span.id && !e._lineSuppress);
        return editPayloadsEqual(prev, payload);
    }

    function sanitizeRichHtml(el) {
        const clone = el.cloneNode(true);
        clone.querySelectorAll('.cv-text-mask').forEach(n => n.remove());
        return clone.innerHTML;
    }

    function editPayloadsEqual(a, b) {
        if (!a && !b) return true;
        if (!a || !b) return false;
        return a.text === b.text
            && a.richHtml === b.richHtml
            && !!a.bold === !!b.bold
            && !!a.italic === !!b.italic
            && normalizeColor(a.color) === normalizeColor(b.color)
            && Math.abs((a.fontSize || 12) - (b.fontSize || 12)) < 0.5
            && (a.fontFamily || '').split(',')[0].trim().toLowerCase() === (b.fontFamily || '').split(',')[0].trim().toLowerCase();
    }

    function measureEditBBox(span, el, scale) {
        const base = span._unionBbox || { x: span.x, y: span.y, width: span.width, height: span.height };
        const w = Math.max(el.scrollWidth || el.offsetWidth || 0, 4);
        const h = Math.max(el.scrollHeight || el.offsetHeight || 0, 10);
        return {
            x: base.x,
            y: base.y,
            width: Math.max(base.width, w / scale),
            height: Math.max(base.height, h / scale),
        };
    }

    function refreshPageOverlay(pageIdx) {
        syncTextAddsFromDom();
        const view = state.pageViews[pageIdx];
        if (!view?.overlay) return;
        const overlay = view.overlay;
        overlay.querySelectorAll('.cv-text, .cv-box, .cv-draw-preview').forEach(n => n.remove());
        renderPageTexts(overlay, pageIdx, overlayScale());
        state.edits.forEach((edit, i) => {
            if (edit.page === pageIdx && edit.type !== 'text_replace') renderBox(overlay, edit, i, overlayScale());
        });
    }

    function renderPageTexts(overlay, pageIdx, scale) {
        const spans = (state.model.pages[pageIdx]?.spans || [])
            .filter(s => !state.edits.some(e => e.type === 'text_replace' && e.spanId === s.id && e._lineSuppress));
        spans.forEach(span => renderSpan(overlay, pageIdx, span, scale));
    }

    function suppressClickAway() {
        state._suppressEditClickAway = true;
        requestAnimationFrame(() => {
            requestAnimationFrame(() => { state._suppressEditClickAway = false; });
        });
    }

    function placeCaretAtPoint(clientX, clientY) {
        const sel = window.getSelection();
        if (!sel) return;
        let range = null;
        if (document.caretRangeFromPoint) {
            range = document.caretRangeFromPoint(clientX, clientY);
        } else if (document.caretPositionFromPoint) {
            const pos = document.caretPositionFromPoint(clientX, clientY);
            if (pos) {
                range = document.createRange();
                range.setStart(pos.offsetNode, pos.offset);
                range.collapse(true);
            }
        }
        if (range) {
            sel.removeAllRanges();
            sel.addRange(range);
        }
    }

    function fillLineHitContent(el, lineSpans, scale) {
        const primary = lineSpans[0];
        if (lineSpans.length > 1) {
            el.innerHTML = buildLineMergedHtml(lineSpans);
        } else {
            const edit = state.edits.find(e => e.type === 'text_replace' && e.spanId === primary.id);
            if (edit?.richHtml) el.innerHTML = edit.richHtml;
            else el.textContent = edit?.text ?? primary.text ?? '';
        }
        applyTextStyle(el, spanStyle(primary), scale);
        el.style.color = 'transparent';
        el.style.webkitTextFillColor = 'transparent';
    }

    function bindTextEditActivation(el, pageIdx, span, lineSpans) {
        el.draggable = false;
        el.addEventListener('dragstart', e => e.preventDefault());
        let down = null;
        el.addEventListener('pointerdown', e => {
            if (state.pending === 'whiteout') return;
            if (state.pending || e.button !== 0) return;
            e.stopPropagation();
            if (state.editing?.el === el) return;
            down = { x: e.clientX, y: e.clientY };
        });
        el.addEventListener('pointerup', e => {
            if (!down || e.button !== 0) return;
            const dx = e.clientX - down.x;
            const dy = e.clientY - down.y;
            down = null;
            if (dx * dx + dy * dy > 64) return;
            e.stopPropagation();
            suppressClickAway();
            void beginTextEditFromHit(pageIdx, span, el, null, e.clientX, e.clientY);
        });
        el.addEventListener('dblclick', e => {
            if (state.pending) return;
            e.stopPropagation();
            e.preventDefault();
            suppressClickAway();
            const spans = findLineSpans(pageIdx, span);
            if (spans.length > 1) {
                void beginLineMergeEdit(pageIdx, span, el, spans, e.clientX, e.clientY);
            } else {
                void beginTextEditFromHit(pageIdx, span, el, null, e.clientX, e.clientY);
            }
        });
    }

    async function beginLineMergeEdit(pageIdx, span, el, lineSpans, clientX, clientY) {
        if (state.pending || state.editing?.el === el) return;
        const union = unionSpanBBox(lineSpans);
        span._unionBbox = union;
        el.innerHTML = buildLineMergedHtml(lineSpans);
        const pos = pdfToScreen(union, overlayScale());
        Object.assign(el.style, {
            left: pos.left + 'px',
            top: pos.top + 'px',
            width: Math.max(pos.width, 8) + 'px',
            minHeight: Math.max(pos.height, 10) + 'px',
        });
        applyTextStyle(el, spanStyle(lineSpans[0]), overlayScale(), union);
        await startTextEdit(pageIdx, lineSpans[0], el, { spans: lineSpans, hiddenEls: [] }, clientX, clientY);
        setStatus(`Editing line (${lineSpans.length} parts)`);
    }

    async function beginTextEditFromHit(pageIdx, span, el, lineSpans, clientX, clientY) {
        if (state.pending || state.editing?.el === el) return;
        if (!(el.textContent || '').trim() && !el.querySelector('b,i,span,a')) {
            el.textContent = span.text || '';
            applyTextStyle(el, spanStyle(span), overlayScale(), span);
        }
        await startTextEdit(pageIdx, span, el, null, clientX, clientY);
    }

    function renderLineHit(overlay, pageIdx, lineSpans, scale) {
        const primary = lineSpans[0];
        const union = unionSpanBBox(lineSpans);
        union.x -= 4; union.y -= 2; union.width += 8; union.height += 4;
        const pos = pdfToScreen(union, scale);
        const el = document.createElement('div');
        el.className = 'cv-text cv-line-hit';
        el.dataset.spanId = primary.id;
        el.title = lineSpans.map(s => s.text).join('');
        el.style.cssText = `left:${pos.left}px;top:${pos.top}px;width:${Math.max(pos.width, 8)}px;min-height:${Math.max(pos.height, 14)}px;`;
        fillLineHitContent(el, lineSpans, scale);
        bindTextEditActivation(el, pageIdx, primary, lineSpans);
        overlay.appendChild(el);
    }

    async function refreshPage(pageIdx) {
        await ensurePageSpans(pageIdx);
        if (state.pageViews[pageIdx]?.rendered) refreshPageOverlay(pageIdx);
    }

    async function invalidatePage(pageIdx) {
        syncTextAddsFromDom();
        await refreshPage(pageIdx);
    }

    function snapshot() {
        state.undoStack.push({
            edits: JSON.parse(JSON.stringify(state.edits)),
            pageOps: JSON.parse(JSON.stringify(state.pageOps)),
            pageOrder: state.pageOrder.slice(),
            pageRotations: { ...state.pageRotations },
            deletedPages: [...state.deletedPages],
        });
        state.redoStack = [];
    }

    function restoreSnap(s) {
        state.edits = s.edits;
        state.pageOps = s.pageOps;
        state.pageOrder = s.pageOrder.slice();
        state.pageRotations = { ...s.pageRotations };
        state.deletedPages = new Set(s.deletedPages);
    }

    function undo() {
        if (!state.undoStack.length) return;
        state.redoStack.push(captureNow());
        restoreSnap(state.undoStack.pop());
        clearSelection();
        rerenderAll(true).then(() => { setStatus('Undone'); updateBadge(); });
    }

    function redo() {
        if (!state.redoStack.length) return;
        state.undoStack.push(captureNow());
        restoreSnap(state.redoStack.pop());
        clearSelection();
        rerenderAll(true).then(() => { setStatus('Redone'); updateBadge(); });
    }

    function captureNow() {
        return {
            edits: JSON.parse(JSON.stringify(state.edits)),
            pageOps: JSON.parse(JSON.stringify(state.pageOps)),
            pageOrder: state.pageOrder.slice(),
            pageRotations: { ...state.pageRotations },
            deletedPages: [...state.deletedPages],
        };
    }

    function getActivePages() {
        return state.pageOrder.filter(p => !state.deletedPages.has(p));
    }

    function initPageOrder() {
        state.pageOrder = state.model.pages.map((_, i) => i);
    }

    function groupSpansIntoLines(spans) {
        const lines = new Map();
        spans.forEach(span => {
            const key = span.lineId || `y${Math.round(span.y / LINE_Y_TOLERANCE)}`;
            if (!lines.has(key)) lines.set(key, []);
            lines.get(key).push(span);
        });
        return [...lines.values()].map(s => s.sort((a, b) => a.x - b.x));
    }

    function ensureTextMask(el) {
        if (el.querySelector('.cv-text-mask')) return;
        el.prepend(Object.assign(document.createElement('div'), { className: 'cv-text-mask' }));
    }

    function removeTextMask(el) {
        el.querySelector('.cv-text-mask')?.remove();
    }

    function resolveTextAddInner(edit, index) {
        if (edit._el?.isConnected) {
            return edit._el.querySelector('.cv-text-add-inner') || edit._inner;
        }
        const overlay = state.pageViews[edit.page]?.overlay;
        const box = overlay?.querySelector(`.cv-box[data-edit-index="${index}"]`);
        return box?.querySelector('.cv-text-add-inner') || edit._inner;
    }

    function syncTextAddsFromDom() {
        state.edits.forEach((edit, index) => {
            if (edit.type !== 'text_add') return;
            const inner = resolveTextAddInner(edit, index);
            if (!inner) return;
            edit._inner = inner;
            let plain = (inner.textContent || '').trim();
            let html = inner.innerHTML;
            if (plain === 'Type here' || html === 'Type here') {
                plain = '';
                html = '';
            }
            edit.text = plain;
            edit.richHtml = html;
        });
    }

    function commitTextAddsFromDom() {
        const before = state.edits.map(e =>
            e.type === 'text_add' ? `${e.text}|${e.richHtml}` : '');
        syncTextAddsFromDom();
        const changed = state.edits.some((e, i) =>
            e.type === 'text_add' && `${e.text}|${e.richHtml}` !== before[i]);
        if (changed) {
            snapshot();
            updateBadge();
        }
        document.querySelectorAll('.cv-text-add-inner[contenteditable="true"]').forEach(el => {
            el.contentEditable = 'false';
        });
    }

    function bindTextAddInner(inner, edit, index) {
        if (inner.dataset.addBlurBound) return;
        inner.dataset.addBlurBound = '1';
        inner.addEventListener('blur', e => {
            const next = e.relatedTarget;
            if (next?.closest('#floatBar, #propsPanel, .cv-props, .cv-chip, .cv-input')) return;
            if (next?.closest('.cv-text, .cv-line-hit, .cv-overlay, .cv-box')) {
                commitTextAddsFromDom();
                return;
            }
            setTimeout(() => {
                const active = document.activeElement;
                if (active?.closest('#floatBar, #propsPanel, .cv-props, .cv-chip, .cv-input')) return;
                if (edit._inner !== inner) return;
                commitTextAddsFromDom();
            }, 0);
        });
    }

    function updateFloatBarVisibility() {
        const bar = $('floatBar');
        if (!bar) return;
        const open = !!state.sessionId;
        bar.classList.toggle('visible', open);
        bar.setAttribute('aria-hidden', open ? 'false' : 'true');
        bar.querySelector('.fb-format')?.classList.toggle('fb-format-visible', !!state.editing);
        const sepMain = bar.querySelector('.fb-sep-main');
        if (sepMain) sepMain.style.display = state.editing ? '' : 'none';
    }

    function clearSelection() {
        commitTextAddsFromDom();
        finishTextEdit();
        state.selection = null;
        $('propsPanel')?.classList.remove('open');
        updateFloatBarVisibility();
        document.querySelectorAll('.cv-selected').forEach(el => el.classList.remove('cv-selected'));
    }

    function getEditTarget() {
        if (state.editing?.el) return state.editing.el;
        if (state.selection?.type === 'text') return state.selection.el;
        if (state.selection?.type === 'textAdd') return state.selection.inner;
        return null;
    }

    function readStylesFromEl(el, fallback) {
        if (!el) return fallback || {};
        const scale = overlayScale();
        const px = parseFloat(el.style.fontSize);
        let fontSize = !isNaN(px) && px > 0 ? Math.round(px / scale * 10) / 10 : (fallback?.fontSize || 12);
        const innerFont = el.querySelector('font, span[style*="font-size"]');
        if (innerFont) {
            const innerPx = parseFloat(innerFont.style.fontSize || window.getComputedStyle(innerFont).fontSize);
            if (!isNaN(innerPx) && innerPx > 0) fontSize = Math.round(innerPx / scale * 10) / 10;
        }
        const fontFamily = (el.style.fontFamily || window.getComputedStyle(el).fontFamily || '')
            .split(',')[0].trim().replace(/^["']|["']$/g, '') || fallback?.fontFamily || 'Arial';
        let color = el.style.color;
        if (!color || color === 'transparent') {
            const colored = el.querySelector('[style*="color"], font[color]');
            if (colored) {
                color = colored.style.color || colored.getAttribute('color') || '';
            }
        }
        if (color && color.startsWith('rgb')) color = rgbToHex(color);
        if (!color || !color.startsWith('#')) color = fallback?.color || '#000000';
        const bold = el.style.fontWeight === '700' || el.style.fontWeight === 'bold'
            || parseInt(el.style.fontWeight, 10) >= 600;
        const italic = el.style.fontStyle === 'italic';
        return {
            fontFamily,
            fontSize,
            color: color.startsWith('#') ? color : (fallback?.color || '#000000'),
            bold,
            italic,
            pdfFontName: fallback?.pdfFontName || '',
        };
    }

    function rgbToHex(rgb) {
        const m = rgb.match(/\d+/g);
        if (!m || m.length < 3) return '#000000';
        return '#' + m.slice(0, 3).map(n => parseInt(n, 10).toString(16).padStart(2, '0')).join('');
    }

    function findLineSpans(pageIdx, span) {
        const spans = state.model.pages[pageIdx]?.spans || [];
        if (span.lineId) {
            const same = spans.filter(s => s.lineId === span.lineId);
            if (same.length > 1) return same.sort((a, b) => a.x - b.x);
        }
        return spans
            .filter(s => Math.abs(s.y - span.y) <= LINE_Y_TOLERANCE)
            .sort((a, b) => a.x - b.x);
    }

    function unionSpanBBox(spans) {
        let x0 = Infinity, y0 = Infinity, x1 = -Infinity, y1 = -Infinity;
        spans.forEach(s => {
            x0 = Math.min(x0, s.x);
            y0 = Math.min(y0, s.y);
            x1 = Math.max(x1, s.x + s.width);
            y1 = Math.max(y1, s.y + s.height);
        });
        return { x: x0, y: y0, width: x1 - x0, height: y1 - y0 };
    }

    function spanDisplayHtml(span) {
        const existing = state.edits.find(e => e.type === 'text_replace' && e.spanId === span.id);
        if (existing?.richHtml) return existing.richHtml;
        const text = existing?.text ?? span.text ?? '';
        if (!text) return '';
        const st = spanStyle(span);
        let html = escapeHtml(text);
        if (st.bold) html = `<b>${html}</b>`;
        if (st.italic) html = `<i>${html}</i>`;
        if (st.color && st.color.toLowerCase() !== '#000000') html = `<span style="color:${st.color}">${html}</span>`;
        return html;
    }

    function buildLineMergedHtml(lineSpans) {
        return lineSpans.map(spanDisplayHtml).join('');
    }

    function selectItem(type, data) {
        clearSelection();
        state.selection = { type, ...data };
        $('propsPanel')?.classList.add('open');
        syncPropsPanel();
        if (data.el) data.el.classList.add('cv-selected');
    }

    function spanStyle(span) {
        const edit = state.edits.find(e => e.type === 'text_replace' && e.spanId === span.id);
        if (edit) {
            const hasInlineFmt = !!(edit.richHtml && edit.richHtml.includes('<'));
            return {
                fontFamily: edit.fontFamily || span.fontFamily || 'Arial',
                fontSize: edit.fontSize || span.fontSize || 12,
                color: edit.color || span.color || '#000000',
                bold: hasInlineFmt ? false : (edit.bold ?? span.bold),
                italic: hasInlineFmt ? false : (edit.italic ?? span.italic),
                pdfFontName: edit.pdfFontName || span.pdfFontName || '',
            };
        }
        return {
            fontFamily: span.fontFamily || 'Arial',
            fontSize: span.fontSize || 12,
            color: span.color || '#000000',
            bold: !!span.bold,
            italic: !!span.italic,
            pdfFontName: span.pdfFontName || '',
        };
    }

    function applyTextStyle(el, st, scale, bbox) {
        el.style.fontFamily = `"${st.fontFamily}", sans-serif`;
        el.style.fontSize = (st.fontSize * scale) + 'px';
        el.style.fontWeight = st.bold ? '700' : '400';
        el.style.fontStyle = st.italic ? 'italic' : 'normal';
        const lh = bbox?.height ? (bbox.height * scale) : st.fontSize * scale * 1.15;
        el.style.lineHeight = lh + 'px';
    }

    function hideSpan(el) {
        el.style.color = 'transparent';
        el.style.webkitTextFillColor = 'transparent';
        el.style.background = 'transparent';
        el.style.boxShadow = 'none';
        el.style.outline = 'none';
        removeTextMask(el);
    }

    function showSpanEdit(el, st, scale) {
        ensureTextMask(el);
        applyTextStyle(el, st, scale);
        el.style.color = st.color;
        el.style.webkitTextFillColor = 'initial';
        el.style.background = 'transparent';
        el.style.boxShadow = 'none';
        el.classList.add('cv-has-edit');
    }

    function showSpanActive(el, st, scale) {
        ensureTextMask(el);
        applyTextStyle(el, st, scale);
        el.style.color = st.color;
        el.style.webkitTextFillColor = 'initial';
        el.style.background = 'transparent';
        el.style.boxShadow = 'none';
    }

    function ensureEditing() {
        return !!state.editing;
    }

    function buildTextPayload(pageIdx, span, el) {
        const richHtml = sanitizeRichHtml(el);
        const plain = el.textContent || '';
        const st = readStylesFromEl(el, spanStyle(span));
        const origSt = spanStyle(span);
        const bbox = measureEditBBox(span, el, overlayScale());
        const hasInlineFmt = richHtml.includes('<');
        return {
            type: 'text_replace',
            page: pageIdx,
            spanId: span.id,
            x: bbox.x, y: bbox.y, width: bbox.width, height: bbox.height,
            text: plain,
            richHtml,
            fontSize: st.fontSize,
            fontFamily: st.fontFamily,
            pdfFontName: st.fontFamily === origSt.fontFamily ? (origSt.pdfFontName || '') : '',
            bold: hasInlineFmt ? false : st.bold,
            italic: hasInlineFmt ? false : st.italic,
            color: st.color,
        };
    }

    function commitLineMerge(pageIdx, primarySpan, el, lineSpans) {
        const plain = (el.textContent || '').trim();
        if (!plain) return;
        const union = unionSpanBBox(lineSpans);
        primarySpan._unionBbox = union;
        const payload = buildTextPayload(pageIdx, primarySpan, el);
        snapshot();
        const idx = state.edits.findIndex(e => e.type === 'text_replace' && e.spanId === primarySpan.id);
        if (idx >= 0) state.edits[idx] = payload;
        else state.edits.push(payload);
        lineSpans.filter(s => s.id !== primarySpan.id).forEach(s => {
            const suppress = {
                type: 'text_replace', page: pageIdx, spanId: s.id,
                x: s.x, y: s.y, width: s.width, height: s.height,
                text: '', richHtml: '',
                fontSize: s.fontSize || 12, fontFamily: s.fontFamily || 'Arial',
                pdfFontName: s.pdfFontName || '', bold: !!s.bold, italic: !!s.italic,
                color: s.color || '#000000', _lineSuppress: true,
            };
            const si = state.edits.findIndex(e => e.type === 'text_replace' && e.spanId === s.id);
            if (si >= 0) state.edits[si] = suppress;
            else state.edits.push(suppress);
        });
        updateBadge();
    }

    async function commitTextEdit() {
        if (!state.editing) return;
        commitTextAddsFromDom();
        const { pageIdx, span, el, lineMerge } = state.editing;
        const plain = (el.textContent || '').trim();

        el.contentEditable = 'false';
        el.classList.remove('cv-editing');
        el.removeEventListener('blur', onEditBlur);
        document.removeEventListener('selectionchange', onEditSelectionChange);
        state.savedEditRange = null;

        if (lineMerge?.hiddenEls) {
            lineMerge.hiddenEls.forEach(h => { h.style.display = ''; });
        }

        if (lineMerge?.spans?.length > 1) {
            if (plain) commitLineMerge(pageIdx, span, el, lineMerge.spans);
            state.editing = null;
            updateFloatBarVisibility();
            await invalidatePage(pageIdx);
            return;
        }

        const payload = buildTextPayload(pageIdx, span, el);
        const idx = state.edits.findIndex(e => e.type === 'text_replace' && e.spanId === span.id && !e._lineSuppress);
        const prev = idx >= 0 ? state.edits[idx] : null;

        if (plain) {
            if (!editPayloadsEqual(prev, payload)) {
                snapshot();
                if (idx >= 0) state.edits[idx] = payload;
                else state.edits.push(payload);
                updateBadge();
            }
        } else if (prev) {
            snapshot();
            state.edits.splice(idx, 1);
            updateBadge();
        }

        state.editing = null;
        updateFloatBarVisibility();
        await invalidatePage(pageIdx);
    }

    function finishTextEdit() {
        if (state.editing) return commitTextEdit();
        return Promise.resolve();
    }

    function beginColorPick() {
        state._colorPickActive = true;
        saveEditSelection();
    }

    function endColorPick() {
        state._colorPickActive = false;
        if (state.editing?.el) {
            state.editing.el.focus({ preventScroll: true });
            restoreEditSelection();
        }
    }

    function onEditBlur(e) {
        if (!state.editing?.el || state.editing.el !== e.target) return;
        if (state._colorPickActive || state._deferEditBlur) return;
        const next = e.relatedTarget;
        if (next?.closest('#floatBar, #propsPanel, .cv-props, .cv-chip, .cv-input, .fb-highlight-label')) return;
        setTimeout(() => {
            if (!state.editing?.el || state.editing.el !== e.target) return;
            if (state._colorPickActive || state._deferEditBlur) return;
            const active = document.activeElement;
            if (active?.closest('#floatBar, #propsPanel, .cv-props, .cv-chip, .cv-input, .fb-highlight-label')) return;
            finishTextEdit();
        }, 0);
    }

    function onEditSelectionChange() {
        if (state.editing) saveEditSelection();
    }

    function escapeHtml(t) {
        return (t || '').replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    async function startTextEdit(pageIdx, span, el, lineMerge, clientX, clientY) {
        if (state.pending) return;
        commitTextAddsFromDom();
        await finishTextEdit();
        el.classList.remove('cv-line-hit');
        state.selection = { type: 'text', pageIdx, span, el };
        state.editing = { pageIdx, span, el, lineMerge: lineMerge || null };
        el.contentEditable = 'true';
        el.classList.add('cv-editing');
        el.classList.remove('cv-selected');
        const bbox = span._unionBbox || { x: span.x, y: span.y, width: span.width, height: span.height };
        const st = spanStyle(span);
        applyTextStyle(el, readStylesFromEl(el, st), overlayScale(), bbox);
        showSpanActive(el, readStylesFromEl(el, st), overlayScale());
        const pos = pdfToScreen(bbox, overlayScale());
        el.style.width = 'auto';
        el.style.minWidth = Math.max(pos.width, 20) + 'px';
        el.style.maxWidth = 'none';
        el.style.overflow = 'visible';
        el.style.whiteSpace = 'pre-wrap';
        el.style.wordBreak = 'break-word';
        el.focus({ preventScroll: true });
        el.addEventListener('blur', onEditBlur);
        document.addEventListener('selectionchange', onEditSelectionChange);
        requestAnimationFrame(() => {
            if (clientX != null && clientY != null) {
                placeCaretAtPoint(clientX, clientY);
            } else {
                try {
                    const range = document.createRange();
                    range.selectNodeContents(el);
                    range.collapse(false);
                    const sel = window.getSelection();
                    sel?.removeAllRanges();
                    sel?.addRange(range);
                } catch (e) { /* ignore */ }
            }
        });
        updateFloatBarVisibility();
        $('propsPanel')?.classList.add('open');
        buildPropsPanelForEdit(span);
        setStatus('Editing — click away or Escape to finish');
    }

    function pushEdit(edit) {
        snapshot();
        state.edits.push(edit);
        updateBadge();
    }

    function removeEditAt(index) {
        if (index < 0) return;
        snapshot();
        state.edits.splice(index, 1);
        updateBadge();
        clearSelection();
        rerenderAll(true);
    }

    function renderBox(overlay, edit, index, scale) {
        const pos = pdfToScreen(edit, scale);
        const el = document.createElement('div');
        el.className = 'cv-box';
        el.dataset.editIndex = String(index);
        el.style.cssText = `left:${pos.left}px;top:${pos.top}px;width:${Math.max(pos.width, 4)}px;height:${Math.max(pos.height, 4)}px;`;

        if (edit.type === 'whiteout') {
            el.style.background = '#fff';
            el.style.border = '1px solid #e2e8f0';
        } else if (edit.type === 'image') {
            const img = document.createElement('img');
            img.src = edit._preview || '';
            img.draggable = false;
            img.style.cssText = 'width:100%;height:100%;object-fit:contain;pointer-events:none;';
            el.appendChild(img);
        } else if (edit.type === 'text_add') {
            el.classList.add('cv-text-add');
            const inner = document.createElement('div');
            inner.className = 'cv-text-add-inner';
            inner.contentEditable = 'false';
            inner.innerHTML = edit.richHtml || edit.text || 'Type here';
            applyTextStyle(inner, edit, scale);
            inner.style.color = edit.color || '#000';
            el.appendChild(inner);
            edit._inner = inner;
            bindTextAddInner(inner, edit, index);
        }

        edit._el = el;

        el.addEventListener('mousedown', e => {
            if (state.editing) return;
            if (e.target.closest('.cv-handle')) return;
            // While a text box is being edited, let clicks place the caret instead
            // of starting a drag / re-selecting the box (which would end editing).
            if (e.target.closest('.cv-text-add-inner[contenteditable="true"]')) return;
            e.stopPropagation();
            selectItem('box', { index, edit, el });
            state.drag = {
                index, el, edit,
                startX: e.clientX, startY: e.clientY,
                origX: edit.x, origY: edit.y,
            };
        });

        el.addEventListener('dblclick', e => {
            if (edit.type !== 'text_add') return;
            e.stopPropagation();
            const inner = edit._inner || el.querySelector('.cv-text-add-inner');
            if (!inner) return;
            // selectItem() commits/clears prior edits (disabling contentEditable),
            // so it must run before we (re-)enable typing on this inner.
            selectItem('textAdd', { index, edit, el, inner });
            inner.contentEditable = 'true';
            bindTextAddInner(inner, edit, index);
            inner.focus();
            selectDefaultText(inner);
        });

        if (edit.type === 'image') addResizeHandles(el, edit, index);
        overlay.appendChild(el);
    }

    function addResizeHandles(el, edit, index) {
        ['nw', 'ne', 'sw', 'se'].forEach(corner => {
            const h = document.createElement('div');
            h.className = 'cv-handle cv-handle-' + corner;
            h.dataset.corner = corner;
            h.addEventListener('pointerdown', ev => startResize(ev, edit, index, el, corner));
            el.appendChild(h);
        });
    }

    function startResize(ev, edit, index, el, corner) {
        if (state.editing) return;
        ev.preventDefault();
        ev.stopPropagation();
        selectItem('box', { index, edit, el });
        const scale = overlayScale();
        const start = { x: ev.clientX, y: ev.clientY, ox: edit.x, oy: edit.y, ow: edit.width, oh: edit.height };
        const ratio = edit.height ? edit.width / edit.height : 1;
        const keepRatio = edit.type === 'image';
        const minW = 12, minH = 12;
        const east = corner === 'ne' || corner === 'se';
        const west = corner === 'nw' || corner === 'sw';
        const north = corner === 'nw' || corner === 'ne';
        const south = corner === 'sw' || corner === 'se';
        let snapped = false;
        state._resizing = true;
        try { el.setPointerCapture(ev.pointerId); } catch (_) { }

        const onMove = e => {
            const d = pointerDeltaToPdf(e.clientX - start.x, e.clientY - start.y);
            let x = start.ox, y = start.oy, w = start.ow, h = start.oh;
            if (east) w = Math.max(minW, start.ow + d.dx);
            if (west) { w = Math.max(minW, start.ow - d.dx); x = start.ox + (start.ow - w); }
            if (south) h = Math.max(minH, start.oh + d.dy);
            if (north) { h = Math.max(minH, start.oh - d.dy); y = start.oy + (start.oh - h); }
            // Images keep aspect ratio by default; hold Shift to distort freely.
            if (keepRatio && !e.shiftKey) {
                h = w / ratio;
                if (north) y = start.oy + (start.oh - h);
            }
            if (!snapped) { snapshot(); snapped = true; }
            edit.x = x; edit.y = y; edit.width = w; edit.height = h;
            const pos = pdfToScreen(edit, scale);
            el.style.left = pos.left + 'px';
            el.style.top = pos.top + 'px';
            el.style.width = Math.max(pos.width, 4) + 'px';
            el.style.height = Math.max(pos.height, 4) + 'px';
        };
        const onUp = () => {
            el.removeEventListener('pointermove', onMove);
            el.removeEventListener('pointerup', onUp);
            el.removeEventListener('pointercancel', onUp);
            try { el.releasePointerCapture(ev.pointerId); } catch (_) { }
            state._resizing = false;
            if (snapped) updateBadge();
        };
        el.addEventListener('pointermove', onMove);
        el.addEventListener('pointerup', onUp);
        el.addEventListener('pointercancel', onUp);
    }

    function hexToRgba(hex, a) {
        if (!hex?.startsWith('#') || hex.length < 7) return `rgba(254,240,138,${a})`;
        const r = parseInt(hex.slice(1, 3), 16), g = parseInt(hex.slice(3, 5), 16), b = parseInt(hex.slice(5, 7), 16);
        return `rgba(${r},${g},${b},${a})`;
    }

    function renderSpan(overlay, pageIdx, span, scale) {
        if (state.edits.some(e => e.type === 'text_replace' && e.spanId === span.id && e._lineSuppress)) return;

        const edit = state.edits.find(e => e.type === 'text_replace' && e.spanId === span.id);
        const bbox = edit && !edit._lineSuppress
            ? { x: edit.x, y: edit.y, width: edit.width, height: edit.height }
            : span;
        const pos = pdfToScreen(bbox, scale);
        const el = document.createElement('div');
        el.className = 'cv-text';
        el.dataset.spanId = span.id;

        const st = spanStyle(span);
        if (edit?.richHtml) el.innerHTML = edit.richHtml;
        else el.textContent = edit?.text ?? span.text;

        el.style.cssText = `left:${pos.left}px;top:${pos.top}px;min-width:${Math.max(pos.width, 4)}px;min-height:${Math.max(pos.height, 10)}px;${edit ? 'width:auto;' : ''}`;
        applyTextStyle(el, st, scale, bbox);
        if (edit) {
            el.classList.add('cv-has-edit');
            showSpanEdit(el, st, scale);
        } else {
            hideSpan(el);
        }

        bindTextEditActivation(el, pageIdx, span, null);

        overlay.appendChild(el);
    }

    async function renderPage(pageIdx) {
        await ensurePageSpans(pageIdx);
        const page = await state.pdfDoc.getPage(pageIdx + 1);
        const vp = page.getViewport({ scale: state.renderScale });
        const wrap = document.createElement('div');
        wrap.className = 'cv-page';
        wrap.dataset.page = String(pageIdx);
        if (state.deletedPages.has(pageIdx)) wrap.classList.add('cv-page-deleted');

        const canvas = document.createElement('canvas');
        canvas.width = vp.width;
        canvas.height = vp.height;
        const overlay = document.createElement('div');
        overlay.className = 'cv-overlay';
        overlay.style.width = vp.width + 'px';
        overlay.style.height = vp.height + 'px';

        wrap.appendChild(canvas);
        wrap.appendChild(overlay);
        await page.render({ canvasContext: canvas.getContext('2d'), viewport: vp }).promise;

        (state.model.pages[pageIdx]?.spans || []);
        renderPageTexts(overlay, pageIdx, overlayScale());
        state.edits.forEach((edit, i) => {
            if (edit.page === pageIdx && edit.type !== 'text_replace') renderBox(overlay, edit, i, overlayScale());
        });

        bindOverlay(overlay, pageIdx);
        applyPageRotation(pageIdx, wrap);
        state.pageViews[pageIdx] = { wrap, overlay, rendered: true };
        return wrap;
    }

    function overlayPoint(overlay, clientX, clientY) {
        const rect = overlay.getBoundingClientRect();
        return { x: clientX - rect.left, y: clientY - rect.top, rect };
    }

    function overlayToPdf(overlay, clientX, clientY) {
        const pt = overlayPoint(overlay, clientX, clientY);
        const factor = displayScaleFactor();
        return screenToPdf(pt.x / factor, pt.y / factor, overlayScale());
    }

    function bindOverlay(overlay, pageIdx) {
        overlay.addEventListener('mousedown', e => {
            if (state.pending === 'whiteout') {
                e.preventDefault();
                e.stopPropagation();
                startAreaDraw(pageIdx, overlay, e.clientX, e.clientY);
                return;
            }
            if (!state.pending && e.target !== overlay) return;
            if (state.editing && e.target === overlay) { finishTextEdit(); return; }

            if (state.pending === 'text') {
                e.preventDefault();
                e.stopPropagation();
                const tl = overlayToPdf(overlay, e.clientX, e.clientY);
                pushEdit({
                    type: 'text_add', page: pageIdx,
                    x: tl.x, y: tl.y, width: 200, height: 32,
                    text: '', richHtml: '', fontSize: 14, fontFamily: 'Arial',
                    color: '#000000', bold: false, italic: false,
                });
                state.pending = null;
                $('topBar')?.classList.remove('pending-text');
                invalidatePage(pageIdx).then(() => {
                    const idx = state.edits.length - 1;
                    const edit = state.edits[idx];
                    if (edit._inner) {
                        selectItem('textAdd', { index: idx, edit, el: edit._el, inner: edit._inner });
                        edit._inner.contentEditable = 'true';
                        bindTextAddInner(edit._inner, edit, idx);
                        edit._inner.focus();
                        selectDefaultText(edit._inner);
                        updateFloatBarVisibility();
                    }
                });
                return;
            }

            if (state.pending === 'image' && state._imageDataUrl) {
                e.preventDefault();
                e.stopPropagation();
                const tl = overlayToPdf(overlay, e.clientX, e.clientY);
                const dataUrl = state._imageDataUrl;
                state.pending = null;
                state._imageDataUrl = null;
                $('topBar')?.classList.remove('pending-image');
                placeImage(pageIdx, tl.x, tl.y, dataUrl);
                return;
            }

            if (e.target === overlay) clearSelection();
        }, true);
    }

    async function placeImage(pageIdx, x, y, dataUrl) {
        if (!state.sessionId) { setStatus('Open a PDF first', true); return; }
        let assetId = null;
        try {
            const blob = await fetch(dataUrl).then(r => r.blob());
            const fd = new FormData();
            fd.append('sessionId', state.sessionId);
            fd.append('file', blob, 'image.png');
            const res = await fetch('/pdf/edit/asset', { method: 'POST', body: fd });
            if (!res.ok) {
                const err = await res.json().catch(() => ({}));
                throw new Error(err.error || 'Image upload failed');
            }
            assetId = (await res.json()).assetId;
        } catch (err) {
            setStatus(err.message || 'Could not add image', true);
            return;
        }
        const img = new Image();
        img.onload = () => {
            const h = 100, w = h * (img.width / img.height);
            pushEdit({
                type: 'image', page: pageIdx, x, y, width: w, height: h,
                imageAssetId: assetId, _preview: dataUrl,
            });
            invalidatePage(pageIdx);
            setStatus('Image added — drag to move');
        };
        img.onerror = () => setStatus('Invalid image', true);
        img.src = dataUrl;
    }

    function applyPageRotation(pageIdx, wrap) {
        const deg = state.pageRotations[pageIdx] || 0;
        wrap.style.transform = deg ? `rotate(${deg}deg)` : '';
        wrap.style.transformOrigin = 'center center';
    }

    function bindThumbActions(thumb, pageIdx) {
        thumb.querySelector('[data-act="rotate"]')?.addEventListener('click', e => {
            e.stopPropagation();
            rotatePage(pageIdx);
        });
        thumb.querySelector('[data-act="delete"]')?.addEventListener('click', e => {
            e.stopPropagation();
            if (confirm(`Delete page ${pageIdx + 1}?`)) deletePage(pageIdx);
        });
    }

    function createThumbShell(pageIdx) {
        const thumb = document.createElement('button');
        thumb.type = 'button';
        thumb.className = 'cv-thumb';
        thumb.dataset.page = String(pageIdx);
        thumb.draggable = !state.deletedPages.has(pageIdx);
        if (state.deletedPages.has(pageIdx)) thumb.classList.add('deleted');
        if (pageIdx === getActivePages()[0]) thumb.classList.add('active');

        const actions = document.createElement('div');
        actions.className = 'cv-thumb-actions';
        actions.innerHTML = '<button type="button" class="cv-thumb-act" data-act="rotate" title="Rotate">↻</button>'
            + '<button type="button" class="cv-thumb-act" data-act="delete" title="Delete">×</button>';
        thumb.appendChild(actions);

        const label = document.createElement('span');
        label.className = 'cv-thumb-num';
        label.textContent = String(pageIdx + 1);
        thumb.appendChild(label);

        thumb.addEventListener('click', e => {
            if (e.target.closest('.cv-thumb-act')) return;
            document.querySelectorAll('.cv-thumb').forEach(t => t.classList.remove('active'));
            thumb.classList.add('active');
            state.pageViews[pageIdx]?.wrap?.scrollIntoView({ behavior: 'smooth', block: 'start' });
        });

        bindThumbActions(thumb, pageIdx);
        return thumb;
    }

    async function renderThumb(pageIdx) {
        const useSimple = state.model.pageCount > THUMB_CANVAS_LIMIT;
        const thumb = createThumbShell(pageIdx);

        if (useSimple) {
            const simple = document.createElement('div');
            simple.className = 'cv-thumb-simple';
            simple.textContent = `Page ${pageIdx + 1}`;
            thumb.appendChild(simple);
        } else {
            const page = await state.pdfDoc.getPage(pageIdx + 1);
            const vp = page.getViewport({ scale: 0.15 });
            const canvas = document.createElement('canvas');
            canvas.width = vp.width;
            canvas.height = vp.height;
            await page.render({ canvasContext: canvas.getContext('2d'), viewport: vp }).promise;
            thumb.appendChild(canvas);
        }

        $('pagePanel')?.appendChild(thumb);
    }

    function setupPageDrag() {
        const panel = $('pagePanel');
        if (!panel || panel.dataset.bound) return;
        panel.dataset.bound = '1';
        let fromPage = null;

        panel.addEventListener('dragstart', e => {
            const t = e.target.closest('.cv-thumb');
            if (!t || t.classList.contains('deleted')) { e.preventDefault(); return; }
            fromPage = parseInt(t.dataset.page, 10);
            t.classList.add('dragging');
        });
        panel.addEventListener('dragover', e => { e.preventDefault(); });
        panel.addEventListener('drop', e => {
            e.preventDefault();
            const t = e.target.closest('.cv-thumb');
            panel.querySelectorAll('.dragging').forEach(x => x.classList.remove('dragging'));
            if (!t || fromPage == null) return;
            const toPage = parseInt(t.dataset.page, 10);
            if (fromPage === toPage) return;
            const order = getActivePages();
            const fi = order.indexOf(fromPage), ti = order.indexOf(toPage);
            if (fi < 0 || ti < 0) return;
            snapshot();
            order.splice(fi, 1);
            order.splice(ti, 0, fromPage);
            state.pageOrder = order;
            rerenderAll(true);
            setStatus('Pages reordered');
        });
        panel.addEventListener('dragend', () => {
            panel.querySelectorAll('.dragging').forEach(x => x.classList.remove('dragging'));
            fromPage = null;
        });
    }

    function setupObserver() {
        state.observer?.disconnect();
        const viewer = $('canvasWrap');
        if (!viewer || !window.IntersectionObserver) return;
        state.observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) return;
                const idx = parseInt(entry.target.dataset.page, 10);
                if (!isNaN(idx)) ensurePage(idx);
            });
        }, { root: viewer, rootMargin: LAZY_MARGIN });
        viewer.querySelectorAll('.cv-page-placeholder').forEach(el => state.observer.observe(el));
    }

    async function ensurePage(pageIdx) {
        if (state.pageViews[pageIdx]?.rendered) return;
        const viewer = $('canvasPanel');
        const ph = viewer?.querySelector(`.cv-page-placeholder[data-page="${pageIdx}"]`);
        try {
            const wrap = await renderPage(pageIdx);
            if (ph) ph.replaceWith(wrap);
            else viewer?.appendChild(wrap);
        } catch (err) {
            console.error(`Page ${pageIdx + 1} render failed:`, err);
            if (ph) {
                ph.classList.remove('cv-page-skeleton');
                ph.innerHTML = `<p style="padding:24px;color:#b91c1c;text-align:center">Could not render page ${pageIdx + 1}</p>`;
            }
            throw err;
        }
    }

    function pagePlaceholder(pageIdx) {
        const ph = document.createElement('div');
        ph.className = 'cv-page-placeholder cv-page-skeleton';
        ph.dataset.page = String(pageIdx);
        const pg = state.model.pages[pageIdx];
        ph.style.width = ((pg?.width || 612) * state.renderScale) + 'px';
        ph.style.height = ((pg?.height || 792) * state.renderScale) + 'px';
        return ph;
    }

    async function layoutDocument(rebuildThumbs) {
        const viewer = $('canvasPanel');
        const panel = $('pagePanel');
        if (rebuildThumbs !== false) {
            if (viewer) viewer.innerHTML = '';
            if (panel) panel.innerHTML = '';
            state.pageViews = {};

            for (const idx of state.pageOrder) {
                await renderThumb(idx);
                if (!state.deletedPages.has(idx)) viewer?.appendChild(pagePlaceholder(idx));
            }
            for (const idx of state.deletedPages) {
                if (!panel?.querySelector(`[data-page="${idx}"]`)) await renderThumb(idx);
            }
        } else {
            viewer?.querySelectorAll('.cv-page-placeholder').forEach(ph => {
                const idx = parseInt(ph.dataset.page, 10);
                const pg = state.model.pages[idx];
                if (pg) {
                    ph.style.width = (pg.width * state.renderScale) + 'px';
                    ph.style.height = (pg.height * state.renderScale) + 'px';
                }
            });
            for (const idx of Object.keys(state.pageViews)) {
                const pageIdx = parseInt(idx, 10);
                if (state.pageViews[pageIdx]?.rendered) {
                    state.pageViews[pageIdx].rendered = false;
                    const ph = pagePlaceholder(pageIdx);
                    state.pageViews[pageIdx].wrap.replaceWith(ph);
                    delete state.pageViews[pageIdx];
                    await ensurePage(pageIdx);
                }
            }
        }

        const active = getActivePages();
        for (let i = 0; i < Math.min(2, active.length); i++) await ensurePage(active[i]);
        setupObserver();
        setupPageDrag();
        applyViewZoom();
    }

    async function rerenderAll(rebuildThumbs) {
        if (!state.pdfDoc || state.rendering) return;
        syncTextAddsFromDom();
        state.rendering = true;
        const scroll = $('canvasWrap')?.scrollTop || 0;
        try {
            await layoutDocument(rebuildThumbs);
            const vp = $('canvasWrap');
            if (vp) vp.scrollTop = scroll;
        } finally {
            state.rendering = false;
        }
    }

    function showLoadFailure(msg) {
        state.sessionId = null;
        state.pdfDoc = null;
        state.model = null;
        state.pageViews = {};
        $('canvasPanel') && ($('canvasPanel').innerHTML = '');
        $('pagePanel') && ($('pagePanel').innerHTML = '');
        $('emptyState')?.classList.remove('d-none');
        $('editorRoot')?.classList.add('d-none');
        updateFloatBarVisibility();
        setStatus(msg || 'Could not open PDF — please upload again.', true);
    }

    async function loadDocument(sessionId, fileName) {
        if (typeof pdfjsLib === 'undefined') {
            throw new Error('PDF viewer failed to load. Check your connection and refresh the page.');
        }
        setStatus('Opening PDF…');
        state.sessionId = sessionId;
        state.fileName = fileName || 'document.pdf';
        state.edits = [];
        state.undoStack = [];
        state.redoStack = [];
        state.pageOps = [];
        state.pageRotations = {};
        state.deletedPages = new Set();
        state.scale = SCALE_DEFAULT;
        state.renderScale = SCALE_DEFAULT;

        pdfjsLib.GlobalWorkerOptions.workerSrc =
            'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.11.174/pdf.worker.min.js';

        let summary;
        try {
            summary = await fetchModelSummary(sessionId);
        } catch (err) {
            throw new Error(err.message?.includes('403') || err.message?.includes('Forbid')
                ? 'Session expired — please open your PDF again.'
                : (err.message || 'Could not load document model'));
        }
        state.model = buildModelFromSummary(summary);

        initPageOrder();
        try {
            state.pdfDoc = await pdfjsLib.getDocument(`/pdf/edit/${sessionId}/file`).promise;
        } catch (err) {
            throw new Error('Could not load PDF file — please open it again.');
        }

        $('emptyState')?.classList.add('d-none');
        $('editorRoot')?.classList.remove('d-none');
        try {
            await layoutDocument(true);
        } catch (err) {
            console.error('PDF layout failed:', err);
            throw new Error('Could not render PDF pages — please try uploading again.');
        }
        updateBadge();

        const spanCount = state.model.totalSpans
            || state.model.pages.reduce((n, p) => n + (p.spanCount || 0), 0);
        const truncated = state.model.pages.some(p => p.spansTruncated);

        if (state.model.pageCount > THUMB_CANVAS_LIMIT) {
            setStatus(`${state.model.pageCount} pages — scroll to navigate · text loads per page`);
        } else if (spanCount > 40) {
            setStatus('Click any text to edit · Lines grouped for easier selection');
        } else if (spanCount === 0) {
            setStatus('No editable text found — use the Text tool to add text, or try OCR PDF for scanned documents');
        } else {
            setStatus('Click text to edit · Double-click a line to edit it all at once');
        }
        if (truncated) {
            setStatus('Some pages have dense text — only the first 800 areas per page are editable', true);
        }
        updateFloatBarVisibility();
    }

    async function bootFromServer(sessionId, fileName) {
        try {
            await loadDocument(sessionId, fileName);
        } catch (err) {
            console.error('PDF editor load failed:', err);
            showLoadFailure(err.message || 'Could not open PDF.');
        }
    }

    function uploadFileWithProgress(file) {
        return new Promise((resolve, reject) => {
            const fd = new FormData();
            fd.append('file', file);
            const xhr = new XMLHttpRequest();
            const bar = $('importProgressBar');
            const msg = $('importProgressMsg');
            const area = $('importProgressArea');
            area.style.display = 'block';
            if (bar) bar.style.width = '0%';
            if (msg) msg.textContent = 'Uploading…';

            xhr.upload.onprogress = e => {
                if (!e.lengthComputable) return;
                const pct = Math.round((e.loaded / e.total) * 100);
                if (bar) bar.style.width = pct + '%';
                if (msg) msg.textContent = pct < 100 ? `Uploading… ${pct}%` : 'Processing…';
            };

            xhr.onload = () => {
                area.style.display = 'none';
                if (bar) bar.style.width = '0%';
                if (xhr.status === 402) {
                    try { PdfToolkit.showPaywall(JSON.parse(xhr.responseText).error); } catch (e) { }
                    reject(new Error('Paywall'));
                    return;
                }
                if (xhr.status < 200 || xhr.status >= 300) {
                    let err = 'Upload failed';
                    try { err = JSON.parse(xhr.responseText).error || err; } catch (e) { }
                    reject(new Error(PdfToolkit.sanitizeErrorMessage(err)));
                    return;
                }
                try { resolve(JSON.parse(xhr.responseText)); } catch (e) { reject(new Error('Invalid server response')); }
            };

            xhr.onerror = () => {
                area.style.display = 'none';
                reject(new Error('Upload failed — check your connection'));
            };

            xhr.open('POST', '/pdf/edit/upload');
            xhr.send(fd);
        });
    }

    async function uploadFile(file) {
        const access = await PdfToolkit.checkToolAccess('editpdf');
        if (!access.allowed) { PdfToolkit.showPaywall(access.denyReason); throw new Error('Paywall'); }
        const maxBytes = access.maxFileSizeBytes || (10 * 1024 * 1024);
        const v = PdfToolkit.validatePdfFiles([file], { maxFiles: 1, maxSizeBytes: maxBytes });
        if (!v.ok) throw new Error(v.error);

        const data = await uploadFileWithProgress(file);
        try {
            await loadDocument(data.sessionId, data.originalFileName);
        } catch (err) {
            showLoadFailure(err.message || 'Could not open PDF.');
            throw err;
        }
        return data;
    }

    function rotatePage(pageIdx) {
        snapshot();
        const op = state.pageOps.find(o => o.type === 'rotate_page' && o.page === pageIdx);
        if (op) op.angle = ((op.angle + 90) % 360);
        else state.pageOps.push({ type: 'rotate_page', page: pageIdx, angle: 90 });
        state.pageRotations[pageIdx] = ((state.pageRotations[pageIdx] || 0) + 90) % 360;
        applyPageRotation(pageIdx, state.pageViews[pageIdx]?.wrap);
        updateBadge();
    }

    function deletePage(pageIdx) {
        if (getActivePages().length <= 1) { setStatus('Cannot delete the only page', true); return; }
        snapshot();
        state.pageOps.push({ type: 'delete_page', page: pageIdx });
        state.deletedPages.add(pageIdx);
        state.pageOrder = state.pageOrder.filter(i => i !== pageIdx);
        rerenderAll(true);
        updateBadge();
    }

    function syncPropsPanel() {
        const panel = $('propsContent');
        if (!panel || !state.selection) return;
        panel.innerHTML = '';

        if (state.selection.type === 'text' || state.selection.type === 'textAdd') {
            const st = state.selection.type === 'text'
                ? spanStyle(state.selection.span)
                : state.selection.edit;
            panel.innerHTML = `
                <p class="cv-prop-title">Text</p>
                <label>Font<select id="propFont" class="cv-input">${fontOptions(st.fontFamily, state.selection.span)}</select></label>
                <label>Size<select id="propSize" class="cv-input">${sizeOptions(st.fontSize)}</select></label>
                <label>Color<input type="color" id="propColor" class="cv-input" value="${(st.color || '#000000').slice(0, 7)}"></label>
                <label>Highlight<input type="color" id="propTextBg" class="cv-input" value="#fef08a" title="Text highlight color"></label>
                <div class="cv-prop-row">
                    <button type="button" class="cv-chip" id="propBold" aria-pressed="${st.bold}"><b>B</b></button>
                    <button type="button" class="cv-chip" id="propItalic" aria-pressed="${st.italic}"><i>I</i></button>
                    <button type="button" class="cv-chip" id="propLink" title="Add link"><i class="fa fa-link"></i></button>
                </div>`;
            bindPropHandlers(state.selection.span);
        } else if (state.selection.type === 'box') {
            const edit = state.selection.edit;
            panel.innerHTML = `
                <p class="cv-prop-title">${edit.type === 'image' ? 'Image' : 'Shape'}</p>
                <button type="button" class="cv-btn cv-btn-danger" id="propDelete">Delete</button>`;
            $('propDelete')?.addEventListener('click', () => removeEditAt(state.selection.index));
        }
    }

    function fontOptions(sel, span) {
        const fonts = new Set(['Arial', 'Helvetica', 'Times New Roman', 'Georgia', 'Courier New']);
        if (span?.fontFamily) fonts.add(span.fontFamily);
        if (sel) fonts.add(sel);
        return [...fonts].map(f => `<option value="${f}"${f === sel ? ' selected' : ''}>${f}</option>`).join('');
    }

    function sizeOptions(sel) {
        return [8, 10, 11, 12, 14, 16, 18, 24, 32]
            .map(s => `<option value="${s}"${s == sel ? ' selected' : ''}>${s}</option>`).join('');
    }

    function saveEditSelection() {
        const sel = window.getSelection();
        if (!sel || !sel.rangeCount || sel.isCollapsed || !state.editing?.el) return;
        const range = sel.getRangeAt(0);
        if (!state.editing.el.contains(range.commonAncestorContainer)) return;
        state.savedEditRange = range.cloneRange();
    }

    function restoreEditSelection() {
        if (!state.editing?.el) return false;
        const sel = window.getSelection();
        if (sel?.rangeCount && !sel.isCollapsed) {
            const live = sel.getRangeAt(0);
            if (state.editing.el.contains(live.commonAncestorContainer)) return true;
        }
        if (!state.savedEditRange) return false;
        sel.removeAllRanges();
        sel.addRange(state.savedEditRange);
        return true;
    }

    function hasEditTextSelection(el) {
        restoreEditSelection();
        const sel = window.getSelection();
        return !!(sel && sel.rangeCount && !sel.isCollapsed
            && el.contains(sel.getRangeAt(0).commonAncestorContainer));
    }

    function startAreaDraw(pageIdx, overlay, clientX, clientY) {
        if (state.pending !== 'whiteout') return;
        if (state._areaDrawing) return;
        state._areaDrawing = true;
        state.pending = null;
        $('topBar')?.classList.remove('pending-whiteout');
        document.querySelector('.cv-app')?.classList.remove('cv-pending-draw');
        const pt = overlayPoint(overlay, clientX, clientY);
        const preview = document.createElement('div');
        preview.className = 'cv-draw-preview';
        overlay.appendChild(preview);
        const sx = pt.x, sy = pt.y;

        const onMove = ev => {
            const p = overlayPoint(overlay, ev.clientX, ev.clientY);
            preview.style.left = Math.min(sx, p.x) + 'px';
            preview.style.top = Math.min(sy, p.y) + 'px';
            preview.style.width = Math.abs(p.x - sx) + 'px';
            preview.style.height = Math.abs(p.y - sy) + 'px';
        };
        const onUp = ev => {
            document.removeEventListener('mousemove', onMove);
            document.removeEventListener('mouseup', onUp);
            preview.remove();
            state._areaDrawing = false;
            const factor = displayScaleFactor();
            const p = overlayPoint(overlay, ev.clientX, ev.clientY);
            const w = Math.abs(p.x - sx), h = Math.abs(p.y - sy);
            if (w < 8 || h < 8) return;
            const tl = screenToPdf(Math.min(sx, p.x) / factor, Math.min(sy, p.y) / factor, overlayScale());
            const box = { x: tl.x, y: tl.y, width: w / factor / overlayScale(), height: h / factor / overlayScale() };
            pushEdit({ type: 'whiteout', page: pageIdx, ...box });
            invalidatePage(pageIdx);
            setStatus('Area erased');
        };
        document.addEventListener('mousemove', onMove);
        document.addEventListener('mouseup', onUp);
    }

    function wrapSelectionStyle(prop, value) {
        restoreEditSelection();
        const sel = window.getSelection();
        if (!sel || !sel.rangeCount || sel.isCollapsed) return false;
        const range = sel.getRangeAt(0);
        if (!state.editing?.el?.contains(range.commonAncestorContainer)) return false;
        const span = document.createElement('span');
        span.style[prop] = value;
        try {
            range.surroundContents(span);
        } catch (e) {
            const extracted = range.extractContents();
            span.appendChild(extracted);
            range.insertNode(span);
        }
        const after = document.createRange();
        after.selectNodeContents(span);
        sel.removeAllRanges();
        sel.addRange(after);
        state.savedEditRange = after.cloneRange();
        return true;
    }

    function applyRichCommand(cmd, value) {
        if (!state.editing) return;
        const el = state.editing.el;
        restoreEditSelection();
        el.focus();
        const scale = overlayScale();
        const hasRange = hasEditTextSelection(el);
        const live = readStylesFromEl(el, spanStyle(state.editing.span));

        if (cmd === 'fontName' && value) {
            if (hasRange) {
                wrapSelectionStyle('fontFamily', `"${value}", sans-serif`);
            } else {
                el.style.fontFamily = `"${value}", sans-serif`;
            }
        } else if (cmd === 'foreColor' && value) {
            if (hasRange) {
                wrapSelectionStyle('color', value);
            } else {
                el.style.color = value;
                el.style.webkitTextFillColor = 'initial';
            }
        } else if (cmd === 'fontSize' && value != null) {
            const pt = parseFloat(String(value).replace(/px/i, ''));
            if (!isNaN(pt) && pt > 0) {
                const displayPx = pt * scale + 'px';
                if (hasRange) {
                    wrapSelectionStyle('fontSize', pt + 'pt');
                } else {
                    el.style.fontSize = displayPx;
                }
            }
        } else if (cmd === 'bold') {
            if (hasRange) {
                document.execCommand('bold', false, null);
                saveEditSelection();
            } else {
                el.style.fontWeight = live.bold ? '400' : '700';
            }
        } else if (cmd === 'italic') {
            if (hasRange) {
                document.execCommand('italic', false, null);
                saveEditSelection();
            } else {
                el.style.fontStyle = live.italic ? 'normal' : 'italic';
            }
        } else if (cmd === 'backColor' && value) {
            if (hasRange) {
                wrapSelectionStyle('backgroundColor', value);
            } else {
                setStatus('Select text first, then pick a highlight color', true);
            }
        } else if (cmd === 'createLink' && value) {
            if (!hasRange) {
                setStatus('Select text first, then add a link', true);
                return;
            }
            const sel = window.getSelection();
            const range = sel.getRangeAt(0);
            const anchor = document.createElement('a');
            anchor.href = value;
            anchor.target = '_blank';
            anchor.rel = 'noopener noreferrer';
            anchor.style.color = '#2563eb';
            anchor.style.textDecoration = 'underline';
            try {
                range.surroundContents(anchor);
            } catch (e) {
                document.execCommand('createLink', false, value);
            }
            sel.removeAllRanges();
        } else {
            document.execCommand(cmd, false, value ?? null);
        }
        refreshFormatUi(state.selection?.span);
    }

    function refreshFormatUi(span) {
        syncFloatBar(span);
        updatePropsControls(span);
    }

    function buildPropsPanelForEdit(span) {
        const panel = $('propsContent');
        if (!panel || !state.editing) return;
        const el = getEditTarget();
        const live = readStylesFromEl(el, spanStyle(span));
        panel.innerHTML = `
            <p class="cv-prop-title">Text</p>
            <label>Font<select id="propFont" class="cv-input">${fontOptions(live.fontFamily, span)}</select></label>
            <label>Size<select id="propSize" class="cv-input">${sizeOptions(live.fontSize)}</select></label>
            <label>Color<input type="color" id="propColor" class="cv-input" value="${(live.color || '#000000').slice(0, 7)}"></label>
            <label>Highlight<input type="color" id="propTextBg" class="cv-input" value="#fef08a" title="Text highlight color"></label>
            <div class="cv-prop-row">
                <button type="button" class="cv-chip" id="propBold" aria-pressed="${live.bold}"><b>B</b></button>
                <button type="button" class="cv-chip" id="propItalic" aria-pressed="${live.italic}"><i>I</i></button>
                <button type="button" class="cv-chip" id="propLink" title="Add link"><i class="fa fa-link"></i></button>
            </div>`;
        bindPropHandlers(span);
    }

    function updatePropsControls(span) {
        if (!state.editing || !span) return;
        const el = getEditTarget();
        if (!el) return;
        const live = readStylesFromEl(el, spanStyle(span));
        if ($('propFont')) $('propFont').value = live.fontFamily || 'Arial';
        if ($('propSize')) $('propSize').value = String(Math.round(live.fontSize || 12));
        if ($('propColor')) $('propColor').value = (live.color || '#000000').slice(0, 7);
        $('propBold')?.setAttribute('aria-pressed', live.bold ? 'true' : 'false');
        $('propItalic')?.setAttribute('aria-pressed', live.italic ? 'true' : 'false');
    }

    function bindPropHandlers(span) {
        const keepSelPrevent = e => { e.preventDefault(); saveEditSelection(); };
        const keepSel = () => saveEditSelection();
        ['propBold', 'propItalic', 'propLink'].forEach(id => {
            $(id)?.addEventListener('mousedown', keepSelPrevent);
        });
        ['propFont', 'propSize'].forEach(id => {
            $(id)?.addEventListener('mousedown', keepSel);
            $(id)?.addEventListener('focus', keepSel);
        });
        ['propColor', 'propTextBg'].forEach(id => {
            $(id)?.addEventListener('mousedown', () => beginColorPick());
            $(id)?.addEventListener('focus', keepSel);
            $(id)?.addEventListener('change', () => setTimeout(endColorPick, 0));
            $(id)?.addEventListener('blur', () => setTimeout(endColorPick, 200));
        });
        const propHighlightLabel = $('propTextBg')?.closest('label');
        propHighlightLabel?.addEventListener('mousedown', e => {
            beginColorPick();
            if (e.target.id !== 'propTextBg') e.preventDefault();
        });
        propHighlightLabel?.addEventListener('click', e => {
            if (e.target.id === 'propTextBg') return;
            e.preventDefault();
            beginColorPick();
            $('propTextBg')?.click();
        });
        $('propFont')?.addEventListener('change', () => {
            if (!state.editing) return;
            applyRichCommand('fontName', $('propFont')?.value);
        });
        $('propSize')?.addEventListener('change', () => {
            if (state.editing) applyRichCommand('fontSize', $('propSize')?.value);
        });
        $('propColor')?.addEventListener('input', () => {
            if (state.editing) applyRichCommand('foreColor', $('propColor')?.value);
        });
        $('propTextBg')?.addEventListener('input', () => {
            if (!state.editing) { setStatus('Select text first, then pick a highlight color', true); return; }
            applyRichCommand('backColor', $('propTextBg')?.value);
        });
        $('propTextBg')?.addEventListener('change', () => {
            if (state.editing) applyRichCommand('backColor', $('propTextBg')?.value);
        });
        $('propBold')?.addEventListener('click', () => {
            if (!state.editing) return;
            applyRichCommand('bold');
        });
        $('propItalic')?.addEventListener('click', () => {
            if (!state.editing) return;
            applyRichCommand('italic');
        });
        $('propLink')?.addEventListener('click', addLinkToSelection);
    }

    function bindFloatBar() {
        const keepSelPrevent = e => { e.preventDefault(); saveEditSelection(); };
        const keepSel = () => saveEditSelection();
        const floatBar = $('floatBar');
        floatBar?.addEventListener('mousedown', e => {
            if (!state.editing) return;
            saveEditSelection();
            // Native <select> dropdowns (font/size) must keep focus to stay open —
            // refocusing the editor on mouseup would close them instantly.
            if (e.target.closest('select')) return;
            if (e.target.closest('.fb-format, .fb-highlight-label, #fbColor, #fbTextBg')) {
                state._deferEditBlur = true;
            }
        }, true);
        $('fbUndo')?.addEventListener('click', () => undo());
        $('fbRedo')?.addEventListener('click', () => redo());
        $('fbAddText')?.addEventListener('click', () => addTextOnActivePage());
        $('fbAddImage')?.addEventListener('click', () => pickImage());
        ['fbBold', 'fbItalic', 'fbLink'].forEach(id => {
            $(id)?.addEventListener('mousedown', keepSelPrevent);
        });
        ['fbFont', 'fbSize'].forEach(id => {
            $(id)?.addEventListener('mousedown', keepSel);
            $(id)?.addEventListener('focus', keepSel);
        });
        ['fbColor', 'fbTextBg'].forEach(id => {
            $(id)?.addEventListener('mousedown', () => beginColorPick());
            $(id)?.addEventListener('focus', keepSel);
            $(id)?.addEventListener('change', () => setTimeout(endColorPick, 0));
            $(id)?.addEventListener('blur', () => setTimeout(endColorPick, 200));
        });
        const highlightLabel = document.querySelector('#floatBar .fb-highlight-label');
        highlightLabel?.addEventListener('mousedown', e => {
            beginColorPick();
            if (e.target.id !== 'fbTextBg') e.preventDefault();
        });
        highlightLabel?.addEventListener('click', e => {
            if (e.target.id === 'fbTextBg') return;
            e.preventDefault();
            beginColorPick();
            $('fbTextBg')?.click();
        });
        $('fbFont')?.addEventListener('change', () => { if (state.editing) { applyRichCommand('fontName', $('fbFont').value); refreshFormatUi(state.selection?.span); } });
        $('fbSize')?.addEventListener('change', () => { if (state.editing) { applyRichCommand('fontSize', $('fbSize').value); refreshFormatUi(state.selection?.span); } });
        $('fbColor')?.addEventListener('input', () => { if (state.editing) applyRichCommand('foreColor', $('fbColor').value); });
        $('fbTextBg')?.addEventListener('input', () => {
            if (!state.editing) { setStatus('Select text first, then pick a highlight color', true); return; }
            applyRichCommand('backColor', $('fbTextBg').value);
        });
        $('fbTextBg')?.addEventListener('change', () => {
            if (!state.editing) return;
            applyRichCommand('backColor', $('fbTextBg').value);
        });
        $('fbBold')?.addEventListener('click', () => {
            if (!state.editing) return;
            applyRichCommand('bold');
        });
        $('fbItalic')?.addEventListener('click', () => {
            if (!state.editing) return;
            applyRichCommand('italic');
        });
        $('fbLink')?.addEventListener('click', addLinkToSelection);
    }

    function applyFloatFmt() {
        syncFloatBar(state.selection?.span);
    }

    function syncFloatBar(span) {
        const st = span ? spanStyle(span) : {};
        const el = getEditTarget();
        const live = el ? readStylesFromEl(el, st) : st;
        if ($('fbFont')) $('fbFont').value = live.fontFamily || 'Arial';
        if ($('fbSize')) $('fbSize').value = String(Math.round(live.fontSize || 12));
        if ($('fbColor')) $('fbColor').value = (live.color || '#000000').slice(0, 7);
        $('fbBold')?.setAttribute('aria-pressed', live.bold ? 'true' : 'false');
        $('fbItalic')?.setAttribute('aria-pressed', live.italic ? 'true' : 'false');
    }

    function syncPropsPanelForEdit(span) {
        if (state.editing) buildPropsPanelForEdit(span);
        else syncPropsPanel();
        syncFloatBar(span);
    }

    function addLinkToSelection() {
        if (!state.editing) return;
        const sel = window.getSelection();
        if (!sel || !sel.rangeCount || sel.isCollapsed) {
            setStatus('Select the text to link first', true);
            return;
        }
        const url = window.prompt('Link URL', 'https://');
        if (!url?.trim()) return;
        const href = url.trim().startsWith('http') ? url.trim() : 'https://' + url.trim();
        applyRichCommand('createLink', href);
    }

    function commitTextAdds() {
        syncTextAddsFromDom();
    }

    async function exportPdf() {
        if (!state.sessionId) { setStatus('Open a PDF first', true); return; }
        await finishTextEdit();
        commitTextAdds();
        const access = await PdfToolkit.checkToolAccess('editpdf');
        if (!access.allowed) { PdfToolkit.showPaywall(access.denyReason); return; }

        const payload = state.edits
            .filter(e => {
                if (e.type !== 'text_replace') return true;
                if (e._lineSuppress) return false;
                const plain = String(e.text || '').trim();
                const rich = String(e.richHtml || '').trim();
                return !!(plain || rich);
            })
            .map(e => {
            const c = { ...e };
            delete c._el; delete c._inner; delete c._preview; delete c._lineSuppress;
            if (c.type === 'image' && c.imageAssetId) delete c.imageBase64;
            return c;
        });

        const defaultOrder = state.model.pages.map((_, i) => i).filter(i => !state.deletedPages.has(i));
        const orderChanged = getActivePages().some((v, i) => v !== defaultOrder[i]);

        if (!payload.length && !state.pageOps.length && !orderChanged) {
            const res = await fetch(`/pdf/edit/${state.sessionId}/file`);
            const blob = await res.blob();
            downloadBlob(blob, state.fileName);
            setStatus('Downloaded');
            return;
        }

        const body = { sessionId: state.sessionId, edits: payload, pageOps: state.pageOps };
        if (orderChanged) body.pageOrder = getActivePages();

        $('exportProgressArea').style.display = 'block';
        const bar = $('exportProgressBar');
        const msg = $('exportProgressMsg');
        try {
            const useAsync = payload.length > 2 || state.pageOps.length > 0 || orderChanged;
            if (useAsync) {
                const res = await fetch('/pdf/edit/export/async', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(body),
                });
                if (!res.ok) throw new Error((await res.json().catch(() => ({}))).error || 'Export failed');
                const job = await res.json();
                await PdfToolkit.pollJob(job.statusUrl, { bar, msg, area: $('exportProgressArea') });
                const dl = await fetch(job.downloadUrl);
                downloadBlob(await dl.blob(), job.outputFileName || 'edited.pdf');
            } else {
                const res = await fetch('/pdf/edit/export', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(body),
                });
                if (!res.ok) throw new Error((await res.json().catch(() => ({}))).error || 'Export failed');
                downloadBlob(await res.blob(), state.fileName.replace(/\.pdf$/i, '') + '_edited.pdf');
            }
            setStatus('Download ready');
        } catch (err) {
            setStatus(PdfToolkit.sanitizeErrorMessage(err.message), true);
        } finally {
            $('exportProgressArea').style.display = 'none';
            if (bar) bar.style.width = '0%';
        }
    }

    function downloadBlob(blob, name) {
        const a = document.createElement('a');
        a.href = URL.createObjectURL(blob);
        a.download = name;
        a.click();
        URL.revokeObjectURL(a.href);
    }

    function currentPageIndex() {
        const pages = getActivePages();
        const wrap = $('canvasWrap');
        if (wrap) {
            const wr = wrap.getBoundingClientRect();
            let best = null, bestDist = Infinity;
            for (const idx of pages) {
                const el = state.pageViews[idx]?.wrap;
                if (!el) continue;
                const r = el.getBoundingClientRect();
                if (r.bottom < wr.top + 4 || r.top > wr.bottom - 4) continue;
                const dist = Math.abs(r.top - wr.top);
                if (dist < bestDist) { bestDist = dist; best = idx; }
            }
            if (best != null) return best;
        }
        const activeThumb = document.querySelector('.cv-thumb.active');
        if (activeThumb) {
            const idx = parseInt(activeThumb.dataset.page, 10);
            if (!isNaN(idx) && pages.includes(idx)) return idx;
        }
        return pages[0] ?? 0;
    }

    function selectDefaultText(inner) {
        try {
            const txt = (inner.textContent || '').trim();
            if (txt && txt !== 'Type here') return;
            const range = document.createRange();
            range.selectNodeContents(inner);
            const sel = window.getSelection();
            sel.removeAllRanges();
            sel.addRange(range);
        } catch (_) { }
    }

    function addTextOnActivePage() {
        if (!state.sessionId) { setStatus('Open a PDF first', true); return; }
        finishTextEdit();
        state.pending = null;
        $('topBar')?.classList.remove('pending-text', 'pending-image', 'pending-whiteout');
        document.querySelector('.cv-app')?.classList.remove('cv-pending-draw');
        const pageIdx = currentPageIndex();
        const pg = state.model?.pages?.[pageIdx];
        const pw = pg?.width || 400;
        const x = Math.max(24, Math.round(pw * 0.12));
        const y = 56;
        pushEdit({
            type: 'text_add', page: pageIdx,
            x, y, width: 220, height: 32,
            text: '', richHtml: '', fontSize: 14, fontFamily: 'Arial',
            color: '#000000', bold: false, italic: false,
        });
        invalidatePage(pageIdx).then(() => {
            const idx = state.edits.length - 1;
            const edit = state.edits[idx];
            if (edit && edit._inner) {
                // selectItem() commits/clears any prior edit (which would disable
                // contentEditable), so it MUST run before we enable typing here.
                selectItem('textAdd', { index: idx, edit, el: edit._el, inner: edit._inner });
                edit._inner.contentEditable = 'true';
                bindTextAddInner(edit._inner, edit, idx);
                edit._inner.focus();
                selectDefaultText(edit._inner);
                updateFloatBarVisibility();
                edit._el?.scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
        });
        setStatus('Text added — type to edit');
    }

    function setPending(action) {
        if (action && !state.sessionId) { setStatus('Open a PDF first', true); return; }
        finishTextEdit();
        state.pending = state.pending === action ? null : action;
        $('topBar')?.classList.remove('pending-whiteout', 'pending-text', 'pending-image');
        document.querySelector('.cv-app')?.classList.remove('cv-pending-draw');
        if (state.pending) {
            $('topBar')?.classList.add('pending-' + state.pending);
            if (state.pending === 'whiteout') {
                document.querySelector('.cv-app')?.classList.add('cv-pending-draw');
            }
        }
        const hints = {
            whiteout: 'Drag on the page to erase',
            text: 'Click where you want text',
            image: 'Click where you want the image',
        };
        setStatus(state.pending ? hints[state.pending] : 'Ready');
    }

    function pickImage() {
        if (!state.sessionId) { setStatus('Open a PDF first', true); return; }
        const input = $('imageInput');
        if (!input) return;
        input.onchange = () => {
            const file = input.files?.[0];
            if (!file?.type.startsWith('image/')) {
                setStatus('Choose a PNG or JPG image', true);
                return;
            }
            if (file.size > 5 * 1024 * 1024) {
                setStatus('Image must be under 5 MB', true);
                return;
            }
            const reader = new FileReader();
            reader.onload = () => {
                state._imageDataUrl = reader.result;
                setPending('image');
            };
            reader.readAsDataURL(file);
            input.value = '';
        };
        input.click();
    }

    function bindUi() {
        $('importBtn')?.addEventListener('click', () => $('pdfFileInput')?.click());
        $('pdfFileInput')?.addEventListener('change', async e => {
            const file = e.target.files?.[0];
            if (!file) return;
            try { await uploadFile(file); } catch (err) { setStatus(err.message, true); }
            e.target.value = '';
        });

        $('btnUndo')?.addEventListener('click', undo);
        $('btnRedo')?.addEventListener('click', redo);
        $('btnDownload')?.addEventListener('click', exportPdf);
        $('btnAddText')?.addEventListener('click', () => addTextOnActivePage());
        $('btnAddImage')?.addEventListener('click', pickImage);
        bindFloatBar();
        $('zoomInBtn')?.addEventListener('click', () => setZoom(Math.min(3, state.scale + 0.15)));
        $('zoomOutBtn')?.addEventListener('click', () => setZoom(Math.max(0.4, state.scale - 0.15)));

        document.addEventListener('mousemove', e => {
            if (!state.drag) return;
            const { dx, dy } = pointerDeltaToPdf(e.clientX - state.drag.startX, e.clientY - state.drag.startY);
            state.drag.edit.x = state.drag.origX + dx;
            state.drag.edit.y = state.drag.origY + dy;
            const pos = pdfToScreen(state.drag.edit, overlayScale());
            state.drag.el.style.left = pos.left + 'px';
            state.drag.el.style.top = pos.top + 'px';
        });
        document.addEventListener('mouseup', () => {
            if (state._deferEditBlur && !state._colorPickActive) {
                setTimeout(() => {
                    state._deferEditBlur = false;
                    if (state.editing?.el) {
                        state.editing.el.focus({ preventScroll: true });
                        restoreEditSelection();
                    }
                }, 0);
            }
        }, true);
        document.addEventListener('mouseup', () => {
            if (!state.drag) return;
            const dx = Math.abs(state.drag.edit.x - state.drag.origX);
            const dy = Math.abs(state.drag.edit.y - state.drag.origY);
            if (dx > DRAG_SNAP_THRESHOLD / overlayScale() || dy > DRAG_SNAP_THRESHOLD / overlayScale()) {
                snapshot();
            }
            state.drag = null;
            updateBadge();
        });

        document.addEventListener('keydown', e => {
            if (e.target.matches('input, select, textarea, [contenteditable="true"]')) {
                if (e.key === 'Escape') finishTextEdit();
                if (e.key === 'Enter' && !e.shiftKey) { e.preventDefault(); finishTextEdit(); }
                return;
            }
            if ((e.ctrlKey || e.metaKey) && e.key === 'z') { e.preventDefault(); undo(); }
            if ((e.ctrlKey || e.metaKey) && e.key === 'y') { e.preventDefault(); redo(); }
            if ((e.ctrlKey || e.metaKey) && e.key === 's') { e.preventDefault(); exportPdf(); }
            if (e.key === 'Delete' && state.selection?.type === 'box') removeEditAt(state.selection.index);
            if (e.key === 'Escape') { clearSelection(); state.pending = null; }
        });

        document.addEventListener('pointerup', e => {
            if (state._suppressEditClickAway) return;
            if (e.target.closest('.cv-props, .cv-topbar, #floatBar, #propsPanel')) return;
            if (document.querySelector('.cv-text-add-inner[contenteditable="true"]')
                && !e.target.closest('.cv-text-add-inner, #floatBar, #propsPanel, .cv-props')) {
                commitTextAddsFromDom();
            }
            if (state.editing && !state._colorPickActive && !state._deferEditBlur
                && !e.target.closest('.cv-editing, .cv-text-add-inner, #floatBar, #propsPanel, .cv-props')) {
                finishTextEdit();
            }
        });

        ['emptyState', 'canvasWrap'].forEach(id => {
            const el = $(id);
            if (!el) return;
            el.addEventListener('dragover', e => { if (e.dataTransfer?.types?.includes('Files')) e.preventDefault(); });
            el.addEventListener('drop', async e => {
                e.preventDefault();
                const file = [...(e.dataTransfer?.files || [])].find(f => f.type === 'application/pdf');
                if (file) try { await uploadFile(file); } catch (err) { setStatus(err.message, true); }
            });
        });

        PdfToolkit.checkToolAccess('editpdf').then(s => {
            const b = $('editUsageBadge');
            if (b) b.textContent = s.isPremium ? 'Pro' : `${s.remaining} free today`;
        }).catch(() => {});

        document.addEventListener('mousedown', e => {
            if (state.pending !== 'whiteout') return;
            if (e.button !== 0) return;
            if (e.target.closest('#topBar, #floatBar, #propsPanel, .cv-topbar, .cv-props')) return;
            const overlay = e.target.closest('.cv-overlay');
            if (!overlay) return;
            const pageIdx = parseInt(overlay.closest('.cv-page')?.dataset.page, 10);
            if (isNaN(pageIdx)) return;
            e.preventDefault();
            e.stopPropagation();
            startAreaDraw(pageIdx, overlay, e.clientX, e.clientY);
        }, true);
    }

        document.addEventListener('DOMContentLoaded', bindUi);

    return {
        initFromServer: bootFromServer,
        bootFromServer,
        uploadFile,
        exportPdf,
        undo,
        redo,
    };
})();

window.exportPdf = () => PdfCanvaEditor.exportPdf();
window.undoEdit = () => PdfCanvaEditor.undo();
window.redoEdit = () => PdfCanvaEditor.redo();
