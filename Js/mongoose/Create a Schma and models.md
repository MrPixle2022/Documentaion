# Schemas and models:

`Schemas` allow you to define how the document in the db will look like, they allow you to set `types, default values, validators, etc...`

---

## create a schema

to create a schema use the schema constructor like:

```javascript
const usersSchema = new mongoose.Schema({
    name: {type: String, required: true, trim:true},
    age: {type: Number, required: true, min:1, max:100, validate: {validator: (v) => v > 1, message: props => props.value}}
})
```

the:

- `type`: sets the type of the field,
- `required`: makes sure a value is present
- `min` and `max`: sets a range
- `validate`: uses a function to check for validity and returns a message.

and there are others like:

- `default`: a function that sets the default value
- `lowercase`: a bool used to convert all letters into lowercase
- `uppercase`: a bool used to convert all letters into uppercase
- `immutable`: a bool that sets the key to be const and can't be overwritten
- `ref`: a string that defines what model this doc follows

---

## using schemas to create a model:

to use this schema and create models based on it use the schema to create an object from it like:

```javascript
const model = mongoose.model('collectionName', schema)
```

```javascript
const UserModel = mongoose.model('Users', UserSchema)
```


## creating a new doc:

```javascript
export const createDoc = async (name, age) => {
    try {
        const u1 =  new UserModel({
            name,
            age
        })

    const res = await u1.save()
    console.log(res)
    } catch (error) {
        console.error(error)
    }
}
```

then import this `createDoc` in the main js file and pass it the arguments it takes, for example:

```javascript
app.get("/:name/:age", (req,res) => {
    createDoc(req.params.name, req.params.age)
})
```

then if we for example used `http://localhost:8000/amr/10` i will see that in the db:

![Database](Imgs/CreateDocExample0.png)

or use the `create` method like:

```javascript
Model.create({data})
```

which takes care of every thing

---

## attaching a method on every instance:

to add a method to each instance of a schema the syntax is like:

```javascript
schemaName.methods.methodName = function(){---}
```

in this function use the `this` keyword to reference the instance

and used like:

```javascript
schemaName.methodName();
```

> [!WARNING]
> This syntax doesn't support arrow functions.

---

## attaching a static method:

to attach a static method the syntax look like:

```javascript
schemaName.statics.methodName = function(){---}
```

and used like:

```javascript
schemaName.staticMethodName();
```

---

## attaching a method to a query:

to attach a method to a query the syntax looks like:

```javascript
schemaName.query.methodName = function(){---}
```

and used like:

```javascript
schemaName.find().methodName();
schemaName.where().methodName();
```

---

## create a virtual:

to add a virtual the syntax looks like:

```javascript
schemaName.virtual('virtualName').get(function(){---})
```

the virtual is a property that won't be saved in the database but you have access to it in the code for example you can use it to get a text containing both the user's `name` and `email` so instead of calling each property you use the virtual property, and since it just depending on two already existing fields and it won't modify them in any way we don't want to save it in the db.