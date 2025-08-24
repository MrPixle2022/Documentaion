# Relations:

---

## One : Many:

let's say we have two models, the `post`:

```prisma
model Post {
  id          String   @id @default(cuid())
  title       String
  description String
  content     String
  published   Boolean? @default(false)
  updatedAt   DateTime @updatedAt
  createdAt   DateTime @default(now())
}
```

and the `user`:

```prisma
model User {
  id    String @id @default(cuid())
  name  String
  email String @unique
  hash  String
}
```

we want to create a relation between the two where each user can have many posts while a post can -obviously- only have one user as it's author.

the user can simply have `Post[]` but what about the post?

for that we use the `@relation` as follows:

```prisma
field ModelType @relation(fields: [A], references: [B])
A TypeOfB
```

so in the end we will have something like:

```prisma
model Post {
  id          String   @id @default(cuid())
  title       String
  description String
  content     String
  published   Boolean? @default(false)
  updatedAt   DateTime @updatedAt
  createdAt   DateTime @default(now())
  authorId String
  author User @relation(fields: [authorId], references: [id])
}

model User {
  id    String @id @default(cuid())
  name  String
  email String @unique
  hash  String
  posts Post[]
}
```

---

## Many : Many:

just use `[]` for both sides.

---

## one : one:

for the user for example:

```prisma
//it may or may not have a post
model User {
  post Post?
}
```

> [!NOTE]
> to get the access to the other table's row make sure to add the relation field to the `include` option of the query function.
