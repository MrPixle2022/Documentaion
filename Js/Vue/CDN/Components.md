<!-- @format -->

# Components:

components are a way to reuse code, they help you write reusable easily maintainable code.

components require an app instance to be attached to, note that thy behave like a mini vue instance, and that they can't access the app instance's data directly.

```html
<script>
	let app = Vue.createApp({---});

	app.mount("body");
</script>
```

now we can create a component:

```html
<script>
	// creates a component named `page-content` that renders the given template.
	app.component("page-content", {
		// like the jsx return for react.
		template: "<div>Hello World</div>",
	});
</script>
```

now we can use the component:

```html
<page-content></page-content>
```

---

## Props:

props are a way to pass data from a parent to a child component.

first we need to define the props in the component:

```html
<script>
	app.component("page-content", {
		// define the props.
		props: ["title"],
		// use the props in the template
		template: "<div>{{ title }}</div>",
	});
</script>
```

now we can use the props in the component:

```html
<page-content title="Hello World"></page-content>
```

[!IMPORTANT] component name are in kebab-case while props are defined in camelCase but used in **kebab-case** in the html.

so if a prop is name `pageTitle` it will be `page-title` in the html.

[!TIP] you can use the `v-bind` directive on props.

components can have their own data, methods, computed properties, etc.
