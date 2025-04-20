<!-- @format -->

# Computed Properties:

computed properties are reactive data that are expected to change, vue's `createApp` has a `computed` property that can be used to define computed properties.

so if we want to create a dynamic class for the navbar for example so that we can change the theme of it based on the theme. we can use a computed property for that.

first initialize the theme:

```html
<script>
	Vue.createApp({
		data() {
			return { useDark: true };
		},
	});
</script>
```

now we can use the `computed` property to define the computed property:

```html
<script>
	Vue.createApp({
		data() {
			return { useDark: true };
		},
		computed: {
			// this will be re-computed on change of the `useDark`
			navbarClasses() {
				return {
					"nav-dark": this.useDark,
					"nav-light": !this.useDark,
				};
			},
		},
	});
</script>
```

now we can use the `navbarClasses` computed property in the html:

```html
<div :class="navbarClasses"></div>
```
