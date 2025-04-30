<!-- @format -->

# Using the Composition api:

when using the `composition` api we rely on the `useRouter` to access the vue router.

the `useRouter` function returns a router instance that we can use to navigate to different routes.

```javascript
import { useRouter } from "vue-router";

const router = useRouter();

function navigateToHome() {
	router.push({path: "/path", query: {---}});
  // also push("/path") works
}
```

the router instance has a set of useful methods like:

- push -> add a new entry
- replace -> replace this url in the entry

and so on..

---

## useRoute

use the `useRoute` to access current route's data

```javascript
import { useRoute } from "vue-router";

const route = useRoute();

console.log(route.path);
```
