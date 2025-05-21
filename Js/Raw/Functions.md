<!-- @format -->

# Function:

a function is a block of repeatable code that can accept and return values.

usually they can be defined like

```javascript
// normal function declaration
function _fun_name_(_params_){
  ---
}

// function expression
const _func_ = function(_params_){---}

// arrow function
const _func_name_ = (_params_) => {---}
const _func_name = (_params_) => returnVal;
```

now know that a function can be called:

```javascript
function gree() {
	console.log("greeting");
}

greet(); //call the function
greet; //the function object, use when passing the function's reference
```

note that when calling a functions it becomes a value

---

## Arguments:

a function can take arguments / params, params are defined in the function's definition between `( )` and they can be normal arguments whose values is assigned based on position, and they can optionally have a default value, also a function can have a single **rest parameter** which holds any number of values defined by `...paramName`

```javascript
// num1 defaults to 1 (use undefined when calling to not overwrite)
// num2 is a normal param , defaults to undefined
// numbers is an array that takes any value passed after the first two
function addNumbers(num1 = 0, num2, ...numbers) {
	if (numbers.length !== 0) {
		return num1 + num2 + numbers.reduce((pre, cur) => pre + cur, 0);
	}
	return num1 + num2;
}

console.log(addNumbers(undefined, 2, 3, 4, 5, 6, 7, 8, 9, 10)); //num1 =1(@default), num2 =2, numbers=[3,---,10], final -> 55
```

---

## Return statement:

using the `return` keyword we can return a value from a function or return none, it's useful when you want to end a function execution, for example we can make a simple function that takes a username and a password and compare the password to a stored value, if they match return an object else exit the function:

```javascript
function getUser(username, password) {
	const thisPassword = "12345";
	if (password !== thisPassword) return;
	return { username, password };
}

const user1 = getUser("user1", "12345"); // {user1, 12345}
const user2 = getUser("user2", "123"); //undefined
```

in javascript functions can return any value even other functions

---

## Callbacks:

a callback function is a function that is used as an argument, like the sorter callback, reducer function, etc..., they are usually are assigned as arrow functions, or by passing the function name without calling it using the `()`

```javascript
function someFunc(msg, callback) {
	callback(msg);
}

someFunc("hello", (msg) => console.log(msg)); //will console log hello
```

---

## Factory functions:

factory functions are function that return another object, be it another function for example or even a decorator like in ts:

```javascript
function factory(n) {
	return function () {
		return n + 1;
	};
}
const fact = factory(2);
console.log(fac()); //3
```
