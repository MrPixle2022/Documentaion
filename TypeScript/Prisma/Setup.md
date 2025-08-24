<!-- @format -->

# Setup:

start by creating a nextjs project and adding prisma to it:

```bash
pnpm create next-app@latest
# then add prisma
pnpm add prisma --save-dev
```

having done so now we can initialize prisma, to initialize prisma we must define our database, this is done via the `--datasource-provider` option for this tutorial it is gonna be `sqlite`.

```bash
pnpm prisma init --datasource-provider sqlite
```

this command will generate the `prisma/schema.prisma` file where we define the schema of our database through **models**, each **model** represents a table in the database.

also this will generate a `.env` file with a key that hold the connection string.

for the `prisma/schema.prisma` file we have:

```prisma
// the generator
generator client {
  provider = "prisma-client-js"
}
// the connection
datasource db {
  provider = "sqlite"
  url      = env("DATABASE_URL")
}
```
