# Hooks:

---

hooks allow your component to hook into a state so, like rerendring them when there state change 

to use hook you first should import them:

```javascript
import {hookname} from 'react';
```

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