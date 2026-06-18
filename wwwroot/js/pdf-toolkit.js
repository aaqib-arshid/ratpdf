/**
 * Shared PDF tool UX: validation, progress bar uploads, async job polling, paywall.
 */
window.PdfToolkit = (function () {
    'use strict';

    const DEFAULTS = {
        maxFiles: 3,
        maxSizeBytes: 200 * 1024 * 1024,
    };

    const LARGE_FILE_BYTES = 10 * 1024 * 1024;
    const LARGE_FILE_MSG = 'This file is greater than 10 MB and may take some time to process. Please keep this tab open.';

    function getLargeFileMessage(files) {
        if (!files?.length) return null;
        const max = Math.max(...files.map(f => f.size || 0));
        return max >= LARGE_FILE_BYTES ? LARGE_FILE_MSG : null;
    }

    function showLargeFileNotice(files) {
        const el = document.getElementById('largeFileNotice');
        if (!el) return;
        const show = getLargeFileMessage(files);
        el.classList.toggle('d-none', !show);
    }

    function sanitizeErrorMessage(msg) {
        if (!msg || typeof msg !== 'string') return 'Something went wrong. Please try again.';
        const technical = /([A-Za-z]:\\|\/home\/|Pdf-Engine|Traceback|ModuleNotFoundError|Exception:|at \w+\.|blob\.core|Script not found|stderr|Ghostscript)/i;
        if (technical.test(msg) || msg.length > 300) {
            return 'We couldn\'t process your file. Please check the file and try again.';
        }
        return msg;
    }

    function fmtBytes(b) {
        if (b < 1024) return b + ' B';
        if (b < 1024 * 1024) return (b / 1024).toFixed(1) + ' KB';
        if (b < 1024 * 1024 * 1024) return (b / (1024 * 1024)).toFixed(2) + ' MB';
        return (b / (1024 * 1024 * 1024)).toFixed(2) + ' GB';
    }

    function validateFiles(fileList, options) {
        const opts = {
            maxFiles: DEFAULTS.maxFiles,
            maxSizeBytes: DEFAULTS.maxSizeBytes,
            extensions: null,
            typeLabel: 'file',
            multiple: true,
            ...options,
        };
        const files = Array.from(fileList || []);
        if (files.length === 0) return { ok: false, error: 'Please select at least one file.' };
        if (!opts.multiple && files.length > 1) return { ok: false, error: 'Please select only one file.' };
        if (files.length > opts.maxFiles) {
            return { ok: false, error: `Maximum ${opts.maxFiles} files allowed.` };
        }
        for (const f of files) {
            if (opts.extensions?.length) {
                const ext = '.' + (f.name.split('.').pop() || '').toLowerCase();
                const ok = opts.extensions.some(e => ext === e.toLowerCase());
                if (!ok) return { ok: false, error: `"${f.name}" is not a supported ${opts.typeLabel} file.` };
            }
            if (f.size > opts.maxSizeBytes) {
                return { ok: false, error: `"${f.name}" exceeds the ${fmtBytes(opts.maxSizeBytes)} limit.` };
            }
        }
        if (opts.maxTotalBytes && opts.maxTotalBytes > 0) {
            const total = files.reduce((s, f) => s + (f.size || 0), 0);
            if (total > opts.maxTotalBytes) {
                const label = opts.maxTotalBatchLabel || fmtBytes(opts.maxTotalBytes);
                return { ok: false, error: `Combined file size exceeds ${label}.` };
            }
        }
        return { ok: true, files };
    }

    function validatePdfFiles(fileList, options) {
        return validateFiles(fileList, {
            extensions: ['.pdf'],
            typeLabel: 'PDF',
            ...options,
        });
    }

    function escapeHtml(text) {
        const el = document.createElement('div');
        el.textContent = text ?? '';
        return el.innerHTML;
    }

    function resolveEl(el) {
        if (!el) return null;
        return typeof el === 'string' ? document.getElementById(el) : el;
    }

    /** Assign File objects to an input (drag-drop safe). */
    function assignFilesToInput(input, files) {
        const el = resolveEl(input);
        if (!el) return;
        const dt = new DataTransfer();
        for (const f of files || []) {
            if (f instanceof File) dt.items.add(f);
        }
        el.files = dt.files;
    }

    /** Compress-style file preview card. */
    function renderPdfFilePreview(container, files, options = {}) {
        const el = resolveEl(container);
        if (!el) return;
        const list = Array.from(files || []);
        if (!list.length) {
            el.innerHTML = '';
            el.classList.add('d-none');
            return;
        }
        el.classList.remove('d-none');

        const totalSize = list.reduce((s, f) => s + (f.size || 0), 0);
        const multi = list.length > 1;
        const title = multi ? `${list.length} files selected` : list[0].name;
        const meta = multi
            ? `Total: ${fmtBytes(totalSize)} · ${list.map(f => f.name).join(', ')}`
            : fmtBytes(list[0].size);
        const showClear = options.showClear !== false;
        const iconClass = options.iconClass || 'bi-file-earmark-pdf text-danger';

        el.innerHTML = `
            <div class="card border" style="border-radius:10px;background:#f8f9fa;">
                <div class="card-body py-3 px-3 d-flex align-items-center gap-3">
                    <div style="width:56px;height:72px;flex-shrink:0;border-radius:6px;overflow:hidden;background:#fff;border:1px solid #dee2e6;display:flex;align-items:center;justify-content:center;">
                        <i class="bi ${iconClass}" style="font-size:1.8rem;"></i>
                    </div>
                    <div class="flex-grow-1 overflow-hidden min-w-0">
                        <p class="mb-1 fw-semibold text-truncate" style="font-size:0.9rem;" title="${escapeHtml(title)}">${escapeHtml(title)}</p>
                        <p class="mb-0 text-muted" style="font-size:0.78rem;word-break:break-word;">${escapeHtml(meta)}</p>
                    </div>
                    ${showClear ? '<button type="button" class="btn btn-sm btn-outline-secondary pdf-preview-clear" style="border-radius:50%;width:30px;height:30px;padding:0;flex-shrink:0;" title="Remove file(s)" aria-label="Remove file(s)"><i class="bi bi-x"></i></button>' : ''}
                </div>
            </div>`;

        if (showClear && options.onClear) {
            el.querySelector('.pdf-preview-clear')?.addEventListener('click', options.onClear);
        }
    }

    /** Wire drop zone + file input to preview card (Merge, Split, etc.). */
    async function bindPdfUpload(cfg) {
        const fileInput = resolveEl(cfg.fileInput);
        const dropZone = resolveEl(cfg.dropZone);
        const previewContainer = resolveEl(cfg.previewContainer);
        const errorArea = resolveEl(cfg.errorArea);
        const toolId = cfg.toolId;
        if (!fileInput || !previewContainer || fileInput.dataset.pdfPreviewBound === '1') return;
        fileInput.dataset.pdfPreviewBound = '1';

        const multiple = cfg.multiple !== false && fileInput.hasAttribute('multiple');
        let limits = {
            maxFiles: cfg.maxFiles || DEFAULTS.maxFiles,
            maxSizeBytes: cfg.maxSizeBytes || DEFAULTS.maxSizeBytes,
            maxTotalBytes: cfg.maxTotalBytes || null,
            maxTotalBatchLabel: cfg.maxTotalBatchLabel || null,
            multiple,
        };

        if (toolId) {
            try {
                const access = await checkToolAccess(toolId);
                limits.maxFiles = access.maxBatchFiles || limits.maxFiles;
                limits.maxSizeBytes = access.maxFileSizeBytes || limits.maxSizeBytes;
                limits.maxTotalBytes = access.maxTotalBatchBytes || limits.maxTotalBytes;
                limits.maxTotalBatchLabel = access.maxTotalBatchLabel || limits.maxTotalBatchLabel;
            } catch { /* ignore */ }
        }

        function clearFiles() {
            assignFilesToInput(fileInput, []);
            renderPdfFilePreview(previewContainer, [], {});
            showLargeFileNotice([]);
            errorArea?.classList.add('d-none');
            const submitBtn = fileInput.closest('form')?.querySelector('button[type="submit"]');
            if (submitBtn) submitBtn.disabled = true;
            updateSubmitHint(false);
            syncStickyCtaState();
            cfg.onChange?.([]);
        }

        async function handleRawFiles(rawFiles) {
            const files = Array.from(rawFiles || []);
            if (!files.length) {
                clearFiles();
                return;
            }

            const accept = (fileInput.getAttribute('accept') || '').toLowerCase();
            const isPdf = accept.includes('.pdf') || accept.includes('application/pdf');
            let v;
            if (isPdf) {
                v = validatePdfFiles(files, limits);
            } else {
                const extensions = accept.split(',').map(a => a.trim()).filter(a => a.startsWith('.'));
                v = validateFiles(files, {
                    ...limits,
                    extensions: extensions.length ? extensions : null,
                    typeLabel: 'file',
                });
            }
            if (!v.ok) {
                if (errorArea) {
                    errorArea.textContent = sanitizeErrorMessage(v.error);
                    errorArea.classList.remove('d-none');
                }
                return;
            }

            errorArea?.classList.add('d-none');
            assignFilesToInput(fileInput, v.files);
            const previewIcon = isPdf ? 'bi-file-earmark-pdf text-danger' : 'bi-file-earmark-text text-primary';
            renderPdfFilePreview(previewContainer, v.files, { onClear: clearFiles, iconClass: previewIcon });
            showLargeFileNotice(v.files);
            const submitBtn = fileInput.closest('form')?.querySelector('button[type="submit"]');
            if (submitBtn) submitBtn.disabled = false;
            updateSubmitHint(true);
            syncStickyCtaState();
            cfg.onChange?.(v.files);
        }

        if (dropZone) {
            dropZone.addEventListener('click', () => fileInput.click());
            dropZone.addEventListener('dragover', e => {
                e.preventDefault();
                dropZone.classList.add('border-primary', 'bg-light');
            });
            dropZone.addEventListener('dragleave', () => {
                dropZone.classList.remove('border-primary', 'bg-light');
            });
            dropZone.addEventListener('drop', e => {
                e.preventDefault();
                dropZone.classList.remove('border-primary', 'bg-light');
                handleRawFiles(e.dataTransfer.files);
            });
        }

        fileInput.addEventListener('change', () => handleRawFiles(fileInput.files));
    }

    function initFormUploadPreviews() {
        document.querySelectorAll('form[data-pdf-tool]').forEach(form => {
            if (form.dataset.pdfPreviewInit === '1') return;
            const fileInput = form.querySelector('input[type="file"]');
            const previewContainer = form.querySelector('.pdf-file-preview');
            if (!fileInput || !previewContainer) return;
            form.dataset.pdfPreviewInit = '1';
            bindPdfUpload({
                fileInput,
                dropZone: form.querySelector('#dropZone') || form.querySelector('[id^="dropZone"]'),
                previewContainer,
                errorArea: form.querySelector('#errorArea'),
                toolId: form.dataset.pdfTool,
                multiple: fileInput.hasAttribute('multiple'),
            });
        });
    }

    function setProgress(elements, pct, msg) {
        if (!elements) return;
        const { bar, msg: msgEl, pct: pctEl, area } = elements;
        if (bar) bar.style.width = Math.min(100, Math.max(0, pct)) + '%';
        if (msgEl && msg) msgEl.textContent = msg;
        if (pctEl) pctEl.textContent = Math.round(pct) + '%';
        if (area) area.style.display = 'block';
    }

    function hideProgress(elements) {
        if (!elements?.area) return;
        elements.area.style.display = 'none';
        if (elements.bar) elements.bar.style.width = '0%';
        if (elements.pct) elements.pct.textContent = '0%';
    }

    function uploadWithProgress(url, formData, onProgress) {
        return new Promise((resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', url);
            xhr.responseType = 'json';

            xhr.upload.addEventListener('progress', (e) => {
                if (e.lengthComputable && onProgress) {
                    onProgress(Math.round((e.loaded / e.total) * 40), 'Uploading…');
                }
            });

            xhr.addEventListener('load', () => {
                if (xhr.status === 402) {
                    const err = xhr.response?.error || 'Daily free limit reached.';
                    const e = new Error(err);
                    e.paywall = true;
                    reject(e);
                    return;
                }
                if (xhr.status >= 200 && xhr.status < 300) {
                    resolve(xhr.response);
                } else {
                    const err = sanitizeErrorMessage(xhr.response?.error || xhr.response?.message || `Server error (${xhr.status})`);
                    reject(new Error(err));
                }
            });

            xhr.addEventListener('error', () => reject(new Error('Network error during upload.')));
            xhr.send(formData);
        });
    }

    function pollJob(statusUrl, elements, onTick) {
        return new Promise((resolve, reject) => {
            let attempts = 0;
            const maxAttempts = 720;

            const tick = async () => {
                attempts++;
                try {
                    const res = await fetch(statusUrl);
                    if (!res.ok) throw new Error('Status check failed');
                    const data = await res.json();

                    if (data.progressPercent != null) {
                        setProgress(elements, 40 + Math.round(data.progressPercent * 0.55), data.progressMessage || 'Processing…');
                    }
                    if (onTick) onTick(data);

                    if (data.status === 'Completed') {
                        setProgress(elements, 100, 'Ready to download');
                        resolve(data);
                        return;
                    }
                    if (data.status === 'Failed') {
                        reject(new Error(sanitizeErrorMessage(data.error || 'Conversion failed')));
                        return;
                    }
                    if (attempts >= maxAttempts) {
                        reject(new Error('Processing timed out. Please try again.'));
                        return;
                    }
                    const delay = attempts <= 15 ? 2000 : 5000;
                    setTimeout(tick, delay);
                } catch (err) {
                    reject(err);
                }
            };
            tick();
        });
    }

    async function checkToolAccess(toolId) {
        const res = await fetch(`/PDF/tool-access?tool=${encodeURIComponent(toolId)}`);
        if (!res.ok) return { allowed: true, remaining: 3, isPremium: false, maxFileSizeBytes: DEFAULTS.maxSizeBytes, maxBatchFiles: 3, maxFileSizeLabel: '200 MB', maxTotalBatchBytes: null, maxTotalBatchLabel: null };
        return res.json();
    }

    function showPaywall(reason) {
        const modal = document.getElementById('pdfPaywallModal');
        const msg = document.getElementById('pdfPaywallMessage');
        if (msg) msg.textContent = reason || 'Subscribe for unlimited PDF tool access.';
        if (modal && window.bootstrap) {
            bootstrap.Modal.getOrCreateInstance(modal).show();
        } else {
            alert(reason || 'Subscribe for unlimited PDF tool access.');
        }
    }

    function showEmailCapture() {
        return new Promise((resolve) => {
            const modal = document.getElementById('pdfEmailCaptureModal');
            if (!modal || !window.bootstrap) {
                resolve();
                return;
            }
            const onHidden = () => {
                modal.removeEventListener('hidden.bs.modal', onHidden);
                resolve();
            };
            modal.addEventListener('hidden.bs.modal', onHidden);
            bootstrap.Modal.getOrCreateInstance(modal).show();
        });
    }

    async function maybePromptEmailCapture(access) {
        if (!access || access.isPremium || access.emailCaptured || access.emailDismissed) return;
        const threshold = access.emailCaptureAfter ?? 2;
        if ((access.usedToday ?? 0) >= threshold) {
            await showEmailCapture();
        }
    }

    async function onToolUseSuccess(toolId) {
        if (!toolId) return;
        const access = await checkToolAccess(toolId);
        await maybePromptEmailCapture(access);
    }

    function initEmailCaptureModal() {
        const form = document.getElementById('pdfEmailCaptureForm');
        const submitBtn = document.getElementById('pdfEmailCaptureSubmit');
        const skipBtn = document.getElementById('pdfEmailCaptureSkip');
        const errEl = document.getElementById('pdfEmailCaptureError');
        const emailInput = document.getElementById('pdfLeadEmail');
        const modal = document.getElementById('pdfEmailCaptureModal');

        submitBtn?.addEventListener('click', async () => {
            const email = emailInput?.value?.trim();
            if (!email) {
                errEl.textContent = 'Please enter your email.';
                errEl.classList.remove('d-none');
                return;
            }
            submitBtn.disabled = true;
            try {
                const body = new URLSearchParams({ email });
                const res = await fetch('/pdf/tool-lead', { method: 'POST', body, headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
                if (!res.ok) {
                    const j = await res.json().catch(() => ({}));
                    throw new Error(j.error || 'Could not save email.');
                }
                if (modal && window.bootstrap) bootstrap.Modal.getInstance(modal)?.hide();
                refreshUsageBadges();
            } catch (e) {
                errEl.textContent = sanitizeErrorMessage(e.message);
                errEl.classList.remove('d-none');
            } finally {
                submitBtn.disabled = false;
            }
        });

        skipBtn?.addEventListener('click', () => {
            fetch('/pdf/tool-lead/dismiss', { method: 'POST' }).catch(() => {});
        });
    }

    function parseFileName(contentDisposition, fallback) {
        if (!contentDisposition) return fallback;
        const utf = /filename\*=UTF-8''([^;]+)/i.exec(contentDisposition);
        if (utf) return decodeURIComponent(utf[1]);
        const plain = /filename="?([^";\n]+)"?/i.exec(contentDisposition);
        return plain ? plain[1].trim() : fallback;
    }

    function downloadBlob(blob, fileName) {
        const a = document.createElement('a');
        a.href = URL.createObjectURL(blob);
        a.download = fileName;
        document.body.appendChild(a);
        a.click();
        a.remove();
        URL.revokeObjectURL(a.href);
    }

    /**
     * POST multipart form; server returns file blob (sync tools: merge, split, etc.).
     */
    async function submitFormWithProgress(form, elements, toolId, defaultFileName) {
        if (!form) throw new Error('Form not found');

        if (toolId) {
            const access = await checkToolAccess(toolId);
            if (!access.allowed) {
                showPaywall(access.denyReason || 'Free daily limit reached.');
                const e = new Error(access.denyReason || 'paywall');
                e.paywall = true;
                throw e;
            }
            await maybePromptEmailCapture(access);
        }

        const url = form.getAttribute('action') || form.action;
        const formData = new FormData(form);

        setProgress(elements, 2, 'Starting…');
        const uploadFiles = [];
        for (const [, v] of formData.entries()) {
            if (v instanceof File) uploadFiles.push(v);
        }
        const largeMsg = getLargeFileMessage(uploadFiles);
        if (largeMsg) setProgress(elements, 5, largeMsg);

        let procTimer = null;
        let procPct = 52;

        const result = await new Promise((resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', url);
            xhr.responseType = 'blob';

            xhr.upload.addEventListener('progress', (e) => {
                if (e.lengthComputable && elements) {
                    setProgress(elements, Math.round((e.loaded / e.total) * 45), 'Uploading…');
                }
            });

            xhr.addEventListener('loadstart', () => {
                procTimer = setInterval(() => {
                    if (procPct < 92) {
                        procPct += 2;
                        setProgress(elements, procPct, 'Processing…');
                    }
                }, 800);
            });

            xhr.addEventListener('load', () => {
                if (procTimer) clearInterval(procTimer);

                if (xhr.status === 402) {
                    const failPaywall = (msg) => {
                        showPaywall(msg || 'Daily free limit reached.');
                        const e = new Error(msg || 'paywall');
                        e.paywall = true;
                        reject(e);
                    };
                    if (xhr.response?.text) {
                        xhr.response.text().then((text) => {
                            try {
                                const j = JSON.parse(text);
                                failPaywall(j.error);
                            } catch {
                                failPaywall();
                            }
                        }).catch(() => failPaywall());
                    } else {
                        failPaywall();
                    }
                    return;
                }

                const type = xhr.getResponseHeader('Content-Type') || '';
                if (xhr.status >= 200 && xhr.status < 300) {
                    if (type.includes('application/json') || type.includes('text/html')) {
                        xhr.response.text().then((text) => {
                            try {
                                const j = JSON.parse(text);
                                reject(new Error(sanitizeErrorMessage(j.error || j.message || 'Processing failed')));
                            } catch {
                                reject(new Error('Processing failed'));
                            }
                        });
                        return;
                    }
                    setProgress(elements, 98, 'Downloading…');
                    resolve({
                        blob: xhr.response,
                        fileName: parseFileName(
                            xhr.getResponseHeader('Content-Disposition'),
                            defaultFileName || 'download'
                        ),
                    });
                    return;
                }

                xhr.response.text().then((text) => {
                    try {
                        const j = JSON.parse(text);
                        reject(new Error(sanitizeErrorMessage(j.error || j.message || `Server error (${xhr.status})`)));
                    } catch {
                        reject(new Error(`Server error (${xhr.status})`));
                    }
                }).catch(() => reject(new Error(`Server error (${xhr.status})`)));
            });

            xhr.addEventListener('error', () => {
                if (procTimer) clearInterval(procTimer);
                reject(new Error('Network error during upload.'));
            });

            xhr.send(formData);
        });

        downloadBlob(result.blob, result.fileName);
        hideProgress(elements);
        refreshUsageBadges();
        if (toolId) await onToolUseSuccess(toolId);
        return result;
    }

    function getStandardProgressElements() {
        return {
            area: document.getElementById('progressArea'),
            bar: document.getElementById('progressBar'),
            msg: document.getElementById('progressMsg'),
            pct: document.getElementById('progressPct'),
        };
    }

    async function runJobFlow({ url, formData, statusUrl, downloadUrl, elements, toolId, defaultFileName, skipAutoDownload }) {
        if (toolId) {
            const access = await checkToolAccess(toolId);
            if (!access.allowed) {
                showPaywall(access.denyReason || 'Free daily limit reached.');
                return null;
            }
            await maybePromptEmailCapture(access);
        }

        setProgress(elements, 2, 'Starting…');
        const uploadFiles = [];
        for (const [, v] of formData.entries()) {
            if (v instanceof File) uploadFiles.push(v);
        }
        const uploadMsg = getLargeFileMessage(uploadFiles);
        if (uploadMsg) setProgress(elements, 5, uploadMsg);

        const accepted = await uploadWithProgress(url, formData, (p) => {
            const msg = uploadMsg || 'Uploading…';
            setProgress(elements, p, p > 35 ? msg : 'Uploading…');
        });
        if (!accepted?.jobId) throw new Error('Invalid server response');

        const convertMsg = uploadMsg || 'Converting with high-fidelity engine…';
        setProgress(elements, 45, convertMsg);
        const result = await pollJob(statusUrl || accepted.statusUrl, elements);
        const resolvedDownloadUrl = downloadUrl || accepted.downloadUrl;

        if (skipAutoDownload) {
            setProgress(elements, 100, 'Ready');
            hideProgress(elements);
            if (toolId) await onToolUseSuccess(toolId);
            return { ...accepted, ...result, downloadUrl: resolvedDownloadUrl };
        }

        setProgress(elements, 98, 'Downloading…');

        const dlRes = await fetch(resolvedDownloadUrl);
        if (!dlRes.ok) throw new Error('Download failed');
        const blob = await dlRes.blob();

        const name = result.outputFileName || accepted.outputFileName || defaultFileName || 'converted';
        const a = document.createElement('a');
        a.href = URL.createObjectURL(blob);
        a.download = name;
        document.body.appendChild(a);
        a.click();
        a.remove();
        URL.revokeObjectURL(a.href);

        hideProgress(elements);
        if (toolId) await onToolUseSuccess(toolId);
        return blob;
    }

    async function ensureAccess(toolId) {
        const access = await checkToolAccess(toolId);
        if (!access.allowed) {
            showPaywall(access.denyReason);
            return false;
        }
        await maybePromptEmailCapture(access);
        return true;
    }

    function updateSubmitHint(hasFiles) {
        const hint = document.getElementById('submitHint');
        if (!hint) return;
        hint.classList.toggle('is-hidden', !!hasFiles);
    }

    function syncStickyCtaState() {
        const sticky = document.getElementById('rpStickyToolCta');
        const stickyBtn = document.getElementById('stickyConvertBtn');
        const stickyHint = document.getElementById('stickyCtaHint');
        const mainBtn = document.getElementById('convertBtn') || document.querySelector('form[data-pdf-tool] button[type="submit"]');
        if (!sticky || !stickyBtn || !mainBtn) return;

        const disabled = mainBtn.disabled;
        stickyBtn.disabled = false;
        if (stickyHint) {
            stickyHint.textContent = disabled ? 'Upload to start' : 'Ready — tap to convert';
        }
    }

    function initStickyMobileCta() {
        const sticky = document.getElementById('rpStickyToolCta');
        if (!sticky) return;

        const mainBtn = document.getElementById('convertBtn') || document.querySelector('form[data-pdf-tool] button[type="submit"]');
        const stickyBtn = document.getElementById('stickyConvertBtn');
        const hero = document.getElementById('rpToolHero') || document.querySelector('.rp-legacy-tool-card') || document.getElementById('dropZone');
        if (!mainBtn || !stickyBtn) return;

        stickyBtn.addEventListener('click', () => {
            if (mainBtn.disabled) {
                document.getElementById('dropZone')?.scrollIntoView({ behavior: 'smooth', block: 'center' });
                document.getElementById('fileInput')?.click() || mainBtn.closest('form')?.querySelector('input[type="file"]')?.click();
            } else {
                mainBtn.click();
            }
        });

        if (hero && 'IntersectionObserver' in window) {
            const obs = new IntersectionObserver(entries => {
                const visible = entries.some(e => e.isIntersecting);
                sticky.hidden = visible;
                document.body.classList.toggle('rp-has-sticky-cta', !visible);
            }, { threshold: 0.05 });
            obs.observe(hero);
        } else {
            sticky.hidden = false;
            document.body.classList.add('rp-has-sticky-cta');
        }

        sticky.hidden = false;
        syncStickyCtaState();
    }

    function initUpgradeNudge() {
        const nudge = document.getElementById('rpUpgradeNudge');
        const textEl = document.getElementById('upgradeNudgeText');
        const badge = document.getElementById('usageBadge');
        if (!nudge || !badge) return;

        const check = async () => {
            const toolId = badge.dataset.pdfUsageBadge;
            if (!toolId) return;
            try {
                const s = await checkToolAccess(toolId);
                if (s.isPremium || s.remaining > 1) {
                    nudge.classList.add('d-none');
                    return;
                }
                if (textEl) {
                    textEl.textContent = s.remaining === 1
                        ? '1 free use left today'
                        : `${s.remaining} free uses left today`;
                }
                nudge.classList.remove('d-none');
            } catch { /* ignore */ }
        };
        check();
        document.addEventListener('pdf-usage-updated', check);
    }

    function setUsageBadgeEl(el, access) {
        if (!el) return;
        el.textContent = access.isPremium ? 'Pro · Unlimited' : `${access.remaining} free today`;
        el.className = access.isPremium ? 'badge bg-warning text-dark' : 'badge bg-secondary';
    }

    function refreshUsageBadges() {
        document.dispatchEvent(new CustomEvent('pdf-usage-updated'));
        document.querySelectorAll('[data-pdf-usage-badge]').forEach(async (el) => {
            const toolId = el.dataset.pdfUsageBadge;
            if (!toolId) return;
            try {
                const s = await checkToolAccess(toolId);
                setUsageBadgeEl(el, s);
            } catch { /* ignore */ }
        });
    }

    /**
     * Initialize a conversion tool page with unified progress bar + dynamic limits.
     */
    async function initJobTool(cfg) {
        const access = await checkToolAccess(cfg.toolId);
        const limits = {
            maxFiles: access.maxBatchFiles || 3,
            maxSizeBytes: access.maxFileSizeBytes || DEFAULTS.maxSizeBytes,
            maxTotalBytes: access.maxTotalBatchBytes || null,
            maxTotalBatchLabel: access.maxTotalBatchLabel || null,
            extensions: cfg.extensions,
            typeLabel: cfg.typeLabel || 'file',
            multiple: cfg.multiple !== false,
        };

        const hint = document.getElementById(cfg.limitHintId);
        if (hint) {
            const batch = limits.maxFiles > 1 ? `Up to ${limits.maxFiles} files · ` : '';
            const totalNote = limits.maxTotalBatchLabel ? ` · ${limits.maxTotalBatchLabel} on Pro` : '';
            hint.textContent = `${batch}${access.maxFileSizeLabel || fmtBytes(limits.maxSizeBytes)} per file${totalNote}`;
        }

        const badge = document.getElementById(cfg.badgeId || 'usageBadge');
        if (badge) setUsageBadgeEl(badge, access);

        const dropZone = document.getElementById(cfg.dropZoneId);
        const fileInput = document.getElementById(cfg.fileInputId);
        const fileList = document.getElementById(cfg.fileListId);
        const convertBtn = document.getElementById(cfg.convertBtnId);
        const errorArea = document.getElementById(cfg.errorAreaId);
        const progressElements = {
            area: document.getElementById(cfg.progressAreaId),
            bar: document.getElementById(cfg.progressBarId),
            msg: document.getElementById(cfg.progressMsgId),
            pct: document.getElementById(cfg.progressPctId),
        };

        let selectedFiles = [];

        function showError(msg) {
            if (!errorArea) return;
            errorArea.textContent = sanitizeErrorMessage(msg);
            errorArea.classList.remove('d-none');
        }
        function clearError() { errorArea?.classList.add('d-none'); }

        function renderFileList() {
            if (!fileList) return;
            if (!selectedFiles.length) {
                renderPdfFilePreview(fileList, [], {});
                if (convertBtn) convertBtn.disabled = true;
                updateSubmitHint(false);
                syncStickyCtaState();
                return;
            }
            renderPdfFilePreview(fileList, selectedFiles, {
                onClear: () => {
                    selectedFiles = [];
                    assignFilesToInput(fileInput, []);
                    renderFileList();
                    showLargeFileNotice([]);
                    clearError();
                },
            });
            if (convertBtn) convertBtn.disabled = false;
            updateSubmitHint(true);
            syncStickyCtaState();
        }

        function setFiles(fileListObj) {
            const v = validateFiles(fileListObj, limits);
            if (!v.ok) { showError(v.error); return; }
            clearError();
            selectedFiles = v.files;
            renderFileList();
            showLargeFileNotice(selectedFiles);
            const largeMsg = getLargeFileMessage(selectedFiles);
            if (largeMsg && progressElements?.msg) {
                progressElements.msg.textContent = largeMsg;
            }
        }

        dropZone?.addEventListener('click', () => fileInput?.click());
        dropZone?.addEventListener('dragover', e => { e.preventDefault(); dropZone.style.background = '#eef2ff'; });
        dropZone?.addEventListener('dragleave', () => { dropZone.style.background = '#f8fafc'; });
        dropZone?.addEventListener('drop', e => {
            e.preventDefault();
            dropZone.style.background = '#f8fafc';
            const dt = e.dataTransfer?.files;
            if (dt?.length) setFiles(dt);
        });
        fileInput?.addEventListener('change', () => setFiles(fileInput.files));

        convertBtn?.addEventListener('click', async () => {
            if (!selectedFiles.length) return;
            clearError();
            convertBtn.disabled = true;

            const formData = new FormData();
            if (limits.multiple) {
                selectedFiles.forEach(f => formData.append('files', f));
            } else {
                formData.append('file', selectedFiles[0]);
            }

            try {
                const largeMsg = getLargeFileMessage(selectedFiles);
                if (largeMsg) setProgress(progressElements, 8, largeMsg);

                await runJobFlow({
                    url: cfg.convertUrl,
                    formData,
                    elements: progressElements,
                    toolId: cfg.toolId,
                    defaultFileName: cfg.defaultFileName,
                });
                const s = await checkToolAccess(cfg.toolId);
                if (badge) setUsageBadgeEl(badge, s);
            } catch (err) {
                if (err.paywall) showPaywall(err.message);
                else showError(sanitizeErrorMessage(err.message || 'Conversion failed.'));
                hideProgress(progressElements);
            } finally {
                convertBtn.disabled = selectedFiles.length === 0;
                syncStickyCtaState();
            }
        });
    }

    document.addEventListener('DOMContentLoaded', () => {
        refreshUsageBadges();
        initFormUploadPreviews();
        initStickyMobileCta();
        initUpgradeNudge();
        initEmailCaptureModal();
        document.querySelectorAll('form[data-pdf-tool] button[type="submit"]').forEach(btn => {
            const form = btn.closest('form');
            if (!form) return;
            // HTML/Text to PDF: editor content is valid without a file upload
            if (form.querySelector('[name="htmlContent"], [name="typedText"]')) return;
            const input = form.querySelector('input[type="file"]');
            if (input && !input.files?.length) btn.disabled = true;
        });
        syncStickyCtaState();
    });

    return {
        fmtBytes,
        validateFiles,
        validatePdfFiles,
        assignFilesToInput,
        renderPdfFilePreview,
        bindPdfUpload,
        initFormUploadPreviews,
        setProgress,
        hideProgress,
        uploadWithProgress,
        pollJob,
        checkToolAccess,
        ensureAccess,
        showPaywall,
        submitFormWithProgress,
        getStandardProgressElements,
        parseFileName,
        downloadBlob,
        runJobFlow,
        initJobTool,
        refreshUsageBadges,
        sanitizeErrorMessage,
        getLargeFileMessage,
        showLargeFileNotice,
        setUsageBadgeEl,
        updateSubmitHint,
        syncStickyCtaState,
        LARGE_FILE_MSG,
    };
})();
