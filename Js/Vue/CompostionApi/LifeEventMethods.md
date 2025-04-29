<!-- @format -->

# Life events methods:

vue provides multiple functions that allows you to handle different life cycle events for a component, named `onLifeCycleName` and accepting a callback function, they function similarly to the `useEffect` but they are bit more specific.

an example for life cycle methods:

- **onBeforeMount** -> runs before the component is mounted to the dom
- **onMounted** -> runs when the component is mounted
- **onBeforeUpdate** -> runs when the reactive data change and before the re-render
- **onUpdated** -> called after re-render
- **onBeforeUnMount** -> runs before the component is removed from the dom
- **onActivated** -> runs when a `kept-alive` component is activated
- **onDeactivated** -> runs when a `kept-alive` component is deactivated
- **onErrorCaptured** -> runs on error onErrorCaptured

so let's see an example:

```javascript
import { ref, onMounted } from "vue";

const tasksTitles = ref([]);

onMounted(async () => {
	try {
		const apiRes = await fetch("https://jsonplaceholder.typicode.com/todos");
		if (apiRes.ok) {
			let data = await apiRes.json();
			//ensuring that we only get the title value
			tasksTitles.value = data.map((task) => task.title);
		}
	} catch (error) {
		console.log("error");
	}
});
```

in this snippet the component will fetch data from the `jsonplaceholder` api after it's mounted to the dom.
