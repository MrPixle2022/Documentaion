# Hooks:

navigation:

- [useState](#usestatetinitialvaluet)
- [useEffect](#useeffecteffect-dependencies)
- [useRef](#userefinitialvalue)
- [useCallback](#usecallbackcallback-dependencies)
- [useMemo](#usememofactory-dependencies)  

---

## useState\<T>(initialValue:T);

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

## useRef\<T>(initialValue):

the `useRef` is a hook responsible for storing values that won't change between rerenders but not so important that their change will rerender the component.
it can be linked to an html element via the `ref` attribute or use other value, the returned object stores the value in a property called current.

```typescript
const inputRef = useRef<HTMLInputElement>(null);
if (inputRef?.current)
  inputRef.current.value = "you dare?!";
```

the `T` is the type of element that will use the ref or the data it will deal with

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

## useMemo\<T>(factory, [dependencies]):

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

---

## useReducer(reducer, initialState):

the `useReducer` is a state hook that works similar to `useState` but it's used to handle complex state logic and sate that depends on a context for example.


```typescript

const initialState = { //the initial state
  count: 0,
  text: "",
}

const enum REDUCER_ENUM{ //an enum to help with autocompletion
  INCREMENT,
  DECREMENT,
  NEW_INPUT
}

type ReducerActionType = { //the type used for the action param
  type: REDUCER_ENUM,
  payload?: string,
}

//the reducer function, must return data of the same type as the state.
const reducer = (state: typeof initialState, action: ReducerActionType): typeof initialState => {
  switch (action.type) {
    default:
      throw new Error("unknown type");
    case REDUCER_ENUM.INCREMENT:
      return { ...state, count: state.count + 1 }
    case REDUCER_ENUM.DECREMENT:
      return { ...state, count: state.count - 1 }
    case REDUCER_ENUM.NEW_INPUT:
      return {...state, text: action.payload?? '' } //<??> means if it's null return ''
  }
}

```

then in your component use it:

```typescript
function Counter() {
//state: the current state object
//dispatch: the function that triggers the reducer and takes the action as a param
  const [state, dispatch] = useReducer(reducer, initialState);

  const increment = () => dispatch({ type: REDUCER_ENUM.INCREMENT })
  const decrement = () => dispatch({ type: REDUCER_ENUM.DECREMENT })
  const handleInput = (e:ChangeEvent<HTMLInputElement>) => dispatch({type: REDUCER_ENUM.NEW_INPUT, payload: e.target.value})

  return (
    <div>
      { state.count }
      <button onClick={increment}> + </button>
      <button onClick={ decrement }> - </button>
      <br />
      { state.text }
      <input type="text" onChange={handleInput} />
    </div>
  )
}

export default Counter
```

---

## useContext(Context):

the `useContext` is a hook that allows passing data as an alternative to props drilling,

to create a context first create a new context using `createContext` then use the `context.provider` and then can we use the `useContext`.

first lets create the context:

```typescript
import { createContext, FC, ReactNode, useState } from "react";

type MyContext = {
  value: string,
  setValue: (newVal: string) => void;
}
//createContext<T>(initialVal)
export const myContext = createContext<MyContext | undefined>(undefined);

```

then lets create the `Provider`:

```typescript
type MyContextProviderProp = {
  children: ReactNode,
}

export const MyContextProvider: FC<MyContextProviderProp> = ({ children }) => {
  const [value, setValue] = useState<string>("");
  const contextValue: MyContext = { value, setValue };
  return <myContext.Provider value={ contextValue }>
    {children}
  </myContext.Provider>;
}
```

then we can use this `MyContextProvider` as a parent to any component that may use the context, and in any children component we can use the `context`.

```typescript
'use client'
import React, { useContext } from 'react'
import {myContext} from '../Context/MyContext';

function MyComponent() {
  const { value, setValue } = useContext(myContext)!;
  return (
    <div>
      <h1>{ value }</h1>
      <input type='text' value={value} onChange={e => setValue(e.target.value)}/>
    </div>
  )
}


export default MyComponent;
```

