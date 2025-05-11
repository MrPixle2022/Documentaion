<!-- @format -->

# Loops:

loops allow a block of code to be re-executed multiple times, based on either a condition or a defined number or a length of a string or an array for an example.

---

## for:

a `for` loop is defined using:

```javascript
// for(initialization; condition; afterThought)
```

the initialization is the statement where a variable is being initialized to be used in the loop.

the condition is the condition that keeps the block running

the after thought is the expression that runs after each loop

for example to log a message to the console 100 times:

```javascript
for (let index = 0; index <= 100; index++) {
	console.log(index);
}
```

the `let index = 0;` is the initialization, while `index <= 100` is the condition and the after thought is the `index++`

> [!IMPORTANT] we can use `break` to exit the loop entirely or `continue` to pass the current one and jump to the next.

---

## for(--in)

---

## for(--of)

---

## while(condition)

a while loop allows a block of code to run as long as the `condition` is truthy

```javascript
let i = 0;
while (i <= 5) {
	console.log(i);
	i += 1;
}
```

this will log all numbers from 0 -> 5

---

## do--while:

the `do while` loop is an inverted while loop, still the same condition based loop, but the syntax is changed:

```javascript
let i = 0;
do {
	i += 1;
	console.log(i);
} while (i <= 5);
```

> [!NOTE] the do while runs **then** checks for the condition unlike the normal `while` which checks the condition before it runs
