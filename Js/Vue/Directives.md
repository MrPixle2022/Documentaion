# Directives:

directives are special attributes that vue uses to link your elements with js code

navigation:
- [Attribute Binding](#attribute-binding)
- [Dynamic Binding](#dynamic-binding)
- [Conditional rendering](#conditional-rendering)
- [List Rendering:](#list-rendering) 


# Attribute Binding:

attribute binding allows you to bind html attributes to js

there are two ways for binding the old and the short way:

old way:

```vue
<script setup>
const google = 'https://www.google.com'
</script>

<template>
  <a v-bind:href="google">google</a>
</template>


```

this will link the value of the `href` on the anchor tag to the value of `google` in the script tag

the short way:

```vue
<script setup>
const google = 'https://www.google.com'
</script>

<template>
  <a :href="google">google</a>
</template>


```

it's identical to the old way just removes the `v-bind` from the syntax, both ways are valid.

another example:

```vue
<script setup>
const img = {
  src: `C:\\Users\\Amro\\Desktop\\Amr`,
  width: '100px',
  height: '100px',
  alt: 'failed'
}
</script>

<template>
  <img :src="img.src" :alt="img.alt" :height="img.height" :width="img.width" />
</template>


```

# Dynamic Binding:

Dynamic binding allows you to bind attributes to js where the attribute name is the same as the key in an object, like:

```vue
<script setup>
const imgINfo = {
  src: `C:\\Users\\Amro\\Desktop\\Amr`,
  width: '100px',
  height: '100px',
  alt: 'failed'
}
</script>

<template>
  <img :="imgINfo" />
</template>


```

this is the same as shown in the example above.
>[!Important]the attribute must be the same as the key.

---

# Event directives:
the `v-on` directive is used to assign js code to an element on an event it's syntax may vary as the dev may want you could use it like:
- `v-on:eventName = 'code'`
- `@:eventName = 'code'`
- `@eventName = 'code'`

for example:

```vue
<script setup>
import { ref, computed } from 'vue'
const number = ref(0)
</script>

<template>
  <button v-on:click="number++">increase</button>
  <button v-on:click="number--">decrease</button>
  <h1>{{ number }}</h1>
</template>

```

in this example we have created a reactive data named `number` with each click defined by `v-on:click` on one of the two buttons it will affect the value of number.

also can use the other short ways:

```vue
<script setup>
import { ref, computed } from 'vue'
const number = ref(0)
</script>

<template>
  <button @:click="number++">increase</button>
  <button @click="number--">decrease</button>
  <h1>{{ number }}</h1>
</template>
```

---

# Conditional rendering:
conditional rendering in vue is done by using certain directives like:
- [v-if](#v-if--condition)
- [v-else-if](#v-else-if--condition)
- [v-else](#v-else)
- [v-show](#v-show--condition)

---

## v-if = 'condition':

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

## v-else-if = 'condition':

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

## v-else:

unlike to previous directives the `v-else` doesn't take a condition since it will be rendered when all element with `v-if` and `v-else-if` above it won't load due to their condition being false

---

## v-show = 'condition':

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

---

# List Rendering:

to loop over the elements of an iterable you can use `v-for` to render this element for each element in the array you are looping over.

## v-for = "(value, index?) in array"

the `v-for` allows you to loop over an array each time taking the value and optionally the index of one of it's values.

>[!Note]
> on the element you use the `v-for` directive on, you must assign a value to it's `key` attribute, usually it's assigned the index of the current value.

example:

```vue
<script setup>
import { ref } from 'vue'
let items = ref([1, 2, 3, 4, 5])
</script>

<template>
  <p v-for="(item, i) in items" :key="i">{{ item }}</p>
</template>

```

this code will create a new `p` element for each value in `items` each with a special value for their `key` attribute.

when working with an array of objects you can use destructuring to make it easier to access data.

for example:

```vue
<script setup>
import { ref } from 'vue'
let items = ref([
  { name: 'amr', age: 16 },
  { name: 'ali', age: 17 },
  { name: 'mohammed', age: 15 }
])
</script>

<template>
  <p v-for="({ name, age }, i) in items" :key="i">{{ name }} -> {{ age }}</p>
</template>

```