# Slices:

slices allow you to to turn the store data into smaller pieces and allows you to assign the **reducer**(the instructions for each state, similar to the [useReducer](../React/Hooks.md#usereducerreducerfunction-initialstate)) in react, it's used to organize the redux store.


## creating slices:

to create a slice import `createSlice` from `redux` after creating a new slice by using syntax similar to creating a store, you will have to assign it a `name` for it's , `reducer` an object which holds all instructions as keys and values

for example i created a slice `src/app/feature/counter/CounterSlice.js`:
```javascript
import { createSlice} from "@reduxjs/toolkit";

const slice = createSlice({
    name: "counter",
    initialState: {value: Number(0)},
    reducers:{
        increment: state => {state.value += 1},
        decrement: state => {state.value -= 1},
    }
})

export const {increment, decrement} = slice.actions;
export default slice.reducer;
```

here both `increment` and `decrement` are `Actions`, the change in the `state` will trigger a rerender by default so no need for hooks

after doing that you need to import it and add it to the `store` reducer obj.

```javascript
import { configureStore } from "@reduxjs/toolkit";
import  counterReducer from "./features/storeSlice"

export const counterStore = configureStore({
    reducer: {
        counter: counterReducer,
    }
});
```
