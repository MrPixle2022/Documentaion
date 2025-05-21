<!-- @format -->

# CORS:

handling cors policy in nest is way either -and is built in- that express, though it's default is false, it can be easily toggled in the `main.ts` file, by setting the `cors` option to true in the `NestFactory`'s options, you will be able to configure the cors using `.enableCors` and passing the options

```typescript
import { NestFactory } from "@nestjs/core";
import { AppModule } from "./app.module";

async function bootstrap() {
	const app = await NestFactory.create(AppModule, { cors: true });
	app.enableCors({
		origin: ["http://localhost:4001", "http://localhost:4000"],
	});
	await app.listen(process.env.PORT ?? 3001);
}

bootstrap();
```
