<!-- @format -->

# Predefined Variables:

php has some predefined variables, often called `super globals`.

---

## $\_SERVER:

the `_serve` super global can give access to info about the server for example:

```php
<?php
$_SERVER["DOCUMENT_ROOT"]; //where is the document on the server
$_SERVER["PHP_SELF"]; //path to the php file
$_SERVER["SERVER_NAME"]; //name of the host
$_SERVER["REQUEST_METHOD"]; //the http method
```

---

## $\_GET:

the `_get` holds data about the incoming get request:

```php
$_GET["query_1"]; //returns the value of query
```

---

## $\_POST:

same as `_get` but this time for `post` -who could have guessed:

```php
$_POST["yourBankPassword"];
```

---

## $\_REQUEST:

the `request` will do the same as get, post but it will look in the get, post, and cookies -cause why not-:

---

## $\_FILES:

the `files` holds data about the uploaded files by user

---

## $\_COOKIE & $\_SESSION:

do i really have to explain?

---

## $\_ENV:

the `env` variable -not the .env-

---

## $\_PHP:
