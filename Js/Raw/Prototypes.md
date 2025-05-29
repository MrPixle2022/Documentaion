<!-- @format -->

# Prototype:

in js every single object has a `__proto__` -will be referred to as just **proto** from time to time- referencing what is called an object prototype.

```javascript
let dude = {};
console.log(dude); //{}
```

the `dude` object is obviously empty, but what happens when we expand it in the dev tools.

when we do so we find a `__proto__`.

even when we try to access some methods we see something weird

```javascript
dude.talk; //this is undefined
dude.toString; //this is a function
```

ok, where did we define this `toString` function? spoiler alert: we didn't ,the `toString` function is defined in the `Object` prototype

so, the dude object has a `__proto__` property that points to the Object prototype and the `Object` prototype has a `__proto__` property that points to the `Function` prototype and the Function prototype has a `__proto__` property that points to the Object prototype and the Object prototype has a `__proto__` property that points to the Function prototype and so on, and so on, and so on

this is what is called the prototype chain.

as it turns out no matter how every you create an object it will always have a **proto** property and that **proto** property will always point to the Object prototype, which includes all the methods and properties of the object it inherits from by default the **proto** property is set to the `Object` but is the Object enumerable? they are not so, the **proto** property is not enumerable so, if you try to loop over the properties of an object using a for...in loop the **proto** property will not be included in the loop

as a matter of fact you will see the **proto** event on things like arrays and strings:

```javascript
const arr = [1, 2, 3];
console.log(arr); //[ 1, 2, 3 ]
// but the __proto__ property exists and the __proto__ property is actually the `Array` and the `Array` has a __proto__ property that points to the `Object`

// hmm... what about strings?

const str = "hello";
console.log(str); //hello
// but the __proto__ property exists and the __proto__ property is actually the `String`

// and actually the `String` has a __proto__ property that points to the `Object`
```

so to recap:

arrays have a proto -> Array which has a proto -> Object strings have a proto -> String which has a proto -> Object

---

## Accessing inherited values:

```javascript
const human = {
	kind: "human",
};

dude = Object.create(human);

console.log(dude); //{}
```

but the dude object has a **proto**, and in the **proto** property is the human object with it's kind

property

```javascript
dude.kind; // this is human
```

wasn't it `{}` just now?, ok lets update the kind

```javascript
dude.kind = "dude";
console.log(dude); //{ kind: 'dude' }
```

but the proto still exists and kind is still human

```javascript
console.log(dude.kind); //dude
console.log(dude.__proto__.kind); //human
console.log(human.kind); //human
```

when you try to access a property on an object, JavaScript first looks for that property on the object itself if it doesn't find it, it looks for the property on the object's prototype if it doesn't find it there, it looks for the property on the prototype's prototype and so on, until it reaches the end of the prototype chain if it doesn't find the property anywhere in the prototype chain, it returns `undefined` and this is how we got the `undefined` value

Ok lets look at the Prototype property and what is the difference between the prototype and the **proto** property

---

## The prototype property:

the `prototype` property is a property of a `constructor function` aka classes

```javascript
//this is a constructor function, creates a new object
function PersonConstruct(name) {
	this.name = name;
}

const person = new PersonConstruct("Dude");
console.log(person); //{ name: 'Dude' }
// the prototype property is a property of the constructor function
console.log(person.prototype); // undefined
console.log(PersonConstruct.prototype);
//{ constructor: [Function: PersonConstruct] }

console.log(person.__proto__); //{ constructor: [Function: PersonConstruct] }
console.log(person.__proto__ === PersonConstruct.prototype); // true

// ok lets add a method to the prototype property
person.__proto__.talk = function () {
	console.log("Hello, my name is " + this.name);
};

// now we can call the talk method on the person object
console.log(PersonConstruct.prototype.talk()); //undefined
```

the conclusion is that the prototype property is a property of the constructor function and the **proto** property is a property of the object itself

both are the same thing, but the prototype property is a property of the constructor function and the **proto** property is a property of the object itself, so they are the same thing but from a different perspective
