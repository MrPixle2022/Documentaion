# Js Expressions:

to use js Expressions in vue within html use `{{}}` which allows you to write js or access js in the script tag.but you cant't create vars in it you will have to create them in the script tag.

for example:

```vue
<script setup>
let count = 0
</script>

<template>
    <h2>{{ count }}</h2>
</template>

<style scoped></style>

```

this will show an h2 element with text of `0`,
also you can use the `{{}}` for functions, arrays, etc...

```vue

<script setup></script>

<template>
    <h2>{{ [1,2,3,4].pop() }}</h2>
</template>

<style scoped></style>

```

this will return an h2 with text of `4`