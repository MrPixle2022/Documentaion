# Setup

first insure you have a compiler, a recommendation is the **gcc** or GNU compiler collection, this can be done as follows:

- Linux:

```bash
sudo apt install gcc
```

- Windows: install the gcc compiler from `https://www.mingw-w64.org/downloads/`

create a file ending in:

`.c` for c code

`.h` for header files (have definition for code that is to be included)

for the most part -using `.c` extension- the file starts with the `#include` pre-processor, then you have the `main` function which is the project’s entry point. a project may have n number of files, but only 1 file can have the `main` function.

```c
#include <stdio.h>

int main(){
	printf("Hello, World!\n");
	return 0;
}
```

the 1st line loads the built-in **stdio.h** which includes many useful function for interaction with the std I/O aka the terminal.

`printf` is a function that writes the given text/string to the terminal.

---

## Compiling

when we want to run the app we will have to compile the source code into a machine-readable format, the app is to be executed as follows:

```bash
gcc <path-to-source-file>
```

this will compile our file into an executable named `a.out`, to alter the name of the output use the `-o` flag followed by the executable's name:

```bash
gcc main.c -o main
```

---

## Comments

in c we can create comments using `//` for single line comments, `/* */` for multi line one.

```c
// Comment
/*
    comment
    also comment
*/
```

---

## Header files

header files are c files with the extension of `.h`, in those files function prototypes are defined with some custom structs also if there are any.

when we use `#include` c will copy the content of that file and insert into our file, this means we can come across a multiple-inclusion problem, it happens when a file is included multiple times causing errors related to redefining functions and structs.

this can be solved using `#pragma once` at the top of the file
