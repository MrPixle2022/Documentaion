# Accessing path params & quires:

on next js you can easily access the params in the url, though the method differs if you are using server or client components.

---

## Server Components

server components by default get two props `params`(path parameters) & `searchParams`(the search query)

start by defining the type of the props then destructure the params

```typescript

type ProfileIdProps = {
  params: {
    id: string;
  },
  searchParams: {
    username?: string
  }
};

export default function ProfileIdPage({
  params,
  searchParams: quires //renaming the searchParams to quires
} : ProfileIdProps) {
  const { id } = params;
  return (
    <div>
      <h1>{ id }</h1>
      {quires.username || "none"}
    </div>
  );
}
```

---

## Client Components

on client components you get access to `hooks` that help you access the params quicker.

by using `useParams` & `useSearchParams` that are found in `next/navigation` you can access the path and search params respectfully.

```typescript
'use client';

import { useParams } from "next/navigation";
import { useSearchParams } from "next/navigation";

export default function DynamicId() {
  const params = useParams<{ id?: string }>();
  const quires = useSearchParams();
  //quires.get(value) -> string;
  //quires.getAll(value) -> string[];
  // quires.has(value) -> boolean;
  //quires.keys() -> string[];
  //quires.values() -> string[];
  return (
    <div>
      <h1>{ params.id ?? "hello" }</h1>
      <h2 className="">{ quires.get("username") || "" }</h2>
    </div>
  );
}
```

> [!NOTE]
> the useSearchParams is a readonly object & is an es6 object
