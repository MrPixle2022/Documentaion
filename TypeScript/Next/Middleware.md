# Middleware

the `middleware.ts` is one of those special files that next js looks for in the project. it's responsible for defining the main logic of the middleware that intercepts incoming requests before sending a response or rendering a page.

to create a middleware file go to the same level as the `app` folder and create a `middleware.ts` file.

> [!IMPORTANT]
> note that only one middleware is allowed

in that file export a function named middleware, it takes a request(Request | NextRequest) as a param

```typescript
import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';

export function middleware(request: NextRequest) {
  //continue with your request
  return NextResponse.next();
}
```

the middleware will intercept all requests by default but this behavior can be adjusted via the `config` object

```typescript
export const config = {
  // the matcher can be a single string or an array, it's job is to match the paths that the middleware is applied to
  // don't forget the "/" if forgotten it will not work
  matcher: ["/profile"],
};
```

in the `middleware` function you can apply logic you want like checking for authentication, etc...

```typescript
import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';

export function middleware(request: NextRequest) {
  const isLoggedIn = true;
  if (isLoggedIn) {
    // cookies can be accessed by request.cookies if the request var is of type "NextRequest"
    const cookie = request.cookies.get('hello');
    if (cookie) {
      console.table(cookie)
    //if logged in then continue with your request
    }
    return NextResponse.next();
  }

  //if not logged in then redirect to home, take the request url(2nd param) and return to it's base(1st param)
  return NextResponse.redirect(new URL('/', request.url));
}

export const config = {
  matcher: ["/profile"],
};

```
