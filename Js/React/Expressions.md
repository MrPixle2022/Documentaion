<!-- @format -->

# Expressions:

while writing jsx react will handle **most** of what you right as literal string, so for example.

```html
<h1>2+2</h1>
```

will show `2 + 2` instead of `4` though you can easily overcome this via expressions, since by just wrapping the expression with `{}` react will handle it as an expression -js code- allowing you to assign values of vars, functions, etc instead of the literal string.

```javascript
function App() {
	const my_user_name = "amr yasser";
	const add_num = (a, b) => a + b;

	return (
		<div>
			<h1>my_user_name</h1>
			<h1>{my_user_name}</h1>
			<hr></hr>
			<p>2 + 2</p>
			<p>{add_num(1, 2)}</p>
		</div>
	);
}

export default App;
```
