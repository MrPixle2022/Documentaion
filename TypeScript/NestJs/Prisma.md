<!-- @format -->

# Prisma:

after installing prisma, and setting it up it's time to prepare the nest app, first create a new module and service for the prisma client, we can then use the `PrismaClient` class to inherit from, and in the `super` pass the database url:

```typescript
@Injectable()
export class PrismaService extends PrismaClient {
	constructor() {
		super({
			datasources: {
				db: {
					url: "postgresql://user:password@host/db_name",
				},
			},
		});
	}
}
```

now in the module, we want to make it global and we want to export the `PrismaService`:

```typescript
import { Global, Module } from "@nestjs/common";
import { PrismaService } from "./prisma.service";

@Global()
@Module({
	providers: [PrismaService],
	exports: [PrismaService],
})
export class PrismaModule {}
```

also make sure to include it in the `app.module.ts`:

```typescript

@Module({
  imports: [---, PrismaModule],
  controllers: [],
  providers: [],
})
export class AppModule {}
```

now we can inject this service any where:

```typescript
@Injectable()
export class AuthService {
	constructor(private prisma: PrismaService) {}

	signIn() {
		return "signed in";
	}

	signUp() {
		return "signed up";
	}
}
```
