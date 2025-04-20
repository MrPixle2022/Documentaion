<!-- @format -->

# Methods:

the `createApp` function not only allows you to define data and computed properties but also custom methods that can be used in your code.

```html
<script>
	Vue.createApp({
		data() {
			return { useDark: true };
		},
		methods: {
			toggleTheme() {
				this.useDark = !this.useDark;
			},
		},
	});
</script>
```

now we can use the `toggleTheme` method in the button:

```html
<button @click="toggleTheme">Toggle Dark Mode</button>
```
