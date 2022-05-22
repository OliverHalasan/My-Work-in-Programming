// Step 1: Defining Constants
const ClickButton = document.querySelector('.toggle-btn');


// Step 2: Adding A Click Event
ClickButton.addEventListener('click' , () => {
    document.querySelector('nav').classList.toggle('show-nav');

});