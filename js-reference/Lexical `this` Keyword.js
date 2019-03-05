var box5 = {
    color: "green",
    position: 1,
    clickMe: function(){
        var self = this;
        document.querySelector(".green").addEventListener("click", function(){
            var string = self.position + " " + self.color;
            console.log(string);
        });
    }
};
box5.clickMe();
//ES5 in fucntion scope this represent the global windows object.

const box6 = {
    color: "blue",
    position: 2,
    clickMe: function(){
        document.querySelector(".blue").addEventListener("click", () => {
            var string = this.position + " " + this.color;
            console.log(string);
        });
    }
}
box6.clickMe();
//arrow fucntion share lexical this keyword of its surroundings.

const box66 = {
    color: "blue",
    position: 2,
    clickMe: () => {
        document.querySelector(".orange").addEventListener("click", () => {
            var string = this.position + " " + this.color;
            console.log(string);
        });
    }
}
box66.clickMe();
//The surrounding od this is global context. The represent window global object


function Person(name){
    this.name = name;
}

Person.prototype.myFriends5 = function(friends){
    var arr = friends.map(function(current){
        return this.name;
    }.bind(this));

    console.log(arr);
};

var friends =["ali", "sinan", "alper", "mustafa"];
new Person("john").myFriends5(friends);

Person.prototype.myFriends6 = function(friends){
    var arr = friends.map(current => {
        return this.name;
    });

    console.log(arr);
};

new Person("mike").myFriends6(friends);