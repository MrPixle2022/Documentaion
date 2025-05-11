<!-- @format -->

# Simple Logic & Compression

## Truthy & Falsy values:

falsy and truthy values are used in lossy check, falsy values are:

- null
- undefined
- 0 & -0
- NaN
- "" & '' & ``

any other value is considered truthy

---

## Compression operators:

in js there are relational & equity operators, the `relational` ones are:

\> , < , >= , <=

```javascript
let number1 = 10;
let number2 = 10;

console.log(number1 > number2); // false -> 10 isn't greater than 10
console.log(number1 >= number2); // true -> 10 is greater than or equal to 10
console.log(number1 < number2); // false -> 10 ----
console.log(number1 <= number2); // true -> 10 ---
```

while the equity operators are:

lossy: == & !== which only checks for value ignoring the type

strict: === & !== which checks for both value & type

```javascript
let number1 = 10;
let number2 = "10";
// relational
console.log(number1 == number2); // true
console.log(number1 === number2); // false
console.log(`` == false); // true
console.log(`` === false); // false
```
