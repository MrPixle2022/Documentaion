# Migrations:

`prisma migrate` is the command suite used to manage and apply database schema changes.

## Development Workflow

Use `prisma migrate dev` in your local development environment. It automatically creates and applies migrations as you change your schema.

```bash
# development environment
pnpm prisma migrate dev --name <descriptive-name>
```

**Common Flags:**
*   `--create-only`: Creates the migration SQL file but does not apply it.

## Production & Staging Workflow

Use `prisma migrate deploy` in your CI/CD pipelines and production environments. It is non-interactive and only applies pending migrations. It will never create new migrations or alter your database in unexpected ways.

```bash
# production environment
pnpm prisma migrate deploy
```

## Status:

```bash
pnpm prisma migrate status
```

This command gives you a report on the status of your database migrations without making any changes. It's useful for checking if your database is in sync with your schema and migration files
