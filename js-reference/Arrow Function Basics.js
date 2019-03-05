const years = [1990,1991,1992,1993,1994];

var ages5 = years.map(function(current){
    return 2019 - current;
});

let age6 = years.map(y => 2019 - y);

age6 = years.map((y, i)=> {
    const now = new Date().getFullYear();
    const age = now - y;
    return age;
});