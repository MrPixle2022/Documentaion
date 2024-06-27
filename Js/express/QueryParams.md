# Query parameters:

`query parameters` are parameters that are sent in the url, in most cases it help in sending sorting data.

they appear at the end of a utr like `/?query1=val&query2=val`

they are accessed through the `request.query` object:

```javascript

const app = express();
const port = process.env.PORT || 3000;

const mockUsers = [
  {
    id: 0,
    username: "amr yasser",
    displayname: "mr_pixel",
  },
  {
    id: 1,
    username: "ammar tareq",
    displayname: "alpha_1",
  }
  ,
  {
    id: 2,
    username: "mohammed abdelmaqsood",
    displayname: "alpha_2",
  }
]

app.get("/api/users", (request, response) => { 
  const { query: { filter, value } } = request;
  if (filter && value) {
    response.send(
      mockUsers.filter((user) => user[filter].includes(value))
    )
  }
  response.send(mockUsers)
})
```
