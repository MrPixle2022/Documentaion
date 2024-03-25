# Using Slices:

to use slices and their actions import the `useDispatch, useSelector` hooks, then import the actions you exported from the slice file.

here i imported the hooks the `useSelector` hook allows you take the store passed by the `Provider` component and then i accessed the value of it's `counter` property (the value of the `name`).

on the other hand `useDispatch` allows you trigger the rerender when calling any action here it will trigger the store when we call `increment` or `decrement`

```javascript
import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { increment, decrement } from '../App/features/storeSlice'


function Counter() {
  const count = useSelector(state => state.counter.value);
  const dispatch = useDispatch();
  return (
    <>
      <h1>{count}</h1>
      <button onClick={() => dispatch(increment())}>+</button>
      <button onClick={() => dispatch(decrement())}>-</button>
    </>
    )
}

export default Counter
```
