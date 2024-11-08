<!-- @format -->

# Special Values

## inherit

`inherit` is a special value that means that the value will be inherited from the parent element. it can be used on all the css properties.

```html
<div>
	<h1>Hello World</h1>
</div>
```

```css
div {
	width: 600px;
	height: 200px;
	background-color: gray;
	border: 1px black solid;
	border-radius: 20px;
}

h1 {
	border: inherit;
	border-radius: inherit;
	background-color: red;
}
```

---
