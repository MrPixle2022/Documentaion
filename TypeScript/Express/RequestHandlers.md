# Request handlers:

the `RequestHandlers` are functions that are used by `endpoints middlewares` to handle the data.

they take `request` ,`response & `next`.

```typescript
export const getNote: RequestHandler = async (
  request: Request,
  response: Response,
  next: NextFunction
) => {
  const { id } = request.params;
  console.log("🚀 ~ id:", id);
  try {
    if (!mongoose.isValidObjectId(id)) {
      throw createHttpError(400, "Invalid NoteID");
    }
    const note = await NoteModel.findById(id).exec();
    if (!note) {
      throw createHttpError(404, "Note not found");
    }
    response.status(200).json(note);
  } catch (error) {
    next(MediaError);
  }
};
```

also they can take generic types to specify the `reqBody` shape.

```typescript
interface CreateNoteBody {
  title?: string;
  text?: string;
}

export const createNote: RequestHandler<CreateNoteBody> = async (
  request,
  response,
  next
) => {
  const title = request.body.title;
  const text = request.body.text;

  try {
    if (!title) {
      throw createHttpError(400, "Title and text are required");
    }
    // `NoteModel.create()` returns a Promise that resolves to the newly created document.
    // can also use new NoteModel({title, text})
    const newNote = await NoteModel.create({ title, text });
    response.status(201).json(newNote);
  } catch (error) {
    next(error);
  }
};
```
