# Getting docs:

to **get docs** in a collection use:
- `modelName.find()` to get all data 
- `modelName.findById("id")` to get a doc with it's id
- `modelName.find({field: val})` to get all based on a specific field

also you can **get a specific number** of docs by using the `limit` like:

```javascript
modelName.find().limit(num)
```

and you can **skip** a `num` number of docs via `skip`:

```javascript
modelName.find().skip(num)
```

also you can get the **count** of the docs using `countDocuments` function.

```javascript
modelName.find().countDocuments()
```

also you can **sort** the documents via the `sort` function:

```javascript
modelName.find().sort({key: 1 || -1})
```

to **use a query** use the same syntax as you would in mongosh:

```javascript
modelName.find({key:{$query: val}})
```
