# HTTP module

---

### to use it:
```javascript
import http from 'http'
```

---

#### creat a server:
to create a server you need to use the createServer(callback) function,

the function takes a call back function as a parameter

the callback takes a request and a response as a parameter

```javascript
const server = http.createServer((req, res)=> {});
```
you can use the respond and request parameters in the callback

#### res.write(chunk):
```javascript
res.write('<h1> server is running </h1>');
//creates an h1 in the page the listen funcion is trageting
```

#### res.end(msg):

```javascript
res.end("bye");
//sends the last message before the stream is closed
```

#### res.setHeader(header):
```javascript
res.setHeader("Content-Type", "text/html");
//tells the server that the request is of type html
```

#### res.statusCode, res.statusMessage:

```javascript
res.statusCode  = 404;
res.statusMessage = "bad";
//the status code and it's message
```

or just use the shorthand

#### res.writeHead(statusCode, statusMessage, headers):

```javascript
res.writeHead(404, "bad", {"Content-Type": "text/html"})
```



---

#### listen(port, callback):

```javascript
server.listen(8000, ()=> console.log("hi"))
```

the [**listen**] method starts the server to listen to the given porrt, the callback:(optional) is excuted when the server starts
