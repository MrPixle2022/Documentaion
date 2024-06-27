<!-- @format -->

# Routers:

a router is essentially just a middleware that allows for more organized code base it allows you to more easily organize request handlers sharing a url partially or completely.

it works almost as same as `express instance` where it has request methods and can use middlewares it self to be applied to any request that depends on it, so it's simply just a simpler version of the express instance providing a way for writing cleaner organized code.

---

## creating a router:

creating a router requires the `Router` method to be imported form `express`:

```javascript
import { Router } from "express";
```

then used to create a new router the same way as creating an `express instance`:

```javascript
const router = Router()

//this register the router as the responsible for handling any request to /api/users and any thing that falls under it
app.use("/api/users", router)
```

on that router you can use the same `request handlers`:

```javascript
//GET : /api/users/
router.get("/", (req,res) => {})

//GET: /api/users/:id
router.get("/:id", (req,res) => {})
//etc...
```
