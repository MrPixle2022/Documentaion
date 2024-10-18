# Api Routes

as shown in the [route](SpecialFiles.md#route) special file. API routes allows you to run backend logic on the server.

navigation:

- [request methods](#request-methods)
- [sending responses](#sending-responses)
- [reading the body data](#reading-a-request-body)
- [accessing query & path params](#accessing-search--path-params)

---

## Creating Request methods

first start by creating a route file, in that file **export** & create an **async** function with name of the verb **ALL Caps**:

```typescript
import { NextResponse , NextRequest} from "next/server"
/*
get -> GET
post -> POST
...
*/
export async function GET() {
  return NextResponse.json({msg: "Hello, Next.js!"})
}
```

in this `route handler` you define the logic of the handler.

`Route handlers` can take multiple params that will be shown later.

---

## Sending responses

by using either the native `Response` object or the better `NextResponse` you can send data back again.

```typescript
import { NextResponse , NextRequest} from "next/server"

export async function GET() {
  //response -> {msg: "Hello, Next.js!"}
  return NextResponse.json({msg: "Hello, Next.js!"})
}
```

---

## Reading a request body

similar to how you would convert a response into json via the `fetch` api, Next js provides a `NextRequest` parameter that contains a lot of data about the request like the body & an async `json` to convert it into json format.

the `request` is passed as a params to the `route handler`

```typescript
export async function POST(req: NextRequest) {
  const data = await req.json();

  return NextResponse.json({ message: data })
}
```

---

## Accessing search & path params

accessing path params & search queries is different, the first is accessed via a second param `context` & the later is in the request param.

```typescript
import { NextResponse, NextRequest } from 'next/server'

type ContextType = { params: { userId: string } }

export async function POST(request: NextRequest, context: ContextType ) {
  const data = await request.json();
  console.log("🚀 ~ POST ~ data:", data)

  //accessing the search queries
  const queryParams = request.nextUrl.searchParams;
  console.log("🚀 ~ POST ~ queryParams:", queryParams)

  //accessing the path params
  const { userId } = context.params;
  return  NextResponse.json({ id: userId });
}

```
