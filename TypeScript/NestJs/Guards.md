<!-- @format -->

# Guards:

guard are used to determine if a request can be handled, they can be useful to prevent unauthorized user from accessing an important endpoint for example.

guards are decorated by the `@Injectable` decorator and implement the `CanActivate` interface

---

## Generating guards:

using the nest generate:

```bash
nest g guard -guard-name-
```

this will create the following:

```typescript
import { CanActivate, ExecutionContext, Injectable } from "@nestjs/common";
import { Observable } from "rxjs";

@Injectable()
export class UsersGuard implements CanActivate {
	canActivate(
		context: ExecutionContext,
	): boolean | Promise<boolean> | Observable<boolean> {
		return true;
	}
}
```

as shown returning **true** means the request can be handheld by the controller

---

## Using guards:

in the guard we can access the request and check it to determine wether the request can be handled or not, we do this by getting the request from the `context` like:

```typescript
import { CanActivate, ExecutionContext, Injectable } from "@nestjs/common";
import { Request } from "express";
import { Observable } from "rxjs";

@Injectable()
export class UsersGuard implements CanActivate {
	canActivate(
		context: ExecutionContext,
	): boolean | Promise<boolean> | Observable<boolean> {
		// retrieve the http data and read the request
		const request: Request = context.switchToHttp().getRequest();
		// if the authorization header is defined allow
		if (request.headers.authorization) return true;
		// else deny
		else return false;
	}
}
```

then we can use the guard on a whole controller or a single route using the `@UseGuards`

```typescript
@Controller("users")
// the guard will be used for the whole controller
@UseGuards(UsersGuard)
export class UsersController {
	/*your code*/
}
```

you can also use it for a single end point by using it to decorate that specific endpoint
