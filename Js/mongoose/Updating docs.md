# Update docs:

to **update** a doc use:

- `updateOne`
- `updateMany`

### updateOne():

the `updateOne` takes two object first holds the conditions that specifies which doc to change, second is what field to update

```javascript
modelName.updateOne({key: val}, {key: newVal})
```

for example:

i created a new function that updates a doc based on it's `name` and assigns the `name` field a new value:

```javascript

export async function updateDoc(name, newName)
{
    const res = await UserModel.updateOne({name: name}, {name: newName})
    console.log('success');
}
```

then i made it listen to any `get` request on `/up`.

```javascript
app.get('/up/:oldName/:newName', (req,res) => {
    const {oldName,newName} = req.params;
    updateDoc(oldName, newName);
})
```

the `updateMany` works similar but instead of getting the first doc that meets the conditions it updates all.

