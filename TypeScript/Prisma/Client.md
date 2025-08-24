# Prisma client:

the prisma client is the part that allows you to use the ORM in your code, it's automatically generated when migrating or pushing changes to the database.

---

## Client instance:

create `src/lib/db.ts` file which will export the single client instance that will be used throughout the application.

```typescript
import { PrismaClient } from "@prisma/client";

const prismaSingleton = () => {
	return new PrismaClient();
};

declare const globalThis: {
	prismaGlobal: ReturnType<typeof prismaSingleton>;
} & typeof global;

export const prisma = globalThis.prismaGlobal ?? prismaSingleton();

export default prisma;
if (process.env.NODE_ENV !== "production") globalThis.prismaGlobal = prisma;

```
