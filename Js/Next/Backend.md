# Backend with Next:

- [file structure](#file-structure)
- [route handlers](#get-post-delete-etc)
- [middlewares](#middlewares)

---

## file structure:

to start working on the backend simply create the `api` folder, then specify the routes like normal, it supports dynamic routes as well as normal ones, the only difference being that you don't create a `page.jsx` file but rather a `route.js` file.

you can use that route in the browser to interact with the response.

---
## GET, POST, DELETE, etc...:

to handle any request type in next js you first have to create an **async function** to handle the data and each one must return a `NextResponse`.

the route handlers must have the name of `GET, POST, DELETE, etc..` depending on the request type it handles & all of them must be **named exports**.

all of them accept two arguments:

- request : the actual request sent
- context: an object containing one value `{params}`

the `params` holds the value of the dynamic route.

```javascript
import { NextResponse } from "next/server";

// DELETE or the handler type
export async function DELETE(request, {params }) {
  const data = await request.json();
  return NextResponse.json({data, id: params.id}, {status: 200});
}
```

of course you can use the `NextResponse` for something like redirecting , etc..

---

## middlewares:

to use middlewares create a `middleware.js` or `.ts` in the root of your app(outside the app or src). 

in next you can only have one middleware file per project, further more you can specify which routes can use middle wares via exporting a config var.

```javascript
import { NextResponse } from "next/server";

export const config = {
  /*an array of routes that will use this middleware, this will work for userslist route and anything afterwards*/
  matcher: ['/userslist/:path*']
}

export function middleware(req){
  if(req.nextUrl.pathname != '/login'){
    //redirects the user to the /login page from the root of the req aka the `req.url`
    return NextResponse.redirect(new URL('/login', req.url));
  }
}
```
