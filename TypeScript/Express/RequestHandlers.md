# Request Handlers

request handlers are function that handle the incoming request similar to any middleware they take a `request`, `response` & optionally a `next` function.

create one using:

```typescript
import { Request, Response } from "express";

export function getUsers(req: Request, res: Response) {
	res.status(200).send([]);
}
```

then this route handler can be used to handle a request.

```typescript
import { getUsers } from "../Handlers/users";

usersRouter.get("/", getUsers);

```
