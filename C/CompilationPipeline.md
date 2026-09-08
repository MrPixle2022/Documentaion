# Compilation pipeline

---

## Preprocessing

the preprocessing stage is the very first step of compiling a C program, this step is handled by the preprocessor which obeys instructions beginning with `#` which are called `directives` by:

- removing comments
- expanding macros
- expanding included files
- replacing symbolic constant defined with `#define` with their values

the preprocessor outputs the file as a `.i` file, we can stop the compilation at this step using the `-E` flag

---

## Compiling

the compiling process is responsible for generating the IR code or intermediate representation from the preprocessed file, the output is produced as a `.s` file, some compilers may also generate assembly code at this step

to stop the compilation at this step use the `-S` flag

---

## Assembling

the assembler takes the generated IR code, converts it into object code, or in other word machine code/binary

the output of this step is an object file with the extension `.o`, we can stop at this step using the `-c` flag

> [!NOTE]
> `.0` files are **not** text files, there content is not human-readable

---

## Linking

linking is the final step of compiling the c code into an executable, it's responsible for linking object code of all source files together, the linker searches for the function definition in both static and dynamic libraries

static libraries are the result of the linker copying all the used libraries functions to the executable files

dynamic libraries on the other hand are not copied, it's only the name of the library that is placed in the binary

the linker can be informed of visibility of some code using `static` and `extern`

`static` makes a variable/function visible only within it's translation uint, basically **private**

however a `static` local variable is made to be persistent across function calls, and is only visible within it's function

`extern` is used to declare to the compiler that this variable exists somewhere else without allocate the space for it yet, it's now up to the linker to find the definition

most of the time external vars/functions are defined in header files

external variable can be used as a global variable shared between many files that are linked together

also something like;

```c
extern int x;

void doSmth(){
    int x = 10;
}
```

when the `doSmth` is called, the compiler will find a declaration and initialization to variable `x`, but it already knows that it should expect a definition for the external int x, hence `extern int x` becomes initialized to 10
