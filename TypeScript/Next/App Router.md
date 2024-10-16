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

## dynamic path params

following the same steps as the [Static pages](#static-pages) you create your pages that can accept path params.
the only difference being the the file name must be between `[ ]`.
for example `app/posts/[id]` -> `/posts/{your value}`.

> [!IMPORTANT]
>
> this approach only stores the first param value. so in the case of the previous example trying to access `/posts/2/1` will throw a `404` error

though this can be changed by naming the folder `[...id]` this will be considered a catch all route that will store the params as an `array`.
