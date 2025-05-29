<!-- @format -->

# Models:

models are the schema of a table, each resemble how the data will look inside the database, their syntax is simple:

```prisma
model model_name{
  property Type @constraints;
  @@modelConstraints
}
```

for example we can define a schema using the `model` keyword and give it a name, in there define a property followed by a type then constraints that have `@` before them like:

```prisma
model User {
  // `id` field is the main id, by default it will auto increment
  id       Int    @id @default(autoincrement())
  username String
}
```

so here the `User` table will have an `id` an **auto incrementing** -hence the use of `autoincrement`- integer -Int- that is to be the main identifier of a record -hence the `@id`-

now that after changes are done, you have to migrate them.

---

## Fields types:

prisma has a set of useful data types to be used in your models for example we have:

- `Int` -> int
- `BigInt` -> huge integer value
- `String` -> string
- `Float` -> a decimal value
- `Decimal` -> a decimal value that is more accurate
- `DateTime` -> time related
- `Json` -> Json type
- `Bytes` -> raw Bytes rarely used
- `UnSupported` -> for an unsupported types
- `model` -> replace with the `model` name with the actual model to create a relation and make sure to reference this model in the other one, so both models reference each other

also it's worth knowing that each field is composed of 4 parts: a name, type, typeModifier, attributes

```prisma
// each line is a field
// a field is composed of 4
// name type | type? @attribute
// ? | [] is the field modifier making it optional
model User {
  //id: name, Int: type typeModifier:none @id, @default: attributes
  id       Int     @id @default(autoincrement())
  username String
  isAdmin  Boolean
}
```

> [!IMPORTANT] you can use set the `id` to **String** and define the default to be `uuid()`

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
  ---
  role            UserRole         @default(Basic)
  ---
}
```

---

## Attributes

in prisma their are two types of attribute field `(@attribute)` and block `(@@attribute)`, like for example:

- @unique: makes sure this field is unique
- @updateAt: updates this field on update to the current timestamps
- @default: assigns a default value to the field
- @id: defines this field as the main identifier
- @relation: defines the relation to another model

these go on a filed line to add some more control.

- block level (@@) they inserted in the model definition apart form the fields
- @@unique([]) : array of fields that are to be unique together
- @@index([]): defines the fields used for indexing to help with sorting, etc...
- @@id([]): defines the fields that **together** defined the id, for example, adding username and email means the only one user can have the username `x` and email `y` **together**, while another can have username `z` and email `y` and vice versa

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
