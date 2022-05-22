
// Part 1

document.querySelector('a.feature.link').addEventListener('click', function (evt) {
    var imgFeature = document.querySelector('img.feature');
    imgFeature.src = evt.target.href;
    //Add your line of code below this comment.
    document.querySelector('img.feature').alt = "Sunrise on Barcelona"     
    imgFeature.classList.remove('hidden');
    evt.preventDefault();
});


// Part 2 Add your code for this part below this comment.

const addcityImage = function (evt){
   let imgFeature = document.querySelector ('img.feature');
    imgFeature.src = evt.target.href;
    imgFeature.classList.remove('hidden');
    evt.preventDefault();
   
}

const noImage = function (evt){
    let imgFeature = document.querySelector ('img.feature');
     imgFeature.src = evt.target.href;
     document.querySelector('img.feature').alt = ""  
     imgFeature.classList.add('hidden');
     evt.preventDefault();
    
 }

 document.querySelector('p.city-intro>a')
 .addEventListener('mouseover', addcityImage);

 document.querySelector('p.city-intro>a')
 .addEventListener('mouseout', noImage);















