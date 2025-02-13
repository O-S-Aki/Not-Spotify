// finds the first color that is not too dark to use as the base of the gradient.
document.addEventListener("DOMContentLoaded", function () {
    const colorThief = new ColorThief();
    const image = document.querySelector('.get-dominant-color');
    const container = document.querySelector('#dominant-color');

    image.onload = function () {
        const palette = colorThief.getPalette(image, 10);
        console.log("Palette:", palette);

        const getBrightness = (rgb) => (rgb[0] * 0.299 + rgb[1] * 0.587 + rgb[2] * 0.114);
        let chosenColor = palette.find(color => getBrightness(color) > 80) || palette[0];

        console.log(`Chosen color: ${chosenColor}`);

        const rgbColor = `rgb(${chosenColor[0]}, ${chosenColor[1]}, ${chosenColor[2]})`;
        container.style.background = `linear-gradient(to bottom, ${rgbColor}, #121212)`;
    };

    if (image.complete) {
        image.onload();
    }
});