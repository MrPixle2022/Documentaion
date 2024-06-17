# CRUD operations:

---

## Create docs:

to create a new Document with mongoose import the model, then use either:

```typescript
const newNote = await NoteModel.create({ title, text });
```

or:

```typescript
const newNote new NoteModel({title, text})
await newNote.save();
```

---

## Read docs:

to read a document use the `find` method on the model or `findById` or `findOne`:

```typescript
const note = await NoteModel.findById(id).exec();
```

it's important to use `.exec()` since it runs the query

---

## Update docs:

to update a document use `findByIdAndUpdate` or manually update the values on the `document` then use `await doc.save()`

```typescript
const note = await NoteModel.findById(id);
note.title = newTitle;
note.text = newText;
const updatedNote = await note.save();
```

---

## Delete docs:

to delete a document use `findByIdAndDelete`.

```typescript
const note = await NoteModel.findByIdAndDelete(id);
```
