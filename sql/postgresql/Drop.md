<!-- @format -->

# DROP:

the `DROP` can be used to remove a thing from the database, from tables and constraints to the database it self, the syntax is simple:

```sql
DROP _TYPE_ _name_
```

---

## Dropping databases

```sql
-- remove the example_Db
DROP DATABASE EXAMPLE_DB
```

---

## Dropping a table:

```sql
-- removes the person table
DROP TABLE person
```

---

## Dropping Constraints:

```sql
-- REMOVE THE person_pkey (primary key) from the person table
ALTER TABLE person DROP CONSTRAINT person_pkey;
```
