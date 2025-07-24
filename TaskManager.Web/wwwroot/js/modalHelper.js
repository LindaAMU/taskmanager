export function show(selector) {
    const el = document.querySelector(selector);
    if (!el) return;
    const modal = bootstrap.Modal.getOrCreateInstance(el);
    modal.show();
}

export function hide(selector) {
    const el = document.querySelector(selector);
    if (!el) return;
    const modal = bootstrap.Modal.getOrCreateInstance(el);
    modal.hide();
}