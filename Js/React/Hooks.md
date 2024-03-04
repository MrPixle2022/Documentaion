# Hooks:

---

hooks allow your component to hook into a state so, like rerendring them when there state change 

to use hook you first should import them:

```javascript
import {hookname} from 'react';
```

---

### useState(initialValue):

the use state hook retuns an `array` of two elements the data and a function to update it

example:

```javascript
import {useState} from 'react';

function Counter()
{
    [count, setCount] = useState(0);

    return(
        <>
            <h1>{count}</h1>
            <button onclick = {() => setCount(count + 1)}>+</button>
            <button onclick = {() => setCount(count - 1)}>-</button>
        </>
    )
}
```

in this example we imported the `useState` hook and used to to create

`count` :  the var that will change and with it the component  
`setCount` :  the function that will update the var's value

---

### useEffect(effect, dependenciesArray):

the `useEffect` hook allows you to run code when the component is [rerendered, mounted, unmounted] from the dom, the `effect` is a function that will be called each time the hook in invoked.

the `dependenciesArray` [**optional**] are the states [values that 
might change] that will invoke the hook when they change
an empty array means that the hook will run once


for example:

```javascript
import { useState, useEffect } from "react"


export default function App()
{

  const [value, setValue] = useState(0);

  useEffect(() => console.log(value), [value])

  return(<>
      <h1>{value}</h1>
      <button  onClick={() => setValue(value + 1)}> click me </button>
  </>)
}
```

the `useEffect` here will log the value of `value` each time the value [**state**] changes

---

### useContext()

the `useContext` hook allows you to share states globally between nested components.

to use this hook you have to had imported the `createContext` by using

```javascript
import {createContext} from 'react';
```

then create a new object of the `createContext`

```javascript 
const Data = createContext();
```

lastly use `Data.Provider` component and pass `value={ valueYouWantToPass }
in-between the `Data.Provider` component tags add any component you want to share the state between.

like:

```javascript
<Data.Provider value ={"amr yasser"}>
    <App />
</Data.Provider>
```

then in the component file in this example `App.js` import the `useContext` hook and the `createContext` obj via:

```javascript
import {useContext} from 'react';
import {Data} from './index.js';
```
in the component pass the `CreateContext` obj as a parameter to the `useContext` hook 

```javascript
export default function App()
{
   const info = useContext(Data);

   return <h1>{info}</h1>
}
```
