<!-- @format -->

# Validation:

first install two packages as dev dependencies using:

```bash
pnpm install -D class-validator class-transformer
```

then in your DTO class import the decorators from 'class-validator'

for example:

```typescript
import { IsNotEmpty, IsString } from "class-validator";

export class CreateUser {
	@IsNotEmpty()
	username: string; // username must not be empty

	@IsNotEmpty()
	@IsString()
	email: string; //email must be a non-empty string
}
```

there are a lot of useful validation decorators like `@IsEmail()` to check if the string is an array

now to register this validation we must use the `@UsePipes()` decorator before the endpoint you want to validate and pass it a new instance of the `ValidationPipe` class.

```typescript
/* eslint-disable prettier/prettier */
import {
	Body,
	Controller,
	Get,
	Post,
	Res,
	UsePipes,
	ValidationPipe,
} from "@nestjs/common";
import { Request, Response } from "express";
import { CreateUser } from "./DTO/CreateUser.dto";

// tracks all request to /users, / is the app.controller
@Controller("users")
export class UsersController {
	@Post("/new")
	@UsePipes(new ValidationPipe())
	createUser(@Res() response: Response, @Body() body: CreateUser) {
		console.table(body);
		response
			.status(201)
			.json({ data: { username: body.username, email: body.email } });
	}
}
```

if you have a pipe you want to use globally we can use the `useGlobalPipes` in the `main.ts` file:

```typescript
async function bootstrap() {
	const app = await NestFactory.create(AppModule);
	// whitelist: only defined properties are allowed, others are omitted
	app.useGlobalPipes(new ValidationPipe({ whitelist: true }));
	await app.listen(process.env.PORT ?? 3333);
	console.log(`http://localhost:${process.env.PORT ?? 3333}`);
}
```

---

## Built in pipes

there are some built in pipes in nest that can be used on decorators like `@Query`, `@Param` & `@Body`, etc... to force a data type and return an error on failure like `@ParseIntPipe`, `@ParseBoolPipe`, etc...

```typescript
@Get("/query")
getQuires(
  // will try to convert (?number=value) to a number if failed return status of 400
  @Query("number", new ParseIntPipe({ errorHttpStatusCode: 400 }))
  num: number,
) {
  return num;
}
```

note that it sends a json response on failure with the message but doesn't specify what exactly is wrong
