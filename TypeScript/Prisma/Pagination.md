<!-- @format -->

# Pagination:

## Where:

the `where` can be used to conditionally select records for example:

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

## Select & Include:

`select` and `include` can't be used together, it's either one or the other.

the `select` defines what to results will the query include, it's useful when you want to hide all fields then pick what you want only to appear.

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
```

> [!IMPORTANT] know that the `select` expects at least one truthy values -one field set to true-

this will enforce the deletion of the fields marked with `false` from the query result.

whilst the `include` is the opposite, it's used when you want to show most and hide some.

```typescript
const amr = await prisma.user.findUnique({
	where: {
		email_username: { email: "amr@amr.com", username: "amr" },
	},
	include: { password: false },
});
```

by this the password field will be omitted

---

## Take, skip & OrderBy:

on queries we can use `take` to limit the number of results, `skip` to ignore `n` of results from the begging & `orderBy` to define the field and the order method

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

## Other queries:

we can use `where` for conditions, or use `some`, `every`, and `none` and some others:

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

also we can check for data on the record being referenced using `is` for example:

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
