<!-- @format -->

# Variables:

in php defining the variables is done by using `${varname}` for example `$name`, this is how you define and use the variables:

```php
$myVar= 1;

$myVar; //1
```

also keep in mind that php is a dynamically-typed language, so the type of data stored in a variable could be anything.

```php
$myVar = 1;
$myVar = "1";
```

we can also integrate values of variables inside text as in using `${}` in javascript but in php we just use the variable:

```php
$name = "pxl";
echo "my name is $pxl"; //my name is pxl
```

and also we can:

```php
$verb = "eat";
echo "I'm ${verb}ing"; // I'm eating
```

---

## Data types:

in php we have some default data types such as:

#### scalar types:

- string
- integer
- float
- boolean

```php
$string = "some string";
$integer = 1234;
$float = 3.1459;
$boolean = true; //also uses false
```

#### other:

- arrays
- objects

```php
// array
$arr = array("elem1", "elem2", "elem3" /*...*/);
$arr = ["elem1", "elem2", "elem3" /*...*/];
// object
$obj = new Class1();
```

> [!TIP] you can initialize a variable with no value and based on the context php will assume a type and use it's default value.

- string -> ""
- int, float -> 0 , 0.0
- boolean -> false
- array -> []
- object -> null

though leaving a variable with no value on initialization in discouraged
