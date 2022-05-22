// Enter your JavaScript for the solution here...

// error trigger
document.querySelector('.meme-form')
    .addEventListener('submit', function (evt){
        let error = document.querySelector('.error'); 
        let textBoxtop = evt.target.elements.memeTopText;
        let textBoxbot = evt.target.elements.memeBottomText;
        let memeImgae = evt.target.elements.memeImage;
        let Topoutput = document.querySelector('p.top-text');
        let Botoutput = document.querySelector('p.bottom-text');
        // image selection
        document.querySelector('img').src = 'img/' + evt.target.elements.memeImage.value + '.png';



        
        if (memeImgae.value.trim() === ''){
            error.innerHTML +="<p>Please Choose an image</p>"
           
        } 
        

        if (textBoxtop.value.trim() === ''){
            error.innerHTML = error.innerHTML += "<p>Top text cannot be empty</p>"
        
        }else {
            Topoutput.innerHTML = evt.target.elements.memeTopText.value
            
  
        }
        
        if (textBoxbot.value.trim() === ''){
            error.innerHTML = error.innerHTML += "<p>Bottom text cannot be empty</p>"

        }else {
            Botoutput.innerHTML = evt.target.elements.memeBottomText.value


        }
        
        evt.preventDefault();

        
    });
    document.querySelector('.content')
    .addEventListener('reset',function(evt){

        evt.preventDefault();

    });
    // let fryMeme = document.querySelector('.fry-meme');
    // let oneDoesnot = document.querySelector('.one-does-not-simply-meme');
    // let mostInteresting = document.querySelector('.most-interesting-man-meme');

    // fryMeme.addEventListener('click', memeSelectionHandler);
    // oneDoesnot.addEventListener('click', memeSelectionHandler);
    // mostInteresting.addEventListener('click', memeSelectionHandler);

    // function memeSelectionHandler(evt) {

    //     let memeSelection = document.querySelector('section.content');
    //     if (evt.target.classList.contains('fry-meme')) {
    //         memeSelection.elements.remove("https://via.placeholder.com/550x300?text=+an+image+from+the+dropdown")
    //     }

    // }

   

    



