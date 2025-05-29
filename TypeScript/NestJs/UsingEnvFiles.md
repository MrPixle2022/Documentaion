<!-- @format -->

# Using Nest config for .env:

nest has a `@nestjs/config` package that can be very useful when using a .env file

use:

```bash
pnpm add @nestjs/config
```

then in the `app.module` or another dedicated module import it and use the `.forRoot` or `.forFeature` depending on where you are using it.

```typescript
@Module({
  imports: [
    ---,
    ConfigModule.forRoot({isGlobal: true}),
  ],
  controllers: [---],
  providers: [---],
})
export class AppModule {}
```

this module uses `dotenv` under the hood and includes a service that can be used:

```typescript
import { Injectable } from "@nestjs/common";
import { ConfigService } from "@nestjs/config";
import { PrismaClient } from "@prisma/client";

@Injectable()
export class PrismaService extends PrismaClient {
	constructor(private configuration: ConfigService) {
		super({
			datasources: {
				db: { url: configuration.get("DATABASE_URL") },
			},
		});
	}
}
```

the `nestConfig` package uses getters and setter to deal with .env values
