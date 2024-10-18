# Special files

next js allows you to use special file to customize and control the behavior of the wep app.

the special files are:

- [page](#page)
- [layout](#layout)
- not-found
- error
- route

---

## page:

in any directory the `page.tsx` file is the file representing the unique ui that will be rendered for that route.

in brief the `page` file is just the structure of the page, it is a component that within you specify wether the page is to be considered a `client` or `server`(default) and set the logic that will be passed to children components

```typescript
import Image from "next/image";
import Link from "next/link";

export default function ProfilesPage() {
  return (
    <div>
      <Image alt="an old image made with blender" src="/Old.jpg" width={ 72 } height={ 16 } className="mx-2 mb-1"/>
      <div className="relative w-20 h-20 ml-2">
        <Image alt="an old image made with blender" src="/New.jpg" fill quality="1"/>s
      </div>
      <ul className="">
        {
          [1, 2, 3, 4, 5].map((id) => (
            <Link href={ {
              pathname: `profile/${id}`,
              query: {
                username:"amr"
              }
            }} key={ id } prefetch>
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

---

## layout

by naming a file `layout.tsx` or `.ts` you can create a layout. it's essentially just a component with ui that well be shared among the components at the same level and their children. layouts can be nested but only the main one (found at /app) can have `html & boy` tags.

> [!IMPORTANT]
> for a layout to render the actual page it must take a children prop.

```typescript
import type { ReactNode } from 'react';

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {

  return (
    <section className='w-screen h-screen bg-gray-300 text-black'>
      {children}
    </section>
  );
}

```

---

## route

the `route` file represents the backend logic(API routes) ran by the next server. in the route you specify how the route will response to different request verbs.

> [!NOTE]
> the `route` files's route follows the same rules as the `pages`

```typescript
import { NextResponse , NextRequest} from "next/server"

export async function GET() {
  return NextResponse.json({msg: "Hello, Next.js!"})
}

```
