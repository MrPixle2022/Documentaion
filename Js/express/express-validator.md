<!-- @format -->

# Express validator:

## setup:

use command:

```powershell
pnpm install express-validator
```

to add it to your project.

---

## query validation:

import the `query` middleware from `express-validator`

use it before any request handler like:

```javascript
app.get(
	"/",
	query("queryName")
		.notEmpty() //checks if the data has a value
		.isString() //checks if the type is string
		.withMessage("msg") //the error message used if the previous validation is false
		.isLength({ min: 1, max: 10 }) //check if the validated value's length is between 1, 10
		.widthMessage("msg2"),
	(req, res) => {},
);
```

then in the request handler use the `validationResult` method & pass it the request object.

```javascript
const result = validationResult(req);
if (!result.isEmpty())
	//if any validation error found
	return res.status(400).send({ errors: result.array() }); //the array method returns an array of all the validation errors
```

so an example will be like:

```javascript
import { query, validationResult } from "express-validator";

app.get(
	"/api/users/",
	query("filter")
		.isString()
		.notEmpty()
		.withMessage("wait wait, is it empty or am i blind")
		.isLength({ min: 3, max: 10 })
		.withMessage("Wait wait what is the piece of shit"),
	(req, res) => {
		//req["express-validator#contexts"]) //created by the query middleware
		const result = validationResult(req); //extracts the validation errors;
		console.log("🚀 ~ app.get ~ result:", result);
		const {
			query: { filter, value },
		} = req;
		if (filter && value) {
			return res.send(mockUsers.filter((user) => user[filter].includes(value)));
		}
		res.status(200).send(mockUsers);
	},
);
```

this also applies for the `body, head, etc...` method.

---

## validating multiple fields:

to validate multiple arrays you use multiple middlewares but in a square bracket:

```javascript
app.post(
	"/api/users/",
	[
		//field 1
		body("username")
			.isString()
			.notEmpty()
			.isLength({ min: 2, max: 15 })
			.withMessage("username can't be empty or not a string"),
		//field 2
		body("displayname").notEmpty().withMessage("display name can't be empty"),
	],
	(req, res) => {},
);
```

---

## validating with a schema:

`express-validator` gives the option of using schemas to organize the code & the validation.

by creating an object you specify each field you want to validate as a nested object, in each one you use names the same as the method name for example:

```javascript
export const createUserValidationSchema = {
	username: {
		isLength: {
			//the check of the `isLength`
			options: { min: 3, max: 10 }, //the options
			errorMessage: "user name must have a length between 3, 10", //the `withMessage`
		},
		//the `isString`
		isString: { errorMessage: "Username must be a string" },
		notEmpty: { errorMessage: "Username can't be empty" },
	},
	displayname: {
		//the `notEmpty`
		notEmpty: { errorMessage: "display name can't be empty" },
	},
};
```

then import the `checkSchema` and replace the middleware with it:

later on you can use the `matchedData` which is the function that returns an object with all the validated values

the `checkSchema` will check for `body`, `query`, etc..

```javascript
app.post("/api/users/", checkSchema(createUserValidationSchema), (req, res) => {
	const result = validationResult(req);
	console.log("🚀 ~ result:", result);
	if (!result.isEmpty())
		return res.status(400).send({ errors: result.array() });

	//the validated data
	const data = matchedData(req);
	console.log("🚀 ~ data:", data);

	const newUser = { id: mockUsers.at(-1).id + 1, ...data };
	mockUsers.push(newUser);
	res.status(201).send(newUser);
});
```
