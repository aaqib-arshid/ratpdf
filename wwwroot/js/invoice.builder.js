/*
 * invoice.builder.js
 * InvoiceCraft – dynamic invoice item rows & live calculations
 */

(function () {
    "use strict";

    // --- Configuration ---
    const itemsContainer = document.getElementById("itemsContainer");
    const addItemBtn = document.getElementById("addItemBtn");
    const saveTemplateBtn = document.getElementById("saveTemplateBtn");
    const taxRateSelect = document.getElementById("taxRateSelect");

    const subtotalDisplay = document.getElementById("subtotalDisplay");
    const taxRateDisplay = document.getElementById("taxRateDisplay");
    const taxAmountDisplay = document.getElementById("taxAmountDisplay");
    const totalDisplay = document.getElementById("totalDisplay");

    // --- Helpers ---
    function currencyFormat(value) {
        return new Intl.NumberFormat("en-IN", {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2,
        }).format(value);
    }

    // Update name attributes to maintain correct array indices (Items[i])
    function reIndexRows() {
        const rows = itemsContainer.querySelectorAll(".item-row");
        rows.forEach((row, idx) => {
            row.querySelectorAll("input, select").forEach((input) => {
                const name = input.getAttribute("name");
                if (name) {
                    // Replace any index inside brackets with current idx
                    input.setAttribute(
                        "name",
                        name.replace(/\[\d+\]/, `[${idx}]`)
                    );
                }
            });
        });
    }

    // --- Calculations ---
    function calculateTotals() {
        const rows = itemsContainer.querySelectorAll(".item-row");
        let subtotal = 0;

        rows.forEach((row) => {
            const qtyInput = row.querySelector(".quantity");
            const priceInput = row.querySelector(".unit-price");
            const amountInput = row.querySelector(".amount");

            const qty = parseFloat(qtyInput?.value) || 0;
            const price = parseFloat(priceInput?.value) || 0;
            const amount = qty * price;

            if (amountInput) amountInput.value = amount.toFixed(2);
            subtotal += amount;
        });

        const taxRate = parseFloat(taxRateSelect?.value) || 0;
        const taxAmount = subtotal * (taxRate / 100);
        const total = subtotal + taxAmount;

        // Update display
        if (subtotalDisplay) subtotalDisplay.textContent = currencyFormat(subtotal);
        if (taxRateDisplay) taxRateDisplay.textContent = taxRate;
        if (taxAmountDisplay) taxAmountDisplay.textContent = currencyFormat(taxAmount);
        if (totalDisplay) totalDisplay.textContent = currencyFormat(total);
    }

    // --- Item Row Management ---
    function getFirstRowHtml() {
        // Return a clean copy of the first row's HTML (with empty values)
        const firstRow = itemsContainer.querySelector(".item-row");
        if (!firstRow) return null;
        const clone = firstRow.cloneNode(true);

        // Clear all inputs
        clone.querySelectorAll("input").forEach((input) => {
            if (input.type === "number" || input.type === "text") {
                input.value = "";
            }
            if (input.classList.contains("quantity")) input.value = "1";
        });
        return clone;
    }

    function addItemRow() {
        const templateRow = getFirstRowHtml();
        if (!templateRow) return;

        itemsContainer.appendChild(templateRow);
        reIndexRows();
        calculateTotals();
    }

    function removeItemRow(button) {
        const rows = itemsContainer.querySelectorAll(".item-row");
        if (rows.length <= 1) {
            // Don't remove the last row – clear it instead
            const inputs = rows[0].querySelectorAll("input");
            inputs.forEach((inp) => {
                if (inp.classList.contains("quantity")) inp.value = "1";
                else inp.value = "";
            });
        } else {
            const row = button.closest(".item-row");
            if (row) row.remove();
        }
        reIndexRows();
        calculateTotals();
    }

    // --- Event Listeners (delegation) ---
    if (itemsContainer) {
        itemsContainer.addEventListener("input", function (e) {
            if (e.target.matches(".quantity, .unit-price")) {
                calculateTotals();
            }
        });

        itemsContainer.addEventListener("click", function (e) {
            if (e.target.closest(".remove-item")) {
                e.preventDefault();
                removeItemRow(e.target.closest(".remove-item"));
            }
        });
    }

    if (addItemBtn) {
        addItemBtn.addEventListener("click", addItemRow);
    }

    if (taxRateSelect) {
        taxRateSelect.addEventListener("change", calculateTotals);
    }

    // --- Template Saving (AJAX) ---
    if (saveTemplateBtn) {
        saveTemplateBtn.addEventListener("click", async function () {
            const templateName = prompt("Enter a name for this template:");
            if (!templateName || templateName.trim() === "") return;

            // Build form data from the current form
            const form = document.getElementById("invoiceForm");
            const formData = new FormData(form);
            formData.append("templateName", templateName.trim());

            try {
                const response = await fetch("/Invoice/SaveTemplate", {
                    method: "POST",
                    body: formData,
                    headers: {
                        "RequestVerificationToken": document.querySelector(
                            'input[name="__RequestVerificationToken"]'
                        )?.value,
                    },
                });

                if (response.redirected) {
                    window.location.href = response.url;
                } else if (response.ok) {
                    alert("✅ Template saved!");
                } else {
                    const text = await response.text();
                    alert("❌ Save failed: " + text);
                }
            } catch (err) {
                alert("Error saving template: " + err.message);
            }
        });
    }
    calculateTotals();
})();