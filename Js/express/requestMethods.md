# Request methods:

---

in express you handle different request verbs aka `GET, POST, DELETE, PATCH, PUT , etc...` by using a request method, a request method can be accessed on the `express` instance or `router` instance.

request method take a `route` and a `route handler` function.

```javascript
app.get(); // get or read data
app.post(); // create a new data
app.delete(); // delete an existing data
app.patch(); //partially change a record
app.put(); //overwrites an entire record
```

the `request handler` is a function that takes a `request` and a `response` objects a parameters, they can access the request data & send a response be it json, html, text, etc...

```javascript
app.get("/api/user", (request, response) => {
  //res.status(statusNumber).send(content);
  //res.status(statusNumber).json(payload);
  //the status() is optional but it's a good practice
  //res.sendStatus(status) sends the status code & it's status message as the body of the response
  res.status(200).send("<h1>Hello there</h1>")
})
```
