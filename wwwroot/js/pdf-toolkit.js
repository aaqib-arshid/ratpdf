/**
 * Shared PDF tool UX: validation, progress bar uploads, async job polling, paywall.
 */
window.PdfToolkit = (function () {
    'use strict';

    const DEFAULTS = {
        maxFiles: 3,
        maxSizeBytes: 200 * 1024 * 1024,
    };

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
        return { ok: true, files };
    }

    function validatePdfFiles(fileList, options) {
        return validateFiles(fileList, {
            extensions: ['.pdf'],
            typeLabel: 'PDF',
            ...options,
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
                    setTimeout(tick, 5000);
                } catch (err) {
                    reject(err);
                }
            };
            tick();
        });
    }

    async function checkToolAccess(toolId) {
        const res = await fetch(`/PDF/tool-access?tool=${encodeURIComponent(toolId)}`);
        if (!res.ok) return { allowed: true, remaining: 3, isPremium: false, maxFileSizeBytes: DEFAULTS.maxSizeBytes, maxBatchFiles: 3, maxFileSizeLabel: '200 MB' };
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
        }

        const url = form.getAttribute('action') || form.action;
        const formData = new FormData(form);

        setProgress(elements, 2, 'Starting…');

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

    async function runJobFlow({ url, formData, statusUrl, downloadUrl, elements, toolId, defaultFileName }) {
        if (toolId) {
            const access = await checkToolAccess(toolId);
            if (!access.allowed) {
                showPaywall(access.denyReason || 'Free daily limit reached.');
                return null;
            }
        }

        setProgress(elements, 2, 'Starting…');
        const accepted = await uploadWithProgress(url, formData, (p) => setProgress(elements, p, 'Uploading…'));
        if (!accepted?.jobId) throw new Error('Invalid server response');

        setProgress(elements, 45, 'Converting with high-fidelity engine…');
        const result = await pollJob(statusUrl || accepted.statusUrl, elements);
        setProgress(elements, 98, 'Downloading…');

        const dlRes = await fetch(downloadUrl || accepted.downloadUrl);
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
        return blob;
    }

    async function ensureAccess(toolId) {
        const access = await checkToolAccess(toolId);
        if (!access.allowed) {
            showPaywall(access.denyReason);
            return false;
        }
        return true;
    }

    function refreshUsageBadges() {
        document.querySelectorAll('[data-pdf-usage-badge]').forEach(async (el) => {
            const toolId = el.dataset.pdfUsageBadge;
            if (!toolId) return;
            try {
                const s = await checkToolAccess(toolId);
                el.textContent = s.isPremium ? 'Pro · Unlimited' : `${s.remaining} free today`;
                el.classList.toggle('bg-success', !!s.isPremium);
                el.classList.toggle('bg-secondary', !s.isPremium);
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
            extensions: cfg.extensions,
            typeLabel: cfg.typeLabel || 'file',
            multiple: cfg.multiple !== false,
        };

        const hint = document.getElementById(cfg.limitHintId);
        if (hint) {
            const batch = limits.maxFiles > 1 ? `Up to ${limits.maxFiles} files · ` : '';
            hint.textContent = `${batch}${access.maxFileSizeLabel || fmtBytes(limits.maxSizeBytes)} per file`;
        }

        const badge = document.getElementById(cfg.badgeId || 'usageBadge');
        if (badge) {
            badge.textContent = access.isPremium ? 'Premium · Unlimited' : `${access.remaining} free use(s) today`;
            badge.className = access.isPremium ? 'badge bg-warning text-dark' : 'badge bg-secondary';
        }

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
                fileList.innerHTML = '';
                if (convertBtn) convertBtn.disabled = true;
                return;
            }
            fileList.innerHTML = selectedFiles.map(f =>
                `<div class="d-flex align-items-center gap-2 p-2 border rounded mb-1">
                    <i class="bi bi-file-earmark text-primary"></i>
                    <span class="flex-grow-1 text-truncate">${f.name}</span>
                    <span class="text-muted small">${fmtBytes(f.size)}</span>
                </div>`
            ).join('');
            if (convertBtn) convertBtn.disabled = false;
        }

        function setFiles(fileListObj) {
            const v = validateFiles(fileListObj, limits);
            if (!v.ok) { showError(v.error); return; }
            clearError();
            selectedFiles = v.files;
            renderFileList();
        }

        dropZone?.addEventListener('click', () => fileInput?.click());
        dropZone?.addEventListener('dragover', e => { e.preventDefault(); dropZone.style.background = '#eef2ff'; });
        dropZone?.addEventListener('dragleave', () => { dropZone.style.background = '#f8fafc'; });
        dropZone?.addEventListener('drop', e => {
            e.preventDefault();
            dropZone.style.background = '#f8fafc';
            setFiles(e.dataTransfer.files);
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
                await runJobFlow({
                    url: cfg.convertUrl,
                    formData,
                    elements: progressElements,
                    toolId: cfg.toolId,
                    defaultFileName: cfg.defaultFileName,
                });
                const s = await checkToolAccess(cfg.toolId);
                if (badge) {
                    badge.textContent = s.isPremium ? 'Premium · Unlimited' : `${s.remaining} free use(s) today`;
                }
            } catch (err) {
                if (err.paywall) showPaywall(err.message);
                else showError(sanitizeErrorMessage(err.message || 'Conversion failed.'));
                hideProgress(progressElements);
            } finally {
                convertBtn.disabled = selectedFiles.length > 0;
            }
        });
    }

    document.addEventListener('DOMContentLoaded', refreshUsageBadges);

    return {
        fmtBytes,
        validateFiles,
        validatePdfFiles,
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
    };
})();
