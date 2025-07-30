# String:

a string is a data type that is used for text, simply it's an array of `char`s -so `char x[]`- or `char *`.

in c a string is:

- text representation
- any number of `char`s ending in a null-terminator `\0` which is used to define the end of a string.
- a pointer to the first element in an array of characters

in c the size of a string is determined by the position of the null-terminator at it's end, this is how `stdlib`'s `strlen` function work.

the `\0` will be automatically added by the compiler.


if we have:

```c
char* str = "Hello world";
```

then:

```c
str;// pointer || the string
*str; //the char
str++; //moving to the next index, this updates the reference so be careful
// works with char [] and char *
str[index]; // access the char at index
```

you can print the string as follows:

```c
printf("%c", *str); //the first char -if pointer is not modified-
printf("%s", str); //the entire string
```

---

## String.h:

the `string.h` file has a set of helpful methods for strings.

- `strcopy`

takes 2 strings and copies the content of the second into the first.

```c
char src[] = "Hello";
char dest[6];
strcpy(dest, src);
//dest = "Hello"
```

- `strcat`

takes two strings and joins them together.

```c
char dest[12] = "Hello";
char src[] = " World";
strcat(dest, src);
// dest = "Hello World"
```

- `strlen`

return the length of the given string excluding the null-terminator

```c
char str[] = "Hello";
size_t len = strlen(str);
// len is 5
```

- `strncpy`

takes 2 strings and an integer, copies `n` number of chars from the second string into the first.

```c
char src[] = "Hello";
char dest[6];
strncpy(dest, src, 3);
// dest = "Hel"
dest[3] = '\0'; //ensures null terminator
```

- `strncat`

takes 2 strings and an integer, concatenates `n` number of chars from the second string with the first one.

```c
char dest[12] = "Hello";
char src[] = " World";
strncat(dest, src, 3);
// dest = "Hello Wo"
```

- `strchr`

return a pointer to the first occurrence of the given char in the given string

```c
char str[] = "Hello";
char *pos = strchr(str, 'l');
// pos points to the first 'l' in "Hello"
```

- `strstr`

returns a pointer to the first occurrence of the given substring in the given string

```c
char str[] = "Hello World";
char *pos = strstr(str, "World");
// pos points to "World" in "Hello World"
```
