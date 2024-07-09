<!-- @format -->

# setup:

start by creating a new directory to hold your app then initialize a new npm project:

```powershell
npm init -y
#or
pnpm init
```

then install `express`:

```powershell
npm i express

#or

pnpm i express
```

now in the `package.json` setup the scripts:

```json
"scripts": {
  "start": "node <path to the main file>",
  "start:dev": "nodemon <path to the main file>"
},
```

just don't forget to set the `type` to `module` to use the `import` & `export` in your file and it's better to use `.mjs` instead of `.js`

now create a `.mjs` file in it import `express` from `"express"`:

```javascript
import express from "express"

//initialize a new express instance
const app = express()
const port = 3000 //the port on which the app will run

//sets the server to listen to any request to the given route
//listen(port, callback)
app.listen(port, () => {
  console.log(`Running at: http://localhost:${port}`)
})

```

now install `cors`:
```powershell
pnpm i cors
```

then use it directly under the `app`.

```javascript
const app = express();
app.use(cors({
  origin: ['http://example1.com', 'http://example2.com'], // Array of allowed origins
  methods: ['GET', 'POST'], // Array of allowed HTTP methods
  allowedHeaders: ['Content-Type', "Authorization"], // Array of allowed headers
  exposedHeaders: ['Authorization'], // Array of headers exposed to the client
  credentials: true, // Allows credentials like cookies to be sent with the request
  preflightContinue: false, // Passes the CORS preflight response to the next handler
  optionsSuccessStatus: 200 // Sets the status code for options success
}))
```

the `preflight` response is a response sent to the server before the request being handled, it checks if the request can pass the cors or not.