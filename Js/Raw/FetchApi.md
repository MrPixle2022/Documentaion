<!-- @format -->

# Fetch API

---

### fetch(url, { options }):

the fetch api is a promise based api that takes a url ,by default it sends a GET request to the url the fetch returns a response object and since it uses promises it's async.

example:

```javascript
let response = await fetch("www.someApi.com");
```

---

### json promise method:

to get the data as a json you use the json method:

```javascript
let response = fetch("www.someApi.com")
	.the((res) => res.json())
	.then((json) => json);
```

> [!IMPORTANT] the fetch api doesn't throw an error unless it's a connection error to check for the success of the request use status and statusText in the then method, after that use the ok property to check if every thing is good

---

### { options } object:

the options object is used to give more info about the request like the method, headers and body.

here we post some data with the post method:

```javascript
let data = {
	name: "amr",
	age: 10,
};

fetch("www.someApi.com", {
	method: "POST", //thr request verb
	headers: {
		"Content-type": "application/json", //the request body payload type
	},
	// The mode option is used to specify whether the request should be made using CORS or not.
	// Setting it to "cors" allows the request to include credentials.
	// This is necessary when making requests to a server that requires authentication.
	mode: "cors", //
	body: JSON.stringfy(data),
	credentials: "include", //send the cookies with the request but requires the server to set the response header "Access-Control-Allow-Credentials" to true, it allows cookies to be sent
})
	.then((res) => res.json())
	.then((json) => console.log(json));
```

the `headers` can also take:

```javascript
headers: {
    // Specifies the type of data being sent in the request body
    'Content-Type': 'application/json',

    // Specifies the type of data that the server will return in the response
    'Accept': 'application/json',

    // Specifies the authorization token for the request
    'Authorization': 'Bearer your_token_here',

    // Specifies the language of the response
    'Accept-Language': 'en-US',

    // Specifies the character encoding of the request and response
    'Content-Encoding': 'gzip',

    // Specifies the character encoding of the request and response
    'Accept-Encoding': 'gzip',

    // Specifies the user agent of the client making the request
    'User-Agent': 'Your User Agent',

    // Specifies the cache control directives for the request
    'Cache-Control': 'no-cache',

    // Specifies the request credentials (such as cookies) to include in the request
    'Credentials': 'include',

    // Specifies the mode for the request (e.g., cors, no-cors, same-origin)
    'Mode': 'cors',
  },
```
