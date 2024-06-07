# Installing Next auth:

to install next auth `v5` use:

```powershell
pnpm add next-auth@beta
```

then generate a new auth secret via:

```powershell
npx auth secret
```

then in the `.env.local` file create `AUTH_SECRET` which is the key that will be used to encrypt the tokens.

---

# Auth config:

start by creating a `auth.js` at the same level as the `app` folder. the name is not mandatory.

in that folder import `NextAuth` from `next-auth` then export `handlers, signIn, signOut, auth`.

the code will look like:

```javascript
import NextAuth from "next-auth"

export const { handlers, signIn, signOut, auth } = NextAuth({
  providers: [], //all the way via which a user can login
  callbacks: {}, // here you can customize the logic of the functions
})
```

then create a new `route` at `app/api/auth/[...nextauth]/route.js`.

in it import the `handlers` from the `auth.js` then get the `GET, POST` from it.

```javascript
import { handlers } from "@/auth" // Referring to the auth.js we just created
export const { GET, POST } = handlers
```

now the last thing is to use a middleware to keep the session running.

create the `middleware.js` at the root of the project.

```javascript
export { auth as middleware } from "@/auth";
```

now you are ready to implement your logic.
