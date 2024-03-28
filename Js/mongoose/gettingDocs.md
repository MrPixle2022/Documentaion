# Getting docs:

to get a single or more documents by mongoose you can use:
1. `find`
1. `where`

---

## find:

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

---

## where:

the `where` allows you to get and find docs based on a query.

```javascript
modelName.where('key').equals(val)
```

this allows you to get all docs where `key` = `val`

> [!IMPORTANT]
> it's chainable so you can use as many wheres as you want on after another similar to promises

after the where you choose the condition like:

- `.gt(val)` for greater that
- `equals(val)` for equal to
- `ls(val)` for less that
- etc..

after that you can use `limit(num)` to limit the result to an `num` number of docs and use `select('field')` to only get certain fields or use `populate(field)` which joins two docs at the `field` for example if you have a best friend field that holds an `_id` referencing another doc the `populate('bestfriend')` will place all that best friend data at the `bestfriend` field