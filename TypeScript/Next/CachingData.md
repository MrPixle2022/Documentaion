# Caching data

in next js you can use `cache` option in the `fetch` api to control the caching of the data.

the value can be:

- `force-cache`: the default value
- `no-cache`: will not cache the data
- `no-store`: will not store the data
- `default`: will cache the data but not store it

an example of that will be using an endpoint & a server & a client components.

api:

```typescript
import { NextResponse, NextRequest } from 'next/server'

export async function GET() {
  return NextResponse.json({ random: Math.floor(Math.random() * (1000 - 100) + 100) });
}
```

---

server:

```typescript
import Link from "next/link";

async function GetRandomNumber() {

  const response = await fetch("http://localhost:3000/api/random", { method: "GET", cache: "no-store", next:{revalidate: 10 /*in seconds*/} });
  const { random } = await response.json();
  return random;
}

export default async function RandomNumberPage() {

  return (
    <div>
      <h1 className="text-3xl text-orange-600">Server Side</h1>
      <h1>{ await GetRandomNumber() }</h1>
      <Link href="/random/csr">To client component</Link>
    </div>
  );
}

```

the `next: {revalidate: seconds}` will revalidate the data every `seconds` once the page is refreshed.

---

client:

```typescript
'use client';

import Link from "next/link";
import { useEffect, useState } from "react";

export default function RandomNumberPage() {
  const [value, setValue] = useState();
  async function getRandomNumber() {
    // default cache: no-store
    const response = await fetch("http://localhost:3000/api/random", { method: "GET", cache: "force-cache" });
    const {random} = await response.json();
    setValue(random);
  }

  useEffect(() => {
    getRandomNumber();
  }, []);
  return (
    <div>
      <h1 className="text-3xl text-orange-600">Client Component</h1>
      <h1>{ value }</h1>
      <Link href="/random/ssr">To server side</Link>
    </div>
  );
}

```

> [!IMPORTANT]
> by default server components are cached while client components are not.
