# Server setup:

---

start in your main `.ts` file.

import `express` from `express` and initialize a new server as if you were using javascript.

```typescript
import "dotenv/config";
import express, { Express, Request, Response } from "express";

//--------------------------------------------------
//----|SERVER SETUP|--->
const app: Express = express();
const port: number = process.env.PORT || 4000 

//--------------------------------------------------
//----|EndPoint|--->

//GET: /
app.get("/", async (req: Request, res: Response) => {
  res.send("this is a ts server")
});

app.listen(port!, () => console.log(`http://localhost:${port}`))

```


