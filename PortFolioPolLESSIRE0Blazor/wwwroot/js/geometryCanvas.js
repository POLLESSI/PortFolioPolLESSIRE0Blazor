window.initGeometryCanvas = () => {
    const canvas = document.getElementById("geometryCanvas");
    const ctx = canvas.getContext("2d");

    let angle = 0;
    const centerX = canvas.width / 2;
    const centerY = canvas.height / 2;

    function drawCube(x, y, size) {
        ctx.save();
        ctx.translate(x, y);
        ctx.rotate(angle);
        ctx.fillStyle = "#b30000";
        ctx.fillRect(-size / 2, -size / 2, size, size);
        ctx.restore();
    }

    function drawSphere(x, y, radius) {
        ctx.beginPath();
        const gradient = ctx.createRadialGradient(x - radius / 4, y - radius / 4, radius / 8, x, y, radius);
        gradient.addColorStop(0, "#ff4d4d");
        gradient.addColorStop(1, "#400000");
        ctx.fillStyle = gradient;
        ctx.arc(x, y, radius, 0, Math.PI * 2);
        ctx.fill();
    }

    function drawCone(x, y, height) {
        ctx.beginPath();
        ctx.moveTo(x, y);
        ctx.lineTo(x - height / 2, y + height);
        ctx.lineTo(x + height / 2, y + height);
        ctx.closePath();
        ctx.fillStyle = "#a00000";
        ctx.fill();
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        // Animation logic
        drawSphere(centerX - 200, centerY, 40);
        drawCube(centerX, centerY, 60);
        drawCone(centerX + 200, centerY - 30, 60);

        angle += 0.01;
        requestAnimationFrame(draw);
    }

    draw();
};
