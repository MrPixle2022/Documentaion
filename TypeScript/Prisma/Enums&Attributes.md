# Enums & attributes
---

## Enums:

in the `.prisma` file we can create and define an enum using the `enum` keyword:

```prisma
enum UserRole {
  Basic
  admin
}
```

then we can use it in our models:

```prisma
model User {

  role            UserRole         @default(Basic)
}
```

---
# Attributes

in prisma their are two types of attribute field `(@attribute)` and block `(@@attribute)`, like for example:

- @unique: makes sure this field is unique
- @updateAt: updates this field on update to the current timestamps
- @default: assigns a default value to the field
- @id: defines this field as the main identifier
- @relation: defines the relation to another model

these go on a filed line to add some more control.

- block level (@@) they inserted in the model definition apart form the fields
- @@unique([]) : array of fields that are to be unique **together**
- @@index([]): defines the fields used for indexing to help with sorting, etc...
- @@id([]): defines the fields that **together** define the id, for example, adding username and email means the only one user can have the username `x` and email `y` **together**, while another can have username `z` and email `y` and vice versa

these -block attributes- are inserted at the end of the model

for example:

```prisma
model User {
  id              String           @id @default(uuid())
  username        String
  age             Int
  email           String           @unique
  role            UserRole         @default(Basic)
  writtenPosts    Post[]           @relation("writtenBy")
  favoritePosts   Post[]           @relation("favoriteBy")
  UserPreferences UserPreferences?

  @@unique([email, username])
  @@index([email])
}
```

---
