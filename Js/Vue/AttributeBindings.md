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

<style scoped></style>

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

<style scoped></style>

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

<style scoped></style>

```

---

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

<style scoped></style>

```

this is the same as shown in the example above, but the attribute must be the same as the key.