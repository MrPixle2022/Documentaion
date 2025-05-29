<!-- @format -->

# Migrations:

when in development you may decide to change the schema of your models, things like renaming columns, tables, adding/removing constraints or even adding and removing tables.

when these changes occur you have two options:

1. DROP the database or table and start again
1. migrate your changes and let the orm handle these changes itself

when in devolvement use the `migrate dev` command:

```bash
# migrate a dev mode migration named init
pnpm prisma migrate dev --name init
# or add reset before dev to drop the previous data
```

just know that not providing a name will trigger a prompt asking for a migration name.

the output is a migration folder with an `.sql` file with the sql required to commit those changes.

> [!TIP] prisma by default will re-generate the client on migration
