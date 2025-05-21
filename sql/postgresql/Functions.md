<!-- @format -->

# Functions:

---

## COUNT(_col_);

the `COUNT` can be used to select the count of the given column, like how many users are from each country in the database, and also you can use `DISTINCT` to ignore duplicates.

```sql
SELECT country, COUNT(email) FROM person GROUP BY country;
```

---

## MIN(_col_):

the `MIN` allows you to get the smallest value in a column

```sql
-- the minimum and lowest price in the price column
SELECT MIN(price) from car;
```

---

## MAX(_col_):

the `MAX` allows you to get the biggest value in a column

```sql
-- the maximum and highest price in the price column
SELECT MAX(price) from car;
```

---

## AVG(_col_):

the `AVG` allows you to get the average value of a column

```sql
-- the average value of the price column
SELECT AVG(price) from car;
```

---

## ROUND(_value_, pos):

the `ROUND` function can be used to round a decimal number to an integer, it can be used on the function that we listed above like min, max:

```sql
-- return the make, model, rounded min price, rounded max price, rounded average
SELECT make, model, ROUND(MIN(price)), ROUND(MAX(price)), ROUND(AVG(price)) FROM car GROUP BY make, model;
```

if `pos` is given it will round to that position -after the `.`-:

```sql
SELECT ROUND(0.9283, 2); -- 0.93
```

---

## SUM(_col_):

the `SUM` can be used to get the sum of a column:

```sql
SELECT make, SUM(ROUND(price)) from Car GROUP BY make;
```

---

## POWER(base, power):

the `POWER` function can be used to raise the `base` to `power`, though you can use `^` to do the same.

```sql
-- 2 * 2 * 2 = 8
SELECT POWER(2, 3);
```

---

## MOD(a, b):

the `MOD` returns the reminder of `a/b`:

```sql
-- 9 / 4 -> 2 R = 1;
SELECT MOD(9, 4); -- -> 1
```

---

## FACTORIAL(n):

the `FACTORIAL` returns the factorial of `n`:

```sql
-- 6! = 6 * 5 * 4 * 3 * 2 * 1
select factorial(6); -- >720
```

---

## COALESCE(_val1_, _val2_, ---)

the` COALESCE` function is used to assign a value if a param doesn't have one or is null, it will walk through it's params until the first defined value, meaning it will walk through all params till the first one with value making it useful to avoid nulls

```sql
-- any cell where email is null will show "no-mail"
SELECT COALESCE(email, 'no-mail') FROM person
```

---

## NULLIF(_val1_, _val2_):

the `NULLIF` is used to check if two values are equal, if so it returns null, else returns the first value:

```sql
SELECT
  -- 10 != 19 -> 10
  NULLIF(10, 19),
  -- 10 = 10 -> NULL
  NULLIF(10, 10);
```

---

## NOW():

the `NOW` returns the current timestamp:

```sql
SELECT NOW();
```

you can cast it to a date or time:

```sql
-- to date
SELECT NOW()::DATE -- return yyyy-mm-dd
-- to time
SELECT NOW()::TIME -- hh-mm-ss-ms
```

---

## CONFLICT(_col_):

using the `CONFLICT` function we can handle what happens on conflict:

```sql
INSERT INTO
  person (
    firstname,
    lastname,
    gender,
    email,
    date_of_birth,
    country,
    id
  )
VALUES
  (
    'amr',
    'yasser',
    'Male',
    'pxl@gmail.com',
    DATE '2007-12-05',
    'Pixelia',
    1
  )
-- if the id conflicts with one of it's constraints do not continue
ON CONFLICT (id) DO NOTHING;
```
