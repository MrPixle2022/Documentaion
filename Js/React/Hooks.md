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

### useEffect(effect):

the `useEffect` hook allows you to run code when the component is rerendered, the `effect` is a function that you can excute 


for example:

```javascript
import { useState, useEffect } from "react"


export default function App()
{

  const [value, setValue] = useState(0);

  useEffect(() => console.log(value))

  return(<>
      <h1>{value}</h1>
      <button  onClick={() => setValue(value + 1)}> click me </button>
  </>)
}
```

the `useEffect` here will log the value of `value` each time the component changes.