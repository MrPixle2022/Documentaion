# Select:

the `SELECT` statement is used to get a **result-set** from the database, in the select statement you pick the columns you want separated by `,` or use `*` to pick every one.

for example to pick 2 columns:

```sql
SELECT col1, col2 FROM table_name;
```

and to pick every column:

```sql
SELECT * FROM table_name;
```



---

## Where clause:

the `WHERE` allows us to define a condition to only include the rows matching it.

```sql
-- get all admins
SELECT username FROM users WHERE is_admin = 1;
-- get all null emails
SELECT * FROM users WHERE email IS NULL;
```

---

## Between:

the `BETWEEN` clause is used with the `WHERE` to check if a field's value falls within the defined range.

```sql
SELECT
  *
FROM
  users
WHERE
  balance BETWEEN 200 AND 3000;
```

also we can invert the search using a `NOT`:

```sql
SELECT
  *
FROM
  users
WHERE
  --range of excluded rows
  balance NOT BETWEEN 200 AND 3000;
```

> [!TIP]
> SQL support logical operators like `AND`, `OR` and also when checking for equality only use one `=`, the rest of the equality operators like `>=`, etc... are the same.

> [!NOTE]
> Conditions can be grouped by surrounding them with `( )`

also we have the `IN` operator which checks if a column's value is one of the defined ones.

```sql
SELECT * FROM products WHERE status IN ('Shipped', 'Prepared', 'Out for delivery');
```

---

## LIKE:

the `LIKE` operator is used as some sort a fuzzy-search as instead of checking for hard-coded values like in the case of `IN` it uses patterns to so, for the pattern operators we have:

- `%`: any number of characters for example:

```sql
-- every element where the product's name ends with ' phone'
SELECT * FROM products WHERE product_name LIKE '% phone';
-- every element where the product's name starts with 'Apple '
SELECT * FROM products WHERE product_name LIKE 'Apple %';
-- every element where the product's name contains 'Galaxy 2'
SELECT * FROM products WHERE product_name LIKE 'Galaxy % 2';
```
- `_`: a placeholder for a single character, for example:

```sql
-- any product whose name is '[][]oot' or 2 letters then `oot`
SELECT * FROM products WHERE product_name LIKE '__oot';
```

---

## Select distinct

the `DISTINCT` keyword allows you to include only one row for a column's value, so it if a column's value is repeated `DISTINCT` will only take one.

```sql
-- only take one of each model
SELECT DISTINCT model FROM cars;
```

---

## Order by:

the `ORDER BY` allows you to sort the resulting data by a given column either in `ACS`ending order -which is the default- or `DESC`ending order.

```sql
-- get all users and sort them by age from the oldest to the youngest
SELECT * FROM users ORDER BY age DESC;
```

> [!TIP]
> Order the data before limiting, if you use `LIMIT` before `ORDER BY` you will get an SQL logic error, so order the data then limit the results.

---
