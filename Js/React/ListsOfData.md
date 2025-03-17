<!-- @format -->

# Rendering a list of data:

for an array to be rendered it requires a js expression to destructure it's values via a loop but not a for loop, rather by the use of the `map` function to handle the values of the array and have more control over the final ui.

> [!IMPORTANT] every single element used in the returned ui must assign a **unique** value to a prop named `key` to make it easier for react to handle state changes for that array.

```javascript
function Lists() {
	const users = [
		{ id: 1, name: "Alice", age: 25 },
		{ id: 2, name: "Bob", age: 30 },
		{ id: 3, name: "Charlie", age: 22 },
	];

	return (
		<div>
			<h1> Users </h1>
			<ul>
				{users.map((user, i) => (
					<li key={i}>
						{user.name}, {user.age} yrs
					</li>
				))}
			</ul>
	);
}

export default Lists;
```

so this code will output an unordered list with 3 list items, each with a unique key -the index in this case- and this will dynamically generate more or less depending on the size of the array.

> [!TIP] it's recommended to check for values in the array before mapping, consider using `Array.isArray(arr) && arr.map()` to avoid run-time errors.
