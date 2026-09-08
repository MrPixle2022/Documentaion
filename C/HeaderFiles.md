# Header files

header files files end in `.h` extension, header files contain the **declaration** for:

- functions
- macros
- constants
- data types

it allows code to be shared and reused across multiple source files without having to redefining them

mainly there are 2 types of header files:

- standard libraries -> like `stdio`, `stdlib` and so on, defined between `< >`
- user-defined -> defined between `" "`

both being imported via the `#include` directive

lets say we have files `calc.c`, `calc.h` inside `src/lib/`:

src/lib/calc.h:

```c
#ifndef CALC_H //include guards
#define CALC_H

int add(int x, int y);
int subtract(int x, int y);

#endif
```

src/lib/calc.c:

```c
#include "calc.h"

int add(int x, int y) {
  return x + y;
}

int subtract(int x, int y) {
  return x - y;
}
```

the code within `calc.c` can be added via importing the header file:

```c
#include <stdio.h>
#include "lib/calc.h"

int main() {
  printf("5 + 5 = %d\n", add(5, 5));
  printf("6 - 4 = %d\n", subtract(6, 4));
  return 0;
}
```

just ensure you compile both files when you run it:

```bash
cd src #just to not have to use src/ before each bath
gcc main.c lib/calc.c -o main
```

additionally we can just use `calc.h`, for the include directive, however we would have to add the `-I` flag to the compile command

we can replace include guards we can also use `#pragma once` at the very top of the header file

---

## How header files are handled

header files are handled on 4 stages of a C program compilation:

### Preprocessing

when the c pre-processor reads the `#include` directive it tries to copy and paste the content of the specified file into the source code, at the exact spot, this happens before the compilation starts

standard/system libraries are searched for at the system directories, while user-defined ones are searched for in the current working directory before falling back to system directories

### Compiling

header files rarely contains executable function definitions, only declarations, the linker combines the compiled object file with the actual implementation to build the exe file
