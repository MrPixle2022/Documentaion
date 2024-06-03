# Server actions:

server actions are `async functions` that are used on the server by next like the are an `api` call.

you can create them easily by using the `"use server"` directive either at the top of the page or inside every function.

```javascript
export async function CreatePost(formData) {
  "use server" //now it's a server action, server actions must be async.
  const { title, slug, userId, desc } = Object.fromEntries(formData);
  try {
    connectToDb();
    const thisPost = new Post({ title, slug, userId, desc });
    await thisPost.save();
    console.log(`success`);
    revalidatePath("/blog");
  } catch (error) {
    console.log(error);
  }
}
```

then they could be used to handle `form actions` for example:

```html
<form action={ CreatePost }>
  <input type="text" placeholder="title" name="title" required />
  <input type="text" placeholder="desc" name="desc" required />
  <input type="text" placeholder="slug" name="slug" required />
  <input type="text" placeholder="userId" name="userId" required />
  <input type="submit" value="submit" />
</form>
```
