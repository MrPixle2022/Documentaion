<!-- @format -->

# Updating Components:

when using the vue router, you will notice that only routing to a different component will trigger the component to be updated, meaning that if you are using a path param -for example-, the component won't update, instead you will have to route to a different url with a different component for the component to update when you return.

---

## using global `$watch`:

luckily this can be solved using watchers, but watchers must named identically to what they watch, so how can we watch the path.

will there is actually a global watch function and when is say global i mean `$watch`, here is how to use it:

```javascript
//recommend using this in the created hook.

this.$watch(
	() => this.$route.params,
	(newVal, oldVal) => {
		//do something
	},
);
// the first argument can be either a function of a string used to defined what to watch
```

---

## passing params as props:

by adding the `props: true` option to the route, the params will be passed as props to the component.

```javascript
{ path: "/path/:id", component: Component, props: true },
```

you can add the prop to the component -with the same name as the param- and use a watcher to watch the prop.

```javascript
export default {
	props: ["id"],
	watch: {
		id(newVal, oldVal) {
			//do something
		},
	},
};
```
