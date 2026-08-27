# Functions

a function is a reusable block of code that may or may not return a value, in c only function exist, there are no methods.

define a function as follows:

```c
returnType functionName(type param1, type param2, ...){
    /*function body*/
    return value;
}
```

as in other languages:

```c
functionName(val1, val2); //calling the function, now we are dealing with the return value, if there is any
functionName; // the pointer to the function
```

> [!WARNING]
> Functions can't be called pre-declaration, for that use a function prototype.

---

## Main function

the `main` function which is the entry point of your program, the `main` function btw can be written is multiple forms such as:

```c
int main(){
 return 0;
}

int main(void){
 return 0;
}

int main(int argc, char *argv[]){
   . .
   return 0;
}
```

in the last form, `argc` is the count of arguments that are in `argv` while `argv` is an array of **null-terminated** strings that are the entered by the user.

by convention `argv[0]` is the command with which the program is invoked and the user-provided args starts at index 1

---

## Function prototypes

a function prototype is used as an early declaration, it tells the compiler to expect a definition of a function with the matching signature:

- return type
- function name
- parameters (same types and order, names can vary)

a function prototype has no body, so no `{ }`:

```c
int add(int, int);
```

the line above is a prototype to a function named `add` that takes in 2 integers and returns an integer, of course we can define a name to the arguments in the prototype, thy can even differ from the names in the actual definition, but regardless they must match in type and order, if for example the prototype takes and `int` then a `float`, then the function must also accept the same arguments in the same order

---

## Variadic functions

a variadic function is a function that takes in a fixed argument and variable number of arguments afterwards, an example of this would be both `scanf` and `printf`.

to work with variadic functions import `stdarg.h` , and in the signature of the function use `...` after the fixed arguments:

```c
int add(int n, ...){
  //------
}
```

the `...` will inform the compiler to parse the variable number of arguments and the `stdarg.h` contains macros like:

```c
va_start(va_list ap, arg); //starts parsing the arguments in the `va_list`
va_arg(va_list ap, type); //convers the next arg in teh va_list to the given `type`
va_copy(va_list dest, va_list src); //copies the arguments from src to dest
va_end(va_list ap); //empties the va_list when done
```

let’s look at an example:

```c
#include <stdio.h>
#include <stdarg.h>

// Variadic function to add numbers

int addition(int n, ...){

   va_list args; //variable arguments are parsed here
   int i, sum = 0;

   va_start (args, n); //start parsing

   for (i = 0; i < n; i++){
      sum += va_arg (args, int); //convert
   }

   va_end (args); //clean

   return sum;
}

//actual use

int main(){

   printf("Sum = %d ", addition(5, 1, 2, 3, 4, 5));

   return 0;
}
```
