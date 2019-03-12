const boxes = document.querySelectorAll(".box");

//ES5
var boxes5 = Array.prototype.slice.call(boxes);
boxes5.forEach(element => {
    element.style.backgroundColor = "dodgerblue";
});

//ES6
const boxes6 = Array.from(boxes);
boxes6.forEach(element => {
    element.style.backgroundColor = "red"
});

//ES5
for(var i = 0; i < boxes5.length; i++){
    if(boxes5[i].className === "box blue"){
        continue;
    }
    boxes5[i].textContent = "I changed to blue es5";
}

//ES6
for(const element of boxes6){
    if(element.className.includes("blue")){
        continue;
    }
    element.textContent = "I changed to blue es6";
}

//ES5
var ages = [12, 17, 8, 21, 22, 14, 11];
var full = ages.map(function(current){
    return current >= 18;
});

console.log(full.indexOf(true));
console.log(ages[full.indexOf(true)]);

//ES6
console.log(ages.findIndex(current => current >= 18));
console.log(ages.find(current => current >= 18));

function addFourAges(a, b, c, d){
    return a + b + c + d;
}
var arr = [18, 30, 12 ,12];
console.log(addFourAges(18, 30, 12 ,12));
//ES5
console.log(addFourAges.apply(null, arr));
//ES6
console.log(addFourAges(...arr));

console.log(...arr, ...arr);
console.log(boxes);
const all = [...boxes];

Array.from(all).forEach(element => {
    element.style.color = "purple";
});