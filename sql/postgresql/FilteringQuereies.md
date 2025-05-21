<!-- @format -->

# Filtering queries:

---

## Using where:

using the `WHERE` class, you can select columns where it meets a certain condition.

```sql
-- one column
SELECT * FROM _table_ WHERE _col_ = 'value';
-- and
SELECT * FROM _table_ WHERE _col_ = 'value' AND _col_ = 'value';
-- or
SELECT * FROM _table_ WHERE _col_ = 'value' OR _col_ = 'value';
-- combined:
SELECT * FROM _table_ WHERE _col_ = 'value' AND (_col_='value' AND _col_='value');
-- lest of data
SELECT * FROM _table_ WHERE _col_ IN ("val1", "val2", "val3")
```

so for example:

```sql
SELECT * FROM person WHERE country = 'Egypt';
```

---

## Limits:

we can limit the number of records received by a query by using the `LIMIT` class.

```sql
SELECT * FROM _table_ LIMIT _number_
```

for example we can filter all admins but limit the number of results to 5:

```sql
SELECT * FROM users WHERE u_role = "admin" LIMIT 5;
```

---

## Offsets:

we can offset the result in a query using the `OFFSET` class, offsetting means that for example if our query returns all users whose id is bigger than 20, but we have an offset of 2 the result will start actually at 23.

```sql
SELECT * FROM _table_ OFFSET _number_ LIMIT _number_
```

---

## Betweens:

you can select records whose value is in the range you want using `BETWEEN`,

by using it like:

```sql
SELECT * FROM _table_ WHERE _col_ BETWEEN _val1_ AND _val2_;
```

```sql
SELECT * FROM person WHERE id BETWEEN 20 AND 50;
```

---

## Grouping queries

---

using the `GROUP BY` we can define that we want to group all records based on a columns value.

```sql
SELECT _column_, COUNT(*) GROUP BY _col_
```

this will return the column and the count of every record that has that group's column's value

for example, if we want to know all the countries in our db and how many user belong to each we can use:

```sql
SELECT
  country,
  COUNT(email)
from
  person
GROUP BY
  country
ORDER BY
  country;
```

> [!IMPORTANT] the column you are selecting must be in the group

notice here we used the count function, the `COUNT` function takes the `column` and returns the count of columns that the query selects, note inside the `COUNT` you can pass `DISTINCT` to ignore duplicates

---

## Using having:

when grouping we can add additional logic using `HAVING`, to having we pass another condition, for instance:

```sql
SELECT
  country,
  COUNT(*)
FROM
  person
GROUP BY
  country
HAVING
  COUNT(*) > 10
ORDER BY
  COUNT(*);
```

this query will select all countries with count of at least 11, and return the countries and count of users from there

---

## LIKE and ILIKE:

we can use `LIKE` or `ILIKI` to check for patterns, we use them to define a pattern to look for which can include `_` for a single character, `%` for any characters and normal characters to enforce, for more clarity:

```sql
-- looks for any user whose email has any number of characters + @ + 3 characters + .com
-- like: someone@sth.com
SELECT * FROM user WHERE email LIKE '%@___.com'
```

now the difference between `LIKE` and `ILIKE` it that `LIKE` is case sensitive whilst `ILIKE` isn't
