# Conditional Rendering
---

conditional rendering is proccess in which you show specific output to the page based on some condition like:

```javascript
let Invalid = () => <h1>Invalid</h1>;
let Valid = () => <h1>Valid</h1>;

function Password({isValid})
{
    return isValid ? <Valid />:<Invalid />;
}



export function App()
{
    return <Password isValid={true}>;
}
```


here i am creating two components ``Valid`` and ``Invalid`` to be rendered based on a certain condition

then i created a new component ``Password`` that can take the ``isValid`` prop, and if it's true display the ``Valid`` component else display``Invalid``

and then in the ``App`` we are rendering this ``Password`` with the ``isValid`` set to ``true``

---
