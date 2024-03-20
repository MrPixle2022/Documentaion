# setup:

to install express globally use;

```powershell
npm i express -g
```

you can either install each time or in you project use [link](../npmCommands/Npm.md#link).

create a file like `index.js` or `app.js`
,then import the express library.

```javascript
import express from 'express'
```

now you have access to the express framework, now you can start the server by using the [listen](../node/HTTPModule.md#listenport-callback) function.

```javascript
import express from 'express'

const app = express();

app.listen(8000, () => console.log('started @port 8000'));
```

this will create a local server at the port `8000`
