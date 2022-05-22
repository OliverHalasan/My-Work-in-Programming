// Find and assign your constant.
let hamburger = document.querySelector('.drop-down');

// Create a click event for it that toggles a CSS class. 

hamburger.addEventListener('click', () => {
    document.querySelector('nav').classList.toggle('active-nav');
});