<!-- @format -->

# Postgresql

---

make sure the postgres server is running, then open the `psql` shell fill in your data, or use the default

> [!NOTE] by default postgres ships a postgres and 2 template databases.

note you can use `\q` to exit & `\?` to show help

---

## Create a database

first check your dbs using `\l`, by default it will display 3, but to create one use:

```sql
CREATE DATABASE _db_name_;
```

important not to forget the `;` and the capitalization.

---

## Connecting to a database

using:

```bash
psql -U _user_ -d _db_name_
```

or if you are already in psql use:

```bash
\c _db_name_
```

---

## Dropping databases

to drop -aka remove- a data base use:

```sql
DROP DATABASE _db_name_;
```
