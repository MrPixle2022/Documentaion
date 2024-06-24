# Request type:

the `Request` type can take some generics to specify the data inside of it providing intellisense and type checking.

```typescript
req: Request<
{}, //req.params 
{}, 
{} , //req.body
{}>, //req.query
```


---

# Response type:

the response type takes generic type for the `the shape of the data sent as a response`

for example:

```typescript
type User = {
  username:string;
  age:number
}

res: Response<User>
```
