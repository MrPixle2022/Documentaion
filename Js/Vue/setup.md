<!-- @format -->

# Project setup:

use the vue cli to create a new project:

```powershell
pnpm create vue@latest
#or use vite
pnpm create vite@latest
```

this will create a new project with the main entry point being `main.js` where the root component `App.vue` is mounted.

now you can create a new component using `filename.vue`, in this file you have your template, script, and style.

```vue
<script setup>
	//here goes the js / ts code
</script>

<template>
	<!-- here goes the html and components -->
</template>
```

now in that `script` tag you can export default the object that defines the options of the component like `data`, `computed`, `methods`, etc..

```vue
<script>
	export default {
		props: ["page"],
	};
</script>

<template>
	<h1>{{ page.pageTitle }}</h1>
	<p>{{ page.content }}</p>
</template>
```

now you can use this component in the `App.vue` file by importing it and using it in the template.

```vue
<script>
	import Page from "./components/Page.vue";
	export default {
		components: {
			Page,
		},
	};
</script>

<template>
	<Page :page="page" />
</template>
```

all of this is using the `options api` of vue.
