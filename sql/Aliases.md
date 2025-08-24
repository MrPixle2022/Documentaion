# Aliases:

aliases allows you to rename columns in the output, so you don't change the actual column name, just what it would be named in the result-set as the effect is only for the query life-time.

an alias is defined via the `AS` clause as follows:

```sql
SELECT col AS new_name FROM table_name;
```

for example:

```sql
SELECT employee_id AS id, employee_name AS name FROM employees;
```
