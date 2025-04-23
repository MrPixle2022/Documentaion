<!-- @format -->

# Accessing global Properties:

when using the composition api, we can't use the `this.$` to access global properties as the `this` now doesn't refer to the app instance.

how ever we can use the `inject` function to access global properties.

first in the `main.js` file we need to make the property available to inject.

```js
// provide("key", value)
app.provide("name", "John");
```

then in the component we can use the `inject` function to access the property.

```js
import { inject } from "vue";
const name = inject("name");
```

and that's it, we can now use the `name` variable in the component.

```js
console.log(name);
```

[!NOTE] even components using the options api can access them using the `inject` options

```js
export default {
	inject: ["name"],
};
```
