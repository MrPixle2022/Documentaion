<!-- @format -->

# Watchers:

watcher are function that monitor change in data, and trigger actions when the change occurs.

the watchers are defined in the `watch` config option, and must have the same name as the property they are monitoring.

```vue
<script>
	export default {
		data() {
			return {
				name: "John",
			};
		},
		watch: {
			name(newVal, oldVal) {
				console.log(newVal, oldVal);
			},
		},
	};
</script>
```

watchers work automatically when the component is mounted, and are called when the data changes.
