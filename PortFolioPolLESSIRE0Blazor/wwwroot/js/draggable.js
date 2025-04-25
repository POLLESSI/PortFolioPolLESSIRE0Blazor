document.addEventListener("DOMContentLoaded", () => {
    const draggable = document.querySelector(".draggable-container");
    if (!draggable) return;

    let isDragging = false;
    let offsetX = 0;
    let offsetY = 0;

    draggable.addEventListener("mousedown", (e) => {
        isDragging = true;
        draggable.style.cursor = "grabbing";
        const rect = draggable.getBoundingClientRect();
        offsetX = e.clientX - rect.left;
        offsetY = e.clientY - rect.top;
    });

    document.addEventListener("mousemove", (e) => {
        if (!isDragging) return;

        const x = e.clientX - offsetX;
        const y = e.clientY - offsetY;

        // Vérifie que la table ne sort pas de la fenêtre (min 1cm = 37.8px)
        const margin = 37.8; // 1cm en px approximativement
        const maxX = window.innerWidth - draggable.offsetWidth - margin;
        const maxY = window.innerHeight - draggable.offsetHeight - margin;

        const finalX = Math.min(Math.max(x, margin), maxX);
        const finalY = Math.min(Math.max(y, margin), maxY);

        draggable.style.left = `${finalX}px`;
        draggable.style.top = `${finalY}px`;
    });

    document.addEventListener("mouseup", () => {
        isDragging = false;
        draggable.style.cursor = "grab";
    });
});












































////Copyrite https://github.com/POLLESSI