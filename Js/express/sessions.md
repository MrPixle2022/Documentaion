<!-- @format -->

# Sessions with express-session:

a `session` refers to the way the server keeps track of the user sending it a `request`, since the http request is `stateless` we use a `session` to keep track of different users.

a `session` is generated on entering the page, and it contains data related to the user and is mainly used for authentication purposes.

---

## express-session

start by using:

```powershell
pnpm i express-session
```

use the default export middleware `session` to handle the sessions in your server.

```javascript
import session from "express-session";

app.use(
	session({
		secret: "amr yasser", //the secret used to encrypt the session id
		saveUninitialized: false, //ignores any uninitialized sessions(new & unmodified or rather users who are not logged in)
		resave: false, // won't force a session to be resaved, if true it will force a resave even if the session was never modified
		cookie: {
			maxAge: 1000 * 60 * 60, //cookie valid for only 1 hour
		},
	}),
);
```

now we can access that session on any request using `request.session`:

```javascript
console.log(request.session);
console.log(request.session.id); //or use request.sessionId
```

now a session will be generated but the problem that it will be generated for each single request no matter who send it, since it won't be save due to it not being initialized.

the session is waiting to be modified to be save, so we will do so.

```javascript
request.session.visited = true; //this is called modifying the session, this makes the session send the cookie to the client so now we can reliably track the user
```

the session is now stored in the `sessionStore` found on the `request` object.

```javascript
request.sessionStore.get(request.session.id, (err, data) => {
    if (err) {
      console.log(err);
      throw err;
    }
    console.log(data)
  }) //the session storage
```
