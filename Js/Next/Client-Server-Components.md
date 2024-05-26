# Client and Server components:


---

## Server components:

by default next considers every component in your project a `server component`.

server components are useful for fetching data and sending less requests but they can't use hooks or event listeners, also they can be cached on the server optionally.

---

## Client Component:

client component are the place where you right react code inside of next, they support hooks, event listeners, custom hooks, etc...

though you first have to tell next that a component is a client component by using:

```javascript
"use client";
```

at the very top of your file.

client component can interact with with browser's Apis like the `local storage`.