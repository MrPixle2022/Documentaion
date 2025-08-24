<!-- @format -->

# Models:

models represent the schema and a table in the database, we define models using `model` keyword as follows:

```prisma
model Name{
  field Type @constraint1 @constraint2
  field2 Type2 @constraint3
}
```

for example:

```prisma
model Post {
  id          String  @id @default(cuid())
  title       String
  description String
  content     String
  published   Boolean @default(false)
}
```

having define your models now apply those changes to the database:

```bash
# syncs your schemas with the database ,doesn't generate a migration only, use carefully
pnpm prisma db push

# For 255 exit code use:
bun add @prisma/client@latest
```

for migrations use:

```bash
pnpm prisma migrate dev
```

---

## Data types:

in prisma we have many data types like for example:

- String: used for text, uuid, cuid
- Int: a whole number
- Bigint: a large integer
- FLoat: a floating-point number
- Decimal: a fixed-point number
- Boolean: a boolean value
- DateTime: a date and time value
- JSON: a JSON value -schema less data-
- Bytes: a binary value, useful for storing images or files

on these types we can add a modifier to them:

- `?`: to make the field optional
- `[]`: to make the field as an array
