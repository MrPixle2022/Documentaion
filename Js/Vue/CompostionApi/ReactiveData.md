<!-- @format -->

# Reactivity:

this part discuss mainly the `ref`, `reactive` & `computed` functions in the composition api.

---

## ref(def):

the `ref` function allows you to define a reactive value, on change it will cause the components using it to re-render.

the `ref` essentially contains the given value in an object, and to access it use `.value` -like a useRef-.

```javascript
import { ref } from "vue";

const count = ref(0);
```

in this example count is actually equal to

```javascript
count = {
	value: 0,
};
```

meaning to use this object within the script the `.value` must be used, however that is not needed in the template.

```html
<!-- this will extract the .value -->
<h1>{{ count }}</h1>
```

---

## reactive(objVal):

the `reactive` functions very similarly to the `ref` function, however it only accepts types that js considers objects like objects and arrays.

unlike the `ref` the value isn't stored in a `.value` but just the same as you define it, so:

```javascript
import { reactive } from "vue";

const user = reactive({ name: "user", email: "user@email.com" });
```

then the `name` can be accessed via `user.name` the same is for the template:

```html
<h1>{{user.name}}</h1>
```

---

## computed(func):

the `computed` allows you to create reactive function that depend on other values to change, any value used in the `func` will be considered a dependency and will cause the value to update.

```javascript
import { computed, ref } from "vue";

const count = ref(0);
const doubleCount = computed(() => count * 2);
//each time the count is updated, the doubleCount is re-calculated
```
