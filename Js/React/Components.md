# Components:

---

> [!IMPORTANT]
> any jsx has to have at least one parent

Components are the basis of react, they return what is called ``jsx`` which is basically html in javascript
``jsx`` elements can take the same attributes as the html files but some are changed:


- class => className
- for => htmlFor

**jsx**:


```javascript
return <section> 
    <h1>Good morning</h1>
    <p>lorem</p>
</section>
```

---

### to create a functional component:

while in the ``App.js`` file for example create a new function with the first letter in uppercase like:

```javascript
export default function someComponent()
{
    return <h1>Good morning</h1>
}
```


### to create a class component:

while in the ``App.js`` file for example create a new function with the first letter in uppercase like:
> [!NOTE]
> You must import the Component class for this to work


```javascript
import {Component} from 'react';

export class SomeClassComponent extends Component
{
    render()
    {
        return <h1>hi there</h1>
    }
}
```


---

to call components in other components you have to import it, and then in the final jsx use the component like:

```html
<componentName />
```

for example:

i created a component in the file named ``Main.jsx``


```javascript
export function Main()
{
    return(
        <div>
            <ul>
                <li>1</li>
                <li>2</li>
                <li>3</li>
            </ul>
        </div>
    )
}
```


and then i imported this component in ``index.js`` and added it in the returns of the ``root.render()`` method return,
not that i had to put a parent so i can combine both components in on render

```html
<div>
    <Main />
</div>
```


if you don't want to create the container each time there is a solution name **fragments**

fragments examples:

```html
<>
    <p>good morning</p>
</>
```


the `<>` & `</>` are fragments that you can think of as an imaginary container that won't be rendered in the html result
