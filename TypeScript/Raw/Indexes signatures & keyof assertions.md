# Indexes signatures & keyof assertions:

in `typescript` since you mostly use `interfaces` and `types` your object mostly have a static shape, but in some cases you would want for a specific type to be dynamically extended without writing extra code in it's declaration further more you can't access `keys` of objects using variables like:

```typescript
interface TransactionObj {
  Pizza: number;
  Books: number;
  Job: number;
}

const todayTransactions: TransactionObj = {
  Pizza: -10,
  Books: -5,
  Job: 50,
};

let prop: string = "Pizza";

console.log(todayTransactions[prop]) //error, type string can't be indexed to type TransactionObj
for (const key in todayTransactions) {
  console.log(todayTransactions[key]) //same error
}

```

as you will get an error. But luckily there is a way to go around this.

---

## Index signatures:

in type script you can make an interface accept additional `keys` of a specific type and hold a specific value.

in your `interface` you can use:

```typescript
interface NewTransactionObj {
  [key: string]: number; //index signatures, means that all keys are string, and all values are numbers, can be set to `readonly` by adding `readonly` before `[]` like `readonly [key:string]: any`
}

const newTodayTransactionsObj: NewTransactionObj = {
  Pizza: -10,
};

console.log(newTodayTransactionsObj[prop]); //-10, valid
console.log(newTodayTransactionsObj["any-thing"]); //undefined, make sure you check if the key exists.

```

> [!CAUTION]
> it's better to check if a key is defined when using this way

also this can be used together with mandatory keys but the index signature must accept all types in the interface and if any key is `optional` than the index signature must accept the type of `undefined`.

```typescript
interface Student {
  [key: string]: string | number | number[] | undefined; //since we added this index signature we must set the type to allow all types that are used in this interface
  name: string;
  GPA: number;
  classes?: number[];
}

const student: Student = {
  name: "amr yasser",
  GPA: 0,
};

for (const key in student) {
  console.log(`${key}: ${student[key as keyof Student]}`); //this how you target a key dynamically on any interface that doesn't use the index signature, the `keyof` word returns a union type of all types in the interface and the `as` keyword casts that type
}
```

in the previous example we used `keyof` which return the types in the following interface or whatever, but if you don't know what interface is the object type the use `typeof`:

```typescript
for (const key in student) {
  console.log(`${key}: ${student[key as keyof typeof student]}`);
```

> [!TIP]
> the `keyof` isn't limited to accessing keys. they can be used in functions, etc...

