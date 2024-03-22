# insert data:

to insert a new record in your db use `db._collectionName_.insertOne({data})

```powershell
db.users.insertOne({name: "amr", age:16, password:"*******"})
```

also you have the option to insert multiple records at once use the `insertMany` method which takes an array of records to insert

```powershell
db.users.insertMany([{name:"mohammed", age:17}, {name:"ali", age: 16}])
```

> [!NOTE]
> mongo automatically assigns a `_id` to each record as a unique id.

