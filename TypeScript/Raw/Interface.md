# Interfaces:

interfaces allow you to create a new type which require certain data to be present in any object of it's type.

```typescript
interface Person{
    name:string;
    age:number;
}

const person1:Person = {
    name:"amr",
    age:10
}
```

in this `Person` interface you won't be able to add any more data in the person1 object, to fix this problem use:

```typescript
interface Person{
    name:string;
    age:number;
    [key:type]: any
}

const person1:Person = {
    name:"amr",
    age:10,
    smart: true
}
```

by default all keys in an interface are required to make one optional add `?` which has the same result as for example `number|undefined`, the `?` isn't limited to interfaces only it can be used for functions and other things, also can be used to check objects and other data if their value isn't null or undefined.

```typescript
interface Person{
    name:string;
    age?:number;
    [key:type]: any
}

const person1:Person = {
    name:"amr",
    smart: true
}
```

using `!` after an optional value means that your are sure that at this point it will have a value so typescript doesn't have to check for undefined.