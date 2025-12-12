<!-- @format -->

# Handling Form data:

let's assume we have the following form:

```html
<form
	action="form/index.php"
	method="post">
	<label for="username">username</label>
	<input
		type="text"
		name="username"
		id="username" />
	<!--  -->
	<label for="email">email</label>
	<input
		type="email"
		id="email"
		name="email" />
	<!--  -->
	<label for="password">password</label>
	<input
		type="password"
		id="password"
		name="password" />
	<!--  -->
	<label for="role">role</label>
	<select
		name="role"
		id="role">
		<option value="user">user</option>
		<option value="admin">admin</option>
	</select>
	<!--  -->
	<button type="submit">Submit</button>
</form>
```

notice we used the `action` and `method`, these are really important as they control where to send the form data and the HTTP verb in order.

inside of `form/index.php`:

```php
// checking for the correct HTTP method
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
  echo $_POST["email"]; //from the POST request extract email -> fromData.email
}
```

keep in mind that leaving it as it is leaves the site vulnerable to hacking, so we better sanitize the incoming data, we can do this using the built-in function of `htmlspecialchars`:

```php
$email = htmlspecialchars($_POST["email"]);
```

we can do things like returning the user if the data is not valid:

```php
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
  $email = htmlspecialchars($_POST["email"]);
}
else header("Location: ../index.php"); // changes the location header, so redirects
```

---

## Validation:

of course it's important to validate user input, say a user somehow left a field empty, we check this with?..., yep you guessed it the function called `empty`.

`empty` returns a boolean which is true if the argument's value is empty and false if not.

```php
if(empty($email)) exit(); //stops the current script
```
