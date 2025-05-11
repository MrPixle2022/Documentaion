<!-- @format -->

# Middlewares:

middlewares a methods that run before an operation, like before the handling the request, a middleware is useful for authorization and has access to the request and response objects and the `next` middleware to proceed to the next operation

---

## Generating a new middleware:

use the `nest generate` command to create a new middleware, you can use the `middleware` argument or it's alias `mi`

```powershell
nest g mi -middleware-name-
```

this will generate a `.middleware.ts` file, whit a class that implements the `NestMiddleware` interface and is decorated by the `@Injectable` decorator, by default the request and response will be of type **any**, so you will have to assigning them their types.

```typescript
import { Injectable, NestMiddleware, Req, Res } from "@nestjs/common";
import { NextFunction, Request, Response } from "express";

@Injectable()
export class UsersMiddleware implements NestMiddleware {
	use(@Req() req: Request, @Res() res: Response, next: NextFunction) {
		next();
	}
}
```

---

## Using middlewares:

though it's decorated by the `@Injectable` class, a middleware isn't used in the `providers` array, as it requires a configuration and some changes to the `Module` file:

```typescript
import { MiddlewareConsumer, Module, NestModule } from "@nestjs/common";
import { UsersController } from "./users.controller";
import { UsersService } from "./users.service";
import { UsersMiddleware } from "./users.middleware";

@Module({
	controllers: [UsersController],
	providers: [UsersService],
})
export class UsersModule implements NestModule {
	configure(consumer: MiddlewareConsumer) {
		consumer.apply(UsersMiddleware).forRoutes("users");
	}
}
```

---

## Routing middlewares

as shown the module is required to implement the `NestModule` interface and use the `configure` method to define that it uses this middleware and this middleware works on any request to `/users`

> [!TIP] you can replace the "users" with the actual controller and it will do the same job.

also you can be more specific when with them:

```typescript
consumer.apply(UsersMiddleware).forRoutes({
	path: "/users",
	// import {RequestMethod} from "@nestjs/common"
	method: RequestMethod.GET,
});
```

so in the end, this registers the `UsersMiddleware` to work for all GET requests to `/users`, and also you can give it an another parameter that is an object of the same type

```typescript
.forRoutes(
  { path: "users", method: RequestMethod.GET },
  { path: "users/:id", method: RequestMethod.POST },
);
```

also you can exclude some routes and methods by using the `.exclude` method:

```typescript
configure(consumer: MiddlewareConsumer) {
  consumer
    .apply(UsersMiddleware)
    .forRoutes(
      { path: "users", method: RequestMethod.GET },
      { path: "users/:id", method: RequestMethod.GET },
    )
    .apply(AnotherMiddleware)
    .exclude({ path: "users", method: RequestMethod.DELETE })
    .forRoutes({ path: "users", method: RequestMethod.PATCH });
  }
```

---

## Using multiple middlewares:

you can easily use multiple middlewares by nest the `.apply().forRoutes`, for example:

```typescript
configure(consumer: MiddlewareConsumer) {
  consumer
    .apply(UsersMiddleware)
    .forRoutes(
      { path: "users", method: RequestMethod.GET },
      { path: "users/:id", method: RequestMethod.GET },
    )
    .apply(AnotherMiddleware)
    .forRoutes({ path: "users", method: RequestMethod.PATCH });
}
```
