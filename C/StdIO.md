# StdIO.h

The `stdio.h` (Standard Input/Output) header file provides the core functions for performing input and output operations in C. It includes functions for console I/O, file I/O, and string formatting.

## printf

the `printf` function prints a formatted output to the standard output stream, which is typically the console.

```c
int printf(const char *format, ...);
```

---

## scanf

the `scanf` function reads a formatted input from the standard input stream, which is typically the keyboard, the type of input is defined through the format specifier.

```c
int scanf(const char *format, ...);
```

a problem with `scanf` is that it doesn't preform any sort of boundary checks, which may cause a buffer overflow and also it tends to include new line characters -`\n`- and is in general terrible when working with strings, if you are using it to read a char the it's recommended to insert a space before the type-specifier

> [!WARNING]
> `scanf` is notoriously unsafe and difficult to use correctly. When reading strings with `%s`, it doesn't perform bounds checking, leading to buffer overflows. It also often leaves newline characters (`\n`) in the input buffer, which can cause problems for subsequent reads. For reading strings, `fgets` is a much safer alternative.

---

## sprintf

the `sprintf` function prints a formatted output to a string **instead** of the console.

```c
int sprintf(char *buffer, const char *format, ...);
```

it returns the number of characters copied into the buffer -not counting `\0`- and returns -1 on failure.

note that it doesn't run any sort of boundary checks and may cause buffer-overflows, so it's recommended to use `snprintf` instead.

---

## snprintf

the `snprintf` is a safer version of `sprintf`. It prints formatted output to a string but will not write more than a specified number of bytes, thus preventing buffer overflows.

```c
int snprintf(char *buffer, size_t size, const char *format, ...);
```

---

## fopen

the `fopen` is used to open a file and returns a `FILE` pointer to it. This pointer is used by other functions to interact with the file.

```c
FILE *fopen(const char *filename, const char *mode);
```

> [!TIP]
> Common modes include `"r"` (read), `"w"` (write, overwrites existing file), and `"a"` (append). Always check if the returned pointer is `NULL`, which indicates that the file could not be opened.

---

## fclose

The `fclose` function is used to close a file stream that was opened by `fopen`, flushing any unwritten data to the file. On success, it returns `0`. On failure, it returns the special value `EOF`.

```c
int fclose(FILE *stream);
```

> [!WARNING]
> Failing to close a file can lead to data loss (as output buffers may not be flushed) and resource leaks. Always pair a successful `fopen` with an `fclose`.

---

## fprintf

the `printf` function prints a formatted output to a file stream.

```c
int fprintf(FILE *stream, const char *format, ...);
```

> [!TIP]
> It works exactly like `printf`, but the first argument specifies the `FILE` pointer (e.g., one returned from `fopen`) where the output should be written.

---

## fgetc / feof / ferror

These functions are often used together to read a file character by character and correctly handle the end of the file or potential errors.

* `fgetc`: Reads the next character from a stream.
* `feof`: Checks if the end-of-file indicator for a stream is set.
* `ferror`: Checks if the error indicator for a stream is set.

```c
int fgetc(FILE *stream);
int feof(FILE *stream);
int ferror(FILE *stream);
```

> [!IMPORTANT]
> `fgetc` returns an `int`, not a `char`. This is because it must be able to return every possible character value (0-255) as well as a special value, `EOF` (End-Of-File), to indicate that the end of the file has been reached or an error occurred. You must use `feof()` and `ferror()` to determine the actual cause.

---

## fgets

Reads a line of text from a stream (like a file or `stdin`) and stores it in a string buffer.

```c
char *fgets(char *buffer, int size, FILE *stream);
```

> [!TIP]
> `fgets` is much safer than `gets` (which should never be used) because it limits the number of characters read to `size - 1`, preventing buffer overflows. It also reads the newline character (`\n`) if it fits in the buffer, which you may need to remove manually.

---

## perror

Prints a descriptive error message to the standard error stream (`stderr`) based on the value of the global variable `errno`.

```c
void perror(const char *s);
```

> [!TIP]
> This is very useful for diagnosing why a system call or library function (like `fopen`) failed. You can pass a custom string to `perror` which will be printed before the system error message, providing more context. For example: `perror("Error opening file");`.
