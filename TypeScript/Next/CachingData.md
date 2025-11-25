<!-- @format -->

# Caching:

in next js caching works a cross multiple layers:

- Browser cache: stores static files locally
- Server cache: stores pre-rendered pages & API responses
- Data cache: caches fetched data to avoid repeated calls

---

## Cache components:

in the `next.config.ts` use :

```typescript
// next.config.js
const nextConfig = {
	cacheComponents: true, // Enable the new caching features
};
module.exports = nextConfig;
```

you can mark functions, pages, etc... to be cached by using the `"use cache"` flag which will cache it an revalidate it every 15 minutes by default.

of course we can configure the cache time using the `cacheLife` function from `next/cache`

```typescript
"use cache";
import { cacheLife } from "next/cache";

export default async function BlogPage() {
	cacheLife("days"); // Blog content updated daily

	const posts = await getBlogPosts();
	return <div>{/* render posts */}</div>;
}
```

the values we can use are:

- seconds
- minutes
- hours
- days
- weeks
- max

also we can use a custom value:

```typescript
{
  twoWeeks: {
    stale: 60 * 5, //how long can the client use the date without re-cheeking the server
    revalidate: 60 * 60 * 24 * 14, // how often does the server regenerates the data
    expire: 60 * 60 * 24 * 365 // the max time before the server must revalidate
  }
}
```

the same configuration can be used in the `next.config.ts` as to define custom cache profiles:

```typescript
import type { NextConfig } from "next";

const nextConfig: NextConfig = {
	cacheComponents: true,
	cacheLife: {
		biweekly: {
			stale: 60 * 60 * 24 * 14, // 14 days
			revalidate: 60 * 60 * 24, // 1 day
			expire: 60 * 60 * 24 * 14, // 14 days
		},
	},
};

export default nextConfig;
```

then use the profile:

```typescript
cacheLife("biweekly");
```

> [!TIP] you can also overwrite the default profiles

---

## Cache tag:

the `cacheTag` function can be used to group different cached values together for easier invalidation

```typescript
"use cache";
import { cacheTag } from "next/cache";
// ----
cacheTag("data_api");
```

and then we can revalidate the group by using the `revalidateTag` -any where on the server- function & updateTag (specifically in Server Actions for read-your-writes consistency).

an example of the `cacheTag`:

```typescript
// lib/db.ts
"use cache";
import { db } from "./your-database-client";
import { cacheTag } from "next/cache";

export async function getProductsByCategory(category: string) {
	cacheTag(`products-${category}`);
	return db.product.findMany({ where: { category } });
}
```
