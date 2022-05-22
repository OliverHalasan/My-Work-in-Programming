// Do NOT modify the following function.
const updateInnerHTML = function (selector, newValue) {
  document.querySelector(selector).innerHTML = newValue;
}

// TODO: Enter your code below.
function italics (evt) { 
 if (evt.target.tagName == 'i')
  evt.preventDefault();
  
}