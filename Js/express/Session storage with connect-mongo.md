<!-- @format -->

# Session storage:

the default storage used by `express-session` is the memory storage, the problem with it is that you lose all the data if the server restarts, even thought you still have the cookie, to handle the storage we could use `connect-mongo` to reuse our db connection with mongoose.

---

## setup:

install `connect-mongo` with:

```powershell
pnpm install connect-mongo
```

then import the `MongoStore` like:

```javascript
import MongoStore from "connect-mongo";
```

in the `express-session` middleware options set the `client` property to `MongoStore.create` and pass it the mongoose driver:

```javascript
store: MongoStore.create({
  client: mongoose.connection.getClient(),
}),
```

this will use the db to store the sessions, and once authenticated you will find a new collection named `session` storing each session `id` & `expire date`.

---

after using a db to store session `resave` & `saveUninitialized` will make sense.

setting `saveUninitialized` to true:

```javascript
saveUninitialized: true,
```

will save sessions of unauthenticated users

while setting `resave` to true:

```javascript
resave: true,
```

will update the session on each request, specifically the `expire` date of the session.