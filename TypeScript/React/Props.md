# Props:

to pass props to a component you must specify the type, create a type or an interface with all properties you want and set them as the type of the `props`

```typescript
interface Props{
  children: React.ReactNode; //this is the children prop that react uses
  title: string
}

//can assign default values to props
function Section({title = "hello", children}: Props) {
  return (
    <div>
      {title}
      {children}
    </div>
  )
}
```

also function can use `Generics` to define their props for example:

```typescript
import { ReactNode } from "react";

interface Props<T>{
  items: T[];
  render: (item:T) => ReactNode;
}

//const name = <T>({props}:Type<T>) => {}
function List <T>({ items, render }: Props<T>) {
  return (
    <ul className="">
      { items.map((item, i) => (<li key={ i }>{ render(item) }</li>))}
    </ul>
  )
}

```

then the generic will be inferred passed on the props type

```typescript
<List items={ ["coffee", "taco", "code"] } render={ (item: string) => <h1>{ item }</h1>}/>
```
