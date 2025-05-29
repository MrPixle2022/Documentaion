<!-- @format -->

# Modules:

---

## Generating a new module:

use the command:

```powershell
nest g module -module-name-
#then use nest g controller -controller-name- to create a controller for the module
```

---

## Using modules:

a `.module.ts` is the file with the class that is decorated via the `@Module` decorator.

```typescript
import { Module } from "@nestjs/common";
import { AppController } from "./app.controller";
import { AppService } from "./app.service";
import { UsersModule } from "./users/users.module";

@Module({
	imports: [UsersModule], // here you add imported modules that this module requires
	controllers: [AppController], // an array of controllers used by this module
	providers: [AppService], // providers that will be injected in this module
})
export class AppModule {}
```

this snippet shows the root module aka `app.module.ts`, with the only exception being the `UserModule` which was created later.

as seen the `@Module` takes some options like:

- `imports`: the imports is a list containing any module the exporters a provider -like a service file- that this module requires.
- `controllers`: the controllers required for this module.
- `providers`: the list of all providers -like services files- that will be used in this module .
- `exports`: what injectable providers does this module allow other modules to use, those exports are exposed on import.

---

## Importing from other modules:

when using a module -content- outside it self, usually we add it to the `imports` array in the target module:

```typescript
@Module({
	providers: [AuthService, PrismaModule],
	controllers: [AuthController],
})
export class AuthModule {}
```

but if we try to inject a service for example from that module:

```typescript
@Injectable()
export class AuthService {
	constructor(private readonly prima: PrismaService) {}
}
```

we will have an error, that's because though the `PrismaService` is defined in the `PrismaModule`,but nest doesn't know that this can be used and injected outside the `PrismaModule`.

for that we use the `exports`:

```typescript
@Module({
	providers: [PrismaService],
	//tells nest that those are exported by this module
	exports: [PrismaService],
})
export class PrismaModule {}
```

so now any module that imports the `PrismaModule` will have the `PrismaService` able to be injected.

---

## Globally marked Modules:

if you have a module that is to be used by the entire app, or you want it to available at any time for most of the project for example, we can use the `@Global` decorator, just make sure to define the `exports` array and that the new global module is imported in the `app.module.ts` file.

```typescript
@Global()
@Module({
	providers: [PrismaService],
	exports: [PrismaService],
})
export class PrismaModule {}
```

```typescript
import { Module } from '@nestjs/common';
import { PrismaModule } from './prisma/prisma.module';

@Module({
  imports: [---, PrismaModule],
  controllers: [],
  providers: [],
})
export class AppModule {}
```

and remove it from the imports along with the service -in this example-
