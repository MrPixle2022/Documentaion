# A Practical Guide to Querying with Prisma

Prisma Client is an auto-generated and type-safe query builder that makes it easy to interact with your database. This guide provides practical examples for common database operations.

For these examples, we'll assume the following Prisma schema:

```prisma
model User {
  id    Int     @id @default(autoincrement())
  email String  @unique
  name  String?
  posts Post[]
}

model Post {
  id        Int      @id @default(autoincrement())
  title     String
  content   String?
  published Boolean  @default(false)
  author    User     @relation(fields: [authorId], references: [id])
  authorId  Int
}
```

## 1. Creating Records

### `create`

Create a single new record in the database.

```typescript
const newUser = await prisma.user.create({
  data: {
    email: 'alice@prisma.io',
    name: 'Alice',
  },
});
```

To create a record and its related records at the same time, use a nested `create`.

```typescript
const userWithPost = await prisma.user.create({
  data: {
    email: 'bob@prisma.io',
    name: 'Bob',
    posts: {
      create: {
        title: 'My first post',
        content: 'Hello, world!',
      },
    },
  },
});
```

### `createMany`

Create multiple records at once. This is much more efficient than calling `create` in a loop.

**Note:** `createMany` does not support nested writes (creating related records).

```typescript
const { count } = await prisma.user.createMany({
  data: [
    { email: 'charlie@prisma.io', name: 'Charlie' },
    { email: 'dave@prisma.io', name: 'Dave' },
  ],
  skipDuplicates: true, // Optional: skip records that would violate a unique constraint
});

console.log(`Created ${count} users.`);
```

## 2. Reading Records

### `findUnique` or `findUniqueOrThrow`

Fetch a single record by a unique identifier (like `id` or a field with `@unique`).

*   `findUnique`: Returns the record or `null` if not found.
*   `findUniqueOrThrow`: Returns the record or throws an error if not found.

```typescript
const user = await prisma.user.findUnique({
  where: {
    email: 'alice@prisma.io',
  },
});
```

### `findFirst` or `findFirstOrThrow`

Fetch the first record that matches a set of criteria.

```typescript
const firstPublishedPost = await prisma.post.findFirst({
  where: {
    published: true,
  },
});
```

### `findMany`

Fetch a list of records. This is your go-to for retrieving multiple items.

```typescript
const allUsers = await prisma.user.findMany();
```

## 3. Filtering and Sorting (`where` and `orderBy`)

The `where` clause is used to filter records, and `orderBy` is used for sorting.

### Filtering with `where`

You can filter by exact matches, or use a rich set of operators.

```typescript
const users = await prisma.user.findMany({
  where: {
    email: {
      endsWith: 'prisma.io', // Filter by email ending
    },
    posts: {
      some: {
        published: true, // Find users with at least one published post
      },
    },
  },
});
```

**Common Filter Conditions:**
*   `equals`: `id: 1` or `id: { equals: 1 }`
*   `not`: `email: { not: 'alice@prisma.io' }`
*   `in`: `name: { in: ['Alice', 'Bob'] }`
*   `lt` / `lte`: Less than / Less than or equal to
*   `gt` / `gte`: Greater than / Greater than or equal to
*   `contains`: `email: { contains: '@prisma' }`
*   `startsWith` / `endsWith`

**Logical Operators:** `AND`, `OR`, `NOT` can be used to combine filters.

```typescript
const result = await prisma.post.findMany({
  where: {
    OR: [
      { title: { contains: 'prisma' } },
      { content: { contains: 'prisma' } },
    ],
    NOT: {
      published: false,
    },
  },
});
```

### Sorting with `orderBy`

Sort your results by one or more fields.

```typescript
const sortedUsers = await prisma.user.findMany({
  orderBy: {
    name: 'asc', // Sort by name in ascending order
  },
});

// Sort by multiple fields
const sortedPosts = await prisma.post.findMany({
  orderBy: [
    {
      author: {
        name: 'asc',
      },
    },
    {
      title: 'desc',
    },
  ],
});
```

## 4. Selecting and Including Fields (`select` and `include`)

By default, Prisma returns all scalar fields. You can customize the output with `select` or `include`.

**Note:** You can only use `select` OR `include` in a single query, not both at the same level.

### `select`

Choose exactly which fields to return. This is great for performance, as you only fetch the data you need.

```typescript
const userWithSpecificFields = await prisma.user.findUnique({
  where: { id: 1 },
  select: {
    id: true,
    email: true,
  },
});
```

### `include`

Include related records in the result.

```typescript
const userWithPosts = await prisma.user.findUnique({
  where: { id: 1 },
  include: {
    posts: true, // Include all posts by this user
  },
});
```

You can also filter and select fields on the included records.

```typescript
const userWithPublishedPosts = await prisma.user.findUnique({
  where: { id: 1 },
  include: {
    posts: {
      where: {
        published: true,
      },
      select: {
        title: true,
      },
    },
  },
});
```

## 5. Updating Records

### `update`

Update a single record. It requires a `where` clause to find the record and a `data` clause with the new values.

```typescript
const updatedUser = await prisma.user.update({
  where: { email: 'alice@prisma.io' },
  data: {
    name: 'Alice Smith',
  },
});
```

### `updateMany`

Update multiple records that match a `where` clause.

```typescript
const { count } = await prisma.post.updateMany({
  where: {
    published: false,
  },
  data: {
    published: true,
  },
});
```

### `upsert`

Update a record if it exists, or create it if it doesn't. It's a combination of `update` and `create`.

```typescript
const user = await prisma.user.upsert({
  where: { email: 'viola@prisma.io' },
  update: {
    name: 'Viola',
  },
  create: {
    email: 'viola@prisma.io',
    name: 'Viola',
  },
});
```

## 6. Deleting Records

### `delete`

Delete a single record.

```typescript
const deletedUser = await prisma.user.delete({
  where: {
    email: 'dave@prisma.io',
  },
});
```

### `deleteMany`

Delete multiple records that match a `where` clause.

```typescript
const { count } = await prisma.post.deleteMany({
  where: {
    published: false,
  },
});
```

## 7. Aggregation, Grouping, and Summarizing

### `count`

Quickly count the number of records that match a condition.

```typescript
const userCount = await prisma.user.count();

const publishedPostsCount = await prisma.post.count({
  where: { published: true },
});
```

### `aggregate`

Perform aggregations like `_count`, `_avg`, `_sum`, `_min`, and `_max`.

```typescript
const postAggregations = await prisma.post.aggregate({
  _count: {
    _all: true,
  },
  _max: {
    id: true,
  },
});

console.log(postAggregations._count._all); // Total number of posts
console.log(postAggregations._max.id);     // The highest post ID
```

### `groupBy`

Group records by one or more fields and perform aggregations on each group.

```typescript
const postsByAuthor = await prisma.post.groupBy({
  by: ['authorId'],
  _count: {
    _all: true,
  },
  orderBy: {
    _count: {
      id: 'desc',
    },
  },
});
```

This guide covers the most common querying patterns in Prisma. For more advanced use cases, be sure to check out the official Prisma documentation.
