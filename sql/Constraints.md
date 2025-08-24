<!-- @format -->

# Constraints:

constraints allow us to have more control over some column.

---

## NOT NULL:

the `NOT NULL` constraint allows us to define that a value in this column can't be null.

```sql
age INTEGER NOT NULL
```

---

## PRIMARY KEY:

the `PRIMARY KEY` constraints defines the unique identifier -the id- for this table, aka the column used to uniquely identify each row, each `PRIMARY KEY` value can't be repeated.

primary keys **can't be null** either and in some databases -like sqlite- primary keys are **auto-incremented**.

```sql
-- primary keys can't be null so no need to use NOT NULL
id INTEGER PRIMARY KEY
```

---

## FOREIGN KEY:

a foreign key defines a field which hold a primary key to a row in another table, it's what makes relational databases relational, defining the foreign key is unlike `NOT NULL` constraints as we have to define a constraints manually using:

```sql
CONSTRAINT c_name
```

let's assume this is our departments table:

```sql
CREATE TABLE departments (
  id INTEGER PRIMARY KEY,
  department_name TEXT NOT NULL
);
```

and we have the `employees` table where each employee has a reference to a department he works for.

```sql
CREATE TABLE employees(
  id INTEGER PRIMARY KEY
  name TEXT NOT NULL,
  department_id INTEGER --notice it's the same type as the primary key of `departments`

  -- naming the constraint is optional
  CONSTRAINT fk_department
  FOREIGN KEY (department_id)
  REFERENCES departments(id)
);
```

---

## DEFAULT:

the `DEFAULT` constraint is used to define a default value of a filed.

```sql
-- if no value is provided then use `0`
balance INTEGER NOT NULL DEFAULT 0,
```

> [!NOTE] To add a `DEFAULT` or `NOT NULL` constraints add `SET` before either.

---

## AUTO INCREMENT:

the `AUTO INCREMENT` is constraint that allows you to ignore assigning a field's value as the database will automatically assign it a value which is incremented at each insertion.

---

## UNIQUE:

the `UNIQUE` constraints allows us to mark a row to only hold unique values without it being our primary key, meaning a value can't repeat more than once per-table.

think something like a social security number, only one person can have a specific one, so we mark it as `UNIQUE`.

```sql
CREATE TABLE IF NOT EXISTS people(
  id INTEGER PRIMARY KEY,
  social_security_number CHAR(32) UNIQUE
);
```

we can also use multiple columns together to define a unique constraint.

```sql
--ensures the first and last name -together- are unique
UNIQUE (first_name, last_name)
```

---

## CONSTRAINTS:

using the `CONSTRAINTS` keyword we can add additional constraints on our table rows, for example:

```sql
CONSTRAINT age_check_c CHECK (age >= 18 AND age < 100);
```

---

## INDEX:

the `INDEX` constraints allows you to define a column to be the indexer, allowing for faster searches, updating tables with an index will take more time than on one that has none as the index must be updated as well.

> [!TIP] only use `INDEX`s on columns that are more usually searched against

```sql
CREATE INDEX index_name ON table_name(column_name);
```

> [!NOTE] Indexes can be done on multiple columns, in this case the index will be used when all the specified columns are being searched against
