# C setup:

check for a c/c++ compiler using:

```bash
gcc --version
```

if you have it create a file named `main.c` and insert the following:

```c
// includes the standard IO aka access to the terminal
#include <stdio.h> //#include is a pre-processor directive

// the main entry point of our application
int main()
{
    //prints a formatted message into the standard output
    printf("Hello");

    // exit code
    // 0 ->  success
    // 1 -> error
    return 0;
}
```

---

## Comments:

in c we can create comments using `//` for single line comments, `/* */` for multi line one.

```c
// Comment
/*
    comment
    also comment
*/
```

---

## Header files:

header files are c files with the extension of `.h`, in those files function prototypes are defined with some custom structs also if there are any.

when we use `#include` c will copy the content of that file and insert into our file, this means we can come across a multiple-inclusion problem, it happens when a file is included multiple times causing errors related to redefining functions and structs.

this can be solved using `#pragma once` at the top of the file
