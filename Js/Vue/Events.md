# Events:

events in vue are accessed by `v-on:eventName` attribute it will allow you to assign a value in js to that event.

for example:

```vue
<script setup>
let count = 0;
</script>

<template>
    <h1>count: {{count}}</h1>
    <button v-on:click="count++">increment</button>
</template>

```

this code here increases `count` by one each time the button is clicked. but note that the component won't rerender because this `count` isn't a **reactive state**

to make it reactive use `ref` like:

```vue
<script setup>
import {ref} from 'vue'
let count = ref(0);
</script>

<template>
    <h1>count: {{count}}</h1>
    <button @:click="count++">increment</button>
</template>

```

you will find that the count changes and it's value is rerendered

> [!NOTE]
> you can either use v-on:event or @:event or @event.

