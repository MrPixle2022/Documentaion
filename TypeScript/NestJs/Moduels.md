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
- `providers`: the list of all providers -like services files- that will be used in this module at least.
