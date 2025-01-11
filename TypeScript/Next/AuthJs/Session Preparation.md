<!-- @format -->

# Session Preparation

the session by default doesn't have the data needed by default, so we need to add it manually via modifying the `callbacks` object.

```typescript
export const { handlers, signIn, signOut, auth } = NextAuth({
	// Configure one or more authentication providers, like Google, Facebook, GitHub, etc. or set the credentials
	providers: [----],
  callbacks: {
  async session({ token, session }) { },

  async jwt({ token, user }) {},

async signIn ({ user, account }) => {},
},
});
```

the `session` is the function responsible for modifying the session data, it is passed the `token` and `session` objects.

the `token` is the data that is used to create the session, it is passed the `user` object.

and the `signIn` is the function that is called when the user signs in, it is passed the `user` and `account` objects, returns `true` if the user can signin and false otherwise, the `account` is used to check for the provider via `account?.provider`

so first start with `jwt`

```typescript
async jwt({ token, user }) {
  if (user) {
    //and do this with all fields you want to transfer to the session
    token.sub = user.id;
    token.username = user.username;
    token.role = user.role;
    token.tags = user.tags;
    token.email = user.email;
  }
  return token;
},
```

> [!TIP] the `jwt` method can also take an `account` object, which is used to check for the provider via `account?.provider` and allows you to modify the token based on the provider since the provider may not pass all the info needed

then start with `session`

```typescript
async session({ session, token }) {
  if (token?.sub) {
    session.user.id = token.sub;
    session.user.username = token.username as string;
    session.user.role = token.role as "admin" | "user";
    session.user.tags = token.tags as string[];
    session.user.email = token.email! as string;
  }
  return session;
},
```

> [!NOTE] type casting was used since the type of the token data is `unknown`

though sometimes you don't need to modify the `signIn` method.

> [!IMPORTANT] sometimes a type error appears to handle that try to extend the types of next-auth look [Type Extensions](Extending%20Types.md).
