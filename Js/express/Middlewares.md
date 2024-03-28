# Middleware:

middleware is the operation that runs between the request being received and the response being sent

---

### param('param', callbackFunc):

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

### json():

the `json` middleware allows you to handle incoming json requests.

```javascript
app.use(express.json())
```

---

### urlencoded({extended: true}):

the `urlencoded` middleware allows you to have access to the request body.

```javascript
app.use(express.urlencoded({extended: true}))
```

---

### static('foldername'):

the `static` middleware allows you to serve static files like `html` directly without using routing for them, it uses the file path as it's url, for example:

```javascript
app.use(static('public'))
```
so now if i have a `public/main/index.html` it will be rendered on `/main/index.html`, an `index.html` in the `folderName` dir directly will be rendered at `/`

---

### creating your own middleware:

a middleware after all is just a function, so you can create one by declaring a function that takes `req` , `res` and `next` then use `app.use(yourMiddleware)`:

```javascript
function Logger(req,res,next)
{
    console.log(res.originalUrl);
    next();
}

// use it every where

app.use(Logger);

//use it on a specific endpoint

app.get('/', Logger, (req, res) => res.send('hi'))
//this will use the `logger` before handling the request
```
