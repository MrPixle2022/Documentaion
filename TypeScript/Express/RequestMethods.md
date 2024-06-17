# Request methods:

---

## get(route, requestHandler):

the `get` method handles all request of type `GET` to `route` via the `requestHandler` the requestHandler is a function that takes `request: Request` & `response: Response`.

```typescript
app.get("/", async (req: Request, res: Response) => {
  res.status(200).json({'okay': true})
});
```

---

## post(route, requestHandler):

the `post` method handles all request of type `POST` to `route` via the `requestHandler` the requestHandler is a function that takes `request: Request` & `response: Response`.

```typescript
app.post("/", async (req: Request, res: Response) => {
  res.status(201).json({'okay': true})
});
```


---

## delete(route, requestHandler):

the `delete` method handles all request of type `DELETE` to `route` via the `requestHandler` the requestHandler is a function that takes `request: Request` & `response: Response`.

```typescript
app.delete("/", async (req: Request, res: Response) => {
  res.status(200).json({'okay': true})
});
```

---

## patch(route, requestHandler):

the `patch` method handles all request of type `PATCH` to `route` via the `requestHandler` the requestHandler is a function that takes `request: Request` & `response: Response`.

```typescript
app.patch("/", async (req: Request, res: Response) => {
  res.status(200).json({'okay': true})
});
```

---

it's also recommended to septate the requestHandler into it's folder `controller` and the endpoint to `routes` folder to further organize them.

for example:

```typescript
app.get("/", async (req: Request, res: Response) => {
  res.status(200).json({'okay': true})
});
```

becomes:

`src/controllers/note.ts`:

```typescript
export const getNotes: RequestHandler = async (req: Request, res: Response) => {
  res.status(200).json({'okay': true})
}
```


`/src/routes/notes.ts`:

```typescript
import * as NotesController from "../controllers/notes"
import express, { Router }  from "express";

const router: Router = express.Router();

router.get("/", NotesController.getNotes);
```

then add this router to the `app`(express instance).

/src/server.ts
```typescript

```
