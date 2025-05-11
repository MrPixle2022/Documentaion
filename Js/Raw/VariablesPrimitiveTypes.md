<!-- @format -->

# Variables & Primitive types:

variables allow you to store data of some type under a name of your choice, the value can be either changeable or unchangeable:

a variable is defined by the following syntax:

```javascript
// reserveKeyword name = value
```

and the `reserveKeyword` can be:

- var -> almost not-used, the variable is **always** in the global scope
- let -> the alternative to define a changeable value, respects scopes
- const -> define values whose value never changes, only changeable @ the declaration line

```javascript
let thatName = "user"; //the thaName can be changed
thatName = "new name"; //reassign the variables value

const otherName = "other name"; // the otherName can't be reassigned
other = "another third name"; //will cause an error
```

note that a variable defined using let can be declared without a value, in this case the default is `undefined` unlike const which require the value to be defined

```javascript
let someVar; //someVar = undefined
```

---

## Naming variables

a variable's name usually follows a convention, the most popular ones are:

-> kebab_case: `variable_name`

-> UPPERCASE: `VARIABLENAME`

-> lowercase `variablename`

-> camelCase: `variableName`

---

## Primitive types:

javascript has a set of primitive types like `Number`, `String`, `Boolean`, `Array` & `Object` in addition to other types.

since javascript is dynamically typed those types are used to `convert` data from one type to another thus they all start with a capital letter

```javascript
let stringified = String(1); // -> stringified = "1"
let numbered = Number("1"); // numbered = 1, if the given value was inconvertible like "a" numbered will equal NaN
let booleanConverted = Boolean(0); // booleanConverted = false
```

---

## Getting a data's type

the type can read using the `typeof` keyword:

```javascript
console.log(typeof "2"); // string
//or use typeof("2") which is also valid
```

---

## Basic mathematics:

basic math operation like addition, subtraction, division, multiplication & even powers and remains can be achieved using symbols like

```javascript
console.log(
	2 + 2, //4
	5 - 3, //2
	9 % 2, //1 -> what remains after dividing 9 over 2
	9 / 2, //4.5
	4 * 8, //32
	2 ** 5, //32
);
```

this can be used to update a variables value like:

```javascript
let base = 0;

base += 2; //base = base + 2 -> base =2
base -= 1; // base = base - 1 -> base = 1
base *= 100; // base = base * 100 -> base = 100
base /= 2; // base = base / 2 -> base = 50
base++; // base += 1 -> base = 51
base--; // base -=1 -> base = 50
```

note there is an important thing:

```javascript
let counter = 0;

console.log(counter++, "and the counter is", counter); //0 and the counter is 1
console.log(++counter, "and the counter is", counter); //1 and the counter is 1
```

using the `++` or `--` before and after the variable has an impact, if used before the variable name the variable will be incremented before it's used, but using it after the variable means the value first then update it
