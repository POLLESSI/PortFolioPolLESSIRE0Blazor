window.scrollFadeIn = () => {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add("visible");
            }
        });
    });

    document.querySelectorAll('.scroll-fade').forEach(el => {
        observer.observe(el);
    });
};
















































////Copyrite https://github.com/POLLESSI







/*//Copyrite https://github.com/POLLESSI*/