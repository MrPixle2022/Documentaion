# Next hooks:

---

## useRouter:

the `useRouter` is a client hook that allows you to work with the browser history for navigation.

imported from `next/navigation` like:

```javascript
"use client";
import { useRouter } from "next/navigation";
```

then can be used in your code.

```javascript
"use client";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import React, { useState } from "react";

function Router() {
  const router = useRouter();
  router.push("/"); // adds a new entry to the browser history
  router.replace("/"); // navigate and replace this page in the browser history
  router.prefetch("/"); // prefetch the page
  router.refresh(); // refresh the current page
  router.forward(); // the next history entry
  router.back(); // the previous history entry
}

export default Router;
```

it has multiple useful methods like:

- `push(url)`
- `replace(url)`
- `prefetch(url)`
- `refresh()`
- `forward()`
- `back()`

---

## usePathname:

imported from `next/navigation` this hook allows you to read the path name after the domain for example:

if the url is `http://localhost:3000/login/users` it will return `/login/users`

```javascript
"use client";

import { usePathname } from "next/navigation";

function Layout({ children }) {
  const path = usePathname();
  console.log("🚀 ~ Layout ~ path:", path);

  return (
    <div>
      {path === "/login/admin" ? (
        <h1>You are an admin</h1>
      ) : (
        <h1>You are a user</h1>
      )}
      {children}
    </div>
  );
}

export default Layout;
```

---

## useParams:

the `useParams` hook allows you to access dynamic params in the `url`, it returns an object with the params.

```javascript
'use client';

import { useParams } from "next/navigation";


export default function BlogWithId() {
  const params = useParams();

  return (
    <div>
      <h1>ID: { params?.id }</h1>
    </div>
  );
}
```


---

## useSearchParams:

the `useSearchParams` is a client **`READONLY`** hook that returns the queries in the `url`.

later you can check for the query you want or get it.

```javascript
"use client";

import { useSearchParams } from "next/navigation";

function UseSearchParamsExample() {
  const query = useSearchParams();
  console.log(query);
  return <>{query.has("name") && query.get("name")}</>;
}

export default UseSearchParamsExample;
```

the `useSearchParams` has a set of useful methods like:

- `get(query)`: return the value of the given query
- `has(query)`: cheeks if the query has a value

since the `useSearchParams` is **`READONLY`** you can no longer use the `set` method but there are solutions like using a `Link` to change the params like:

```javascript
'use client';

import Link from "next/link";
import {useSearchParams, usePathname } from "next/navigation";


export default function BlogWithId() {
  const searchParams = useSearchParams();
  const pathName = usePathname();

  return (
    <div>
      <h1>{ searchParams?.get("age") || "check again" }</h1>
      <Link href={ `${pathName}?size=xl` }>{ searchParams.get("size") }</Link>
    </div>
  );
}
```

or use update it via the `URLSearchParams`. 

this one can be used directly in code and is instantiated via the `new` keyword, pass it the `searchParams` and use the `set` method to set the `key`, `value`.

but note it won't update the url directly.