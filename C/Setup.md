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
# compile the file
gcc main.c -o main
# run the file
./main
```

the build process goes as follows:

1. **Preprocessing:**

    in this step the following happens:
    - comments are removed
    - header files are added
    - macros are replaced with their values

    to stop the compiler at this step use the `-E` flag

2. **Compiling:**

    The compiler generates the IR code (Intermediate Representation) from the preprocessed file, so this will produce a **".s"** file. That being said, other compilers might produce assembly code at this step of compilation.

    We can stop after this step with the `-S` flag

3. **Assembling:**

    at this step code -IR- is translated into object code found in **”.o”** files, the object code is basically the machine code.

4. **Linking:**

    in this stage all object code of all source files are linked together .

    The linker knows where to look for the function definitions in the **static libraries** or the **dynamic libraries**.

    Static libraries are the result of the linker making a copy of all the used library functions to the executable file. The code in dynamic libraries is not copied entirely, only the name of the library is placed in the binary file.

By default, after this fourth and last step, that is when you type the whole "**gcc main.c**" command without any options, the compiler will create an executable program called **main.out** (or **main.exe** in case of Windows) that we can run from the command line.

We can also choose to create an executable program with the name we want, by adding the "**-o**" option to the gcc command, placed after the name of the file or files we are compiling.

we can run the final output file which we have specified after the **”-o”**

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
