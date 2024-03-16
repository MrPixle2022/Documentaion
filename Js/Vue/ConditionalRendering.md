# Conditional rendering:


conditional rendering in vue is done by using certain attribute like:

- [v-if](#v-if--condition)
- [v-else-if](#v-else-if--condition)
- [v-else](#v-else)
- [v-show](#v-show--condition)

---

# v-if = 'condition':

the `v-if` directive is used to specify a condition on which the element is rendered.

example:
```vue
<script setup>
import { ref, computed } from 'vue'
const number = ref(5)
</script>

<template>
  <button @click="number++">increase</button>
  <button @click="number--">decrease</button>
  <h1>{{ number }}</h1>
  <h2 v-if="number > 4 && number < 10">ok stop now</h2>
</template>
```

in this example we have an `h2` element that will only render when the value of `number` is greater than 4.

---

# v-else-if = 'condition':

the `v-else-if` directive allows the element to be rendered on a certain condition when the element with `v-if` isn't rendered to it's condition not being true.

example:

```vue
<script setup>
import { ref } from 'vue'
const number = ref(5)
</script>

<template>
  <button @click="number++">increase</button>
  <button @click="number--">decrease</button>
  <h1>{{ number }}</h1>
  <h2 v-if="number > 4 && number < 10">ok stop now</h2>
  <h2 v-else-if="number > 1">almost there</h2>
</template>
```

in this example the `h2` with `v-else-if` will only render when `number` is greater than one.

---

# v-else:

unlike to previous directives the `v-else` doesn't take a condition since it will be rendered when all element with `v-if` and `v-else-if` above it won't load due to their condition being false

---

# v-show = 'condition':

similar to `v-if` the `v-show` takes a condition but unlike it `v-show` is used to toggle the visibility of an element instead of showing multiple elements based on a condition.

example:

```vue
<script setup>
import { ref } from 'vue'
const number = ref(5)
</script>

<template>
  <button @click="number++">increase</button>
  <button @click="number--">decrease</button>
  <h1>{{ squerdNumber }}</h1>
  <p v-show="number > 10">{{ number }} > 10</p>
</template>
```

in this example the `p` will only appear when `number` is greater than 10 else it won't be rendered. 