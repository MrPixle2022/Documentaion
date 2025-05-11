<!-- @format -->

# Setup:

---

## Installation:

first install the nestjs cli globally using:

```powershell
pnpm i -g @nestjs/cli
```

then use the cli to create a new app:

```powershell
nest n -project-name-
#Or
nest new -project-name-
```

also you can pass flags like `-s` to not install the packages & `-g` to not initialize a git repo

---

## File structure:

nest js stores all source code in the `src` directory, each `module` -the building basis of nest- is made of 3 sections, a `.module.ts` for the module configuration, `.controller.ts` to set the api end points and control the flow, `.service.ts` which the source of the logic and the functionality. all of these pieces can be created using the nest cli

---

## Running the server in dev mode:

use the command:

```powershell
pnpm start:dev
```

the default port is `3000` which can be changed in the `main.ts`, the `main.ts`'s bootstrap function is where you would add things like middlewares, passport js strategies ,etc...
