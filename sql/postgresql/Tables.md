<!-- @format -->

# Tables:

## Creating a new table with no constraints:

using the `CREATE` command to create a table, for example:

```sql
CREATE TABLE _table_name_ {
  _column_name_ _type_ _constrains_
}
```

and tou can have as many columns as you wish

here is a list of useful types:

- int8 -> int8 type (big int)
- varchar(n) -> a variable-length string
- date -> dates
- json -> json object
- money -> money and currency
- numeric | decimal -> float point number
- text -> text with no max length
- timestamp -> for time stamps

> [!NOTE] all types are in uppercase

```sql
CREATE TABLE person(
  id INT,
  firstname VARCHAR(50),
  lastname VARCHAR(52),
  date_of_birth DATE
);
```

you can list all tables using `\d` or `\d _table_name_` to show that very table

remember you can drop a table using:

```sql
DROP TABLE _table_name_;
```

---

## Creating a table with constraints:

constraints like `NOT NULL` and assigning defaults is important to make sure that the right data is the only stored data.

```sql
CREATE TABLE person(
  -- this id will be the main unique identifier of this table, bigserial means that it auto increments
  id BIGSERIAL NOT NULL PRIMARY KEY,
  firstname VARCHAR(50) NOT NULL,
  lastname VARCHAR(52) NOT NULL,
  date_of_birth DATE NOT NULL
);
```

now this `person` will be of type `sequence` because of the big serial

---

## Inserting a record:

using the `INSERT INTO` command, we can add a record to the table, for example adding a person record to our person tables

the syntax is like the following:

```sql
INSERT INTO _table_name_ (_column1_, _column2_) VALUES (_column1_value_ , _column2_value_)
```

```sql
INSERT INTO person(firstname, lastname, gender, date_of_birth) VALUES ('amr', 'yasser', 'male', DATE '5-12-2007');
```

however if you have an sql file and want to read it use `\i`

```bash
\i '_path_'
```

just remember to replace the `\` with `/`

---

## Reading records from table:

to read every single records use:

```sql
SELECT * FROM _table_name_
```

this will return all columns from that table, however you can choose individual columns by specifying the name and separating each column with a `,`:

```sql
SELECT _col1_, _col2_ FROM _table_name_
```

also you can actually order the output by a filed both acceding and descending using the `ORDER BY`

```sql
-- ascending(default)
SELECT * FROM _table_name_ ORDER BY _column_ ASC;
-- descending
SELECT * FROM _table_name_ ORDER BY _column_ DESC;
-- by multiple columns
SELECT * FROM _table_name_ ORDER BY _column1_ ,_column2_;
```

and you can also eliminate duplicates in the out put using the `DISTINCT` class:

```sql
SELECT DISTINCT _col_ FROM _table_
```

also we can use the `AS` to rename the output columns in sql:

```sql
-- rename the make to maker
SELECT make AS maker from car;
```

---

## Deleting records:

using the `DELETE` we can remove all or specified records from the database:

```sql
-- remove all content
DELETE FROM _table_name_
-- remove based on condition
DELETE FROM _table_name_ WHERE _condition_
```

---

## Updating a record:

to update a record we can use the `UPDATE` and `SET` to update -all or a- records in the table

```sql
UPDATE _table_name_ SET _col1_ = _val1_, _col2_ = _val2_;
```

```sql
-- rewrite the email to `amr@gmail.com`
UPDATE person SET email = 'amr@gmail.com' Where id =377;
```
