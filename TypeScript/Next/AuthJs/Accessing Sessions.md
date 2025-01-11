<!-- @format -->

# Accessing the session data

to access the session it differs between server & client components

---

## server components

first turn the component into an `async` function, then import `auth` from the `auth.ts` file

```typescript
const session = await auth();
```

and with that you access the session via `session.`

> [!NOTE] the session can be null so check for truthiness first

---

## client components

you need to contain you client components with the `Session Provider`

so in a layout file for example:

```typescript
import type { ReactNode } from "react";
import { auth } from "@/auth";
import { SessionProvider } from "next-auth/react";

type LayoutProps = {
	children: ReactNode;
};

export default async function Layout({ children }: LayoutProps) {
	const session = await auth();
	return <SessionProvider session={session}>{children}</SessionProvider>;
}
```

then in a client component use the `useSession` hook imported from `next-aut/react`

```typescript
"use client";
import { useSession } from "next-auth/react";

export default function ClientComponent() {
	const { data: sessionData, status } = useSession();
	return (
		<div>
			<h1>{status}</h1>
			<h1>{sessionData?.user?.username}</h1>
		</div>
	);
}
```

the hook returns:

- `data`: the session data which is usually renamed
- `status`: the status of the session, like `loading`, can be one of the following values: `authenticated`, `unauthenticated`, `loading`

> [!NOTE] the session can be null so check for truthiness first
