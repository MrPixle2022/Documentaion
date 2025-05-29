<!-- @format -->

# Prisma:

start by creating a new node project using:

```bash
pnpm init
```

then install the following dependencies:

```bash
pnpm i -D prisma typescript ts-node @types/node nodemon
```

then simply create a `tsconfig.json`:

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

then initialize prisma using:

```bash
# or replace the `postgresql` with your db
pnpm prisma init --datasource-provider postgresql
```

this will create a `.env` folder and some files required to define your schema in a directory called `prisma`

```prisma
generator client {
  provider = "prisma-client-js"
  output   = "../generated/prisma"
}

datasource db {
  provider = "postgresql"
  url      = env("DATABASE_URL")
}
```

---

## Define a simple schema:

define a schema using the `model` keyword and give it a name, in there define a property followed by a type then constraints that have `@` before them like:

```prisma
model User {
  // `id` field is the main id, by default it will auto increment
  id       Int    @id @default(autoincrement())
  username String
}
```

then migrate your schema using:

```bash
# migrate a dev mode migration named init
pnpm prisma migrate dev --name init
# or add reset before dev to drop the previous data
```

this will add a migration.sql file and a prisma client which allows us to communicate a database though we still need to install the actual library.

```bash
pnpm i @prisma/client
```

---

## Migration:

when we make a change in the schema of our database we have to migrate those changes into the database, for that we the `migrate` command:

```bash
# migrate a dev mode migration named init
pnpm prisma migrate  --name _migration_name_
pnpm prisma migrate dev --name _migration_name_ # this is a development mode migration, not the build
pnpm prisma migrate reset dev --name _migration_name_ # drop all data and migrate
```

then we will have to re-generate the client using:

```bash
pnpm prisma generate
```

so our client has access to the updated schema

---

## Using prisma in ts:

in a typescript file use:

```typescript
import { PrismaClient } from "./generated/prisma";
const prisma = new PrismaClient();
```

now we can use the prisma client to access the data from our code.

just keep in mind it's recommended to disconnect when leaving using the `.$disconnect` method:

```typescript
async function main() {}
main()
	.catch((err) => {
		console.error(err.message);
	})
	.finally(() => prisma.$disconnect());
```

though prisma automatically does it by default, so the previous snippet is absolutely optional.

---

## Fields types:

prisma has a set of useful data types to be used in your models for example we have:

- Int -> int
- BigInt -> huge integer value
- String -> string
- Float -> a decimal value
- Decimal -> a decimal value that is more accurate
- DateTime -> time related
- Json -> Json type
- Bytes -> raw Bytes rarely used
- UnSupported -> for an unsupported types
- model -> replace with the model name with the actual model to create a relation and make sure to reference this model in the other one, so both models reference each other

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

note you actually use uuids for this job, replace the `Int` with `String` and replace `autoincrement()` with `uuid()`

---

## Relations:

in prisma models can have a relation of:

- one to one: one model references another one
- one to many: one model references multiple ones of another
- many to many: when each model references multiple models and those models do the same

we can easily define a relation by using the model name as a type and using the `@relation` attribute

to the `@relation` attribute pass an optional name -only required if multiple relation to the same model is needed- and a fields, an array of fields that -in this model- will be used as a reference to the other model, `references` which is an array of the fields that -exists on the other model and- you will reference

so lets make a one-to-many:

```prisma
model User {
  id            String  @id @default(uuid())
  username      String
  email         String
  isAdmin       Boolean
  preferences   Json?
  // declaring two relations, not the @relation here isn't required if only one relation is used
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

many-to-many:

to define a many-to-many we simple make use of the `[]` modifier, their will be no need for the @relation

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

one-to-one:

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

---

## Attributes:

in prisma their are two types of attribute field (@attribute) and block(@@attribute):

```prisma
/**
 * attribute
 * @unique: makes sure this field is unique
 * @updateAt: updates this field on update to the current timestamps
 * @default: assigns a default value to the field
 * @id: defines this field as the main identifier
 * @relation: defines the relation to another model
 */
```

these go on a filed line to add some more control.

```prisma
/**
 * block level (@@) they inserted in the model definition apart form the fields
 * @@unique([]) : array of fields that are to be unique together
 * @@index([]): defines the fields used for indexing to help with sorting, etc...
 * @@id([]): defines the fields that together defined the id, meaning that it will use the values of the given fields an an id
 */
