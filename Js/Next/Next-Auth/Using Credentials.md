# Login using user credentials:

first in the `auth.js` import the `CredentialsProvider` under any name you want, but import it from `next-auth/providers/credentials`

the add the `CredentialsProvider` to the `providers` array.

```javascript
import NextAuth from "next-auth"
import Credentials from "next-auth/providers/credentials";

export const { handlers, signIn, signOut, auth } = NextAuth({
  providers: [Credentials({
    credentials: { //these are just input fields for next auth and are not mandatory
      email: {
        title: "email",
        placeholder: "email",
        required: true
      },
      userName: {
        title: "username",
        placeholder: "username",
        required: true
      },
      password: {
        title: "password",
        placeholder: "password",
        required: true
      }
    },
  })],
})
```

---

# Adding custom logic for the authorization:

after the `credentials` object add `async authorize` this function takes the user's data(`credentials`) as an argument.

if the user is found it returns it else it returns `null`.

```javascript
import NextAuth from "next-auth"
import Credentials from "next-auth/providers/credentials";
import { getUsersData } from "./lib/data";

export const { handlers, signIn, signOut, auth } = NextAuth({
  providers: [Credentials({
    credentials: {
      email: {
        title: "email",
        placeholder: "email",
        required: true
      },
      userName: {
        title: "username",
        placeholder: "username",
        required: true
      },
      password: {
        title: "password",
        placeholder: "password",
        required: true
      }
    },
    // handle the give credentials when signing in
    async authorize(credentials) {
      const { email, password, userName } = credentials;
      try {
        const user = await getUsersData({ email, password });
        console.log("🚀 ~ authorize ~ user:", user)
        if (!user) {
          return null; //user not found
        }
        return user; // the users data for the session
      } catch (error) {
        throw new Error(error);
      }
    }
  })],
})
```