const unityIframe = document.querySelector(".unitystuff");

const baseWidth = 1080;
const baseHeight = 720;

let scaleRatioX = 1; 
let scaleRatioY = 1; 

function ResizeGame() {
    scaleRatioX = window.innerWidth / baseWidth;
    scaleRatioY = window.innerHeight / baseHeight;



    console.log('New width:', window.innerWidth);
    console.log('New height:', window.innerHeight);

    console.log('ratio width:', scaleRatioX);
    console.log('ratio height:', scaleRatioY);

    let scalefactor = Math.min(scaleRatioX, scaleRatioY);

    unityIframe.style.setProperty('--scale-factor', scalefactor / 1.1);
    unityIframe.style.setProperty('--scale-factor-x', scaleRatioX / 1.1);
    unityIframe.style.setProperty('--scale-factor-y', scaleRatioY / 1.1);

}

ResizeGame();


window.addEventListener('resize', function () {

    ResizeGame();


});


