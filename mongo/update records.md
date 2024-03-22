# Update data:

to update a field in a single documents use `.updateOne()` it updates a single documents, the method takes a query to look for a documents by, and takes another object which specifies how to update it.

```powershell
db.users.updateOne({$lt: {age: 18}}, {$set: {age: 10} }):
```

this will update the first documents where `age < 18` the sets the `age` to `18`

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
> to edit all documentss that meets the query use `updateMany` it takes the same params and applies for all.