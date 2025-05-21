<!-- @format -->

# Constraints:

---

## PRIMARY KEY:

the `PRIMARY KEY` specifies that a field is the **unique** identifier for a record in the table, this is one of the things that is assigned on table creation.

```sql
CREATE TABLE person(
  -- this id will be the main unique identifier of this table, big_serial means that it auto increments
  id BIGSERIAL NOT NULL PRIMARY KEY,
  firstname VARCHAR(50) NOT NULL,
  lastname VARCHAR(52) NOT NULL,
  date_of_birth DATE NOT NULL
);
```

later on this can be removed or added back:

```sql
-- REMOVE THE person_pkey (primary key) from the person table
ALTER TABLE person DROP CONSTRAINT person_pkey;
-- add the primary key, based on the id
ALTER TABLE person ADD PRIMARY KEY (id);
```

---

## UNIQUE:

the `UNIQUE` constraint is used to mark a column that it can only have one of any value, we can them in the table creation or as an alteration:

for the alteration:

```sql
ALTER TABLE _name_ ADD CONSTRAINT _constraint_name_ UNIQUE (_col1_, _col2_, ...)
```

```sql
-- create a new unique constraint name u_email for the email column
ALTER TABLE person ADD CONSTRAINT u_email UNIQUE (email)
-- this time the name is defined by the database
ALTER TABLE person ADD UNIQUE (email)
```

---

## CHECK:

the `CHECK` constrain can be used to allow a column to have a certain value if it satisfies a condition

```sql
-- only gender which are `Male` or `Female` are allowed
ALTER TABLE person ADD CONSTRAINT gender_constraint CHECK (gender In ('Male', 'Female'));
```
