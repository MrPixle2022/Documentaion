# SubQuires:

we can use subqueries for an `IN` check, using data from another table, subqueries are always enclosed in `( )`, for example:

```sql
SELECT
  id,
  make,
  model,
  price
FROM
  cars
WHERE
  price < (
    SELECT
      balance
    FROM
      users
    WHERE
      id = 1
  );
```

this query will fetch us the `id`, `make`, `model` and `price` of the cars that are below the balance of the user with `id = 1`.
