<!-- @format -->

# Hooks:

navigation:

- [useState](#usestatetinitialvaluet)
- [useEffect](#useeffecteffect-dependencies)
- [useRef](#userefinitialvalue)
- [useCallback](#usecallbackcallback-dependencies)
- [useMemo](#usememofactory-dependencies)
- [useReducer](#usereducerreducer-initialstate)
- [useContext](#usecontextcontext)
- [use](#use)
- [useFormStatus](#useformstatus)
- [useActionState](#useactionstatefunction-initialstate)

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

the `useEffect` allows you to run code when the component first mounts, unmounts or when a value changes. it takes a function known as `effect` and an array of the values that will recall the effect when they change.

```typescript
useEffect(() => {
	console.log(`hello`);
	return () => console.log(`bye`); //clean up function executed when unmounting the component
	//beware that when using strict mode a component will be mounted ,unmounted & remounted again hence the effect runs multiple times on load.
}, []);
```

for an api fetch example:

```javascript
/** @format */

import React, { useEffect, useState } from "react";

//the type to be casted
interface User {
	id: number;
	name: string;
	username: string;
	email: string;
	phone: string;
}

function App() {
	const [usersList, setUsersList] = useState<User[]>([]);

	const url = "https://jsonplaceholder.typicode.com/users";

	useEffect(() => {
		async function fetchUsers() {
			const api_response = await fetch(url);
			const api_data =
				api_response && api_response.ok
					? ((await api_response.json()) as User[])
					: [];
			setUsersList(api_data);
		}
    //calling and letting the promise resolve itself
		fetchUsers();
	}, []);

	return <div>{usersList.length}</div>;
}

export default App;
```

---

## useRef\<T>(initialValue):

the `useRef` is a hook responsible for storing values that won't change between rerenders but not so important that their change will rerender the component. it can be linked to an html element via the `ref` attribute or use other value, the returned object stores the value in a property called current.

```typescript
const inputRef = useRef<HTMLInputElement>(null);
if (inputRef?.current) inputRef.current.value = "you dare?!";
```

the `T` is the type of element that will use the ref or the data it will deal with

---

## useCallback(callback, [dependencies]):

the `useCallback` is a performance hook that memoizes a function caching it, it takes a callback and a dependencies array and returns a memoized version of the callback function.

```typescript
const [count, setCount] = useState<number>(0);
// callback can take the event value, e: MouseEvent<Element> |KeyboardEvent<Element> | ....
const addTwo = useCallback((): void => setCount((prev) => prev + 1), []);
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
function fib(n: number): number {
	if (n < 2) return n;
	return fib(n - 1) + fib(n - 2);
}

const myNum: number = 73;
//useMemo memoizes a value similar to useCallback
// useMemo<T>(factory, [dependencies])
const result = useMemo<number>(() => fib(72), [myNum]);
```

---

## useReducer(reducer, initialState):

the `useReducer` is a state hook that works similar to `useState` but it's used to handle complex state logic and sate that depends on a context for example.

```typescript
const initialState = {
	//the initial state
	count: 0,
	text: "",
};

const enum REDUCER_ENUM { //an enum to help with autocompletion
	INCREMENT,
	DECREMENT,
	NEW_INPUT,
}

type ReducerActionType = {
	//the type used for the action param
	type: REDUCER_ENUM;
	payload?: string;
};

//the reducer function, must return data of the same type as the state.
const reducer = (
	state: typeof initialState,
	action: ReducerActionType,
): typeof initialState => {
	switch (action.type) {
		default:
			throw new Error("unknown type");
		case REDUCER_ENUM.INCREMENT:
			return { ...state, count: state.count + 1 };
		case REDUCER_ENUM.DECREMENT:
			return { ...state, count: state.count - 1 };
		case REDUCER_ENUM.NEW_INPUT:
			return { ...state, text: action.payload ?? "" }; //<??> means if it's null return ''
	}
};
```

then in your component use it:

```typescript
function Counter() {
	//state: the current state object
	//dispatch: the function that triggers the reducer and takes the action as a param
	const [state, dispatch] = useReducer(reducer, initialState);

	const increment = () => dispatch({ type: REDUCER_ENUM.INCREMENT });
	const decrement = () => dispatch({ type: REDUCER_ENUM.DECREMENT });
	const handleInput = (e: ChangeEvent<HTMLInputElement>) =>
		dispatch({ type: REDUCER_ENUM.NEW_INPUT, payload: e.target.value });

	return (
		<div>
			{state.count}
			<button onClick={increment}> + </button>
			<button onClick={decrement}> - </button>
			<br />
			{state.text}
			<input
				type="text"
				onChange={handleInput}
			/>
		</div>
	);
}

export default Counter;
```

---

## useContext(Context):

the `useContext` is a hook that allows passing data as an alternative to props drilling,

to create a context first create a new context using `createContext` then use the `context.provider` and then can we use the `useContext`.

first lets create the context:

```typescript
import { createContext, FC, ReactNode, useState } from "react";

type MyContext = {
	value: string;
	setValue: (newVal: string) => void;
};
//createContext<T>(initialVal)
export const myContext = createContext<MyContext | undefined>(undefined);
```

then lets create the `Provider`:

```typescript
type MyContextProviderProp = {
	children: ReactNode;
};

export const MyContextProvider: FC<MyContextProviderProp> = ({ children }) => {
	const [value, setValue] = useState<string>("");
	const contextValue: MyContext = { value, setValue };
	return (
		<myContext.Provider value={contextValue}>{children}</myContext.Provider>
	);
};
```

then we can use this `MyContextProvider` as a parent to any component that may use the context, and in any children component we can use the `context`.

```typescript
"use client";
import React, { useContext } from "react";
import { myContext } from "../Context/MyContext";

function MyComponent() {
	const { value, setValue } = useContext(myContext)!;
	return (
		<div>
			<h1>{value}</h1>
			<input
				type="text"
				value={value}
				onChange={(e) => setValue(e.target.value)}
			/>
		</div>
	);
}

export default MyComponent;
```

---

## use():

the `use` hook is a new hook added in react 19 that allows accessing resources -api calls and context- meaning it replaces the `useEffect` hook along with `useContext`.

### fetching data with it:

be careful as the `use` component must be contained within a `suspense`.

> [!IMPORTANT] the hook takes a promise as a parm, make sure that the promise isn't created in render, since it won't render at all a good tip is to use either a framework that caches promises like next js or to simply use a function that returns a promise from outside a component.

```typescript
export async function fetchData() {
	return (await fetch("https://jsonplaceholder.typicode.com/todos/1")).json();
}
```

then use a server component to pass the promise to the component:

```typescript
/** @format */
"use server";
import React from "react";
import DataComponent from "./DataComponent";
import { fetchData } from "./FetchUsingUse";

function App() {
	return (
		<React.Suspense fallback={<h1>loading data...</h1>}>
			<DataComponent data={fetchData()} />
		</React.Suspense>
	);
}
```

then lastly in the component use the `use` hook:

```typescript
/** @format */
"use client";
import { use } from "react";

function DataComponent({ data }: { data: Promise<any> }) {
	const todo = use(data); //this will be resolved and loaded
	return (
		<div>
			{todo?.title} {todo?.id} {todo?.userId} {String(todo?.completed)}
		</div>
	);
}
```

### consuming a context:

there is no big difference in the way nor is their in the benefits, just remove `useContext` and use `use`.

```typescript
export function useTheme() {
	// that's it
	const context = React.use(ThemeContext);
	if (!context) return {};
	return context;
}
```

---

## useFormStatus():

the `useFormStatus` -imported from `react-dom` instead of `react`- is a react-19-hook that helps you monitor the state of a form. it returns an object with properties of:

1. `pending`: wether the form action is submitted or still in that process
1. `action`: the action method of the form
1. `method`: get or post
1. `data`: the form data.

> [!IMPORTANT] the `useFormStatus` only works with parent forms, so it won't consider a same-component-form

note that these properties are only available when the form is submitted meaning only for a short time can you access them before they are null -except pending which becomes false-.

for the use of this hook two components -@ least- are needed, the form and the button in this example

the form:

```typescript
"use client";
import FormBtn from "./ActionState";
import { useFormStatus } from "react-dom";
import FormStatusBtn from "./FormStatusBtn";

async function formHandler(formData: FormData) {
	//artificial delay.
	await new Promise((resolve) => setTimeout(resolve, 1000));
}

function Form() {
	return (
		<form
			method="get"
			action={formHandler}
			className="flex flex-col w-full items-center justify-center m-auto outline-2 gap-3">
			<div className="">
				<label htmlFor="name">name</label>
				<input
					type="text"
					id="name"
					name="name"
				/>
			</div>
			<div className="">
				<label htmlFor="password">password</label>
				<input
					type="password"
					id="password"
					name="password"
				/>
			</div>
			<div className="">
				<label htmlFor="email">email</label>
				<input
					type="email"
					id="email"
					name="email"
				/>
			</div>
			<FormStatusBtn />
		</form>
	);
}
```

the submit button:

```typescript
import { useFormStatus } from "react-dom";

function FormStatusBtn() {
	console.clear();
	const { pending, action, method, data } = useFormStatus();
	const formObj = Object.fromEntries(data || new FormData());
	console.log("🚀 ~ FormStatusBtn ~ action:", action);
	console.log("🚀 ~ FormStatusBtn ~ method:", method);
	console.log("form data");
	console.table(formObj);
	return (
		<button
			className="btn btn-primary hover:btn-active"
			type="submit">
			{pending ? "Submitting..." : "Submit"}
		</button>
	);
}
```

---

## useActionState(function, initialState):

the `useActionState` is yet another react-19-hook that allows you to control a state's value based on a form result.

it returns an array with elements of:

1. state: the current state's value
1. formAction: the form action to trigger the form and the action.
1. isPending: wether the form action is submitted or still in that process

the function is a function that accepts the previous state and the form data and returns the new state.

```typescript
import { useActionState } from "react";

async function increment(previousState, formData: FormData) {
	await new Promise((resolve) => setTimeout(resolve, 1000));

	const name = formData.get("name");
	console.log("🚀 ~ increment ~ name:", name);

	return name !== "pxl" ? previousState + 1 : previousState + 2;
}

export default function StatefulForm() {
	const [state, formAction, isPending] = useActionState(increment, 0);
	return (
		<form action={formAction}>
			{state}
			<input
				type="text"
				id="id"
				name="name"
				placeholder="placeholder"
				className="w-[300px] border border-slate-200 rounded-lg py-3 px-5 outline-none	bg-transparent"
			/>
			<button
				type="submit"
				disabled={isPending}
				className="btn btn-primary disabled:btn-ghost">
				Increment
			</button>
		</form>
	);
}
```
