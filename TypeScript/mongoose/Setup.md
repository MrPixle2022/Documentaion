# Mongoose setup:

---

unlike other modules & libraries, mongoose provides type support standalone.

first add it to the project.

```powershell
pnpm add mongoose

pnpm install mongoose
```

---

then create a connection to the db.

```typescript
mongoose
  .connect(process.env.MONGO!)
  .then(() => {
    console.log(`successfully connected`);
    //port!: means that the port will always be defined
    app.listen(port!, () => console.log(`http://localhost:${port}`));
  })
  .catch((err) => console.log(err));
```
