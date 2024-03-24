# the response object:

the `response` you make in the callback in any request method has a set of methods and function like.

navigation:

- [status message](#statusmessage)
- [status code](#statuscode)
- [send](#senddata)
- [send file](#sendfilepath-root-rootpath-errfunc)

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


---

### send('data'):

the `send` method allows to send text or assign html to the page.

```javascript
app.get('/', (req,res) => res.send("<h1>Hello</h1>"));
```

this will create an `h1` element at the home page.

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
