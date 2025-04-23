<!-- @format -->

# Reactive Data:

the composition api provides an easy -react like- way to create your component and it's logic.

[!NOTE] to use the composition api you need to use the `script setup` syntax, just add the `setup` attribute to the `script` tag.

the api provides a `ref` function and the `reactive` function that can be used to create a reactive reference to a value.

the difference being that the `ref` accepts any type of data, and wraps it in an object with a `value` property so for example:

```javascript
import { reactive, ref } from "vue";

// refs can accept any value
const count = ref(0);
count = { value: 0 };

const increment = () => {
	count.value++;
};

const decrement = () => {
	count.value--;
};
```

```vue
<template>
	<h1>Counter {{ count }}</h1>
	<button @click="increment">+</button>
	<button @click="decrement">-</button>
</template>

<script setup>
	//here we add the js logic
</script>
```

[!NOTE] though the count is technically an object where the actual value is stored in the `value` property we can just use it's name and vue will extract it's value in the template.

---

## reactive:

the `reactive` function accepts an object and returns a reactive proxy of that object.

<!-- @format -->

```vue
<template>
	<div>
		<h1>Pages List</h1>
	</div>
	<h1>Counter {{ count.value }}</h1>
	<button @click="increment">+</button>
	<button @click="decrement">-</button>
</template>
```

```javascript
import { reactive, ref } from "vue";

// reactive only accepts object, arrays, maps, etc...
let count = reactive({ value: 0 });

const increment = () => {
	count.value++;
};

const decrement = () => {
	count.value--;
};
```

[!NOTE] here since we used the `reactive` function we had to extract the value our selves in the template.

---

## Computed:

the `computed` function is used to create a computed property.

```javascript
import { computed, ref } from "vue";

const count = ref(0);

const doubleCount = computed(() => count.value * 2);
```
