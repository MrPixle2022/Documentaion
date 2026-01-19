<!-- @format -->

# Variables:

in java we define a variable using the following syntax:

```java
type name = initialValue;
```

data types include:

- `int` -> an integer number
- `long` -> a huge integer number
- `short` -> small integer number
- `byte` -> a byte integer
- `float` -> single precision decimal, add `f` at the end of value
- `double` -> double precision decimal
- `char` -> one single character
- `String` -> an array of chars

you can initialize multiple variables at once if they share a type:

```java
int x, y;
// if we want to assign values as well
int a = 10; b = 5;
```

---

## Type conversion:

in java we can sometimes convert one type to another using type casting:

```java
double d = 3.95;
int i = (int) d;// 3
```

in this example we are converting a double into an integer using type casting, using typecasting we may lose some data -in this case all digits after the `.`- and also may have an exception thrown if conversion fails.

when working with classes if you cast to a parent class it's called `up-casting` and if you are casting a parent to a subclass it's called `down-casting`, now this when using `up-casting` you are lo-sing the extra methods and variables in the subclass.
