<!-- @format -->

# Components:

components are reusable ui that represents the method of building ui in react, they used to be classes and functional components but now functions are the go to.

components return `jsx` which is a mixture of both js & html with some slight modifications that respects the js keywords, for example certain attributes have been changed in jsx. like:

`class -> className` to avoid collision with the `class` keyword & `for -> htmlFor` to avoid collision with the `for loop`.

the jsx return by a function must have a **singular parent** meaning all content of a component is a child of a singular element that holds all as children

```javascript
function App() {
	return (
		<div>
			<h1>hello</h1>
		</div>
	);
}

export default App;
```

and then be used as html tags.

though the **single parent rule** there is a way to avoid it if needed by using what is called a `react fragments`, since by just containing the content of a component by `<> </>` you create an imaginary parent that will be in the `jsx` code but won't be in the final html.

```javascript
import App from "./App.jsx";

function SecondComponent() {
	return (
		<>
			<div>
				<App />
			</div>
		</>
	);
}
```

here we set the `<App/>` to be a self-closing tag, though we can use the traditional way of `<App></App>` but that's optional unless the component requires having children.
