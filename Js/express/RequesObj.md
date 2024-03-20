# Request:

navigation:

- [path params](#path-params)
- [body params](#path-params)
- [query params](#query-params)

---

# Path params:

to take a path param first in your url add `:` before the part that is a variable, then access it from `request.params` which is an object holding all path params as string.

```javascript
app.get('/add/:num1/:num2', (req,res) => {
    console.log(req.params)
    res.send(`sum is ${Number(req.params.num1) + Number(req.params.num2)}`);
})
```

in this example `num1` and `num2` are both parameters that i have access two via the `params` object.

so if i entered `http:\\localhost:3000\1\2` i will get `3`

---

# Body params:

body params are usually sent as json object, to use them first you must allow json requests and then access the `body` object which holds all body params.

```javascript
app.get('/name', (req,res) => {
    console.log(req.body);
    res.send(`hello ${req.body.name}`)
})
```

this request takes a body parameter named `name` and returns it in a message.

---

# Query params:

query params are defined by keys and values in the url, the look like.
`http:\\localhost\query?age=10`

you can access them by using the `query` object.

```javascript
app.get('/query', (req,res) => {
    res.send(req.query.age)
})
```

so if i entered `http://localhost:3000/query?age=10` i will get `10` back