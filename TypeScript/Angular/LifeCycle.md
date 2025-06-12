<!-- @format -->

# Lifecycle events:

a component's lifecycle events are class methods that start with `ngOn`, like `ngOnInit`.

---

## ngOnInit:

the `ngOnInit` runs once the component's inputs are initialized and before the template is rendered, allowing you to alter the component pre-render, and it runs once.

---

## ngOnChanges:

the `ngOnChanges` runs on input change, it can take a `SimpleChanges` record which holds the `input` as the key and the value is a `SimpleChange` object which holds the `current` and `previous` values of the input.

```typescript
@Component({
	/* ... */
})
export class UserProfile {
	name = input("");

	ngOnChanges(changes: SimpleChanges) {
		for (const inputName in changes) {
			const inputValues = changes[inputName];
			console.log(`Previous ${inputName} == ${inputValues.previousValue}`);
			console.log(`Current ${inputName} == ${inputValues.currentValue}`);
			//firstChange is a boolean that is true if this is the first time it changes
			console.log(`Is first ${inputName} change == ${inputValues.firstChange}`);
		}
	}
}
```

> [!NOTE] If you provide an `alias` for any input properties, the SimpleChanges Record still uses the TypeScript property name as a key, rather than the alias.

---

## ngOnDestroy:

the `ngOnDestroy` event is called once, just before a component is destroyed.

Angular destroys a component when it is no longer shown on the page, such as being hidden by `@if` or upon navigating to another page.

---

## ngAfterContentInit:

The `ngAfterContentInit` method runs once after all the `children` nested inside the component (its content) have been initialized.
