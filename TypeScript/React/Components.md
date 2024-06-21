# Components:

to create a new react functional component you follow the same rules as js but with some changes.

```typescript
export function Section() {
  return (
    <div>
      Hello!
    </div>
  )
}
```

but you can explicitly infer types :

```typescript
function Section():ReactElement {
  return (
    <div>
      Hello!
    </div>
  )
}
```

for arrow syntax it looks like:

```typescript
export const Header = ():ReactElement => {return <h1>Hello!</h1>}
```


