# Forms:

---

forms in react work a little diffrent from html forms as they require ``hooks`` to work and function for example:


```javascript

import { useState} from "react";

export default function FormComponent
{
    const [userName, setUserName] = useState('');
    return(
    <form onSubmit={e => {e.preventDefault(); console.log(userName)}}>
        <input type='text' value = {userName} onChange= {e => setUserName(e.target.value)}/>
        <input type='submit'/>
    </form>)
}

```


the ``onSubmit`` is an event that fires when the form is submitted

``preventDefault`` method on the ``e`` (the event object) prevenets the default behaviour of the onSubmit event (the page refresh)

``onChange`` event that fires on the input when it's value (input given) changes
