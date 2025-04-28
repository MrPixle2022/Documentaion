<!-- @format -->

# Props:

using the `defineProps` macro we can define the props, their types, are they required or the default value

```javascript
defineProps({
	// title: String
	title: {
		type: String,
		default: "Become A Vue Dev", //default value
	},
});
```

the `title` can be accessed directly within the template but to use it inside the script it must be extracted

```javascript
const { prop } = defineProps({
	//----
});
```
