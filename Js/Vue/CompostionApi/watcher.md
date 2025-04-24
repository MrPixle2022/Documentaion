<!-- @format -->

# Watchers:

vue provides a `watch` function that can be used instead of the `watch` option in the options api.

```javascript
import { ref, watch } from "vue";

const count = ref(0);

// watched properties must be reactive -will change-.
watch(count, (newVal, oldVal) => {
	console.log(newVal, oldVal);
});
```

[!NOTE] any value that will change can be accepted, know that the property can be a function returning the value

also the `watch` can accept another object to define the behavior of the watcher:

```javascript
watch(
	count,
	(newVal, oldVal) => {
		console.log(newVal, oldVal);
	},
	{
		once: true, // will only run once,
		immediate: true, // will run immediately,
		deep: true, // will watch the deep properties of the object
	},
);
```

---

## watchEffect:

the `watchEffect` is a function that will watch the reactive properties and run the function when the properties change.

unlike the watch it doesn't need to specify the watched property, it will watch all the reactive properties accessed in it **synchronously** so if an async callback is used only properties before the first `await tick` will be considered dependency.

```javascript
cont count = reactive({value: 0})
watchEffect(() => {
	console.log(count.value);
});
```

also there is the `onCleanup` function that will be called when the watcher is about to re-run it is passed to the callback function as the second argument.

```javascript
watchEffect((onCleanup) => {
	console.log(count.value);
	onCleanup(() => {
		console.log("cleanup");
	});
});
```

the `watch` has the same but passed as the third argument to it's callback function -second argument- after the `newValue & oldValue` arguments.
