window.initParallax = function () {
    console.log("initParallax called");
    console.log("✅ initParallax is now globally available.");

    setTimeout(() => {
        const bg = document.querySelector('.parallax-bg');
        if (bg) {
            document.addEventListener('mousemove', e => {
                const x = (e.clientX / window.innerWidth - 0.5) * 20;
                const y = (e.clientY / window.innerHeight - 0.5) * 20;
                bg.style.transform = `translate(${x}px, ${y}px)`;
            });
        }

        const fig = document.querySelector('.figurine');
        if (fig) {
            fig.addEventListener('mousemove', (e) => {
                const rect = fig.getBoundingClientRect();
                const x = (e.clientX - rect.left) / rect.width - 0.5;
                const y = (e.clientY - rect.top) / rect.height - 0.5;
                fig.style.transform = `translate(-50%, -50%) rotateY(${x * 40}deg) rotateX(${y * -40}deg)`;
            });
        }
    }, 500); // delay 500ms
};
