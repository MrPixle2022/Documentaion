<!-- @format -->

# Props:

Props are the data passed to a component by a higher one -like it's parent-, it's jsx's equivalent to attributes in html, they can be made via the parameters of the component, then you either destructure them or use an object that holds them which is usually called `prop`, though the earlier method is preferred

```javascript
function User(props) {
	const { name, age, isMarried, hobbies } = props;
}
```

or

```javascript
function User({ name, age, isMarried, hobbies }) {}
```

here is an example

```javascript
function User({ name, age, hobbies }) {
	return (
		<div>
			<h1>{name || "User"}'s data</h1>
			<section>
				<h2>age</h2>
				<p>{age || NaN}</p>
			</section>
			<section>
				<h2>hobbies</h2>
				<ul>
					{Array.isArray(hobbies) &&
						hobbies.map((h, i) => <li key={i}>{h}</li>)}
				</ul>
			</section>
		</div>
	);
}
```

now to using these props:

```javascript
<User
	name="amr yasser"
	age={17}
	hobbies={["programming", "minecraft"]}
/>
```

---

## Children props:

a prop can be any sort of data - a number, string, array, object or even another component, sometimes a component is passed as a prop to be displayed conditionally or as child of another component, usually named **_children_** but this is no rule.

```javascript
export function User({ name, age, content }) {
	return (
		<>
			<h1>{name}</h1>
			<h3>{age}</h3>
			{content}
		</>
	);
}
```

```javascript
export function App() {
	return (
		<div>
			<User
				name="amr"
				age={10}>
				<p>children prop</p>
			</User>
		</div>
	);
}
```

as shown that `content` prop was assigned the value in-between the components tags, notice that here it required a closing tag for the `User` component though it's possible to still pass the children while it's a self-closing tag by calling the param it self like `content={<p>child</p>}`
