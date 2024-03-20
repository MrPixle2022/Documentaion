# Request methods:

navigation:

- [get](#geturl-request-response)
- [post](#posturl-request-response)
- [delete](#deleteurl-request-response)
- [patch](#patchurl-request-response)

---

# get('url', (request, response) => {}):

the `get` method allows you to handle a get request at `url` 

```javascript
app.get('/hello', (request, response) => {
    response.sendFile('./public/main.html', {root: './'}, err => console.log(err));
})

```

this will create a get request at `http://localhost:8000/hello` and will add `<h1>hi there</h1>`.

```javascript
app.get('/', (req, res) => {
res.sendFile('./views/mainPage.html',{root: './'}, err => console.log(err));
});
```

---

# post('url', (request, response) => {}):

the `post` function allows you handle a post request at `url`.

```javascript
app.post('/post', (req,res) => {
    res.send("2")
});
```

this will send `2` when a post request is sent to `/post`.

---

# delete('url', (request, response) => {}):

the `delete` method allows you to handle a delete request at `url`.

```javascript
app.delete('/delete', (req,res) => res.send("done"))

```

---

# patch('url', (request, response) => {}):

the `patch` method allows you to handle a patch request at `url`.

```javascript
app.patch('/patch', (req,res) => res.send("done"))
```

---
