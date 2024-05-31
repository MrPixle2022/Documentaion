# Next hooks:

---

## useRouter:

the `useRouter` is a client hook used that allows you to work with the browser history for navigation.

imported from `next/navigation` like:

```javascript
"use client"
import { useRouter } from 'next/navigation'
```

then can be used in your code.

```javascript
"use client"
import Link from 'next/link'
import { usePathname, useRouter } from 'next/navigation'
import React, { useState } from 'react'

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
'use client';

import { usePathname } from "next/navigation";

function Layout({children}){
  const path = usePathname();
  console.log("🚀 ~ Layout ~ path:", path)
  
  return <div>
    {path === '/login/admin'? (<h1>You are an admin</h1>) : (<h1>You are a user</h1>)}
    {children}
  </div>
}

export default Layout
```

---

## useSearchParams:

the `useSearchParams` is a client hook that returns the queries in the `url`.

later you can check for the query you want or get it.

```javascript
'use client';

import { useSearchParams } from "next/navigation";

function UseParamsExample() {
  const query = useSearchParams();
  console.log(query)
  return <>
    { query.has("name") && query.get("name") }
  </>
}

export default UseParamsExample
```

the `useSearchParams` has a set of useful methods like:

- `get(query)`: return the value of the given query
- `has(query)`: cheeks if the query has a value
