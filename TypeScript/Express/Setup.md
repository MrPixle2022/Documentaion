# Setup:

to setup `express` with typescript first initialize a new project using:

```powershell
pnpm init

#or use

npm init -y
```

then install:

```powershell
pnpm add typescript @types/express -D #adds typescript and express types as a dev dependency

pnpm add express
```

now you can initialize tsc here using:

```powershell
tsc --init
```

then configure the typescript compiler as you like.

now we need to monitor the changes and updated the server on save so we will need two more packages.

```powershell
pnpm add nodemon ts-node -D
```

and for sure we have to install `dotenv` to access the `.env` file

```powershell
pnpm add dotenv
```

now in the `package.json` setup a script to run the server:

```json
"scripts": {
    "dev": "pnpm nodemon <path to the .ts file>"
  },
```

