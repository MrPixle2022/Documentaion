# Next js app router

navigation:

- creating pages
- navigating

---

next js provides it's unique way of handling routing, through using the `app` folder you can create routes even use queries or dynamic path params.

## Static pages

using the app router you can just create a folder with the name of the route then add a `page.tsx` to create the page.
So for example `app/about` -> `/about`.

---

## Dynamic pages

following the same steps as the [Static pages](#static-pages) you create pages that can accept dynamic path params.
the only difference being that the file name must be between `[ ]`.
for example `app/posts/[id]` -> `/posts/{your value}`.

> [!IMPORTANT]
> this approach only stores the first param value. so in the case of the previous example trying to access `/posts/2/1` will throw a `404` error

though this can be changed by naming the folder `[...id]` this will be considered a catch all route that will store the params as an `array`.

later in your page you can access these params. though the method differs between `server` & `client` components.

**server components**:
they are passed as a prop named params.

```typescript
//the type defining the props & the path params
type ProfileIdProps = {
  params: {
    id: string;
  }
};

export default function ProfileIdPage({
  //here the params are destructured
  params
} : ProfileIdProps) {
  //the params is destructured from the params object.
  const { id } = params;
  return (
    <div>
      <h1>{ id }</h1>
    </div>
  );
}
```

**client components**:
they require the usage of hooks like `useParams` that takes a generic type representing the params object.

```typescript
'use client';

import { useParams } from "next/navigation";

export default function DynamicId() {
  const params = useParams<{ id?: string }>();
  return (
    <div>
      <h1>{ params.id?? "hello"}</h1>
    </div>
  );
}
```
