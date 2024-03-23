# Deleting docs:

to **delete** a doc use:

- `deleteOne`
- `deleteMany`
- `findByIdAndDelete`


### deleteOne():

the `deleteOne` takes an obj to match the doc with and removes it:

```javascript
modelName.deleteOne({key: val})
```

---

### deleteMany():

the `deleteMany` is similar to `deleteOne` but it applies to all docs that match the condition

---

### findByIdAndDelete():

the `findByIdAndDelete` takes an id and deletes the doc with that id.

```javascript
modelName.findByIdAndDelete("id")
```
