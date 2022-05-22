// Enter your JavaScript for the solution here...
let p = document.getElementsByClassName('tags')
let reset = document.querySelector('.reset');
let display = document.getElementsByClassName('thumb-display')

document.querySelector('.frm-control').addEventListener('input',function(evt){
    let target = evt.target;
    
    if (target.value !=='') 
    {
        reset.classList.remove('hidden');
    }
    else
    {
        reset.classList.add('hidden');
    }
       
    for (let i = 0; i < p.length; i++){        
        if (p[i].innerHTML.toLowerCase().includes(target.value.toLowerCase())) {
            display[i].classList.remove('hidden');
        } else {
            display[i].classList.add('hidden');
        }
    }
});

//reset button
reset.addEventListener('click',function (evt) {
documunet.querySelector('.frm-control').value = '';
reset.classList.add('hidden');

for(let i = 0; i < display.length; i++){
    display[i].classList.remove('hidden')
}
});