<!-- @format -->

# Sessions with express-session:

a `session` refers to the way the server keeps track of the user sending it a `request`, since the http request is `stateless` we use a `session` to keep track of different users via a `session id`.

when a user enters the website the server creates a new session for this user containing the `session id` that will be sent to the user as a `cookie`, the session is used mainly for authentication purposes and it can store data about the user.

the `cookie` containing the `session id` is sent to the server with each request, the serve reads the session id and looks for the user that has the `session id` correspondent to the `session id` cookie

---

## express-session

start by using:

```powershell
pnpm i express-session
```

use the `session` middleware to handle the sessions in your server.

the `middleware` must be passed an `options object`.

in this example we will use:

- `secret`: the string used to encrypt the session id
- `saveUninitialized`: a boolean used to set wether should uninitialized sessions be stored or not
- `resave`: a boolean used to set if the session is to be saved wether it being modified or not

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

now a `session` will be generated but the problem that it will be generated for each single request even if it was sent through the same user, since it wasn't saved due to it being `uninitialized`.

an `uninitialized` session is a session that has been created but not modified during a request.

the server must add properties to the created session so that the session is initialized and can be saved in the `session store`

```javascript
//now the session is initialized
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

**but** it is recommended to use `request.session` over the `sessionStore` as it is simpler