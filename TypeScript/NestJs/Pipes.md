<!-- @format -->

# Pipes:

pipes can be used to control data, by modifying types and values making them useful for validation, nestjs already has some useful built that were motioned in the [pipes validation](Validation.md) file

---

## Generating new pipes:

using the nest cli we can use the command:

```bash
nest g pipe -pipe-name-
```

this creates a new class that is decorated by the `@Injectable` and implements the `PipTransform` interface

```typescript
import {
	ArgumentMetadata,
	HttpException,
	Injectable,
	PipeTransform,
} from "@nestjs/common";

@Injectable()
export class ValidateUserPipe implements PipeTransform {
	transform(value: any, metadata: ArgumentMetadata) {
		return value;
	}
}
```

the `value` is the actual data the pipe receives, and the `metadata` contains some specialized data that isn't that important for the most part

---

## Using pipes:

first we will configure the pipe for our need, we can use the `value` and assign it the correct type that modify it as we need, when a error happens or we find something that doesn't meet the criteria we can throw an http exception

```typescript
import {
	ArgumentMetadata,
	HttpException,
	Injectable,
	PipeTransform,
} from "@nestjs/common";
import { CreateUser } from "src/users/DTO/CreateUser.dto";

@Injectable()
export class ValidateUserPipe implements PipeTransform {
	transform(value: CreateUser, metadata: ArgumentMetadata) {
		// trying to parse the value.age to an integer
		const parseAge = parseInt(value.age.toString());
		if (isNaN(parseAge)) throw new HttpException("age must be a number", 400);
		return value;
	}
}
```

note that in this example we aren't modifying the data, just cheeking for if age can be parsed

then use the pip for the body using:

```typescript
@Body(ValidateUserPipe) body: CreateUser,
```

---

## Using global pipes:

for pipes that are to be used globally we can add them in the `main.ts` file using the `useGlobalPipes`:

```typescript
async function bootstrap() {
	const app = await NestFactory.create(AppModule);
	// whitelist: only defined properties are allowed, others are omitted
	app.useGlobalPipes(new ValidationPipe({ whitelist: true }));
	await app.listen(process.env.PORT ?? 3333);
	console.log(`http://localhost:${process.env.PORT ?? 3333}`);
}
```
