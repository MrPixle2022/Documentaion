# Next-auth:

navigation:

- [setup](#setup)
- [using next auth](#using-next-auth)
- [add users to db](#adding-the-user-to-the-db)
- [using the signOut](#signout)
- [login using user's credentials](#credentials)

---

## setup:

install `next-auth v5` via:

```powershell
pnpm add next-auth@beta
```

then in your `.env.local` create:

- `AUTH_SECRET`: a random value that is used to encrypt the user's token etc... 
- `AUTH_URL` :  

then create an `auth.js` file.

in it you specify the auth configurations:

```javascript
import NextAuth from "next-auth";
import GitHub from "next-auth/providers/github"

export const { handlers, auth, signIn, signOut } = NextAuth({
  providers: [GitHub //uses github
    ({
      clientId: process.env.GITHUB_ID,
      clientSecret: process.env.GITHUB_SECRET
    }),
  ],
  
})
```

then create a `api/auth\[...nextauth]\route.js` to handle all request then export the `GET` & `POST` found in the `handlers`:

```javascript
import { handlers } from "@/lib/auth";

export const { GET, POST } = handlers;
```

---

## using next-auth

since we added the `github` provider there we will first work on using it.

first create a `server action` to handle the github auth.

```javascript
export async function handleGitHub() {
  await signIn("github"); //the signIn is exported from the `auth.js` file
}
```

the `signIn` is an async function that takes the type of `provider` and an `options` object which is not essential for github.

the you can check if the user is authenticated in any page using the return of the `auth` function

```javascript
const session = await auth();
```

then use the `session.user` to access the data of the user.

---

## adding the user to the db

but now we want to add the github user to our db so we have to edit the signIn functions.

in the `auth.js` file:

```javascript
import NextAuth from "next-auth";
import GitHub from "next-auth/providers/github"


export const { handlers, auth, signIn, signOut } = NextAuth({
  providers: [GitHub
    ({
      clientId: process.env.GITHUB_ID,
      clientSecret: process.env.GITHUB_SECRET
    }),
  ],
  callbacks: {
    async signIn({ user /* the users data*/, account /*the github account data*/, profile/*the data stored in the profile*/ }) {
      if (account?.provider === "github") {
        connectToDb();
        try {
          const user = await User.findOne({ email: profile?.email });
          if (!user) {
            const newUser = new User({
              userName: profile?.login /*-name may vary depending on the provider*/,
              email: profile?.email,
              img: profile?.avatar_url /*-name may vary depending on the provider*/,
            })

            await newUser.save();
          }
        } catch (error) {
          console.log(error)
          return false
        }
      }
      return true;
    }
  }
})
```

---

## signOut:

```javascript
export async function handleLogout() {
  await signOut();
}
```

use it like this to signOut of the account.


----

## Credentials:

to use the Credentials import the `CredentialsProvider` from `next-auth/providers/credentials`

```javascript
import CredentialsProvider from "next-auth/providers/credentials"
```

then:

```javascript
import NextAuth from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials"
import { connectToDb } from "./utils";
import { User } from "./models";
import bcrypt from "bcryptjs";

const login = async (credentials) => {
  try {
    connectToDb();
    const user = await User.findOne({ email: credentials?.email });
    if (!user) {
      throw new Error("user not found");
    }
    const isPasswordCorrect = await bcrypt.compare(credentials?.password, user?.password);
    if (!isPasswordCorrect) {
      throw new Error("wrong credentials");
    }
    return user;
  } catch (error) {
    console.log("🚀 ~ login ~ error:", error)
    throw new Error("failed to login")
  }
}

export const { handlers, auth, signIn, signOut } = NextAuth({
  providers: [
  CredentialsProvider({
    async authorize(credentials) {
      try {
        return await login(credentials)
      } catch (error) {
        return null
      }
    }
  })
  ],
})
```

now create a `server action` to handle the login or register.

```javascript
export async function register(formData) {
  const { userName, email, password, passwordRepeat, img } = Object.fromEntries(formData);
  if (password !== passwordRepeat) {
    return "password doesn't match"
  }
  try {
    connectToDb();
    const user = await User.findOne({ email });
    if (user) {
      return "user already exists"
    }
    const salt = await bcrypt.genSalt(10);
    const hashedPassword = await bcrypt.hash(password, salt);
    const newUser = new User({
      email,
      password: hashedPassword,
      userName,
      img,
    })

    await newUser.save();
  } catch (error) {
    console.log("🚀 ~ register ~ error:", error)
    return { error: "error" }
  }
}

```

then use it with the login form.