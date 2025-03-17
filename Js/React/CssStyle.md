<!-- @format -->

# Styling your components:

## inline styles:

since most elements in react have the same attributes they would hav in html most elements have a `style` prop.

a `style` is an object -requires the use of {{}} since it's a js expression- where you put your style in a key-value pair, note that the rule with `-` in css have been changed to `camelCase` in react so `font-size` -> `fontSize`.

```javascript
function App() {
	return (
		<div style={{ color: "blue", fontSize: "32px", textAlign: "center" }}>
			txt
		</div>
	);
}
```

also you can create a variable to stores the style obj to use it instead on an inline-object.

---

## external css file:

you can create a css file and **import** it to your component using the `import` statement. this is what you will find in the `app.jsx` and `main.jsx` files since -by default- they have two css files that handle their css.

so just use something like:

```javascript
import "./index.css";
```
