# Getting the user's session:

to get the session data import the `auth` function from `auth.js`.

the data is stored in the `session.user`.

at first the only value inside the `user` is the `email`

```javascript
import { auth, signOut } from "@/auth";

async function HomePage() {
  const session = await auth();
  console.log("🚀 ~ HomePage ~ session:", session)
  return (
    <div>
      <h1>{ session?.user?.name }</h1>
      { session && <form action={ async () => {
        "use server"
        await signOut({ redirectTo: "/login" })
      } }>
        <button>SignOut</button>
      </form> }
    </div>
  );
}

export default HomePage;
```

---

# Adding the users information to the session:

in the `auth.js` file in the `callbacks` will add 2 methods:
- `jwt`: destructure the `token` and the `user`(credentials)
- `session`: destructure the `session` and the `token`

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
          return null;
        }
        return user;
      } catch (error) {
        throw new Error(error);
      }
    }
  })],
  callbacks: {
    //handles the jwt process
    jwt({ token, user }) {
      console.log("🚀 ~ jwt ~ user:", user)
      console.log("🚀 ~ jwt ~ token:", token)
      if (user) { // User is available during sign-in
        token.id = user.id;
        token.name = user.userName;
      }
      return token;
    },
    session({ session, token }) {
      console.log("🚀 ~ session ~ session:", session)
      console.log("🚀 ~ session ~ token:", token)
      session.user.id = token.id
      session.user.name = token.name;
      return session
    },
  },
})
```
