<!-- @format -->

# Events:

custom events can be emitted from a component using the `$emit` method.

```vue
<script>
	export default {
		methods: {
			handleClick() {
				this.$emit("customEvent", "custom arg");
			},
		},
	};
</script>
```

```html
<component @custom-event="(a) => console.log(a)"></component>
```

let's explain the code:

on calling the `handleClick` method the component will emit a custom event called `customEvent` with the argument `custom arg`.

when the event is emitted, the parent component will receive it and the callback function will be called with the argument `custom arg`.

so the output will be:

`custom arg` in the console.

---

## using the emits option:

the emits option is used to define the events that a component can emit.

```vue
<script>
	export default {
		emits: ["customEvent"],
	};
</script>
```

or using an object with functions for validation:

````vue
<script>
	export default {
		emits: {
			customEvent(a) {
				if (!a) return false;
				return true;
			},
		},
	};
</script>

then use the `$emit` method to emit the event in code: ```vue
<component @custom-event="handleCustomEvent"></component>
````

[!IMPORTANT] the validation function won't prevent the emission of the event, but it will trigger a warning in the console for debugging.

[!NOTE] custom events don't bubble up to the parent component, they are only available to the component that emits them.
