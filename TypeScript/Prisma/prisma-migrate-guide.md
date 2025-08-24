# A Guide to `prisma migrate`

`prisma migrate` is a powerful tool for managing your database schema changes in a declarative and predictable way. It has different commands tailored for various stages of your development lifecycle, from local development to production deployment.

Let's break down the different ways you can use `prisma migrate`.

## 1. Development Workflow: `prisma migrate dev`

This is the command you'll use most often during development. It's designed to be an interactive command that helps you evolve your database schema as you update your `schema.prisma` file.

### What it does:
1.  **Compares Schemas:** It compares your current `schema.prisma` file with the state of your development database.
2.  **Generates SQL:** It generates a new SQL migration file in the `prisma/migrations` directory based on the changes.
3.  **Applies Migration:** It applies the newly generated migration to your development database.
4.  **Ensures Sync:** It ensures your database schema is in sync with your Prisma schema.
5.  **Generates Prisma Client:** It runs `prisma generate` to update your Prisma Client to reflect the new schema.

### How to use it:

When you make a change to your `schema.prisma` file, you run:

```bash
prisma migrate dev
```

Prisma will prompt you for a name for the new migration. It's good practice to give it a descriptive name.

```bash
# You can also provide a name directly with the --name flag
prisma migrate dev --name add-user-roles
```

### Common Flags for `migrate dev`:

*   `--name <name>`: Specifies the name of the migration, skipping the interactive prompt.
*   `--create-only`: Creates the migration file but does not apply it to the database. This is useful if you want to inspect the generated SQL before running it.
*   `--skip-generate`: Skips running `prisma generate` after the migration.
*   `--skip-seed`: Skips running the seed script after the migration.

## 2. Production/Staging Workflow: `prisma migrate deploy`

This command is designed for non-interactive environments like your CI/CD pipeline or when deploying your application. It is the **only** command you should use to apply migrations in production.

### What it does:
1.  **Applies Pending Migrations:** It checks the `_prisma_migrations` table in your database and the `prisma/migrations` folder in your codebase and applies all migrations that have not yet been applied.
2.  **Non-interactive:** It never asks for input and will not attempt to generate new migration files or warn you about schema drift. It simply applies existing migration files.

### How to use it:

```bash
prisma migrate deploy
```

This command will apply all pending migrations and exit. It's safe to run on every deployment, as it will only apply migrations that haven't been applied yet.

## 3. Managing and Inspecting Migrations

Prisma provides several commands to help you understand and manage the state of your migrations.

### `prisma migrate status`

This command gives you a report on the status of your database migrations without making any changes. It's useful for checking if your database is in sync with your schema and migration files.

```bash
prisma migrate status
```

The output will tell you which migrations have been applied and if there are any pending migrations.

### `prisma migrate reset`

This command is for **development environments only**. It's a quick way to reset your database to a clean state.

**What it does:**
1.  Drops the database (or tables).
2.  Re-applies all migrations from the beginning.
3.  Runs your seed script (if you have one).

```bash
# This will prompt for confirmation as it's a destructive action
prisma migrate reset
```

### `prisma migrate resolve`

This command is a powerful tool for resolving discrepancies between your migration history folder, the `_prisma_migrations` table in your database, and the actual database schema (a situation known as "drift"). It allows you to tell Prisma that a migration has been applied or rolled back without actually running the SQL.

**When to use it:**
*   You manually applied a hotfix in production and need to mark a migration as applied.
*   You manually reverted a change and need to mark a migration as rolled back.

**How to use it:**

```bash
# Mark a specific migration as successfully applied
prisma migrate resolve --applied "20240521100000_add_user_roles"

# Mark a specific migration as rolled back (no longer applied)
prisma migrate resolve --rolled-back "20240521100000_add_user_roles"
```

## How to "Move" in Migration History (Rollbacks)

Prisma has a specific philosophy: it favors generating new migrations to correct issues over providing a `down` or `rollback` command. This makes the migration history a reliable, forward-only log of changes.

If you need to undo a migration, here are the recommended approaches:

### 1. The "New Migration" Approach (Recommended)

1.  **Revert Schema:** Change your `schema.prisma` file back to the state it was in before the migration you want to undo.
2.  **Create a New Migration:** Run `prisma migrate dev`. Prisma will detect the changes and create a *new* migration file that effectively reverses the last one.
    ```bash
    prisma migrate dev --name "revert-add-user-roles"
    ```
3.  **Deploy:** Commit and deploy this new migration.

### 2. The "Manual Revert" Approach (For Development)

This is useful when you've just created a migration locally, haven't pushed it, and want to start over.

1.  **Manually Revert the Database:** If you have a backup or can easily revert the SQL changes, do that first.
2.  **Mark as Rolled Back:** Use `prisma migrate resolve` to tell Prisma the migration is no longer applied.
    ```bash
    prisma migrate resolve --rolled-back "20240521100000_the_migration_to_undo"
    ```
3.  **Delete Files:** Delete the corresponding migration folder from `prisma/migrations`.
