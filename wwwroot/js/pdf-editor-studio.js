/**
 * Professional PDF studio editor — canvas rendering + object-level edits.
 */
window.PdfStudioEditor = (function () {
    'use strict';

    const state = {
        sessionId: null,
        fileName: 'document.pdf',
        model: null,
        pdfDoc: null,
        scale: 1.35,
        tool: 'select',
        pageViews: [],
        edits: [],
        undoStack: [],
        redoStack: [],
        selectedEl: null,
        drag: null,
        pan: null,
    };

    function $(id) { return document.getElementById(id); }

    function setStatus(msg) {
        const el = $('editorStatus');
        if (!el) return;
        el.textContent = msg;
        el.style.display = msg ? 'block' : 'none';
        if (msg) setTimeout(() => { el.style.display = 'none'; }, 4000);
    }

    function snapshot() {
        state.undoStack.push(JSON.parse(JSON.stringify(state.edits)));
        state.redoStack = [];
    }

    function undo() {
        if (!state.undoStack.length) return;
        state.redoStack.push(JSON.parse(JSON.stringify(state.edits)));
        state.edits = state.undoStack.pop();
        rerender().then(() => setStatus('Undo'));
    }

    function redo() {
        if (!state.redoStack.length) return;
        state.undoStack.push(JSON.parse(JSON.stringify(state.edits)));
        state.edits = state.redoStack.pop();
        rerender().then(() => setStatus('Redo'));
    }

    function clearSelection() {
        if (state.selectedEl) {
            state.selectedEl.style.outline = '';
            state.selectedEl = null;
        }
    }

    function selectElement(el) {
        clearSelection();
        state.selectedEl = el;
        el.style.outline = '2px solid #3b82f6';
    }

    function setTool(tool, btn) {
        state.tool = tool;
        clearSelection();
        document.querySelectorAll('.tb-btn[data-tool]').forEach(b => b.classList.remove('active'));
        if (btn) btn.classList.add('active');
        const viewer = $('pdfPageViewer');
        if (viewer) viewer.style.cursor = tool === 'pan' ? 'grab' : (tool === 'select' ? 'default' : 'crosshair');
        document.querySelectorAll('.pdf-text-span').forEach(el => {
            el.style.pointerEvents = tool === 'select' ? 'auto' : 'none';
        });
        document.querySelectorAll('.pdf-annotation-preview').forEach(el => {
            el.style.pointerEvents = tool === 'select' ? 'auto' : 'none';
        });
    }

    function pdfToScreen(rect, scale) {
        return {
            left: rect.x * scale,
            top: rect.y * scale,
            width: rect.width * scale,
            height: rect.height * scale,
        };
    }

    function screenToPdf(x, y, scale) {
        return { x: x / scale, y: y / scale };
    }

    function pushEdit(edit) {
        snapshot();
        state.edits.push(edit);
    }

    function removeSelected() {
        if (!state.selectedEl) return;
        const idx = parseInt(state.selectedEl.dataset.editIndex, 10);
        if (!isNaN(idx)) {
            snapshot();
            state.edits.splice(idx, 1);
            rerender();
            setStatus('Removed');
        }
        clearSelection();
    }

    function createSpanOverlay(pageIdx, span, scale, overlay) {
        const pos = pdfToScreen(span, scale);
        const el = document.createElement('div');
        el.className = 'pdf-text-span';
        el.dataset.spanId = span.id;
        el.contentEditable = 'true';
        el.spellcheck = false;
        el.textContent = span.text;

        const textColor = span.color || '#000000';
        const fontSizePx = span.fontSize * scale;

        // Invisible until focused: canvas already draws the text. Showing overlay
        // text on top caused the double/ghosted appearance.
        el.style.cssText = `
            position:absolute;left:${pos.left}px;top:${pos.top}px;
            min-width:${Math.max(pos.width, 12)}px;height:${Math.max(pos.height, 10)}px;
            font-size:${fontSizePx}px;
            font-family:${span.fontFamily || 'Arial'},sans-serif;
            font-weight:${span.bold ? 'bold' : 'normal'};
            font-style:${span.italic ? 'italic' : 'normal'};
            color:transparent;-webkit-text-fill-color:transparent;
            caret-color:${textColor};
            background:transparent;outline:none;cursor:text;
            line-height:${Math.max(pos.height, fontSizePx * 1.1)}px;
            white-space:pre;overflow:visible;z-index:20;
            padding:0 1px;box-sizing:border-box;`;

        const originalText = span.text;
        const alreadyEdited = state.edits.some(
            e => e.type === 'text_replace' && e.spanId === span.id
        );

        function showEditedState() {
            el.style.color = textColor;
            el.style.webkitTextFillColor = textColor;
            el.style.background = '#ffffff';
            el.style.boxShadow = 'none';
        }

        if (alreadyEdited) {
            showEditedState();
        }

        function enterEditMode() {
            el.style.color = textColor;
            el.style.webkitTextFillColor = textColor;
            el.style.background = '#ffffff';
            el.style.boxShadow = '0 0 0 1px #3b82f6';
            el.style.zIndex = '30';
        }

        function leaveEditMode() {
            el.style.color = 'transparent';
            el.style.webkitTextFillColor = 'transparent';
            el.style.background = 'transparent';
            el.style.boxShadow = 'none';
            el.style.zIndex = '20';
        }

        el.addEventListener('focus', enterEditMode);
        el.addEventListener('blur', () => {
            const newText = el.textContent || '';
            const changed = newText !== originalText;
            if (changed) {
                const existing = state.edits.findIndex(
                    e => e.type === 'text_replace' && e.spanId === span.id
                );
                const edit = {
                    type: 'text_replace',
                    page: pageIdx,
                    x: span.x, y: span.y,
                    width: span.width, height: span.height,
                    text: newText,
                    fontSize: span.fontSize,
                    fontFamily: span.fontFamily,
                    bold: span.bold,
                    italic: span.italic,
                    color: span.color,
                    spanId: span.id,
                };
                if (existing >= 0) {
                    state.edits[existing] = edit;
                } else {
                    snapshot();
                    state.edits.push(edit);
                }
                span.text = newText;
                showEditedState();
            } else if (!alreadyEdited) {
                leaveEditMode();
            }
        });

        el.addEventListener('mousedown', e => e.stopPropagation());
        overlay.appendChild(el);
    }

    function renderAnnotationPreview(overlay, edit, scale, editIndex) {
        const pos = pdfToScreen(edit, scale);
        const el = document.createElement('div');
        el.className = 'pdf-annotation-preview';
        el.dataset.editIndex = editIndex;
        el.style.cssText = `position:absolute;left:${pos.left}px;top:${pos.top}px;width:${Math.max(pos.width, 4)}px;height:${Math.max(pos.height, 4)}px;z-index:15;`;

        if (edit.type === 'whiteout') {
            el.style.background = '#fff';
            el.style.border = '1px solid #cbd5e1';
        } else if (edit.type === 'highlight') {
            el.style.background = 'rgba(255,255,0,0.35)';
        } else if (edit.type === 'text_add') {
            el.contentEditable = 'true';
            el.style.background = 'rgba(255,255,255,0.95)';
            el.style.border = '1px dashed #3b82f6';
            el.style.fontSize = (edit.fontSize * scale) + 'px';
            el.style.fontFamily = edit.fontFamily || 'Arial';
            el.style.color = edit.color || '#000';
            el.style.padding = '2px 4px';
            el.style.outline = 'none';
            el.textContent = edit.text || 'New text';
            el.addEventListener('blur', () => { edit.text = el.textContent; });
            el.addEventListener('mousedown', e => e.stopPropagation());
        } else if (edit.type === 'image' && edit._previewSrc) {
            const img = document.createElement('img');
            img.src = edit._previewSrc;
            img.style.cssText = 'width:100%;height:100%;object-fit:contain;pointer-events:none;';
            el.appendChild(img);
        }

        el.addEventListener('click', e => {
            if (state.tool !== 'select') return;
            e.stopPropagation();
            selectElement(el);
        });

        edit._dom = el;
        overlay.appendChild(el);
    }

    async function renderPage(pageIdx) {
        const pageData = state.model.pages[pageIdx];
        const page = await state.pdfDoc.getPage(pageIdx + 1);
        const viewport = page.getViewport({ scale: state.scale });

        const wrap = document.createElement('div');
        wrap.className = 'pdf-page-view';
        wrap.dataset.page = pageIdx;

        const canvas = document.createElement('canvas');
        canvas.className = 'pdf-page-canvas';
        canvas.width = viewport.width;
        canvas.height = viewport.height;

        const overlay = document.createElement('div');
        overlay.className = 'pdf-page-overlay';
        overlay.style.width = viewport.width + 'px';
        overlay.style.height = viewport.height + 'px';

        const label = document.createElement('div');
        label.className = 'pdf-page-label';
        label.textContent = 'Page ' + (pageIdx + 1);

        wrap.appendChild(label);
        wrap.appendChild(canvas);
        wrap.appendChild(overlay);

        await page.render({ canvasContext: canvas.getContext('2d'), viewport }).promise;
        (pageData.spans || []).forEach(span => createSpanOverlay(pageIdx, span, state.scale, overlay));

        setupOverlayInteraction(overlay, pageIdx);
        state.pageViews[pageIdx] = { wrap, overlay };

        state.edits.forEach((edit, idx) => {
            if (edit.page === pageIdx && edit.type !== 'text_replace') {
                renderAnnotationPreview(overlay, edit, state.scale, idx);
            }
        });

        return wrap;
    }

    function setupOverlayInteraction(overlay, pageIdx) {
        overlay.addEventListener('mousedown', e => {
            if (state.tool === 'select') {
                if (e.target === overlay) clearSelection();
                return;
            }

            const rect = overlay.getBoundingClientRect();
            const sx = e.clientX - rect.left;
            const sy = e.clientY - rect.top;
            state.drag = { pageIdx, sx, sy, overlay, rect };

            const preview = document.createElement('div');
            preview.className = 'drag-preview';
            preview.style.cssText = `position:absolute;left:${sx}px;top:${sy}px;width:0;height:0;border:2px dashed #3b82f6;background:rgba(59,130,246,0.08);z-index:30;pointer-events:none;`;
            overlay.appendChild(preview);
            state.drag.preview = preview;

            const onMove = ev => {
                const x = ev.clientX - state.drag.rect.left;
                const y = ev.clientY - state.drag.rect.top;
                const left = Math.min(state.drag.sx, x);
                const top = Math.min(state.drag.sy, y);
                preview.style.left = left + 'px';
                preview.style.top = top + 'px';
                preview.style.width = Math.abs(x - state.drag.sx) + 'px';
                preview.style.height = Math.abs(y - state.drag.sy) + 'px';
            };

            const onUp = ev => {
                document.removeEventListener('mousemove', onMove);
                document.removeEventListener('mouseup', onUp);
                preview.remove();

                const x = ev.clientX - state.drag.rect.left;
                const y = ev.clientY - state.drag.rect.top;
                const left = Math.min(state.drag.sx, x);
                const top = Math.min(state.drag.sy, y);
                const w = Math.abs(x - state.drag.sx);
                const h = Math.abs(y - state.drag.sy);
                state.drag = null;

                if (w < 6 || h < 6) return;

                const tl = screenToPdf(left, top, state.scale);
                const pdfRect = { x: tl.x, y: tl.y, width: w / state.scale, height: h / state.scale };

                let edit;
                if (state.tool === 'whiteout') {
                    edit = { type: 'whiteout', page: pageIdx, ...pdfRect };
                } else if (state.tool === 'highlight') {
                    edit = { type: 'highlight', page: pageIdx, ...pdfRect, color: '#ffff00' };
                } else if (state.tool === 'addText') {
                    edit = {
                        type: 'text_add', page: pageIdx, ...pdfRect,
                        text: 'New text',
                        fontSize: parseFloat($('fontSizeSelect')?.value || '12'),
                        fontFamily: $('fontFamilySelect')?.value || 'Arial',
                        color: $('textColor')?.value || '#000000',
                        bold: $('boldToggle')?.classList.contains('active') || false,
                        italic: $('italicToggle')?.classList.contains('active') || false,
                    };
                }
                if (edit) {
                    pushEdit(edit);
                    renderAnnotationPreview(overlay, edit, state.scale, state.edits.length - 1);
                }
            };

            document.addEventListener('mousemove', onMove);
            document.addEventListener('mouseup', onUp);
            e.preventDefault();
        });
    }

    function setupPan() {
        const viewer = $('pdfPageViewer');
        if (!viewer) return;
        viewer.addEventListener('mousedown', e => {
            if (state.tool !== 'pan') return;
            state.pan = { x: e.clientX, y: e.clientY, l: viewer.scrollLeft, t: viewer.scrollTop };
            viewer.style.cursor = 'grabbing';
            const onMove = ev => {
                viewer.scrollLeft = state.pan.l - (ev.clientX - state.pan.x);
                viewer.scrollTop = state.pan.t - (ev.clientY - state.pan.y);
            };
            const onUp = () => {
                document.removeEventListener('mousemove', onMove);
                document.removeEventListener('mouseup', onUp);
                viewer.style.cursor = 'grab';
                state.pan = null;
            };
            document.addEventListener('mousemove', onMove);
            document.addEventListener('mouseup', onUp);
        });
        viewer.addEventListener('wheel', e => {
            if (!e.ctrlKey) return;
            e.preventDefault();
            state.scale = Math.min(3, Math.max(0.5, state.scale + (e.deltaY < 0 ? 0.1 : -0.1)));
            $('zoomLabel').textContent = Math.round(state.scale * 100) + '%';
            rerender();
        }, { passive: false });
    }

    async function renderThumbnail(pageIdx) {
        const page = await state.pdfDoc.getPage(pageIdx + 1);
        const viewport = page.getViewport({ scale: 0.18 });
        const canvas = document.createElement('canvas');
        canvas.width = viewport.width;
        canvas.height = viewport.height;
        await page.render({ canvasContext: canvas.getContext('2d'), viewport }).promise;

        const thumb = document.createElement('div');
        thumb.className = 'pdf-page-thumb';
        thumb.innerHTML = `<span class="pdf-page-num">${pageIdx + 1}</span>`;
        thumb.appendChild(canvas);
        thumb.addEventListener('click', () => {
            document.querySelectorAll('.pdf-page-thumb').forEach(t => t.classList.remove('active'));
            thumb.classList.add('active');
            state.pageViews[pageIdx]?.wrap?.scrollIntoView({ behavior: 'smooth', block: 'start' });
        });
        if (pageIdx === 0) thumb.classList.add('active');
        $('pdfPageSidebar')?.appendChild(thumb);
    }

    async function loadDocument(sessionId, model, fileName) {
        state.sessionId = sessionId;
        state.model = model;
        state.fileName = fileName || 'document.pdf';
        state.edits = [];
        state.undoStack = [];
        state.redoStack = [];
        state.pageViews = [];

        pdfjsLib.GlobalWorkerOptions.workerSrc =
            'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.11.174/pdf.worker.min.js';

        state.pdfDoc = await pdfjsLib.getDocument(`/PDF/Edit/${sessionId}/file`).promise;

        const viewer = $('pdfPageViewer');
        const sidebar = $('pdfPageSidebar');
        if (viewer) viewer.innerHTML = '';
        if (sidebar) sidebar.innerHTML = '';

        $('zoomLabel').textContent = Math.round(state.scale * 100) + '%';
        setStatus('Rendering document…');

        for (let i = 0; i < state.model.pages.length; i++) {
            await renderThumbnail(i);
            viewer?.appendChild(await renderPage(i));
        }

        $('emptyState')?.classList.add('d-none');
        $('editorWorkspace')?.classList.remove('d-none');
        setStatus('Ready — select text to edit, or choose a tool from the toolbar');
    }

    async function uploadFile(file) {
        const v = PdfToolkit.validatePdfFiles([file], { maxFiles: 1, maxSizeBytes: 200 * 1024 * 1024 });
        if (!v.ok) throw new Error(v.error);

        const access = await PdfToolkit.checkToolAccess('editpdf');
        if (!access.allowed) {
            PdfToolkit.showPaywall(access.denyReason);
            throw new Error('Paywall');
        }

        const formData = new FormData();
        formData.append('file', file);
        const prog = { area: $('importProgressArea'), bar: $('importProgressBar'), msg: $('importProgressMsg') };
        prog.area.style.display = 'block';

        return new Promise((resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', '/PDF/Edit/Upload');
            xhr.responseType = 'json';
            xhr.upload.onprogress = e => {
                if (e.lengthComputable) {
                    const pct = Math.round((e.loaded / e.total) * 70);
                    prog.bar.style.width = pct + '%';
                    prog.msg.textContent = 'Uploading… ' + pct + '%';
                }
            };
            xhr.onload = async () => {
                if (xhr.status === 402) {
                    PdfToolkit.showPaywall(xhr.response?.error);
                    reject(new Error('Paywall'));
                    return;
                }
                if (xhr.status < 200 || xhr.status >= 300) {
                    reject(new Error(xhr.response?.error || 'Upload failed (' + xhr.status + ')'));
                    return;
                }
                prog.bar.style.width = '95%';
                prog.msg.textContent = 'Preparing editable layers…';
                try {
                    await loadDocument(xhr.response.sessionId, xhr.response.documentModel, xhr.response.originalFileName);
                    prog.area.style.display = 'none';
                    resolve(xhr.response);
                } catch (err) { reject(err); }
            };
            xhr.onerror = () => reject(new Error('Network error'));
            xhr.send(formData);
        });
    }

    function flushPendingEdits() {
        if (document.activeElement) document.activeElement.blur();

        state.model?.pages?.forEach((pageData, pageIdx) => {
            (pageData.spans || []).forEach(span => {
                const el = document.querySelector(`.pdf-text-span[data-span-id="${span.id}"]`);
                if (!el) return;
                const newText = el.textContent || '';
                if (newText === span.text) return;

                const existing = state.edits.findIndex(
                    e => e.type === 'text_replace' && e.spanId === span.id
                );
                const edit = {
                    type: 'text_replace',
                    page: pageIdx,
                    x: span.x, y: span.y,
                    width: span.width, height: span.height,
                    text: newText,
                    fontSize: span.fontSize,
                    fontFamily: span.fontFamily,
                    bold: span.bold,
                    italic: span.italic,
                    color: span.color,
                    spanId: span.id,
                };
                if (existing >= 0) state.edits[existing] = edit;
                else state.edits.push(edit);
                span.text = newText;
            });
        });

        state.edits.forEach(edit => {
            if (edit._dom && edit.type === 'text_add') {
                edit.text = edit._dom.textContent || edit.text || '';
            }
        });
    }

    async function exportPdf() {
        if (!state.sessionId) { setStatus('Open a PDF first'); return; }

        const access = await PdfToolkit.checkToolAccess('editpdf');
        if (!access.allowed) { PdfToolkit.showPaywall(access.denyReason); return; }

        flushPendingEdits();

        setStatus('Building your edited PDF…');
        $('exportProgressArea').style.display = 'block';

        try {
            const payload = state.edits.map(e => {
                const c = { ...e };
                delete c._dom;
                delete c._previewSrc;
                return c;
            });

            if (payload.length === 0) {
                setStatus('No edits to export — make changes first');
                return;
            }

            const res = await fetch('/PDF/Edit/Export', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ sessionId: state.sessionId, edits: payload }),
            });

            if (res.status === 402) { PdfToolkit.showPaywall('Daily limit reached'); return; }
            if (!res.ok) {
                const err = await res.json().catch(() => ({}));
                throw new Error(err.error || 'Export failed');
            }

            const blob = await res.blob();
            const a = document.createElement('a');
            a.href = URL.createObjectURL(blob);
            a.download = state.fileName.replace(/\.pdf$/i, '') + '_edited.pdf';
            a.click();
            URL.revokeObjectURL(a.href);
            setStatus('Download started');

            const s = await PdfToolkit.checkToolAccess('editpdf');
            const b = $('editUsageBadge');
            if (b) b.textContent = s.isPremium ? 'Pro · Unlimited' : s.remaining + ' free today';
        } catch (err) {
            setStatus('Export failed: ' + err.message);
        } finally {
            $('exportProgressArea').style.display = 'none';
        }
    }

    function insertImage() {
        const input = $('imageStampInput');
        if (!input || !state.pageViews.length) return;
        input.onchange = e => {
            const file = e.target.files[0];
            if (!file) return;
            const reader = new FileReader();
            reader.onload = () => {
                const activeThumb = document.querySelector('.pdf-page-thumb.active');
                const pageIdx = activeThumb ? parseInt(activeThumb.querySelector('.pdf-page-num').textContent, 10) - 1 : 0;
                const overlay = state.pageViews[pageIdx]?.overlay;
                if (!overlay) return;
                const edit = {
                    type: 'image', page: pageIdx,
                    x: 72, y: 72, width: 180, height: 120,
                    imageBase64: reader.result,
                    _previewSrc: reader.result,
                };
                pushEdit(edit);
                renderAnnotationPreview(overlay, edit, state.scale, state.edits.length - 1);
                setStatus('Image added — select it and press Delete to remove');
            };
            reader.readAsDataURL(file);
            input.value = '';
        };
        input.click();
    }

    function toggleStyle(btn, prop) {
        btn.classList.toggle('active');
    }

    async function rerender() {
        if (!state.pdfDoc || !state.model) return;
        const viewer = $('pdfPageViewer');
        const sidebar = $('pdfPageSidebar');
        const scrollTop = viewer?.scrollTop || 0;
        if (viewer) viewer.innerHTML = '';
        if (sidebar) sidebar.innerHTML = '';
        state.pageViews = [];
        clearSelection();

        for (let i = 0; i < state.model.pages.length; i++) {
            await renderThumbnail(i);
            viewer?.appendChild(await renderPage(i));
        }
        if (viewer) viewer.scrollTop = scrollTop;
        $('zoomLabel').textContent = Math.round(state.scale * 100) + '%';
    }

    function initFromServer(sessionId, modelJson, fileName) {
        if (!sessionId || !modelJson) return;
        const model = typeof modelJson === 'string' ? JSON.parse(modelJson) : modelJson;
        loadDocument(sessionId, model, fileName);
    }

    function bindUi() {
        window.setTool = setTool;
        window.exportPdf = exportPdf;
        window.insertImageStamp = insertImage;
        window.undoEdit = undo;
        window.redoEdit = redo;
        window.toggleStyle = toggleStyle;

        $('importBtn')?.addEventListener('click', async () => {
            const file = $('pdfFileInput')?.files[0];
            if (!file) { setStatus('Choose a PDF file first'); return; }
            try { await uploadFile(file); }
            catch (e) { if (e.message !== 'Paywall') setStatus(e.message); }
        });

        $('zoomInBtn')?.addEventListener('click', async () => {
            state.scale = Math.min(3, state.scale + 0.15);
            await rerender();
        });
        $('zoomOutBtn')?.addEventListener('click', async () => {
            state.scale = Math.max(0.5, state.scale - 0.15);
            await rerender();
        });

        document.addEventListener('keydown', e => {
            if (e.key === 'Delete' || e.key === 'Backspace') {
                if (document.activeElement?.contentEditable === 'true') return;
                removeSelected();
            }
            if ((e.ctrlKey || e.metaKey) && e.key === 'z') { e.preventDefault(); undo(); }
            if ((e.ctrlKey || e.metaKey) && e.key === 'y') { e.preventDefault(); redo(); }
        });

        setupPan();

        PdfToolkit.checkToolAccess('editpdf').then(s => {
            const b = $('editUsageBadge');
            if (b) b.textContent = s.isPremium ? 'Pro · Unlimited' : s.remaining + ' free today';
        });
    }

    document.addEventListener('DOMContentLoaded', bindUi);
    return { initFromServer, uploadFile, exportPdf, setTool };
})();
