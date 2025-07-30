# Functions:

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

## Function prototypes:

function prototypes allows you to predefine a function without it's body, it's like a signature or you telling the compiler at some point a function with this name, this return type and takes those parameters will be defined.

a prototype includes:

- the return type
- arguments

function prototypes are usually associated with a header file, files with the `.h` extension.

a function prototype can be defined as follows:

```c
returnType functionName(type1 param1, ...);
```

notice there is no `{}` nor a body.

then at any stage in your file you can define the body, but the signature of the definition and the prototype **must** always match.

```c
int sum2int(int a, int b);
```

then we will have:

```c
int sum2int(int a, int b){
    return a + b;
}
```
