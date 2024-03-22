# Update data:

to update a field in a single record use `.updateOne()` it updates a single record, the method takes a query to look for a record by, and takes another object which specifies how to update it.

```powershell
db.users.updateOne({$lt: {age: 18}}, {$set: {age: 10} }):
```

this will update the first record where `age < 18` the sets the `age` to `18`

you can use:


|  |  |  |
|---------|---------|---------|
|$set     |set a key to value|{$set:{key:val}}|
|$unset|remove a field|{$unset: {key: ""}}|
|$inc|increment key by value|{$inc: {key:val}}|
|$rename|rename key to value|{$rename: {key:val}}|
|$push|add value to the end of an array|{$push: {arr:val}|
|$pull|removes elements from an array|{$pull: {arr:val}}|

> [!IMPORTANT]
> to edit all records that meets the query use `updateMany` it takes the same params and applies for all.