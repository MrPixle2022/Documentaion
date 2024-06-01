# Data fetching:

---

## remote apis:

to fetch data from a remote api use the `fetch` api.

next js provides more options to it like `cache` to control the caching, `next` to revalidate the data for example.

```javascript
async function getData() {
  const res = await fetch("https://jsonplaceholder.typicode.com/posts", {
    cache: "force-cache" /*default, no-store / no-cache only-if-cached*/,
    next: { revalidate: 30 /*refresh every 30sec*/ },
  });
  if (!res.ok) {
    return new Error("Failed to fetch data");
  }
  return res.json();
}
```

then simply turn your component into an async function and await the this function
