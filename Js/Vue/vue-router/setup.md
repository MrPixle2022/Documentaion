<!-- @format -->

# Setup:

start by installing the router:

```bash
pnpm install vue-router -D
```

then create a file to define the routes:

```javascript
//or import createWebHashHistory
import { createRouter, createWebHistory } from "vue-router";
const routes = createRouter();
```

then in the main.js file:

```javascript
import router from "./router";

const app = createApp(App);
// the app.use() method is used to use allow plugins to be used in the app
app.use(router);
app.mount("#app");
```

now you can use the router in the app:

```vue
<template>
	<nav>this nav will always be visible</nav>
	<router-view />
</template>
```
