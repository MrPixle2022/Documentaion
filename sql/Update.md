# Update:

to update a record use the `UPDATE` statement.

```sql
UPDATE table_name
  SET col1 = val1,
  col2 = val2
WHERE condition;
```

for example:

```sql
UPDATE users
SET
  balance = 1000,
  is_admin = TRUE
WHERE
  id = 1
```
