# Insertion:

to insert rows into a table use the `INSERT` keyword:

```sql
INSERT INTO table_name (col1, col2, col3) VALUES (col1_v, col2_v, col3_v);
```

for example if we have this table:

```sql
CREATE TABLE users (
  id INTEGER AUTO_INCREMENT NULL,
  name VARCHAR(250) NULL,
  age INT NOT NULL DEFAULT 0 ,
  balance INT NULL DEFAULT 0 ,
  is_admin BOOLEAN NULL DEFAULT 0 ,
  PRIMARY KEY (id)
);

```

then we would have something like:

```sql
INSERT INTO users (id, name, age, balance, is_admin) VALUES (
  7, --id
 'user-7', --name
  19, --age
  0, --balance
  0 --is_admin
);
```
