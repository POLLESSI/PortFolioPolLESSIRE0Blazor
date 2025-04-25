window.getScrollTop = (elementId) => {
    const el = document.getElementById(elementId);
    if (el) {
        return el.scrollTop;
    }
    return 0;
};
window.getScrollTop = () => {
    return window.pageYOffset
        || document.documentElement.scrollTop
        || document.body.scrollTop
        || 0;
};
window.getScrollHeight = (element) => {
    return element ? element.scrollHeight : 0;
};

window.getClientHeight = (element) => {
    return element ? element.clientHeight : 0;
};




















































































////Copyrite https://github.com/POLLESSI




























/*//Copyrite https://github.com/POLLESSI*/