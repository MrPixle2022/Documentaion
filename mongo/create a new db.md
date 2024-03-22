# create a new db:

first make sure you have `C:\data\db` this is where mongo saves all dbs, if not use:

```powershell
mkdir C:\data\db
```

then run `mongod`:

```powershell
mongod
```

then in a separate terminal use:

```powershell
mongosh
```

to start the mongo shell.

---

to get the name of the current db use `db.getName()`

---

to see all dbs in your project first in the `mongo shell` use:

```powershell
show dbs
```

which will log all dbs.

then to **create** a new db use `use _dbName_` like:


```powershell
use appDb
```

to **remove** a db enter the db and use:

```powershell
db.dropDatabase()
```
