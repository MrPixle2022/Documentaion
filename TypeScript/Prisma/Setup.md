<!-- @format -->

# Setup:

start by creating a new node project using:

```bash
pnpm init
```

then install the following dependencies:

```bash
pnpm i -D prisma typescript ts-node @types/node nodemon
pnpm i @prisma/client
```

then simply create a `tsconfig.json` and set the `compilerOptions` to the following:

```json
{
	"compilerOptions": {
		"sourceMap": true,
		"outDir": "dist",
		"strict": true,
		"lib": ["ESNext"],
		"esModuleInterop": true
	}
}
```

then initialize prisma and define the datasource aka the database:

```bash
# or replace the `postgresql` with your db
pnpm prisma init --datasource-provider postgresql
```

this will create a `.env` folder and some files required to define your schema in a directory called `prisma`

> [!TIP] postgresql is the default data source, you don't have to provide it

```prisma
// a generator is the configuration that prisma uses to compile your models into typescript
generator client {
  provider = "prisma-client-js"
  output   = "../generated/prisma"
}

datasource db {
  provider = "postgresql"
  url      = env("DATABASE_URL")
}
```

you can have multiple generators for multiple cases.

note that sometimes you will have to manually generate the client using:

```bash
pnpm prisma generate
```

> ![TIP] you can remove the output option on the generator and it will automatically put the client in the `@prisma/client` file in the `node_modules`

you can visualize your data using:

```bash
pnpm prisma stdio
```

which will open a nextjs page @`localhost:5555` with your models and the data of each table
