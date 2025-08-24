# Functions:

sql supports function that can be used for repetitive or special cases.

---

## Count:

the `Count` function is an aggregation function that returns the count of the specified columns or the number of rows if you pass it `*`.

```sql
-- number of rows
SELECT Count(*) FROM users;
```

if a condition is defined it will return how many values of the defined column passed it.

---

## IIF:

the `IIF` function works like a ternary-operator, you pass it a condition, if true value then if false value -in-order-.

for example:

```sql
SELECT
  IIF (balance > 10, 'Rich', 'Poor') as status
FROM
  users;
```

---

## Sum:

the `SUM` is an aggregation methods that returns the sum value for the given column.

```sql
-- get the sum of the `balance` for all users whose balance is in [100, 1000]
SELECT SUM(balance) FROM users WHERE balance BETWEEN 100 AND 1000;
```

---

## Max:

the `MAX` function is an aggregation function that returns the biggest value of the given column.

```sql
-- get the biggest user's balance from egypt
SELECT MAX(balance) FROM users WHERE country_coe = 'EGY';
```

---

## Min:

the `MIN` is an aggregation function that returns the smallest value of the given column.

```sql
-- get the smallest user's balance from egypt
SELECT MIN(balance) FROM users WHERE country_coe = 'EGY';
```

---

## Average:

the `AVG` is an aggregation function that returns the average of the given column, keep in mind that it will automatically **ignore NULL** fields.

```sql
SELECT AVG(age) FROM users;
```
