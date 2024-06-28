# Passport js:

## setup:

install `passport` using the command:

```powershell
pnpm install passport
```

then install the authentication strategies you will use:

```powershell
# to use user credentials install the local strategy
pnpm install passport-local
```

then use the `passport.initialize` & `passport.session` middlewares below the `session` middleware.

```javascript
import session from "express-session";
import passport from "passport";


app.use(express.json());
app.use(session({
  secret: "amr yasser", //the secret used to encrypt the session id
  saveUninitialized: false, //ignores any uninitialized sessions(new & unmodified or rather users who are not logged in)
  resave: false, // won't force a session to be resaved, if true it will force a resave even if the session was never modified
  cookie: {
    maxAge: 1000 * 60 * 60, //cookie valid for only 1 hour
  }
}));
app.use(passport.initialize());
app.use(passport.session());
```

---

## Credentials config:

start by creating a file to setup you authentication, in that file import `passport` and the `Strategy` class from the strategy package you are using in this case `passport-local`.

```javascript
import passport from "passport";
import { Strategy } from "passport-local";
```

then setup the methods:

```javascript
export default passport.use(new Strategy((user, password, done) => {
  console.log(email, password);
  try {
    const user = mockUsers.find(user => user.username === email);
    if (!user) throw new Error("User not found");
    if (password !== user.password) throw new Error("Passwords don't match");
    //done(err, user)
    done(null, user);
  } catch (error) {
    console.log(error);
    done(error, null);
  }
})) 
```

the code above specifies the process of authenticating a user, the `passport.use` takes a `strategy instance`, that instance can take two arguments:

`{options}`: an object used to remap fields to different fields, provided before the callback

`callback`: a function that takes three params:
  - `username`
  - `password`
  - `done(err, user)`

but if you want to use another field instead of the `username` for example you use the `{options}` object here.

by setting the `usernameField` to the value you want the username will be renamed to that value, so for example we can change it to `email`:

```javascript
export default passport.use({usernameField: "email"},new Strategy((email, password, done) => {}))
```

> [!IMPORTANT]  
> this request must contain a field with the same name as the field or else it won't be read.

for the `done` function it takes an `error` and the user data, one of them is null and the other is defined & based on that it will decide wether to throw an error or resolve the authentication.

but still we need to provide more.

we have to set the `serializeUser` to handle to user's session creation & the `deserializeUser` to handle extracting the user based on the session

```javascript
passport.serializeUser((user, done) => {
  console.log("🚀 ~ passport.serializeUser ~ user:", user)
  //the `id` passed below is passed as the first argument to the `deserializeUser` method
  //done(error, id)
  done(null, user.id) //the user.id will be set to the `request.session.passport.user`
})
//the id will be the value the is assigned to `request.session.passport.user`
passport.deserializeUser((id, done) => {
  console.log("🚀 ~ passport.deserializeUser ~ id:", id)
  try {
    const user = mockUsers.find(user => user.id === id);
    if (!user) throw new Error("User not found in mockUser");
    //done(err, user)
    done(null, user)
  } catch (error) {
    done(error, null);
  }
})
```

> [!IMPORTANT]  
> the `serializeUser` will be called once for the user authentication request, any other request will be handled through the `deserializeUser`

now we are ready to use `passport js`.

## Using passport js:

in the main file import this config file:

```javascript
import "./strategies/local-strategy.mjs"
```

the users data will be found in the `request.user` for the authenticated  user

will start by creating a new `POST` request endpoint and before the `request handler` use the `passport.authenticate` middleware

```javascript
//passport.authenticate('strategy`)
app.post("/api/auth", passport.authenticate("local"), (request, response) => {
  response.send({ user: request.user, sid: request.sessionID })
})
```

now we can use that data to handle other route:

```javascript
app.get("/api/auth/status", (request, response) => {
  console.log("🚀 ~ app.get ~ user:", request.user)
  console.log("🚀 ~ app.get ~ session:", request.session)
  if (!request.user) {
    return response.status(403).send("unauthorized");
  }
  return response.status(200).send(request.user);
})
```

## logout:

to logout use the `request.logout` method in your route:

```javascript
app.post("/api/auth/logout", (request, response) => {
  if (!request.user) {
    return response.sendStatus(404);
  }
  request.logOut((err) => {
    if (err) return response.sendStatus(400);
    return response.sendStatus(200);
  })
})
```
