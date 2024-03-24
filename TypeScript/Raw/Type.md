# Type:

the `type` keyword allows you to create custom types based on a data type or a value.

```typescript
type FrontEndLang = 'js'|'ts'|'html & css'

let lang:FrontEndLang = 'ts'
```

this `FrontEndLang` type will only accept on of these values defined `'js'|'ts'|'html & css'`

---

### Type combining:

to combine multiple types in one use `&` also note that [Utilities](Utitlites.md) also works on types.

```typescript
type Person = {
    name: string;
    age:number;
}

type Car = {
    carName: string;
    model?: string; 
}

type PersonWithCar = Person & Required<Car>

const p:PersonWithCar = {
    name: 'someone',
    age: 10,
    carName: 'Bmw',
    model: 'M5'
}
```
