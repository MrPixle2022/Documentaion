<!-- @format -->

# Authjs setup

in your `nextjs` project use the command:

```powershell
pnpm i next-auth@beta
```

now after that create the `.env` file to store your secrets and provider's ids etc..

but you must create a `AUTH_SECRET` that will be used by auth js.

to create a random value use the `bash command`:

```bash
openssl rand -base64 32
```

now at the root of your project create a `auth.ts` file to configure your authentication.

```typescript
import NextAuth from "next-auth";

export const { handlers, signIn, signOut, auth } = NextAuth({
	// Configure one or more authentication providers, like Google, Facebook, GitHub, etc. or set the credentials
	providers: [],
});
```

from this code we are exporting:

- `handlers`: the functions that are used to handle the authentication process in the api route that will be created later.
- `signIn`: the function that is used to sign in on server
- signOut: the function that is used to sign out on server
- `auth`: the function that is used to check if the user is authenticated and return the user and get the session.

the `providers` is just an array in which you define the authentication methods and configure each independently.

two more files before going to code the authentication:

create a middleware file to intercept the requests and check if the user is authenticated or not.

`middleware.ts`:

```typescript
export { auth as middleware } from "@/auth";
```

though you can still use your own middleware with the auth function.

```typescript
/** @format */

import { NextRequest, NextResponse } from "next/server";
import { auth } from "./auth";

export async function middleware(request: NextRequest) {
	// accessing the session if it exists
	const session = await auth();
	console.log("🚀 ~ middleware ~ request.url:", request.url);
	if (session?.user) {
		if (
			request.nextUrl.pathname === "/login" ||
			request.nextUrl.pathname === "/signup"
		)
			return NextResponse.redirect(`${request.nextUrl.origin}/`);
	}
	return NextResponse.next();
}

export const config = {
	matcher: [
		"/((?!api|_next/static|_next/image|favicon.ico|sitemap.xml|robots.txt).*)",
	],
};
```

finally create a `/api/auth/[...nextauth]/route.ts` file to handle the authentication requests.

```typescript
import { handlers } from "@/auth";

export const { GET, POST } = handlers;
```

now you are ready to start coding the authentication process.
