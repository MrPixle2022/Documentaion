<!-- @format -->

# Destructuring:

destructure allows for easier extraction of data from an objects, arrays, functions returns, function parameters, etc...

---

## Destructure arrays:

destructing arrays depends on order, using the **const [var1, ---]** we can extract the data, it also supports the rest operator

```javascript
const arr = [1, 2, 3, 4];
const [v1, v2, ...v3] = arr;

console.log(v1); //1
console.log(v2); //2
console.log(v3); //[3,4]
```

and also can have defaults:

```javascript
const arr = [];
const [one = 1] = arr;
// one = 1 as it's the default and arr can assign it another value of its own
```

remember you can pass an index or two:

```javascript
const arr = [1, 2, 3, 4, 5, 6, 7];

const [one, , , four] = arr;

console.log(one, four); //1 4
```

---

## Destructure objects:

destructing objects offers more flexibility since your obligation is that the var name is the same as the object's key though you can rename them:

```javascript
const user = {
	username: {
		first: "first",
		last: "name",
	},
	age: 23,
	email: "first@last.com",
};

const {
	username: { first, last },
	email,
	age: userAge,
} = user;

console.log(first, last);
console.log(email);
console.log(userAge);
```

this snippet extracts the `username` object from the user and destructure the values of `first and last`, extract the email and extracting the age and **renaming** it to userAge.

so we can nest destructuring, rename values and extract the key with it's name, also we can use the rest operator and assign defaults:

```javascript
const { username, ...rest } = user;

console.log(rest); // {age: --, email: --}

const { password = "null" } = user;

console.log(password); //"null"
```
