# Routes:

routes in typescript allows you to organize the project by groping handlers sent to a specific route.

create a new file the import `Router` from `"express"`

```typescript
import { Router } from "express";
import { createUser, getUserById, getUsers } from "../Handlers/users";

export const usersRouter = Router();

usersRouter.get("/", getUsers);

usersRouter.get("/:id", getUserById);

usersRouter.post("/", createUser);
```

then in the main server file use it:

```typescript
import { usersRouter } from "./Routes/Users";

//uses the `userRouter` to handle any request to `/api/users`
app.use("/api/users", usersRouter);
```
