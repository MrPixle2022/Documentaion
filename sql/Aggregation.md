# Aggregation:

aggregation is the process of taking raw data and processing it to generate a single value.

sql has some aggregation methods like the `COUNT` function which takes the columns and **aggregates** them into a single value which is the ***count***

---

## Group by:

the `GROUP BY` clause makes it easier to group similar row into `summary rows` which are treated as one row, each of these `summary rows` can have it's own aggregation process through function.

```sql
SELECT grouper_col, Function(Column) FROM table_name GROUP BY grouper_col;
```

for example:

```sql
-- return the total sum of money users from each country own.
SELECT country_code, Count(balance) FROM users GROUP BY country_code;
```

---

## Having:

the `HAVING` clause is used along side the `GROUP BY` to add more conditions on the summary rows, the `HAVING` runs post-aggregation, after the grouping is done where as the `WHERE` is done pre-aggregation

so when using the `HAVING` what happens is:

- `WHERE` is executed to query
- results are grouped by the `GROUP BY`
- the `HAVING` is executed
- the result are returned

```sql
SELECT country, COUNT(id) FROM users GROUP BY country HAVING balance > 1000;
```
