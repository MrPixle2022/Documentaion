<!-- @format -->

# Using the Composition api:

when using the `composition` api we rely on the `useRouter` to access the vue router.

the `useRouter` function returns a router instance that we can use to navigate to different routes.

```javascript
import { useRouter } from "vue-router";

const router = useRouter();

function navigateToHome() {
	router.push({path: "/path", query: {---}});
}
```

also you can use the `useRoute` to access current route

```javascript
import { useRoute } from "vue-router";

const route = useRoute();

console.log(route.path);
```
