# Data types:

navigation:

- [Primitive types](#primitive-types)
- [Multiple types](#multiple-types)
- [Arrays of single or multiple types](#arrays-of-single-or-multiple-types)
- [Functions, parameters and return types](#functions-parameters-and-return-types)

---

# Primitive types:

to create a var in typescript you follow syntax of `let varName:type = value`, the type is all lower case for primitive types.

```typescript
let var1:number = 2; //can only store numbers
let var2:string = "amr"; //can only store string
let var3:boolean = true; //can only store boolean
let var4:object = {}; //an object
```


---
# Multiple types:

to allow a variable to hold multiple values use the union syntax `let varName:(type1|type2) = value`.

```typescript
let var1:(string|number) = "amr"; //works
var1 = 2; //works
```

you are not limited to two types, foreach type you want add `|` and then the type.

---

# Arrays of single or multiple types:

to create an array of numbers for example add `[]` after the type.

```typescript
let var1:number[] = [1,2,3,4];
```

to create an array that allows for multiple types use `(type1|type2)[]`.

```typescript
let var1:(number|boolean) = [1,true,false,4]
```

another way of creating arrays is with tuples they specify the length,data types and order of elements.

```typescript
let tuple:[string, number] = ["hello", 10]
```

this tuple length can't be anything but 2 since we specified 2 values first must be of type `string` while second must be a `number`

---

# Any type:

if you wan't a variable to be dynamic at any time use the `any` type, it can be used to create arrays that can hold any type in it.

```typescript
let var1:any = "amr";
var1 = true;

let var2:any[] = ["amr", true, false, 2,3];

```

---

# Functions, parameters and return types:

functions stored in variables and created with the arrow syntax must have a type, the syntax is like

`const func: (para1:type1, para2:type2) => returnType = (para1, para2) => return returnType`.

```typescript
const firstFunc:(number1:number) => number = (number1) => {return 1}
const secondFunc:() => void = () => {}
```

the `void` keyword means no returned data.

---

