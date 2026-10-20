# Preprocessors

in C preprocessors runs before the actual compilation process starts, it's responsible for things like including files and also defining macros

---

## Include

the `#include` directive is used to include other header/c files in the currant file

```c
#include <systemLib>
#include "localLib"
```

---

## Define

the `#define` is used to create a macro, macros are names that can represent:

- values
- piece of code

for example, define a macro for PI using:

```c
#define PI 3.14
```

macros can take params as well:

```c
#define SQR(x) ((x) * (x))

SQR(3);
```

---

## Ifdef and ifnedf

these directives let us include or skip parts of code depending on if a macro is defined or not

for example, if a macro called `DEBUG` is defined run this code, else don't

```c
int main(){
    #ifdef DEBUG
    printf("Debug defined");
    #endif
}
```

there is also an `#else` directive we can use, often the case these directives are used as include guards, so the contents of a file are not included twice

additionally we use them for platform-specific things, for example we can define a default buffer size that is OS dependant as follows:

```c
#ifdef LINUX
#define BUFFERSIZE 100
#endif

#ifdef WINDOWS
#define BUFFERSIZE 200
#endif

#ifdef MAC
#define BUFFERSIZE 120
#endif
```

we can simply add a `#define LINUX` for example to use Linux's buffer size

---

## Predefined C macros

C has many predefined macros we can use, like:

- `__LINE__` represents the currant line number in code
- `__FILE__` the name of the currant file
- `__TIME__` the compilation time, in format **HH:MM**
- `__STDC__` defined as 1 if the compiler complies with the C standards

> [!IMPORTANT]
> macros don't check for types, nor do they produce useful debugging info
