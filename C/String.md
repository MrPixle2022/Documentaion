# String

a string is a data type that is used for text, simply it's an array of `char`s -so `char x[]`- or `char *`.

in c a string is:

- text representation
- any number of `char`s ending in a null-terminator `\0` which is used to define the end of a string.
- a pointer to the first element in an array of characters

in c the size of a string is determined by the position of the null-terminator at it's end, this is how `stdlib`'s `strlen` function work.

the `\0` will be automatically added by the compiler.

but note tha if we have something like:

```c
char *str = "abcd";
str[0] = 'k';
```

the code above would yield a segmentation fault.

any set of strings within a pair of `" "` ended by the null-terminator is considered a string literal, string literals can be used to initialize a char array, so for example:

```c
int main(){
    char s1[] = "abcdef";
    s1[0] = 'x';
}
```

in the previous code, an array of characters of size 7 is created on the stack -since it's a local var to main-, and since it's on the stack we can modify it, however, since the C standard does not know where to store string literals, most of the time it's stored in places where we lack access of writing, so we end up with a pointer to a character that we cannot write or modify, however we can read just fine

---

## String.h

the `string.h` has many great utility functions for working with strings, all the following functions are included in the `string.h` file

---

## strlen

`strlen` returns the length of the given address:

```c
char str[] = "123";
int size = strlen(str); // 3
```

the advantage of using `strlen` over just `sizeof` is that `strlen` doesn't account for the null-terminator, moreover `sizeof` returns the byte size not the actual length of the string:

```c
char alphabet[50] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
printf("%zu\n", strlen(alphabet));   // 26
printf("%zu\n", sizeof(alphabet));   // 50
```

## strcat

the `strcat` is used to concat 2 strings, it doesn't return the result, instead it attaches the 2nd string to the first

```c
char str1[20] = "Hello ";
char str2[] = "World!";

strcat(str1, str2);
printf("%s", str1); // Hello Wold!
```

make sure that the first string has enough space to concat the other string

to concat a certain number of chars use `strncat`, it takes 1 additional argument that being the number of characters to the destination string

```c
char myStr[20] = "Hello";
strncat(myStr, " World!", 5);
printf("%s", myStr); //Happy Worl
```

## strcpy

the `strcpy` copies the value of the one string into the other

```c
char str1[20] = "Hello World!";
char str2[20];

//     dest, src
strcpy(str2, str1);
printf("%s", str2);
```

to copy only a portion of the string use `strncpy`, it takes one more option which is the number of characters to copy

```c
char str1[] = "Hello World!";
char str2[] = "Write code!";
strncpy(str2, str1, 6);
printf("%s\n", str2); //Hello code!
```

## strcmp

`strcmp` checks if 2 strings or equal or not, returning 0 for true, and any other value false

```c
char str1[] = "Hello";
char str2[] = "Hello";
char str3[] = "Hi";

printf("%d\n", strcmp(str1, str2));  // Returns 0 (the strings are equal)
printf("%d\n", strcmp(str1, str3));  // Returns -4 (the strings are not equal)
```

want to compare specific parts of the string?, use `strncmp`, in addition to receiving the max number of characters to be compared as the 3rd argument, the function runs as follows:

- if `n` comparisons were made without any mismatch the function returns 0
- if the functions reaches the end of both strings without any mismatch the function returns 0
- at the first mismatch if the ASCII value of the char in the 1st string is greater than the char in the 2nd string it returns a positive number
- otherwise the 2nd string's char's ASCII value is greater it returns a negative value

to simplify, it basically does the following:

```c
char1 - char2
```

but the chars are in ASCII code, and returns the value when they don't equal zero, reached the limit, reached the end with no mismatch

```c
char myStr1[] = "ABCD";
char myStr2[] = "ABCE";
int cmp = strncmp(myStr1, myStr2, 3);
if (cmp > 0) {
  printf("%s is greater than %s\n", myStr1, myStr2);
} else if (cmp < 0) {
  printf("%s is greater than %s\n", myStr2, myStr1);
} else {
  printf("%s is equal to %s\n", myStr1, myStr2); //printed
}
```

---

## memcpy

the `memcpy` is used to copy some data from a place to another, this function operators on **raw byte buffers** not NULL-terminated strings

the definition is as follows:

```c
void *memcpy(void *restrict dest, const void *restrict src, size_t n);
```

only `n` bytes are copied

an example would be:

```c
int arr1[5], arr2[5];
memcpy(arr1, arr2, sizeof(arr1));  // copies all 5 integers
```

> [!IMPORTANT] the `dist` and `src` must not overlap, if they overlap then this is undefined behavior

---

## memmove

the `memmove` acts like `memcpy` however it's safe when both src and dist overlap

```c
void *memmove(void *dest, const void *src, size_t n);
```

for example:

```c
char s[] = "hello world";
memmove(&s[0], &s[6], 5);  // s is now "world world"
```

`memmove` is best used when shifting elements within a single array

---

## memset

the `memset` function fills the first `n` bytes of `s` by the byte value of `c` (cast to unsigned char), the function returns `s`

```c
void *memset(void *s, int c, size_t n);
```

it's commonly used to **zero-intialize** buffers and structs

```c
int buf[100];
memset(buf, 0, sizeof(buf));  // sets all 100 ints to 0

char str[64];
memset(str, 0, sizeof(str));  // NUL-terminate / clear
```

> [!IMPORTANT], setting `c` to `1` will actually set every byte to `0x01` or `0x01010101` on 32-bit system

---

## memcmp

the `memcmp` is used to compare the first `n` bytes of `s1` and `s2` byte by byte as `unsigned char`

```c
int memcmp(const void *s1, const void *s2, size_t n);
```

the function returns `0` for match, `> 0` if the first differing byte in `s1` is less than in `s2`, `<0` if the first differing byte in `s1` is greater than in `s2`

```c
struct Point { int x, y; };
struct Point a = {1, 2}, b = {1, 2};
if (memcmp(&a, &b, sizeof a) == 0) /* equal */
```