```

these are inserted at the end of the model

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

## Using prisma in code:

first in your folder import the `PrismaClient` from `@prisma/client` and create a new instance of it, know that you only have to create a single one as this very single prisma client will handle all connections for you.

```typescript
import { PrismaClient } from "./generated/prisma";
const prisma = new PrismaClient();
// you can optionally log certain data
// const prisma = new PrismaClient({ log: ["query"] });
// this will log every query that prisma runs
// another useful option is using the `omit` option to omit certain fields form the queries
//-> const prisma = new PrismaClient({omit: {user: {email: true}}});
//this will hide the email in the user model
```

---

## Creation operation:

prisma provides `create` and `createMany` to create a one or more record, we do this by defining an options to the method and assigning the `data` object to the the new record object or an array of records objects for `createMany`:

```typescript
await prisma.user.create({
	data: {
		email: "mrpixel0010@gmail.com",
		username: "pxl",
		age: 18,
		role: "admin",
		userPreferences: {
			create: {
				emailUpdate: true,
			},
		},
	},
});
```

you will notice that the `userPreferences` though is supposed to be a separate model we were just able to define it inside the create, and by nesting another create object, that actually simplifies the process of creating records, we can replace the create with a `connect` if we have an existing record we want to link and `disconnect` -a boolean- to disconnect relations.

we also can use other options like `include` and `select`.

```typescript
const newUser = await prisma.user.create({
	// select: { username: true, id: false, email: true, userPreferences: t },
	include: { userPreferences: true },
	data: {
		email: "mrpixel0010@gmail.com",
		username: "pxl",
		age: 18,
		role: "admin",
		userPreferences: {
			create: {
				emailUpdate: true,
			},
		},
	},
});
```

by this we are making sure that we will get the new `userPreferences` object.

`select` is similar but is used to only pick certain fields only:

```typescript
const newUser = await prisma.user.create({
	select: { username: true, id: false, email: true },
	// include: { userPreferences: true },
	data: {
		email: "mrpixel0010@gmail.com",
		username: "pxl",
		age: 18,
		role: "admin",
		userPreferences: {
			create: {
				emailUpdate: true,
			},
		},
	},
});
```

by using `select` we are making sure we only get the username and email, and ignoring the id and any other field

> [!IMPORTANT] Note you can only use either `select` or `include`, and know you can nest selects and include, for example:

```typescript
select: {
  username: true,
  userPreferences: { select: { id: true } },
  email: true,
},
```

---

## Using createMany:

we can use the `createMany` to insert multiple records at once, but know that when using `createMany` both `select & include` won't work

```typescript
const users = await prisma.user.createMany({
	data: [{ username: "amr", email: "amr@amr.com", age: 18 }],
});
users; // {count: 1}
```

if you want to get those users back use ``:

```typescript
const users = await prisma.user.createManyAndReturn({
	data: [{ username: "amr", email: "amr@amr.com", age: 18 }],
});
console.log(users); //an array of users -in this case it's only one-
```

---

## Getting records:

when getting data based on a unique filed use the `findUnique`, it will look based on the `where` condition:

```typescript
const amr = await prisma.user.findUnique({
	where: {
		email_username: { email: "amr@amr.com", username: "amr" },
	},
	include: { userPreferences: false },
});
console.log("🚀 ~ main ~ amr:", amr);
```

note the `email_username` object, this was actually generated by the `@@unique([email, username])` in the schema file and can be used to find a record, now that any not-unique field is invalid for this condition

though their are option like `findFirst` which will find the very first record that meets a conation:

```typescript
const amr = await prisma.user.findFirst({
	where: { role: "Basic" },
	select: {
		userPreferencesId: false,
		userPreferences: false,
		email: true,
		username: true,
	},
});
console.log("🚀 ~ main ~ amr:", amr);
```

or use `findMany`:

```typescript
const users = await prisma.user.findMany({
	where: { role: "Basic" },
	select: {
		userPreferencesId: false,
		userPreferences: false,
		email: true,
		username: true,
	},
});
console.log("🚀 ~ main ~ users", users);
```

in addition to the `where` we can use the `distinct` option to ignore duplicate fields:

```typescript
const distinctUsersName = await prisma.user.findMany({
	where: { role: "Basic" },
	distinct: ["username"],
});
console.table(distinctUsersName);
```

so this will select all `basic` role users whose username is **distinct**

we can go even further:

```typescript
const distinctUsersName = await prisma.user.findMany({
	where: { role: "Basic" },
	distinct: ["username"],
	take: 1, //only take one result
	skip: 1, //skip the first result
	orderBy: { age: "asc" }, //order by age ascending, or use desc for descending
});
console.table(distinctUsersName);
```

this will select all users whose role is **basic** and has a distinct **username**, take only **1** result and skip the first one, and then order the result based on the age in ascending order

---

## Advanced Where:

`where` can actually be used to handle more complex logic, for example:

```typescript
where: {
  age: { gte: 10 },
},
```

here we selection all records whose age is `>=` 10, we also have `gt` for grater than, `lt` and `lst` for less than & less than or equal, `equals` for equality & `not` for inequality , or use `in` and `notIn` to check if a field's value is a part or not part of an array:

```typescript
where: {
  age: { in: [18, 19] },
},
```

this picks all ages that are either 18 or 19

also we have the `contains`, `endsWith`, `startsWith` to check if the text value is included in a field

```typescript
const distinctUsersName = await prisma.user.findMany({
	where: {
		email: { contains: "@", startsWith: "amr" },
	},
});
console.table(distinctUsersName);
```

this will select all emails that contains `@` @any position, and start with `amr`

also we can combine conditions using thing like `AND`, `OR` & `NOT`:

```typescript
const distinctUsersName = await prisma.user.findMany({
	where: {
		AND: [{ email: { endsWith: "@amr.com" } }, { role: "Basic" }],
		OR: [{ email: { endsWith: "@gmail.com" } }],
		NOT: [{ username: { equals: "amr" } }],
	},
});
console.table(distinctUsersName);
```

---

## Relational filtering:

we can use `some`, `every`, and `none` along side the previous queries:

```typescript
const distinctUsersName = await prisma.user.findMany({
	where: {
		writtenPosts: {
			every: { title: "test" },
			none: { avgRating: 2.3 },
			some: { avgRating: { gt: 3 } },
		},
	},
});
```

also we can check for data on the record being referenced:

```typescript
where: {
  author: {
    is: {
      // select all posts whose author is an admin
      role: "admin",
    }
  }
}
```

---

## Updating records:

to update one or more records use the `update`, or `updateMany` methods on your model, you can use a `where` for the condition and the `data` to use:

```typescript
const user = await prisma.user.update({
	where: {
		email: "pxl@amr.com",
	},
	data: {
		username: "mr_pxl",
	},
});
table(user);
```

> [!TIP] You can use a `select` and `include` on `update` not `updateMany`, also know that when using `update` make sure to use **unique** fields

---

## Deletion:

using `delete` and `deleteMany` we can delete one or more records:

```typescript
const deleted = await prisma.user.delete({
	where: { email: "target@target.com" },
});
console.log(deleted);
```
