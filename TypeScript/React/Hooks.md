# Hooks:

navigation:

- [useState](#usestatetinitialvaluet)
- [useEffect](#useeffecteffect-dependencies)
- [useRef](#userefinitialvalue)
- [useCallback](#usecallbackcallback-dependencies)
- [useMemo](#usememofactory-dependencies)  

---

## useState<T?>(initialValue:T);

similar to how it is used in js the `useState` hook didn't change, the only change is that it now accept a generic type to more accurately specify the type, it's inferred based on the `initialValue` but for more accuracy use `generics`

```typescript
interface User {
	name: string;
	id: number | string;
}
```

```typescript
	const [user, setUser] = useState({} as User); //same as useState<User>({})
```

---

## useEffect(effect, \[dependencies]):

the `useEffect` allows you to run code when the component first mounts, unmounts or when a value changes.
it takes a function known as `effect` and an array of the values that will recall the effect when they change.

```typescript
useEffect(() => {
		console.log(`hello`);
		return () => console.log(`bye`); //clean up function executed when unmounting the component
		//beware that when using strict mode a component will be mounted ,unmounted & remounted again
	}, []);
```

---

## useRef<T>(initialValue):

the `useRef` is a hook responsible for storing values that won't change between rerenders but not so important that their change will rerender the component.
it can be linked to an html element via the `ref` attribute or use other value, the returned object stores the value in a property called current.

```typescript
const inputRef = useRef<HTMLInputElement>(null);
if (inputRef?.current)
  inputRef.current.value = "you dare?!";
```

---

## useCallback(callback, [dependencies]):

the `useCallback` is a performance hook that memoizes a function caching it, it takes a callback and a dependencies array and returns a memoized version of the callback function.

```typescript
const [count, setCount] = useState<number>(0);
	// callback can take the event value, e: MouseEvent<Element> |KeyboardEvent<Element> | ....
	const addTwo = useCallback(():void => setCount((prev) => prev + 1), []);
```

then can use the memoized callback:

```typescript
<h1>{count}<h1>
<button onClick={addTwo}>Add</button>
```

---

## useMemo<T>(factory, [dependencies]):

the `useMemo` is another performance hook that is similar to `useCallback` but the difference is that it memoizes values of an expensive operation and returns the memoized value

```typescript
function fib(n: number):number {
  if (n < 2)
    return n;
  return fib(n - 1) + fib(n - 2);
}

const myNum: number = 73;
//useMemo memoizes a value similar to useCallback
// useMemo<T>(factory, [dependencies])
const result = useMemo<number>(() => fib(72), [myNum])
```
