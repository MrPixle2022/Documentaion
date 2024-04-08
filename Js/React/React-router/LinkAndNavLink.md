# Link and NavLink components:

navigation:

- [Link](#link)
- [NavLink](#navlink)
- [Navigate & useNavigate](#navigate)

---

## Link:

the `Link` component allows you to change the url of the page without reloading the entire file, instead it triggers the rerender of the specific part of the component that changes depending on the url, but that's by default and you can pass it some attributes to change this behavior.

link example:

```html
<nav>
  <ul>
    <li><Link to="/about">About</Link> </li>
  </ul>
</nav>
```

the attributes it could take:


|prop  |description  |syntax  |
|:---------|:---------:|:---------|
|to     |the path it takes you to|to={'/url'}|
|replace     |replace the previous page in the history with this link|replace|
|reloadDocument|forces the page to reload|reloadDocument|
|state     |allows you to pass data|state={data}|


---

## NavLink:

the `NavLink` works similar to the `Link` tag, but it gives you more control over the link.

the `NavLink` allows you to apply style, className and children, it takes all previous as a callback function that takes an object that has the property of `isActive`.

for example:

```javascript
<NavLink to="/" style={({isActive}) => isActive?{color:"red"}:{color:"blue"}} > home </NavLink>
<NavLink to="/" className={({isActive}) => isActive?"here":"there"} > home </NavLink>
<NavLink to="/" > {({isActive}) => isActive?"home":"you are home"}</NavLink>
<NavLink to="/" end > home </NavLink>
```


|prop  |description  |syntax  |
|---------|---------|---------|
|style    |applies a style if the link is active|style={({isActive} => ----{cssStyle})}|
|className|applies a class name if the link is active|className={({isActive}) => ---}|
|children|changes the text in the NavLink if it's active|{({isActive}) => ----}|
|end|sets the navLink's isActive to be true only when the url matches the to attr|end|


---

## Navigate:

the `Navigate` components works exactly like the `Link` component but instead of waiting for a click it automatically redirects to the specified `to`, could be used to automatically redirect the user to the home page if he entered a non-existing page.

```javascript
<Navigate />
```

although sometimes you would want to send data when redirecting so instead you could use the `useNavigate` hook like:

```javascript
import { useNavigate } from 'react-router-dom'

function NotFound() {
  const navigate = useNavigate();
  navigate("/", {state: {val:0}, replace:true})
}

export default NotFound
```

this code will redirect the user to the home page and send the state and replace the previous url in the browser history