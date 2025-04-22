<!-- @format -->

# Life Cycle Events:

life cycle events are events that are triggered when a component is created, mounted, updated, and destroyed.

---

## created:

the `created` event is triggered after the computed properties and the data are set and before being added to the DOM.

```vue
<script>
	export default {
	   <!-- this runs this function on creation -->
		created() {
			console.log("created");
		},
	};
</script>
```
