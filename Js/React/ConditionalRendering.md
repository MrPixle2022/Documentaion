<!-- @format -->

# Conditional Rendering

you can conditionally render the ui in react in multiple ways.

you can use props to determine the condition

```javascript
let Invalid = () => <h1>Invalid</h1>;
let Valid = () => <h1>Valid</h1>;

function Password({isValid})
{
    return isValid ? <Valid />:<Invalid />;
}



export function App(){
    return <Password isValid={true}>;
}
```

so in this snippet an isValid prop is used to conditionally determine the ui output of the component.

note you aren't limited to one condition nor this method alone you can use ternary operator, && or || operators to conditionally render the ui as well.
