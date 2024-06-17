# Middlewares:

in express middlewares like `route handlers` are called in order so the order by which you use them matters.

you use middleware by using the `use` method` on the express instance.

also you can create your own middleware.

middleware can take `request`, `response`, `next` that jumps to the next middleware, and some that are used to handle errors take the error first.

```typescript
//initialize an error handler middleware
//this example uses `http-errors` & `@types/http-errors`
app.use((error: unknown, req: Request, res: Response, next: NextFunction) => {
  console.log(error);
  let errMsg = "An unknown error occurred";
  let statusCode = 500;
  if (isHttpError(error)) {
    statusCode = error.status;
    errMsg = error.message;
  }
  res.status(statusCode).json({ error: errMsg });
});
```

as we mentioned the order matters:

```typescript
//--------------------------------------------------
//----|SERVER SETUP|--->
const app: Express = express();
//--------------------------------------------------
//----|Middlewares|--->

// parse JSON bodies of incoming requests:
app.use(express.json()); //if this middleware was below the router below, that router won't be able to access the body of the request

// uses the notesRoute routes to handle requests that come to /api/notes
app.use("/api/notes", notesRoute);

//initialize a middleware for 404 error:
app.use((request: Request, response: Response, next: NextFunction) => {
  response.status(404);
  next(createHttpError(404, "Endpoint not found"));
});

//initialize an error handler middleware
//it's down below so it's not invoked first when calling next()
app.use((error: unknown, req: Request, res: Response, next: NextFunction) => {
  console.log(error);
  let errMsg = "An unknown error occurred";
  let statusCode = 500;
  if (isHttpError(error)) {
    statusCode = error.status;
    errMsg = error.message;
  }
  res.status(statusCode).json({ error: errMsg });
});

export default app;

```
