<!-- @format -->

# Joins:

`joins` are feature in relational-databases that allows you to query multiple tables at once, joins have many forms.

the syntax is as follows:

```sql
SELECT _cols_ FROM tableA join_type JOIN tableB ON join_condition;
```

---

## Inner join:

an `INNER JOIN` is the default behavior for joins, it will the records in table `a` that have a matching record in table `b` so like we get the rows that exists -or being references- in both tables.

```sql
SELECT * FROM employees INNER JOIN departments ON employees.department_id = departments.id;
```

---

## Left join:

the `LEFT JOIN` will return all the rows of **tableA** regardless of the `ON` clause, also it will return any matching records in **tableB**.

```sql
-- made an alias for employees -> e, departments -> d
SELECT e.name, d.name FROM employees e LEFT JOIN departments d ON e.department_id = d.id;
```

---

## Right join:

the `RIGHT JOIN` will return all the rows of **tableB** regardless of the `ON` clause, also it will return any matching records in **tableA**.

right joins are pretty useless as you can get the same result by swapping the table names in a left join, that's why `SQLITE` doesn't support them.

---

## Full join:

the `FULL JOIN` will return all the rows of **tableA** and **tableB** regardless of the `ON` clause, also it will return any matching records.

> [!NOTE] Sqlite supports neither `FULL` nor `Right` joins.

use a `FULL JOIN` when you want to get all the data from two tables wether they are related or not.

> [!TIP] You can use multiple joins to get data from multiple tables, but note that the more the joins the slower the query.
