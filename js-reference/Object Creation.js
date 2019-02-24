var person = { //object literal
    name: ['Bob', 'Smith'],
    age: 32,
    gender: 'male',
    interests: ['music', 'skiing'],
    bio: function() {
      alert(this.name[0] + ' ' + this.name[1] + ' is ' + this.age + ' years old. He likes ' + this.interests[0] + ' and ' + this.interests[1] + '.');
    },
    greeting: function() {
      alert('Hi! I\'m ' + this.name[0] + '.');
    }
  };

  function createNewPerson(name){ 
      var obj = {};
      obj.name = name;
      obj.greeting = function(){
          alert("Hi I am "+ this.name);
      };
      return obj;
  }

  function Person(name){
    this.name = name;
    this.greeting = function(){
        alert("Hi I am "+ this.name);
    };
}

class Person {
    constructor(name) {
        this.name = name;
        this.greeting = function () {
            alert("Hi I am " + this.name);
        };
    }
}

var person1 = new Object({
    name: 'Chris',
    age: 38,
    greeting: function() {
      alert('Hi! I\'m ' + this.name + '.');
    }
  });
