// Find and assign your constant.
let monkeyToggle = document.querySelector('.menu-icon');

// Create a click event for it that toggles a CSS class. 

monkeyToggle.addEventListener('click', () => {
    document.querySelector('nav').classList.toggle('active-nav');
});