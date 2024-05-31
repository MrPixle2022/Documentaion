# Client and Server components:


---

## Server components:

by default next considers every component in your project a `server component`.

server components are useful for fetching data and sending less requests but they can't use hooks or event listeners, also they can be cached on the server optionally.

server components can optionally destructure multiple props passed automatically by next.

`params` : the value of the dynamic part of the url.

`searchParams`: the value of the query params

example:

```javascript
import Image from 'next/image'
import React from 'react'

function SinglePostPage({ params, searchParams }) {

  return (
    <h1>{params}</h1>
  // unlike useSearchParams this one is just a normal object 
    <h1>{searchParams?.name}</h1>
  )
}

export default SinglePostPage
```


---

## Client Component:

client component are the place where you right react code inside of next, they support hooks, event listeners, custom hooks, etc...

though you first have to tell next that a component is a client component by using the `use client` directive at the top of the file:

```javascript
"use client";
```

at the very top of your file.

client component can interact with with browser's Apis like the `local storage`.

to learn how to handle `params & search params` read:

[Next hooks](NextHooks.md)