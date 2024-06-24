# Setup:

to setup express with typescript we do the same as initializing a new express app with js.

first initialize a new project using

```powershell
pnpm init
#or 
npm init -y
```

then we are ready to install the first dependency `express`:

```powershell
pnpm i express
#or
npm i express
```

then we install the dev dependencies:

```powershell
pnpm i typescript @types/express ts-node nodemon
#or
npm i typescript @types/express ts-node nodemon
```

then initialize a new typescript project using:

```powershell
tsc --init
```

set up your project then create your script commands:

```json
"scripts": {
  "build": "tsc --build",
  "start": "node ./dist/index.js",
  "dev": "nodemon ./src/index.ts"
},
```
