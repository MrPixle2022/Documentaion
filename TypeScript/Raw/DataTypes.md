# DataTypes:

navigation:

- [Basic types](#basic-types)
- [Union types](#union-types)
- [Tuples](#tuples)
- [Functions](#functions)

---

## Basic types:

the syntax for defining types it typescript is

```typescript
//let varName:type = value
```

```javascript
let inferred = 2; //typescript consideres a number
let x: number = 5; // a number
let y: string = ""; // a string
let z: boolean = false; //a boolean
let w: string[] = ["", ""]; //a string array
let h: object = {}; //an object
let o: any; //can have any value
let re: RegExp = /\w+/g; //regular expression
```

---

## Union types:

type script allows you to set a variable to accept multiple data types using the `Union types`. 

they follow the same syntax as `Basic types` but the difference is that it looks like:

```typescript
//let <name>: type1 | type2 = <value>; //not only limited to 2 types but can be any, add '|' and the type to add more types
//let <name>: value1 | value2 = <value>; //only one of the values can be used

```

an example:

```typescript

let a: number | string = ""; // a var that can be either number or string
a = 2;

let b: (number | string)[] = ["amr", 2]; //an array of either numbers or strings

let c: number[] | string = [1, 2, 3]; //a number array or a normal string

```

---

## Tuples:

a `tuple` in typescript is a more strict version of an array ,instead of only specifying a data type, you specify the length & the type of data at each position.

the syntax looks like:

```typescript
//            the number of elements(types) in the tuple(:[type1, type2]) is the length of the tuple
//let <name>: [type1, type2] = [<value1 of type1>, <value2 of type2>];

```

```typescript

let d: [number, string] = [1, "amr"]; //a tuple of number and string in order

//a tuple can only be of a certain length, in the above example it is 2 since we set it to 2(number, string)

let e: [number, string, number] = [1, "2", 3]; //a tuple of 3 elements, number -> string -> number

```

---

### functions:

functions in typescript can take `params` and `return a certain type of value`.

the syntax to declare a function looks like:

```typescript
//function <name>(params:type):<return-type>{----}
//const funcName: (param1: type, param2:type) => returnType = (param1, param2) => {----}
```

for example:

```typescript
function add(x: number, y: number): number {
  return x + y;
}

const sum: (x: number, y: number) => number = (x, y) => {
  return x + y;
};
```
