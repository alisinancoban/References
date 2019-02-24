var verseChoose = document.querySelector("select");
var poemDisplay = document.querySelector("pre");

updateDisplay(verseChoose.value);

verseChoose.onchange = function(){
    var verse = verseChoose.value;
    updateDisplay(verse)
};

function updateDisplay(verse){
    verse = verse.replace(" ", "");
    verse = verse.toLowerCase();
    var url = "https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json";
    
    fetch(url).then(function(response){
        response.text().then(function(text){
            poemDisplay.textContent = text;
        });
    });
    /*var request = new XMLHttpRequest();
    request.open("GET", url);
    request.responseType = "text";
    request.onload = function(){
        poemDisplay.textContent = request.response;
    }

    request.send();
    */
};

var L;

var map = L.mapquest.map('map', {
  center: [53.480759, -2.242631],
  layers: L.mapquest.tileLayer('map'),
  zoom: 12
});