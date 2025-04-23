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
