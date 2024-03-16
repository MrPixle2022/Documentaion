# Props:

props allow you to share data between components and their children.

they are passed to components like attributes on html tags like:

```html
<SomeComponent name="user_Amr" age=10/>
```

to create props in a component use `defineProps` which is a method that takes all your props as an array or an object for more options.

array style:

```vue
<script setup>
const props = defineProps(['name', 'age'])
</script>

<template>
    <h1> {{ props.name }} {{props.age}}</h1>
</template>

```

then in the `App.vue` file:

```vue
<script setup>
import newComponent from './components/newComponent.vue';
</script>

<template>
  <newComponent name="amr yasser" age=10/>
</template>

```

object style:

```vue
<script setup>
const props = defineProps({
    name: String,
    age: {
        type: Number,
        required = true,
        default: 0
    }
})
</script>

<template>
    <h1> {{ props.name }} {{props.age}}</h1>
</template>

```

in this syntax you get to define the prop as a key and it's type is  a value, if you want to make it required use `required: true` in the object like i did with the `age` prop, use `default: value` to set a default value for the prop.

complex validation:

```javascript
const props = defineProps({
    name: {
        type: String,
        validator: (value) => ['ali', 'amar', 'mohammed'].contains(value);
    },
    age: {
        type: Number,
        required = true,
        default: 0
    }
})
```

the `validator` key allows you to assign a function to check the validity of the prop.