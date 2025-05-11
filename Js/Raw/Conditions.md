<!-- @format -->

# Conditions:

conditions allow you to run code only when a certain condition is met. when a conation is truthy the block runs, however if the condition is falsy the block is ignored, an if statement is defined by using: `if`, `else if` & `else`

here we have to variables we will use for this example:

```javascript
let a = 10;
let b = 4;
```

```javascript
if (a > b) {
	console.log(a);
} else if (a < b) {
	console.log(b);
} else {
	console.log(a, b);
}
```

this code can be interpreted as:

if **a** is greater than **b** log **a**, if not check if **b** is greater, if so log **b**, however if neither is greater -they are equal- log both **a** & **b**.

[!NOTE]> you are'nt limited to one `else if`, and conditions can be nested in one another

```javascript
if (a > b) {
	if (a === b * 2) {
		console.log("a is double b");
	}
}
```

you can define multiple conditions using the logical operators:

`&&`: the `and` operator, both side must be truthy so that the condition is truthy

`||`: the `or` operator, at least on side must be true for the condition to be truthy

`!`: the `not` operator, inverts truthy conditions to falsy and vice versa

---

## Switch expression:

the `switch` keyword is used for conditions -like `if` -but it depends upon a single variable and it's value.

```javascript
let a = 10;

switch (a) {
	case 1: // will run when a =1
		console.log("a = 1");
		break;
	case 2: // when a = 2
		console.log("a = 2");
		break;
	default: //when a = neither 1 || 2
		console.log("this condition isn't defined, a ->", a);
}
```

we used `break` because otherwise all code bellow a the case will be run if no break or return were used

so actually if a = 1, then all cases will run if no break was used
