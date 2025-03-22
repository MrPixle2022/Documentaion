<!-- @format -->

# Hooks:

---

navigation:

- [useState](#usestateinitialvalue)
- [useEffect](#useeffecteffect-dependenciesarray)
- [useContext](#usecontextcontext)
- [useReducer](#usereducerreducerfunction-initialstate)
- [useRef](#userefinitialvalue)
- [useCallback](#usecallbackcallback-dependenciesarray)
- [useMemo](#usememofactory-dependenciesarray)

---

hooks allow your component to hook into a state(data within your component that may change) which means linking them to a state and when that state changes it triggers them which will change your component in a way or another, like rerendering them when there state change

to use hook you first should import them:

```javascript
import { hookName } from "react";
```

---

### useState(initialValue?):

the `useState` is a hook that allows you to create a state in your component and have control over the components on that state's change, on state change the component will rerender meaning that any variable defined with `var, let, const` will be reassigned to it's default value, but the state variables itself won't.

the `useState` takes an optional parameter being the **initial state value** and returns an array of two elements, the state variable and the method to update the state.

usually the naming of these two follows a rule of `stateName, setStateName`.

example:

```javascript
import { useState } from "react";

function Counter() {
	[count, setCount] = useState(0);

	return (
		<>
			<h1>{count}</h1>
			<button onclick={() => setCount(count + 1)}>+</button>
			<button onclick={() => setCount(count - 1)}>-</button>
		</>
	);
}
```

this example shows a simple counter which uses a state to keep track of the `count` variable, on each click on either buttons it will invoke the state change and rerender this component.

note that the setter function can also take a function as an argument, that function takes the previous state value as a parameter as shown in this snippet.

```javascript
<button onClick={() => setCounter((prev) => prev + 2)}>add 2</button>
```

> [!TIP] Note it's better to use the spread operator when updating either an array or an object unless you are using a method that automatically returns that updated object or array like this example.

```javascript
<button onClick={() => setArr(arr.slice(0, arr.length - 1))}>
	pop an element
</button>
```

> [!IMPORTANT] make sure to include the `() => ` otherwise any function -including the setCount- will be invoked always preventing the render of the component due to rendering exceeding the max render limit

a last thing about the `useState` hook is that a **function** can be passed as a parameter, the on component mount and the return value will be the initial value

```javascript
// count will be 100 by default
const [count, setCount] = useState(() => {
	return 100;
});
```

---

### useEffect(sideEffect, dependenciesArray):

the `useEffect` is a hook that allows you to perform side effects in your component, a side effect is essentially a process that is performed when the component mounts, updates or unmounts. like data-fetching, subscribing to events, manually changing the DOM, and timers or accessing browser APIs.

for the `useEffect` you provide the sideEffect -A function` and an optional array of all the states that you want to watch for changes.

based on the dependencies array the sideEffect will behave differently.

not providing the array will make the hook run the side effect on every rerender, whilst providing an empty array will trigger that effect on mount only, if an array is given along with the values to monitor then the effect will be executed on their change -even if a single one changes-

```javascript
/** @format */
import { useState, useEffect } from "react";

function App() {
	const [value, setValue] = useState(0);
	//dependency array:
	// none -> runs every rerender
	// [] -> on mount only
	// [value] or [value1, value2, ...] -> runs when that specific value -or list of values- changes
	useEffect(() => {
		console.log("effect called");
		document.title = `${value} clicks`; //changes the title every time the state `value` changes.
	}, [value]);

	return (
		<div>
			<button onClick={() => setValue(value + 1)}>click</button>
		</div>
	);
}

export default App;
```

the `effect` is not special in it's self as it's just basically a function though it can also return a function which is called the **cleanup function** which is called when the component **unmounts** meaning it's no longer being rendered.

```javascript
/** @format */
import { useState, useEffect } from "react";
import DataFetch from "./Components/Hooks/DataFetch";

function ToggledComponent() {
	//this effect log that msg to the console every time it unmounts.
	useEffect(() => {
		return () => console.log("well, ... goodbye");
	});
	return <h1>Here is a toggled component</h1>;
}

function App() {
	const [toggle, setToggle] = useState(true);

	return (
		<div>
			<button onClick={() => setToggle(!toggle)}>Toggle todos</button>
			{toggle && <ToggledComponent />}
		</div>
	);
}

export default App;
```

a major use case for the `useEffect` hook is to perform data-fetching from an api, though the side effect **can't be async** that doesn't mean it's impossible to use async functions though.

```javascript
/** @format */

import { useEffect, useState } from "react";

function FetchDataEffect() {
	const [posts, setPosts] = useState([]);

	useEffect(() => {
		async function getPosts() {
			const apiResponse = await fetch(
				"https://jsonplaceholder.typicode.com/posts",
			);
			const apiData = await apiResponse.json();
			if (apiData && apiData.length) setPosts(apiData);
		}

		getPosts();
	}, []);

	return (
		<div>
			<h1>FetchDataEffect</h1>
			<ul>
				<li>{posts.length} posts found</li>
				{posts &&
					posts.length &&
					posts.map((post, i) => <li key={i}>{post.title}</li>)}
			</ul>
		</div>
	);
}
```

---

### useContext(context)

the `useContext` hook allows you to share states globally between nested components.

to use this hook you have to had imported the `createContext` by using

```javascript
import { createContext } from "react";
```

then create a new object of the `createContext`

```javascript
export const Data = createContext();
```

lastly use `Data.Provider` component and pass `value={ valueYouWantToPass }`in-between the `Data.Provider` component tags add any component you want to share the state between.

like:

```javascript
<Data.Provider value={"amr yasser"}>
	<App />
</Data.Provider>
```

then in the component file in this example `App.js` import the `useContext` hook and the `createContext` obj via:

```javascript
import { useContext } from "react";
import { Data } from "./index.js";
```

in the component pass the `CreateContext` obj as a parameter to the `useContext` hook

```javascript
export default function App() {
	const info = useContext(Data);

	return <h1>{info}</h1>;
}
```

---

### useReducer(reducerFunction, initialState):

the `useReducer` hook is similar to `useState` but it's used to handle complex state like showing some output based on current state.

it returns an array of two `state`, `dispatch` the later is used to set action types to modify the state

an example of `useReducer` will be like:

```javascript
import { useReducer } from "react";

function Reducer(state, action) {
	switch (action.type) {
		case "increment":
			return { ...state, count: state.count + 1 };

		case "decrement":
			return state.count >= 0
				? { ...state, count: 0 }
				: { ...state, count: state.count - 1 };

		case "reset":
			return { ...state, count: 0 };

		default:
			return Error("action unknown?");
	}
}
```

here i setting up the reducer function for the hook which will take two objects as arguments: `state`: the object with the data you want to change. `action`: an object that holds string data about how to change the state.

note that each time i return the state again by spreading it's value in an object and then i modify the value of `count`

```javascript
export function App() {
	const [state, dispatch] = useReducer(Reducer, { count: 0 });

	return (
		<section>
			<h1>{state.count}</h1>
			<button onClick={() => dispatch({ type: "increment" })}>+</button>
			<button onClick={() => dispatch({ type: "reset" })}>reset</button>
			<button onClick={() => dispatch({ type: "decrement" })}>-</button>
		</section>
	);
}
```

and here iam using the hook to create a state object and a dispatch function by destructuring the array.

each time i use the `dispatch` i pass it an object with key `type` and a string value. if the value isn't defined in the switch case in the reducer function it will throw an error because of:

```javascript
default:
    return Error('action unknown?');
```

---

### useRef(initialValue):

the `useRef` is a hook used to reference jsx data that won't trigger a rerender

for example:

```javascript
import { useRef } from "react";

export function App() {
	const target = useRef();
	return <p ref={target}>some text being referenced</p>;
}
```

the hook allows you to access the target via a current object in the var you created to do something based on an event like:

```javascript
<button onClick= {() => target.current.scrollIntoView({
    behavior: 'smooth', //scroll transition: smooth, instant, auto
    block: 'end', //vertical alignment: start,center, end
    inline: 'nearest' //horizontal alignment: start,center,end,nearest
});}>Scroll to the para</button>
```

here when we click that button the page will scroll to the element with the `ref = {target}`

there are a lot of things you do with the `.current` object like:

another usage of this hook is to **store changeable data between rerenders** by passing an initial value which will be the value of `current`

---

### useCallback(callback, dependenciesArray):

the `useCallback` allows you to cache the result of an expensive function, it takes the `function` as an argument & the `dependenciesArray` to know when to update the cached results.

```javascript
import { useCallback } from "react";

function Shit() {
	const expensiveFunc = useCallback((val1, val2) => {
		return val1 * val2;
	}, []);
	return (
		<>
			<button>{expensiveFunc}</button>
		</>
	);
}

export default Shit;
```

---

### useMemo(factory, dependenciesArray):

the `useMemo` is another performance hook that is similar to `useCallback` but the difference is that it memoizes values of an expensive operation and returns the memoized value

```typescript
function fib(n) {
	if (n < 2) return n;
	return fib(n - 1) + fib(n - 2);
}

const myNum = 73;
//useMemo memoizes a value similar to useCallback
// useMemo(factory, [dependencies])
const result = useMemo(() => fib(72), [myNum]);
```
