const ClickButton = document.querySelector('.toggle-btn');



ClickButton.addEventListener('click' , () => {
    document.querySelector('nav').classList.toggle('show-nav');

});

