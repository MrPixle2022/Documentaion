# Reactivity:

when your component depends on a value as a part of it's output and this value might change anytime you would want to make this data reactive so their change will rerender the component for that use either:
- [ref](#refinitialvalue)
- [reactive](#reactivetargets)
- [computed](#computedgetter)

---

# ref(initialValue):

the `ref` function allows you to create reactive single value so it works for primitive types ,arrays and objects.

```vue
<script setup>
import { reactive } from 'vue'
let count = ref(count: 0)
</script>

<template>
  <h1>count: {{ count }}</h1>
  <button v-on:click="count++">click</button>
</template>

```

here the value will increase by 1 each time the button is clicked

# reactive(target):

the reactive function takes an obj with it's key and values and sets it to be reactive, this function doesn't accept primitive types [int,float,string,bool]

for example:

```vue
<script setup>
import { reactive } from 'vue'
let counter = reactive({ count: 0 })
</script>

<template>
  <h1>count: {{ counter.count }}</h1>
  <button v-on:mouseenter="counter.count++">click</button>
</template>
```

this will create a new reactive object named `counter` whose `count` is set to 0 and will trigger the rerender each time the mouse enters the button.

---

# computed(getter):

computed values are values that automatically update when there state change for example:

```vue
<script setup>
import { ref, computed } from 'vue'
const number = ref(5)
const squaredNumber = computed(() => number.value * number.value)
</script>

<template>
  <button @click="number++">increase</button>
  <h1>{{ squaredNumber }}</h1>
</template>

<style scoped></style>

```

here we created a reactive value named `number` and then we created a `computed` var that's value is equal to the value of `number` squared, each time you click the button the value of `number` increases by one and the `squaredNumber` will update as well giving us the `number` squared