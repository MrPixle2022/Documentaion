# Tables:

a table in sql is what is used to hold data and organize it into rows and columns, a `row` represents an entry while a column defines the property or it's value.

---

## Create a table:

to create a table use the `CREATE` statement, to which we define the table name & it's columns between `()`

```sql
CREATE TABLE table_name (
  field1 type1,
  field2 type2,
  field3 type3
);
```

so for example let's create a table named `people`, in which we have to following

- id
- handle
- name
- age
- balance
- is_admin

than it would look like:

```sql
CREATE TABLE people (
    id INTEGER,
    handle TEXT,
    name TEXT,
    age INTEGER,
    balance INTEGER,
    is_admin BOOLEAN
);
-- display the info about the table, like it's columns -sqlite specific-
pragma table_info('people')
```

---

## Table altering:

to alter -change- a table we can use `ALTER TABLE`, this allows us to rename tables and columns & adding or dropping columns.

```sql
-- rename table
ALTER TABLE table_name RENAME TO new_name;
-- rename column
ALTER TABLE table_name RENAME COLUMN column_name TO new_name;
-- add a new column
ALTER TABLE table_name ADD COLUMN column_name column_type;
-- remove a column
ALTER TABLE DROP COLUMN column_name;
-- add a constraint
ALTER TABLE table_name ADD CONSTRAINT constraint_name constraint_type (column_name);
ALTER TABLE table_name ADD constraint_type (column_name);
-- remove a constraint
ALTER TABLE table_name DROP CONSTRAINT constraint_name ;
```

---

## Drop a table:

to remove/drop a table use:

```sql
DROP TABLE table_name;
```
