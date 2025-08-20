# Navigation

## Client side

by importing the `useRouter` hook in a client component like:

```typescript
"use client";

import { useRouter } from "next/navigation";
```

> [!IMPORTANT]
> be sure it's imported from `next/navigation` not from `next/router`

then create an instance by calling the hook.

```typescript
const router = useRouter();
```

this `router` has methods that allow you to not only navigate different pages but also control the history of your app.

```typescript
router.push("/home")
// router.push(href: string) -> navigates to the given `href` & adds a new entry in the browser history

router.replace("/contact")
// router.replace(href: string) -> navigates to the given href & replace the entry to the current page with that of the href

router.refresh()
//simply refreshes the current route

router.prefetch("about")
// router.prefetch(href: string) -> prefetches the given href for faster loading on the client side

router.back()
router.forward()
//simply go to the previous entry in the browser history or to the next one
```

an example of using the `useRouter`:

```tsx
"use client";

import { useRouter } from "next/navigation";
export default function ProfilesPage() {
  const router = useRouter();
  return (
    <div>
      <ul className="">
        {
          [1, 2, 3, 4, 5].map((id) => (
            <li key={ id } onClick={() => router.push(`/profile/${ id }`)}>{ id }</li>
          ))
        }
      </ul>
    </div>
  );
}
```

---

## Using the Link Component

using the `Link` component that is imported from `next/link` you can set a simple link to navigate between the pages just simply by using the `href` prop.

```typescript
import Link from "next/link";
export default function ProfilesPage() {

  return (
    <div>
      <ul className="">
        {
          [1, 2, 3, 4, 5].map((id) => (
            <Link href={`/profile/${id}`} key={id}>
              <li className="">{ id }</li>
            </Link>
          ))
        }
      </ul>
    </div>
  );
}

```

also the `href` can take an object with `pathname` for the href & `query` which is an object with keys & values representing the query params

```typescript
import Link from "next/link";
export default function ProfilesPage() {

  return (
    <div>
      <ul className="">
        {
          [1, 2, 3, 4, 5].map((id) => (
            <Link href={ {
              pathname: `profile/${id}`,
              query: {
                username:"amr"
              }
            }} key={ id }>
              profile
              <li className="">{ id }</li>
            </Link>
          ))
        }
      </ul>
    </div>
  );
}
```

also you can add the `prefetch`  which is a boolean to set wether the href is to be prefetched or not
