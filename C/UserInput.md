# User input

to accept user input in c we can use the `scanf` method, the method takes the FS for our type and an address to store the given value in, getting the address can be done with a pointer or using `&varName` to get the memory address.

```c
int age = 0;

printf("Age -> "); //print prompt
scanf("%d", &age); //scan for an int
```

note that when we press `ENTER` to enter the value, the `\n` -the enter- will be registered into the input buffer, so on the next scan it will be inserted before our next input, though we can avoid that by add a ` ` in the next scanf call.

```c
int age = 0;
float gpa = 0.0f;

printf("Age -> ");
scanf("%d", &age);

printf("GPA -> ");
scanf(" %f", &gpa); //the space before %f ignores the \n
```

note that `scanf` returns `1` for success and `EOF` for failure

---

## fgets

`fgets` is the replacement for the `gets` function, `fgets` stands for **"file get string"**, this function takes the following arguments in order:

1. string (char pointer)
1. size of string (accounting for the `\0` or null terminator)
1. stream/source (usually a file, but we can use `stdin`)

the signature or the `fgets` function is as follows:

```c
char *fgets(char *str, int num, FILE *stream);
```

the function will stop reading on:

- encountering a new line
- filling the buffer
- reading `EOF` or end of file

note the function will retain the `\n` character, and will also append the `\0` in the end of the string, so the buffer must account for 1 additional byte for the null-terminator

it returns the pointer provided to it -akd the `str` argument-, or `NULL` if it fails to read.

---

## getchar

if we only want to read 1 character we can use `getchar`, this function will read one character from the user input and return it in it's ASCII code format

```c
char a = getchar();
```
