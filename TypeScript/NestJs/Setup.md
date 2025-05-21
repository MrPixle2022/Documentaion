<!-- @format -->

# Setup:

---

## Installation:

first install the nestjs cli globally using:

```bash
pnpm i -g @nestjs/cli
```

then use the cli to create a new app:

```bash
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

```bash
pnpm start:dev
```

the default port is `3000` which can be changed in the `main.ts`, the `main.ts`'s bootstrap function is where you would add things like middlewares, passport js strategies ,etc...

---

## Build & serve:

after completing the app if the app was already running you will notice a `dist` folder with an almost 1:1 replica of your `src` folder but in javascript instead of the typescript, this is the final build of the app, however if you want to build after making a change when the server wasn't running use:

```bash
pnpm build
```

then run it using:

```bash
pnpm start:prod
```
