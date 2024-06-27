<!-- @format -->

# Cookies with Cookie-parser:

using cookies in express is very easy but similar to the `request body` it's not parsed by default leaving that to third party packages like `cookie-parser`.

using:

```powershell
pnpm i cookie-parser
```

we get access to the `cookie-parser` middleware, so you can import it since it's the default export for the package

```javascript
import cookieParser from "cookie-parser";
```

then used at the very top of the app:

```javascript
//can optional take a string `secret` to be used with signed cookies
app.use(cookieParser());
```

now we can send the client a cookie using the `response.cookie`:

```javascript
app.get("/", (request, response) => {
	//cookie(name, value, {options})
	response.cookie("hello", "world", {
		maxAge: 10000 * 10, //this the expiring time in milliseconds,
		signed: true, // creates a signed cookie based on the `secret` passed to the `cookieParser` middleware
	});
	response.status(200).send("success");
});
```

now in your request you can read the cookies via `request.cookies`

```javascript
app.get("/api/products", (request, response) => {
	console.log(request.cookies); //parsed coolies, {cookieName: val}
	if (request.cookies.hello && request.coolies.hello === "world") {
		return response.status(200).send("there you go");
	}
	return response.sendStatus(403);
});
```

but it's better and more secure to hide the actual value in the cookies, for that we use the `singed` option on the `response.cookie` & the `secret` passed to the `cookieParser` middleware,but the `request.cookies` will now contain the encrypted value which we don't know, but there is a solution to read the actual value, using the `request.signedCookies` we have access to the request signed cookies with their actual values.

```javascript
app.use(cookieParser("secret"));

app.get("/", (request, response) => {
	response.cookie("hello", "world", {
		maxAge: 10000 * 10, //this the expire time in ms,
		signed: true, // creates a signed cookie based on the secret based to the `cookieParser` middleware
	});
	response.status(200).send("success");
});

app.get("/api/products", (request, response) => {
	console.log(request.signedCookies); // the signed cookies object, where you found the actual value of the cookie
	if (request.signedCookies.hello && request.signedCookies.hello === "world") {
		return response.status(200).send("there you go");
	}
	return response.sendStatus(403);
});
```
