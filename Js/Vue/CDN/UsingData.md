<!-- @format -->

# Using the data method:

as the app instance is created, it's time to learn how to add data that can be used in the html, we do this in the options of the `createApp` method, specifically the `data` method.

```html
<script>
	Vue.createApp({
		// state counterpart in react
		data() {
			// the pageTitle will be accessible for element that are child of the element with id of app
			return {
				pageTitle: "My App",
			};
		},
	}).mount("#app");
</script>
```

then this data can be accessed in the html using the `{{ }}` syntax.

```html
<div id="app">
	<h1>{{ pageTitle }}</h1>
</div>
```

---
