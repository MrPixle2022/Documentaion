<!-- @format -->

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
	{ timestamps: true },
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

a better alternative is extending the `mongoose.Document` type

```typescript
/** @format */

import mongoose, { Schema, Document } from "mongoose";

export interface UserDoc extends Document {
	email: string;
	username: string;
	password: string;
	role: "admin" | "user";
}

const UserTypeSchema = new Schema<UserDoc>({
	id: { type: String, required: true },
	email: { type: String, required: true },
	username: { type: String, required: true },
	password: { type: String, required: true },
	role: { type: String, enum: ["admin", "user"], required: true },
});

export const UserModel =
	mongoose.models.User || mongoose.model<UserDoc>("User", UserTypeSchema);
```

this links your type to your schema and help you modify it easily. X
