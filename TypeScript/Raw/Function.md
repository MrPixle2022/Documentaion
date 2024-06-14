# Functions:

to declare a function statement in typescript you follow the syntax of:

```typescript
//function <name>(params:type):<return-type>{----}

```

```typescript
//function that takes x(number) & y(number) & reruns their sum(number);
function add(x: number, y: number): number {
  return x + y;
}
```

but to declare as an arrow function you follow:

```typescript
// const funcName: (parma1: type1, params2: type2) => returnType = (param1, params2) => {---}

// const funcName = (param1: type1, params2: type2): returnType => {---}
```

so an arrow function that adds two numbers will look like:

```typescript
const sum: (x: number, y: number) => number = (x, y) => {
  return x + y;
};

const three = (a: number, b: number): number => {
  return a + b;
};
``` 

also you don't need to set a return type since `tsc` will infer the type automatically based on the returned value.

> [!TIP]  
> you can make a parameter optional by adding `?` before the `:` for example `x?: number`

> [!IMPORTANT]
> any function that returns nothing has a return type of `void`

> [!IMPORTANT]
> to set a default value to a params use `param: type = value`
> 
> to pass a param with a default value set use undefined at it's position

> [!IMPORTANT]
> a rest parma is always an array, `...params:type[]`
