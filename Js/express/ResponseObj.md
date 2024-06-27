# the response object:

the `response` you make in the callback in any request method has a set of methods and function like.

navigation:

- [status message](#statusmessage)
- [status code](#statuscode)
- [status](#statusstatuscode)
- [send](#senddata)
- [sendStatus](#sendstatusstatuscode)
- [send file](#sendfilepath-root-rootpath-errfunc)
- [render](#renderfilepath-data)
- [download](#downloadpath)
- [redirect](#redirectpath)

---

### statusMessage:

the `status message` property allows you to set the status text for the response.

```javascript
res.statusMessage = "Good request";
```


---

### statusCode:

the `status code` allows you to set the status code for the response:

```javascript
res.statusCode = 200;
```

--

### status(statusCode):

the `status` method allows you to set the status code of the response and chain a response message or json to it:

```javascript
app.get("/", (req, res) => res.status(200).json({msg: "operation success"}))
app.get("/", (req, res) => res.status(200).send("operation success"))
```


---

### send('content'):

the `send` method allows to send text or assign html to the page.

```javascript
app.get('/', (req,res) => res.send("<h1>Hello</h1>"));
```

this will create an `h1` element at the home page.

---

### sendStatus(statusCode):

the `sendStatus` send a status code and sets the status message correspondent to the status code as the body.

```javascript
app.get("/", (req, res) => res.sendStatus(404)) //status: 404, body: not-found
```

---

### sendFile('path', {root: 'rootPath'}, errFunc):

the `sendFile` method allows you to send a file as a response to a request it takes three parameters.
1. `path` : the path to the file you want to send.
1. `{root}` : the root of the project, set it to __dirname to reference this folder.
1. `errFunc` : the function to handle any error.

```javascript
app.get('/', (req,res) => res.sendFile(__dirname+"views/main.html"));
```
---


### render(filePath, {data}):

the `render` method allows you to display static file on the server but it requires some work like setting the default view engine the path, etc.., by default it will look for file in the `views` dir, after finding the file it will pass it the data object under the name of `locals`.

```javascript
import express from 'express';

const app = express();
app.set('view engine', 'ejs')

const port = 3000

app.get('/', (req, res) => {
    res.render('index.ejs', {name:"amr"})
});

app.listen(port, () => console.log(`server is up @: http://localhost:${port}/`));
```

---

### download(path):

the `download` allows you to send a file to be downloaded on the client's device.

---

### redirect('path'):

the `redirect` allows you to send the client to another url

```javascript
app.get('/', (req,res) => res.redirect('/users'))
```

---
