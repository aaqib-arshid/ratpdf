/**
 * Freemium gate for client-side image tools (3 uses/day, same as PDF tools).
 */
window.ImageToolkit = (function () {
    'use strict';

    const PRICING_URL = '/Subscription/Plans?source=image-tools';

    async function checkAccess(toolId) {
        const res = await fetch(`/Tools/tool-access?tool=${encodeURIComponent(toolId)}`);
        if (!res.ok) return { allowed: true, remaining: 3, isPremium: false };
        return res.json();
    }

    function showPaywall() {
        window.location.href = PRICING_URL;
    }

    async function ensureAccess(toolId) {
        const access = await checkAccess(toolId);
        if (!access.allowed) {
            showPaywall();
            const e = new Error(access.denyReason || 'paywall');
            e.paywall = true;
            throw e;
        }
        return access;
    }

    async function recordUsage(toolId, count = 1) {
        try {
            await fetch(`/Tools/record-usage?tool=${encodeURIComponent(toolId)}&count=${count}`, {
                method: 'POST',
            });
        } catch { /* best effort */ }
    }

    async function refreshBadge(toolId, badgeId = 'imageUsageBadge') {
        const badge = document.getElementById(badgeId);
        if (!badge) return;
        const access = await checkAccess(toolId);
        badge.textContent = access.isPremium
            ? 'Premium · Unlimited'
            : `${access.remaining} free use(s) today`;
        badge.className = access.isPremium ? 'badge bg-warning text-dark' : 'badge bg-secondary';
    }

    async function runWithAccess(toolId, action, count = 1) {
        await ensureAccess(toolId);
        const result = await action();
        await recordUsage(toolId, count);
        await refreshBadge(toolId);
        return result;
    }

    document.addEventListener('DOMContentLoaded', () => {
        document.querySelectorAll('[data-image-tool-id]').forEach(el => {
            refreshBadge(el.getAttribute('data-image-tool-id'), el.id || 'imageUsageBadge');
        });
    });

    return {
        checkAccess,
        ensureAccess,
        recordUsage,
        refreshBadge,
        showPaywall,
        runWithAccess,
    };
})();
