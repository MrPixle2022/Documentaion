# Body parameters:

`Body parameters` are a special type of parameters, they are sent through the request. 

before using them you must use a special middleware at the top of your file after creating the express instance that is `express.json()` this will parse the incoming request's body to json.

```javascript
import express from "express"

const app = express()
const port = 3000

app.use(express.json())
```

later the `body params` can be accessed through `request.body`.
