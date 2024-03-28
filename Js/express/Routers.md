# Routers:

routers allow you to easily manage routing across your project they can be nested or given a specific path to work on.

### creating a router:

to create a router initialize a new var.

```javascript
const router = express.Router()
```

the router works similar to the normal express app, it has `get`, `post`, etc...

### setting a router for a path:

if you have multiple urls to a shared path like having multiple urls like `/users/data`, `/users/id/name` , etc..
you will notice that the `/users` is repeated, you can instead use routers to handle these requests by setting them like:

```javascript
app.use("/users", router)
```

this will make it so that we use the `router` to handle all requests sent to any url under the `/users`

---

### routing for a url with multiple requests types:

if you have a url that you will go to and run code depending on the request method than use `app.route` instead, it take the url `prefix` which the section that gets repeated than chain the method yuo want by using `.`

```javascript
app.route("/users").get(---).delete(----)
```
