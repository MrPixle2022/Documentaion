# Hooks:

---

navigation:

- [useState](#usestateinitialvalue)
- [useEffect](#useeffecteffect-dependenciesarray)
- [useContext](#usecontextcontext)
- [useReducer](#usereducerreducerfunction-initialstate)
- [useRef](#userefinitialvalue)
- [useCallback](#usecallbackcallback-dependenciesarray)

---

hooks allow your component to hook into a state(data within your component that may change) which means linking them to a state and when that state changes it triggers them which will change your component in a way or another, like rerendering them when there state change

to use hook you first should import them:

```javascript
import { hookName } from "react";
```

---

### useState(initialValue):

the use state hook returns an `array` of two elements the data and a function to update it

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

in this example we imported the `useState` hook and used to to create

`count` : the var that will change and with it the component  
`setCount` : the function that will update the var's value

---

### useEffect(effect, dependenciesArray):

the `useEffect` hook allows you to run code when the component is [rerendered, mounted, unmounted] from the dom, the `effect` is a function that will be called each time the hook is invoked.

the `dependenciesArray` [**optional**] are the states [values that might change] that will invoke the hook when they change an empty array means that the hook will run once

for example:

```javascript
import { useState, useEffect } from "react";

export default function App() {
  const [value, setValue] = useState(0);

  useEffect(() => console.log(value), [value]);

  return (
    <>
      <h1>{value}</h1>
      <button onClick={() => setValue(value + 1)}> click me </button>
    </>
  );
}
```

the `useEffect` here will log the value of `value` each time the value [**state**] changes

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
