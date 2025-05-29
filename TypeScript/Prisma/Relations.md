<!-- @format -->

# Relations:

in prisma models can have a relation of:

- **one to one**: one model references another one
- **one to many**: one model references multiple ones of another
- **many to many**: when each model references multiple models and those models do the same

we can easily define a relation by using the model name as a type and using the `@relation` attribute

---

## One to many:

to the `@relation` attribute pass an optional name -only required if multiple relation to the same model is needed- and a **fields array** which is an array of fields that -in this model- will be used as a reference to the other model, and `references` which is an array of the fields that -exists on the other model and- you will reference

```prisma
model User {
  id            String  @id @default(uuid())
  username      String
  email         String
  isAdmin       Boolean
  preferences   Json?
  // declaring two relations, know the @relation name here isn't required if only one relation is used
  writtenPosts  Post[]  @relation("writtenBy")
  favoritePosts Post[]  @relation("favoriteBy")
}

model Post {
  id           String   @id @default(uuid())
  rating       Float
  createdAt    DateTime
  updateAt     DateTime
  // this is a relation, the `authorId` references the `User.id` field
  author       User     @relation("writtenBy", fields: [authorId], references: [id])
  authorId     String
  // another relation by a name, fields , references
  favoriteBy   User     @relation("favoriteBy", fields: [favoriteById], references: [id])
  favoriteById String
}
```

---

## Many to many

to define a many-to-many we simple make use of the `[]` modifier, their will be no need for the `@relation`

```prisma
model Post {
  id           String     @id @default(uuid())
  ---
  categories   Category[]
}

model Category {
  id    String @id @default(uuid())
  posts Post[]
}
```

---

## One to one:

a one to one requires a `@unique` field to work properly but it's fairly simple

```prisma
model User {
  id              String           @id @default(uuid())
  ---
  UserPreferences UserPreferences?
}

model UserPreferences {
  id          String  @id @default(uuid())
  emailUpdate Boolean
  user        User    @relation(fields: [userId], references: [id])
  userId      String  @unique
}
```
