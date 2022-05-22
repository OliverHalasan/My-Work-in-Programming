let images = ['mountain1.jpg', 'mountain2.jpg', 'mountain3.jpg'];
let currentImage = 0;
let slideshowInterval;
let carousel = document.querySelector('.carousel>img');
let pause

carousel.src = 'images/' + images[0]; 

document.querySelector('.carousel').addEventListener('click', function (evt){
    if (evt.target.className == 'control prev') {
        moveSlide(-1);
    } else if (evt.target.className == 'control next'){
        moveSlide(+1);
    }   
});

function moveSlide(dir) {
	currentImage += dir;
	if (currentImage < 0) {
		currentImage = images.length - 1;
	} else if (currentImage === images.length) {
		currentImage = 0;
	}
    carousel.src = 'images/' + images[currentImage];
}

slideshowInterval = setInterval(function () {
    moveSlide(+1);
}, 3000);

//Add your code here.

document.querySelector('.carousel').addEventListener('mouseover', function (){
    clearInterval(slideshowInterval)
});


document.querySelector('.carousel').addEventListener('mouseout', function (){
    slideshowInterval = setInterval(function () {
        moveSlide(+1);
    }, 3000);
});