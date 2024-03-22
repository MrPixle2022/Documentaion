# find data:

### find():
the `find` method allows you to get all documentss in the collection, for example:

```powershell
db.users.find()
```

which will log all documentss in the `users` collection.

you can limit the result to a specific number using the `limit` method after `find`.

---

### findOne(---):

use it to find one documents that satisfies the query

---

### limit(n):

the `limit` method limits the returned documentss from the `find` method to n number of documentss.

```powershell
db.users.find().limit(2)
```

this will return only the first 2 documentss in the `users` collection.

---

### sort({key: -1 || 1}):

the `sort` method allows you to sort the documentss after finding them depending on the `key`, if `key` is set to:
- `1`: ascending
- `-1`: descending

```powershell
db.users.find().sort({age: 1})
```

---

### skip(n):

the `skip` method  is similar to the `limit` method since both takes a **number**, but the `skip` skips the first `n` number of documentss.

```powershell
db.users.find().skip(2)
```

this will skip the first 2 documentss

---

# find in advance:

### find({key0: value}, {key1: 1||0}):

the `find` method can take an object to get all documentss where they have the given key equal to the `value`, the second object specifies if the find should return that key or not:

- `1`: grab the key
- `0`: don't grab the key

```powershell
db.users.find({age:16}, {_id:0})
```

this will return all documentss where `age` is equal to `16` and will return all data in them except the `_id`

---

### query:

to get documentss based on a condition use a query.

syntax:

```.find({$query: {key: val} })


|query  |usage  |example  |
|:---------|:---------|:---------|
|$eq|check for equality|$eq: {key: val}|
|$ne|checks for inequality|$en: {key:val}|
|$gt|checks if key is greater than the value|$gt: {key: val}|
|$gte|greater than or equal|$gte: {key: val}|
|$lt|less than|$le:{key:val}|
|$lte|less than or equal|$lte: {key: val}|
|$in|value of key is in the array|{key: {$in: [val1,val2]} }|
|$nin|value of key is not in the array|{key: {$nin: [val1,val2]} }|
|$exists|checks if the key exists(not it's value)|{key: {$exists: true} }|
|$and|both conditions are true|{$and: [{query}, {query}]}|
|$or|one of the conditions|{$or: [{query}, {query}]}|
|$not|not|{key: {$not: {query} } }|