<!-- @format -->

# Type Extensions

to extend and modify the default types used by next-auth you can use the `declare` keyword to declare a new module. typescript will automatically merge the types with the same type name.

you can use that directly in the `auth.ts` or create `.d.ts` file for that.

```typescript
import { CredentialsSignin } from "next-auth";

declare module "next-auth" {
	//the user type used in the `jwt` function
	interface User {
		username: string;
		email?: string | null;
		role: "user" | "admin";
		tags: string[];
	}
	interface Session {
		//the user in the session object
		user: { email?: string | null } & UserType & DefaultSession["user"];
	}
}
```
