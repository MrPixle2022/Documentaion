<!-- @format -->

# Controllers:

controllers are the part of a module that is responsible for receiving requests and responses, a controller is a class decorated with the `@Controller` decorator, to that decorator we pass the base url that the controller is responsible for, this will automatically be the controller name passed to `nest g controller` command.

@src/users/user.controller.tss

```typescript
import { Controller } from "@nestjs/common";

// tracks all request to /users, / is the app.controller
@Controller("users")
export class UsersController {}
```

note that a controller must be imported into it's module which is automatically done by nest generate:

```typescript
import { Module } from "@nestjs/common";
import { UsersController } from "./users.controller";

@Module({
	controllers: [UsersController],
})
export class UsersModule {}
```

---

## Requests endpoints:

defining an api endpoint is done by declaring a class method decorated with a HTTP verb decorator from `@nestjs/common` like `@Get`, `@Post`, `@Delete`, `Patch`, etc..., the class method usually returns a function from the `service` file that is injected in the constructor of the `controller`, for each http verb you can give it a string of a url to define it's route and define path params using `/:param`, if you leave it empty nest will assume it's routes to the root of this controller.

```typescript
import { Controller, Get } from "@nestjs/common";

// tracks all request to /users, / is the app.controller
@Controller("users")
export class UsersController {
  import { Controller, Get } from "@nestjs/common";

// tracks all request to /users, / is the app.controller
@Controller("users")
export class UsersController {
  //GET: /users
  @Get()
  getHello() {
    return "hello user";
  }
  // GET: /users/welcome
  @Get("/welcome")
  getWelcome() {
    return "welcome bro";
  }
}
}
```

though usually the controller would use a service file for the logic handling

> [!TIP] you can nest routes in a controller via the path passed to the http verb decorator
