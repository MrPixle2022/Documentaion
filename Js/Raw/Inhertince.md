<!-- @format -->

# Inheritance:

let say we have two objects named `me` and `you`, we want both to talk via a method `talk`:

```javascript
//Inheritance:
const me = {
	talk() {
		return "Hello, I'm a person";
	},
};

const you = {
	talk() {
		return "Hello, I'm a person too";
	},
};
```

now both `me` and `you` can `talk`, but what if wa want to **update** the `talk` method for both?, and what if we have like 1000 objects that we want to update the `talk` method for?, for that we use **inheritance**.

---

## Class inheritance:

using classes for inheritance is usually the standard way to do it.

so instead of copying the method to each object, we can create a `Person` class and make `me` and `you` inherit from it":

```javascript
class Person {
	talk() {
		return "Hello, I'm a person added via class";
	}
}
const newMe = new Person();
const newYou = new Person();
```

though classes in js are different, a class in js is a function that creates a new object with the methods and properties instead it's `prototype`.

now both share the same prototype, so if we update the `talk` method in the `Person` class, it will be updated for both `me` and `you`

```javascript
console.log(newMe.talk()); // Hello, I'm a person
console.log(newYou.talk()); // Hello, I'm a person
```

but there is something you have to understand, the `talk` **doesn't actually exist** in the `newMe` and `newYou` objects, neither on the **person**, but actually on the class's prototype. meaning that talk is actually at `person.prototype.talk`

also `Person.prototype === newMe.__proto__` so logically `newMe.__proto__.talk()` is the very same `talk` method in the class

```javascript
//we can update the `talk` method in the `Person` class and it will be updated for both `newMe` and `newYou`:
Person.prototype.talk = function () {
	return "Hello, I'm a person, but I have a new talk method assigned after declaring the class";
};

console.log(newMe.talk()); // Hello, I'm a person, but I have a new talk method assigned after declaring the class
```

---

## Constructor functions flaw:

we can also use a constructor function:

```javascript
function PersonConstructor() {
	//this refers to the object that is being created
	this.age = 18;
	this.talk = function () {
		return `Hello, I'm a person, but I have a new talk method created by a constructor function`;
	};
}

const thirdMe = new PersonConstructor();

console.log(thirdMe.talk()); // Hello, I'm a person, but I have a new talk method
```

but the `talk` method is actually on the `thirdMe` object, not on the **prototype**, so if we update the `talk` method in the `PersonConstructor` class, it will not be updated for `thirdMe`, so this is actually not inheritance, but rather a copy of the method.

```javascript
PersonConstructor.prototype.age = 40;
console.log(thirdMe.age, PersonConstructor.prototype.age); // 18 40
```

---

## Object prototypes inheritance:

on each and every object there is a hidden `__proto__` that hides the objet which this object inherits from and the default one is the `Object` constructor

we can make use of the prototype for inheritance for example using the `create` method:

```javascript
const personObj = {
	age: 18,
	talk() {
		return "Hello, I'm a person, but I have a new talk, but this is a pure object";
	},
};

const thatGuy = Object.create(personObj);
```

this creates a new object with the specified prototype object and properties.

so `thatGuy` is an object that inherits from `personObj`, so it has access to the `talk` method and the `age` property of `personObj`

```javascript
console.log(thatGuy.talk()); // Hello, I'm a person, but I have a new talk, but this is a pure object
personObj.talk = function () {
	return "Hello, I'm a person, but I have a new talk method assigned after declaring the pure object";
};
console.log(thatGuy.talk()); // Hello, I'm a person, but I have a new talk method assigned after declaring the pure object
```

and also we can use the `setPrototypeOf` method:

```javascript
const thatOtherDude = {};
Object.setPrototypeOf(thatOtherDude, personObj); // this sets the prototype of `thatOtherDude` to `personObj`, so it has access to the `talk` method and the `age` property of `personObj`
console.log(thatOtherDude.talk()); // Hello, I'm a person, but I have a new talk method assigned after declaring the pure object
```
