<!-- @format -->

# Components:

using components is a vue js project is similar to the way used via cdn, thought there are some differences.

first create a new component file in the `components` folder.

```vue
<script>
	<!-- the configuration and props -->
	 export default{
	   props: {---},
	   data(){---}
	 }
</script>

<template>
	<!-- here goes the html -->
</template>

<style scoped>
	<!-- here goes the css -->
</style>
```

then in the parent component import the component and use it in the template.

```vue
<script>
	import Component from "----";
	export default {
		components: {
			Component,
		},
	};
</script>

<template>
	<!-- here goes the html -->
	<Component />
</template>

note that even if the component name is not camel case, it will be converted to
kebab case when used in the parent component.
```

note that props can have a default value:

```vue
<script>
	export default {
		props: {
	     // this will create a prop of type string defaulted to "default value"
			prop: { type: String, default: "default value" },
		}
	   },
</script>
```

but if the prop is an object the default must turn into a factory function:

```vue
<script>
	export default {
		props: {
			prop: { type: Object, default: (rawProps) => ({}) },
		},
	};
</script>
```
