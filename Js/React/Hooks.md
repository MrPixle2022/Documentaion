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

the `Context api` is a react api used to allow the share of states, function or objects between components without the need for prop drilling.

the context has 2 parts, the `Provider` and the `Consumer` which is used to access the context.

the `Provider` is used to wrap the components that need to access the context, and the `Consumer` is used to access the context though the `consumer` can be replaced by the `useContext` hook.

first create a context by using the `createContext` function:

```javascript
//the useState is imported because we will alow the context to be updated
import { useState, createContext } from "react";

export const UserContext = createContext();
```

then -optionally- create a context provider component to wrap the children but a wrapper must be present.

```javascript
function UserProvider({ children }) {
	const [username, setUsername] = useState("User");
	return (
		<UserContext.Provider value={{ username, setUsername }}>
			{children}
		</UserContext.Provider>
	);
}
```

note that the context must be exported.

as shown the provider -context.Provider- takes the value as a prop, though you can give an initial value in the `createContext` function as a parm.

now the context can be consumed by either `context.Consumer` or the better `useContext`.

```javascript
<UserProvider>
  <App />{/*the App can access the context*/}
</UserProvider>,
```

then in the app component:

```javascript
/** @format */

import { useContext } from "react";
import { UserContext } from "./----/UserContext";

function App() {
	//access that context and destructure it.
	const { username, setUsername } = useContext(UserContext);
	return (
		<div>
			<h1>{username}</h1>
			<input onChange={(e) => setUsername(e.target.value)} />
		</div>
	);
}
```

or the other way:

```javascript
/** @format */

import { UserContext } from "./exercs/exer_4/UserContext";

function App() {
	return (
		<UserContext.Consumer>
			{({ username, setUsername }) => (
				<>
					<h1>{username}</h1>
					<input onChange={(e) => setUsername(e.target.value)} />
				</>
			)}
		</UserContext.Consumer>
	);
}
```

as shown when using the `.Consumer` a function that takes the context data as a param is used to load the ui.

---

### useReducer(reducerFunction, initialState):

the `useReducer` is a state hook -like the useState- that is used to handle complex state logic that depends on a context for example.

the `useReducer` hook takes two params -unlike the useState- and returns two element -like the useState-, first it takes a **reducer** ,the function that handles the logic and an optional `initialState` which is the initial value of the state.

```javascript
function reducer(state, action) {
	switch (action.type) {
		case "logout": //the type comes from the dispatch call.
			return {}; //removes all data
		//if an unknown action is used.
		default:
			return state;
	}
}
```

the **reducer** takes two params, the `state` -current value- and the action -what is triggering the change-.

for the return values it returns an array of two a `state` & a `dispatch` function, the dispatch function is a function that triggers the update and provide the `action.type` which the reducer depends on for the logic.

```javascript
{
	/*on click, the dispatch function is triggered and sets the action to -> {type: "increment"} for the reducer*/
}
<button onClick={() => dispatch({ type: "increment" })}>Increment</button>;
```

lets see an example:

```javascript
/** @format */

import { useReducer } from "react";

function countReducer(state, action) {
	switch (action.type) {
		case "increment":
			return { ...state, count: state.count + 1 };
		case "decrement":
			if (state.count <= 0) return { ...state, count: 0 };
			return { ...state, count: state.count - 1 };
		case "reset":
			return { ...state, count: 0 };
		default:
			return state;
	}
}

function App() {
	// the state.count represents the value, the dispatch is the function that triggers the update and the action.type
	const [state, counterDispatch] = useReducer(countReducer, { count: -10 });
	return (
		<div>
			<h1>{state.count}</h1>
			<button onClick={() => counterDispatch({ type: "increment" })}>
				Increment
			</button>
			<button onClick={() => counterDispatch({ type: "decrement" })}>
				Decrement
			</button>
			<button onClick={() => counterDispatch({ type: "reset" })}>Reset</button>
		</div>
	);
}
```

> [!TIP] you can also provide more data to the reducer via the dispatch's action, for example: `{type: "increment", payload: 10}`

---

### useRef(initialValue):

the `useRef` is a hook that allows holding a reference to a jsx element or a value to store through rerenders which won't cause a rerender if changed.

the `useRef` hook takes an optional `initialValue` which is the stored in `reference.current`.

```javascript
const element = useRef(null);
```

then by using the `ref` prop of the jsx element you can access the `reference` object.

```javascript
<div ref={element}>
	Lorem, ipsum dolor sit amet consectetur adipisicing elit. Unde explicabo
	aperiam quae nulla necessitatibus, suscipit aliquam ipsa amet ducimus alias
	blanditiis temporibus harum non distinctio tempore omnis consectetur. Amet,
	dolor.
</div>
```

then by using the `current` property you can access the value of the `reference` object and do a lot of thing with it, like scrolling to that element using the `scrollIntoView` method.

```javascript
<button onClick= {() => target.current.scrollIntoView({
    behavior: 'smooth', //scroll transition: smooth, instant, auto
    block: 'end', //vertical alignment: start,center, end
    inline: 'nearest' //horizontal alignment: start,center,end,nearest
});}>Scroll to the para</button>
```

you can directly change the value of the `reference` object by using the `current` property like any normal variable and the change wont cause a rerender

---

### useId():

the `useId` is a hook that returns a random string to be used as a unique id.

```javascript
import { useId } from "react";

function App() {
	const uId = useId(); //id1
	return <div id={`${useId() /*id2*/}-div`}>{uId}</div>;
}
```

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
