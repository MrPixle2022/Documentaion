<!-- @format -->

# Initializing the client in ts:

in a typescript file use:

```typescript
import { PrismaClient } from "./generated/prisma";
const prisma = new PrismaClient();
```

now we can use the prisma client to access the data from our code.

just keep in mind it's recommended to disconnect when leaving using the `.$disconnect` method:

```typescript
async function main() {}
main()
	.catch((err) => {
		console.error(err.message);
	})
	// this one is not needed and is absolutely optional
	.finally(() => prisma.$disconnect());
```

though prisma automatically does it by default, so the previous snippet is absolutely optional.

for another example:

```typescript
import { PrismaClient } from "./generated/prisma";
const prisma = new PrismaClient();
// you can optionally log certain data
// const prisma = new PrismaClient({ log: ["query"] });
// this will log every query that prisma runs
// another useful option is using the `omit` option to omit certain fields form the queries
//-> const prisma = new PrismaClient({omit: {user: {email: true}}});
//this will hide the email in the user model
```

> [!IMPORTANT] if you removed the `output` on the generator make sure you import the client from the `@prisma/client`
