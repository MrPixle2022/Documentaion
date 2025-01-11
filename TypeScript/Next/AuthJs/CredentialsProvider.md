<!-- @format -->

# Credentials Provider

to authenticate the users by their credential (`email` and `password`) go to the `auth.ts` file and import the `Credentials` provider.

```typescript
import Credentials from "next-auth/providers/credentials";
```

then in the `providers` array use the `Credentials` provider and pass the configuration object as a param.

```typescript
providers: [

  CredentialsProvider({
    name: "credentials",//chose the name you like
    credentials: { //defines the input fields created at the sign in from, access at /api/auth/signin
      email: { type: "email", placeholder: "example@example.com" },
      password: { type: "password", placeholder: "*********" },
    },
  }),
],
```

this defines our fields, but how still we must define the authentication process.

below to `credentials` create an `async` function named `authorize` to handle the authentication process.

```typescript
providers: [
  CredentialsProvider({
    name: "credentials",
    credentials: {---},
    authorize: async (credentials) => {
      console.log("🚀 ~ authorize: ~ credentials:", credentials);
      const { email, password } = credentials; //extracting the credentials

      if (!email || !password) {
        throw new CredentialsSignin({
          cause: CREDENTIALS_QUERY_ERRORS.LAKING_CREDENTIALS,
        }); //throwing a signIn error
      }

      await ConnectDb();
      const existingUser = await UserModel.findOne({
        email,
      });

      console.log("🚀 ~ authorize ~ existingUser:", await existingUser);

      if (!existingUser)
        throw new CredentialsSignin({
          cause: CREDENTIALS_QUERY_ERRORS.USER_NOT_FOUND,
        });

      if (password !== existingUser.password)
        throw new CredentialsSignin({
          cause: CREDENTIALS_QUERY_ERRORS.WRONG_CREDENTIALS,
        });

      const userData = {
        username: existingUser.username,
        email: existingUser.email,
        role: existingUser.role,
        tags: existingUser.tags,
      }; //setting the data to return
      console.log("🚀 ~ authorize ~ userData:", userData);
      return userData;
    },
  }),
],
```

now the user can authenticate by signing in with their credentials.
