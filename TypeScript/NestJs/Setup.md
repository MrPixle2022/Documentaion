<!-- @format -->

# Setup:

---

start by installing the nest cli using:

```bash
pnpm i -g @nestjs/cli
```

then create a new project using:

```bash
nest new _projectName_
# alias
nest n _projectName_
```

we can add some flags like `-s` to skip installation and `-g` to not initialize a local git repo

---

## Architecture

nest's architecture is based on `modules`, which is a septate part of the app that when combined together create the entire app, in a module we define other modules this module requires, controllers and providers.

a `controller` is the part responsible for the request-response handling and the `service` -an injectable provider- which is responsible for the actual logic.

this isolation allows for easier maintenance and reusability.

it's worth noting that nest uses dependency injection and decorators, providers -like services- that are decorated by the `@injectable` decorator are instantiated once and have their reference injected into any class who requires them in their constructor

an example of dependency injection would be:

```typescript
@Controller("auth")
export class AuthController {
	constructor(private authService: AuthService) {}
}
```

this `authService` will be injected and added to the class's properties automatically by nest.

```typescript
@Controller("auth")
export class AuthController {
	constructor(private authService: AuthService) {
		this.authService = authService;
	}
}
```

this is saves the extra line where you usually will have to use:

> [!NOTE] using the `nest generate` or `nest g` command you can create any of the above:

```bash
nest g module _moduleName_
nest g service _serviceName_
nest g controller controllerName_
# optionally add --no-spec to not create a test file
```

---

## Running the server in dev mode:

use the command:

```bash
pnpm start:dev
```

the default port is `3000` which can be changed in the `main.ts`, the `main.ts`'s bootstrap function is where you would add things like middlewares, passport js strategies ,global pipes and guards, etc...

---

## Build & serve:

after completing the app if the app was already running you will notice a `dist` folder with an almost 1:1 replica of your `src` folder but in javascript instead of the typescript, this is the final build of the app, however if you want to build after making a change when the server wasn't running use:

```bash
pnpm build
```

then run it using:

```bash
pnpm start:prod
#runs the dist folder, useful when you want to run the server and don't actually plant on editing
```
