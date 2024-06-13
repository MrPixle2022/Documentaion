# The `type` keyword:

the `type` keyword allows the developed to create custom data types for better intellisense, it can be used to create objects with keys that has specific data type.

```typescript
//type type_Name = types
//type type_name = {
//  key: type,
//  key2: type
//}

//const myObj: type_name = {
//  key: ----,
//  key2: ----
//}
```

for example:

```typescript
type test = {
  name: string;
  age: number;
  alive?: boolean;
};

let myObj: test = {
  name: "amr",
  age: 17,
  alive: true,
};

type secondTest = 'html' | 'js' | number;


```
also you can make a property optional bu adding a `?` before the `:`

```typescript
type user = {
  username: string,
  age: number,
  isAdmin?:boolean 
}

const newUser:user = {
  username: "amr",
  age: 19
}
//no error since `isAdmin` is optional
```

---

# The `interface` keyword:

an interface is a way to shape object, it's similar to `type` since you can use it to specify `keys` and their `types` for an obj.

```typescript
/*
interface interfaceName{
  key: value
}
*/
```


an example
```typescript
interface hello {
  name: string;
  age: number;
  isAdmin?: boolean;
}

const thisObj: hello = {
  name: "",
  age: 11,
  isAdmin: false,
};

```
