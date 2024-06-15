# Generics:

generics allow you to make a function, interface or class accept dynamic types, so instead of your function only limited to a certain type you can use generics to dynamically set a type that will be used eternally.

```typescript
// function declaration <GenericName>(param:GenericName)
const isObj = <T>(arg: T): boolean => {
  return typeof arg === "object" && !Array.isArray(arg) && arg != null;
};
// interface declaration <GenericName>{key:GenericName}
interface BoolCheck<T> {
  arg: T;
  is: boolean;
}
// class declaration <GenericName>{field:GenericName}
class StateObj<T> {
  private data: T;

  constructor(data: T) {
    this.data = data;
  }

  get state() {
    return this.data;
  }
  set state(val: T) {
    this.data = val;
  }
}
```

now you can set that type using `<Type>` but if you have already provided a value `tsc` will infer that type.

```typescript
isObj<string>("");
isObj("");
isObj<number>(1);
isObj(1);
```

---

also if you have a function that uses a type or an interface to specify the return type and it happens to use generics the generic type must be passed to type of interface

```typescript
interface BoolCheck<T> {
  arg: T;
  is: boolean;
}

function isTrue<T>(arg: T): BoolCheck<T> {
  if (Array.isArray(arg) && !arg.length) {
    return { arg, is: false };
  }
  if (isObj<typeof arg>(arg) && !Object.keys(arg as keyof T).length) {
    return { arg, is: false };
  }
  return { arg, is: !!arg };
}
```

---

also generic types can extend each other:

```typescript
interface HasId {
  id: number;
}

const processUer = <T extends HasId, K extends keyof T>(
  users: T[],
  key: K
): T[K][] /*returns all keys (K) from array of T*/ => {
  return users.map((user) => user[key]);
};

console.log(
  processUer(
    [
      { id: 1, name: "amr" },
      { id: 2, name: "ali" },
    ],
    "name"
  )
); //[amr, ali]
```
