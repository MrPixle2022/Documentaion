<!-- @format -->

# Writing test:

in this example we will test this request handler:

```javascript
export const GetUserById = (req, res) => {
	const { id } = req.params;
	const parsedId = parseInt(id);

	if (isNaN(parsedId)) return res.sendStatus(400);

	const targetedUserIndex = mockUsers.findIndex((user) => user.id === parsedId);
	if (targetedUserIndex === -1) return res.sendStatus(404);
	return res.send(mockUsers[targetedUserIndex]);
};
```

will start by defining the possible outcomes of this function:

1. sendStatus(400) if the `id` is invalid
1. sendStatus(404) if the `user` was not found
1. send(user) if all is ok

now that we 've defined the outcomes we can start writing out test.

create a `__test__` folder to hold the test(the name isn't mandatory), then create a new file ending in `.test.js` or `.spec.js`

in that file write:

```javascript
// describe("test-name", function)
describe("GET: users/:id", () => {});
```

the `describe` method declares a test block, in the function we write our test.

now create a `mockRequest & mockResponse` to work as our test request and response.

```javascript
const mockRequest = {
	params: { id: 0 },
};
const mockResponse = {
	sendStatus: jest.fn(), //create a mockFunction
	send: jest.fn(),
};
```

the `jest.fn` creates a mock function that can will be called as if it were the original method, we can optionally pass the `fn` a function to set how the function work.

now we will test the first outcome:

```javascript
it("should get user based on the id", () => {
	//calling the function with the mock object
	GetUserById(mockRequest, mockResponse);
	//test whats is passed to based on the matcher
	expect(mockResponse.send).toHaveBeenCalled(); //checks if the mock  function has actually been called
	expect(mockResponse.send).toHaveBeenCalledWith(
		mockUsers[mockRequest.params.id],
	); //checks it the mock function was called and passed (mockUsers[mockRequest.params.id]) as an argument
	expect(mockResponse.send).toHaveBeenCalledTimes(1); //makes sure the function has only been called once
	//expecting the `.send` to not be called
	expect(mockResponse.sendStatus).not.toHaveBeenCalled();
});
```

lets understand the code above:

first we are creating a test for `GetUserById`

we are expecting the `send` method to be:

- called (`.toHaveBeenCalled`)
- passed the user in `mockUsers` with index `id` that exists in `request.params` (`.toHaveBeenCalledWith`)
- only called once (`.toHaveBeenCalledTimes`)

and expecting the `sendStatus` to `NOT` be called.

---

# Mocking modules:
