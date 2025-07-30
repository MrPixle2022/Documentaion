# Variables:

to define a variable in c we use the following syntax:

```c
// type name = value;
// type name; //can't be used until assigned
```

so for example:

```c
int age = 17;
printf("Hello %d", age); // replace %d with age
```

in c we have:

- int -> for integers (%d)
- float -> floating point numbers, keeps 6 digits after the point (%f)
- double -> precise point number, keeps around 15 digits after the point (%f)
- char -> a single character in `''` (%c)
- char [] -> a string or an array of characters (%s)
- char * -> also a string -useful for function return types-
- bool -> a boolean, requires `stdbool.h` to be included (%d)

for example:

```c
int age = 17; // (4 bytes)
float gpa = 2.256f; // (4 bytes)
double euler = 2.7182818284590; // (8 bytes)
char a = 'A'; // (1 byte) must use ''
char name[] = "Amr"; //(variable size)  use ""
bool isTrue = 1; // (1 byte)

printf("You are %d\n", age);
printf("Your gpa %.2f\n", gpa);
printf("Euler constant = %.15f\n", euler);
printf("Your grad is %c \n", a);
printf("Your name is %s\n", name);
printf("Is it true %d", isTrue);
```

note that for bool we can also use `_Bool`.

> [!NOTE]
> you can define variables outside the `main` function, this is c's global scope, though this is not recommended

> [!TIP]
> use `const` before the type to declare a constant

---

## int:

ints are used to hold whole-numbers they take up **4 bytes**, the range from `-2,147,483,648` to `2,147,483,647` and have an FS of `%d`.

from int we also have:

- `unsigned int` -> from **0** to **2,147,483,647**
- `short int` -> It is lesser in size than the int by **2 bytes** so can only store values from `-32,768` to `32,767`.
- `unsigned short int` -> from **0** to **32,767**
- `long int` -> for values that are grater then what normal int can take, it takes more then normal int at `8 bytes`
- `long long int` -> even bigger integers, it takes 8-bytes
- `unsigned long long int`-> you get the idea
- `stdlib -> size_t` -> unsigned integer used to store memory sizes

---

## Char:

represents a single character, takes **1-byte** and ranges from -128 -> 127 or 0 -> 255.

- `singed char` -> -128 -> 127
- `unsigned char` -> 0 -> 255

---

## float:

stores a precision floating-point value, takes **4-bytes**.

---

## double:

stores decimal numbers with **double** the precision of a float like 16 - 17 digits after the point, takes **8-bytes**

`long double` -> 16 bytes and way bigger range

---

## Type casting:

we type cast in c using the following syntax:

```c
(type) value;
```
