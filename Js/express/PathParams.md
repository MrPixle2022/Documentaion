# Path Params:

in express you can set a route handler for a dynamic route, dynamic routes can be defined by `/:paramName` and you will get auto completion for them.

`path params` can be accessed by the `request.params` object


```javascript
app.get("/api/users/:id", (request, response) => {
  const {id} = request.params;
  console.log(`id: ${id}`);
})
```

so when accessing `/api/users/10` for example the server will log `id: 10` to the console
