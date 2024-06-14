# Type casting:

in typescript sometimes there will be a returned value that could either be inferred to a less specific type or a more specific type, you do that with casting.

for example:

```typescript
// const var = <type> ---
// const var = --- as type
```

usually `tsc` will ask to set the value type to `unknown` but it's not obligatory for cases like a function that returns a `number` or `string` you can cast the result to one of them.


```typescript

//--|TYPE ASSERTION & TYPE CASTING|-->

type One = string;
type Two = string | number;
type Three = "hello";

let one: One = "hello";

let two = one as Two; //less specific conversion
let three = one as Three; //more specific conversion
let four = <One>"hi there"; // this syntax is the same as above but with less typing & invalid in react

function addOrConcat(
  n1: number,
  n2: number,
  op: "add" | "concat" = "add"
): number | string {
  if (op === "add") return n1 + n2;
  return "" + n1 + n2;
}

const five = addOrConcat(2, 3, "add") as string;
console.log("🚀 ~ five:", five, typeof five); //5, string

const six = addOrConcat(2, 3, "concat") as number; //be aware of this bug, it seems valid but the return type is a string thought being casted as a number;
console.log("🚀 ~ six:", six, typeof six); //23, string

```

when working with the `dom`, type assertion is almost always required when targeting a `dom element`

```typescript 
//with dom.
//requires the .js file to be connected to the html file

const img = document.querySelector("img") as HTMLImageElement;
const input = document.querySelector("input") as HTMLInputElement;
```

