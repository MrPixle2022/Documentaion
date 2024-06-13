# Enums:

enums in typescript are a way to reuse data. they serve similar to a var but a constant one and easier to handle.

```typescript
//enum enumName{key1, key2}  -> the values are indexes by default.

//enum enumName{key1 = 1, key2} -> the first key's value = 1 and each key's value = index + 1

//enum enumName{key1 = val1, key2 =val2}
```

example:

```typescript
enum GRADES {
  U,// 0
  D,// 1
  C,// 2
  B,// 3
  A,// 4
}

enum GRADES_TWO {
  U = 2,
  D, //3
  C, //4
  B, //5
  A, //6
}

console.log(GRADES.A); //4
console.log(GRADES_TWO.A); //6

enum DAYS {
  FIRST = "saturday",
  SECOND = "sunday",
}

console.log(DAYS.FIRST); //saturday

```
