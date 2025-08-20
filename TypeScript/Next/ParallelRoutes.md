# Parallel routes:

parallel routes allows you to treat next pages as components, each parallel routes can define it's own ui for cases like:
- loading
- not found
- error

and can have children routes themselves, but they are placed by a layout as components.

---

## Define a parallel route:

to define a parallel route use `@{dirname}` and inside define your `page.tsx` and other special files.


```text
|-app
    |-split
        |-@members
            |-page.tsx
            |-loading.tsx
            |-error.tsx
        |-@comments
            |-page.tsx
            |-loading.tsx
```

for parallel routes they require a `layout.tsx` file as they are passed to it so at our `split/` we must define a `layout.tsx` file.

---

## Using parallel routes:

parallel routes are passed to `layout` props, the name is as the route's name and the type is `React.ReactNode` just like `children`.

```tsx
//layout function
export default function RootLayout({
    children,
    comments,
    members
}: Readonly<{
    //children and parallel routes
    children: React.ReactNode;
    comments: React.ReactNode;
    members: React.ReactNode;
}>) {
    return (
        <html lang="en">
            <body
                className="w-screen h-screen antialiased flex "
                suppressHydrationWarning>
                { comments }
                { members }
                { children }
            </body>
        </html>
    );
}
```

---

## Child routes:

parallel routes can have child routes themselves, we can access them via the `Link` component, let's assume this is our file structure:

```txt
|-app
    |-@members
        |-page.tsx
        |-salary
            |-page.tsx
```

in the `@members/page.tsx` we will have:

```tsx
<div className='border p-[10rem] w-[30rem]'>MembersPage
    <Link href="/salary">Salaries?</Link>
</div>
```

but note that on a **hard-reload** we will get a `404` not-found error because parallel routes aren't something to which we can navigate to.

---

## Default.tsx:

the `default.tsx` is yet a special file made specifically for parallel routes, as we said in the previous section on refreshing at the `salary` route, we will get a `404` error.

the `default.tsx` is used to show a fallback ui for such cases, but it must be at the same level as the `layout.tsx` file.

if you don't want to show any thing return null.
