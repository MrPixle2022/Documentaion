<!-- @format -->

# Request & Responses:

to read a request or a response object import `Request` or `Req` for requests and `Response` or `Res` for responses from `@nestjs/common`, along that import `Response` & `Request` types form `express` to used for the type definition.

the `Req`, `Res`, `Request` & `Response` are decorators used in class methods argument, through the request & response most data can be accessed, or extract things like path params and body params and queries through `@Body`, `@Param` & `@Query` decorators.

---

## Reading a request body:

reading the request's body can be done in two ways, using the `@Req` or the `@Request` both are exact:

```typescript
import { Controller Post, Req } from "@nestjs/common";
import { Request } from "express";

@Controller("users")
export class UsersController {

  // POST: /users/new
  @Post("/new")
  createUser(@Req() request: Request) {
    return request.body as Record<string, any>;
  }
}
```

you will notice we used `Express.Request` for the type, as this is recommend.

for the second way is using the `@Body`:

```javascript
@Post("/new")
  createUser(
    @Req() request: Request, //read the request object
    @Res() response: Response, // add the response object
    @Body() body: Record<string, any>, // same as request.body
  ) {
    console.log("with @Body");
    console.table(body);
    console.log("with @Req");
    console.table(request.body);
    // returning a status code and a json response
    response.status(200).json({ msg: "ok!" });
  }
```

note that you still are required to define the type

also note that a string can be passed to the `@Body`, the name represents a propriety to extract from the request body

```typescript
@Get("/field")
//field will be extracted from the incoming request
returnField(@Body("field") field: string) {
  return field;
}
```

just note if the property doesn't exist field will be `undefined` though we specified the type to be only string

there is also `@Param` & `@Query` which extract the path params & query objects and optionally you can specify a specific value to extract like the `@Body`
