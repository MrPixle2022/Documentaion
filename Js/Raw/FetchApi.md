# Fetch API

---

### fetch(url, { options }):

the fetch api is a promise based api that takes a url by default to send a GET request to the url
the fetch returns a response object and since it uses promises it's async.

example:
```javascript
let response = fetch("www.someApi.com")
```

---

### json promise method:

to get the data as a json you use the json method:

```javascript
let response = fetch("www.someApi.com")
    .the(res => res.json())
    .then(json => json)
```

> [!IMPORTANT]
> the fetch api doesn't throw an error unless it's a connection error
> to check for the success of the request use status and statusText in the then method, after that use the ok property to check if every thing is good

---

### { options } object:

the options object is used to give more info about the request like the method, headers and body.

here we post some data with the post method:

```javascript
let data = {
    name : 'amr',
    age: 10
}

fetch("www.someApi.com", {
    method: 'POST',
    headers: {
        'Content-type': 'application/json'
    },
    body: JSON.stringfy(data)
}).then(res => res.json()).then(json => console.log(json))
```
