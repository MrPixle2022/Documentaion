# Models & Schemas:

---

import `Schema, InferSchemaType, model` from mongoose, then create the Schema.

```typescript
import { InferSchemaType, Schema, model } from "mongoose";

const noteSchema = new Schema(
  {
    title: { type: String, required: true },
    text: String,
  },
  { timestamps: true }
);
```

then create a new type name it what ever you want but it must use the `InferSchemaType` utility provided by mongoose and pass it the Schema instance you created as generics

then pass the type you created to the `model` and export default.

```typescript
//creates a type out of the schema
type Note = InferSchemaType<typeof noteSchema>;

//creates a model out based on a type, and the schema
//model<T>('collectionName', schema)
export default model<Note>("Note", noteSchema);
```

