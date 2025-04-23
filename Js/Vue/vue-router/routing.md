<!-- @format -->

# Routing:

---

## static routing:

first create a router instance, define the history option and the routes array:

```javascript
import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";

const router = createRouter({
	history: createWebHistory(),
	routes: [
		{ path: "/", component: Home },
		{ path: "/about", component: About },
	],
});
```

this will route every component to the path in the same object, it's important to make sure to import the components.

---

## dynamic routing:

using the `:var` syntax, you can route to a component that will be expect a path parameter named `var`.

```javascript
const router = createRouter({
	history: createWebHistory(),
	/*
    path -> the url to match
    component -> the component to render
    props -> pass the param as props to the component
  */
	routes: [{ path: "/:page", component: PageContent, props: true }],
});
```

note that for the `/` path, no component will be rendered as the router only know to map the `PageContent` to the `/:path` aka the path with the param, so unless you want to use the same component exactly for the both paths you can make the path param optional for example `:var?`.

```javascript
{ path: "/:page?", component: PageContent },
```

later the params can be accessed in the component via the `this.$route.params` since using the `app.use(router)` adds the router the global `this` object.

---

## nested routes:

you can define nested routes by adding a `children` property to the route object:

```javascript
{ path: "/", component: Home, children: [{ path: "about", component: About }] },
```

the `children` is an array that accepts other router instances to nest the routes.
