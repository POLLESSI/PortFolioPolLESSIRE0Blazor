document.addEventListener('scroll', () => {
    const scrollY = window.scrollY;
    const max = 400;
    const opacity = 1 - Math.min(scrollY / max, 0.5);
    document.documentElement.style.setProperty('--bg-opacity', opacity);
});

















































////Copyrite https://github.com/POLLESSI
