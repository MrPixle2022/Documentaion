<!-- @format -->

# Github Provider

to use the github provider you will have to register your app in github.

go to `https://github.com/settings/developers`, create your app and get the `client id` & `client secret` and add them to your `.env` file.

set the homepage url to you app's origin

and the callback url to `[your origin]/api/auth/callback/github`

now in you `auth.ts` add the `GithubProvider` under the credentials provider.

```typescript
import GithubProvider from "next-auth/providers/github";
```

```typescript
providers: [
  GithubProvider({
    clientId: process.env.GITHUB_ID,
    clientSecret: process.env.GITHUB_SECRET,
  }),
],
```

then finally update the `signIn` callback to handle the new method of authentication.

```typescript
callbacks:{
async signIn({ user, account }) {
  //if the user logged in via credentials allow the process to happen
  if (account?.provider === "credentials") {
    return true;
  }
  //if the user used github
  if (account?.provider === "github") {
    try {
      await ConnectDb();
      const existingUser = await UserModel.findOne({
        email: user?.email,
      });
      if (!existingUser) {
        await UserModel.create({
          username: user?.name,
          email: user?.email,
          role: "user",
          tags: [""],
        });
      }
      return true;
    } catch (error) {
      console.log("signin function error");
      console.log(error);
    }
  }
  //other than that deny the process
  return false;
},}
```

> [!IMPORTANT] git hub uses `name` for storing the name of the user.
