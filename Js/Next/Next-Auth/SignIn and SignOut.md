# Sign in:

to sign in create a form to sign in then create a server action.

import `signIn` from `auth.js`.

the `signIn` takes the type of `provider` as a string and the `options` as a second argument

```javascript
"use server"
import { signIn } from "@/auth"

function SignIn() {
  return (
    <form
      action={ async (formData) => {
        "use server"
        await signIn("credentials", Object.fromEntries(formData))
      } }
    >
      <label>
        Email
        <input name="email" type="email" />
      </label>
      <label>
        Password
        <input name="password" type="password" />
      </label>
      <button>Sign In</button>
    </form>
  )
}

export default SignIn;
```

---

# Sign out:

to sign out simply create another form , another server action but this time import the `signOut` method.

```javascript
import { signOut } from "@/auth";

async function HomePage() {
  return (
    <div>
      <form action={ async () => {
        "use server"
        await signOut({ redirectTo: "/login" } /*redirect the user to /login after successfully signing out*/)
      } }>
        <button>SignOut</button>
      </form>
    </div>
  );
}

export default HomePage;
```
