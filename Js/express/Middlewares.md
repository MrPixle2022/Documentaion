# Middleware:

`middlewares` are functions that runs between other functions, they can be used to validate or handle incoming requests, actually the `route handlers` are a type of middlewares.


`express js` provides builtin middlewares for specific use cases and allows the use of custom ones

---

## Custom middlewares:

to create a **custom** middleware you create a function similar to a `route handler` taking a `request` & a `response`, but it will take another argument, `next` the function that when called will call the **next middleware**

> [!IMPORTANT]
> Middlewares work in order from top to bottom so order matters.  

in this example i will create a new middleware and call it `loggingMiddleware`:

```javascript
const loggingMiddleware = (request, response, next) => {
  //logs the type of the request method & it's url
  console.log(`${request.method} - ${request.url}`)
  //moves to the next middleware
  next();
};
```

now lets use in the two ways

### local middleware usage:

to locally use a middleware means to use it for a specific route or multiple specific routes, by passing them before the route handler they can be used before them:

```javascript
app.get("/api/users/", loggingMiddleware ,(req, res) => {
  res.status(200).send([]);
})
```

> [!NOTE]  
> you are not limited to one you can use as many as you wish

```javascript
app.get("/api/users/", loggingMiddleware, loggingMiddleware ,(req, res) => {
  res.status(200).send([]);
})
```

### global middleware usage:

to globally use a middleware you use `app.use`, depending on where do you use it it will affect different parts of the app or the whole app.

```javascript
app.use(loggingMiddleware)

app.get("/api/users/", loggingMiddleware ,(req, res) => {
  res.status(200).send([]);
})
```

through middlewares you can validate data and attach them to the request object for example.

```javascript
function anotherMiddleware(request, response, next){
  request.user = {
    name: "amr",
    age: 16
  }
  next()
}

app.get("/api/users/", loggingMiddleware ,(req, res) => {
  res.status(200).send(req.user.name); //amr
})
```

> [!NOTE]  
> the `next` can be passed an error to be thrown optionally
---

## param('param', callbackFunc):

the `param` is a middleware that runs when the url contains the specified `param`, it takes a call back function that takes `req`, `res`, `next` and the param itself.

- `next`: the next operation like the response.

```javascript
const rout = express.Router();
app.use("/users", router)

rout.get('/users/:id', (req,res) => res.send("hi"))

rout.param('id', (req, res, next, id) => {
    console.log(id);
    next()
})
```

so this will log the `id` before it sends `hi` to the page.

---

## json():

the `json` middleware allows you to handle incoming json requests.

```javascript
app.use(express.json())
```

---

## urlencoded({extended: true}):

the `urlencoded` middleware allows you to have access to the request body.

```javascript
app.use(express.urlencoded({extended: true}))
```

---

## static('foldername'):

the `static` middleware allows you to serve static files like `html` directly without using routing for them, it uses the file path as it's url, for example:

```javascript
app.use(static('public'))
```
so now if i have a `public/main/index.html` it will be rendered on `/main/index.html`, an `index.html` in the root of the static folder will be rendered at `/`

---
