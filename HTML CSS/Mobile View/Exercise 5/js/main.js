// Step 1: select the element the user will click on to make this menu show/hide. 
let toggle = document.querySelector('.toggle-btn')
// Step 2: add a click event to that icon

toggle.addEventListener('click',  () => {
    document.querySelector('nav').classList.toggle('show-nav')
});
