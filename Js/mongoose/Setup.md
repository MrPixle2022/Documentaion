# Mongoose setup:

to setup mongoose in your project install it by using:
```nodejs
npm install mongoose
```

then import it in the a js(recommended to create a separate file for that) file:

```javascript
import mongoose  from "mongoose";
```

then establish a connection with the data base:

```javascript
const connect = async (DATABASE) => {
    try {
        await mongoose.connect(DATABASE)
        console.log("connected")
    } catch (error) {
        console.error(error);
    }
}

export default connect
```

this function will be responsible for the connection with the db.
then import it in your main file.

then pass the url to the function, the url will have the name of the db at the end like:

`"mongodb://127.0.0.1:27017/test"`

