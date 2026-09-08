# Variables

to define a variable in c we use the following syntax:

```c
// type name = value;
// type name; //can't be used until assigned
```

so for example:

```c
int age = 17;
printf("Hello %d", age); // replace %d with age
```

the types provided by C are:

|  type  | size (bytes) |
| :----: | :----------: |
|  char  |      1       |
|  int   |    2 or 4    |
| short  |      2       |
|  long  |      8       |
| float  |      4       |
| double |      8       |

all of these types are signed by default, in other words they support negative numbers, we can use `unsigned` to allow only positive numbers, also `long` can be used on types to extend there range, `short` as well can be used, these are called extended types

|          type          |    size     |
| :--------------------: | :---------: |
|       short int        |      2      |
|      unsigned int      |   2 or 4    |
|        long int        |   4 or 8    |
|   unsigned long int    |   4 or 8    |
|     long long int      |      8      |
| unsigned long long int |      8      |
|      long double       | 8, 12 or 16 |

some types's size differ between devices, this can lead to unexpected behavior, however we have a solution with `fixed with integers`, these are provided by the `stdint.h` header file

|   Type   | Size |
| :------: | :--: |
|  int8_t  |  1   |
| uint8_t  |  1   |
| int16_t  |  2   |
| uint16_t |  2   |
| int32_t  |  4   |
| uint32_t |  4   |
| int64_t  |  8   |
| uint64_t |  8   |

---

## Type casting

type casting is the process of converting some data of one type to another it can be done in 2 ways

### Implicit

implicit conversion happens automatically, it’s done by the compiler, it often happens when a smaller type is assigned to a larger one, in this cases the compiler will promote the smaller type to a bigger one.

- `byte` and `short` are promoted to `int`
- if one operand is `long` the entire expression becomes `long`
- if one operand is `float` the entire expression becomes `float`
- if any operand is `double` the result is promoted to `double`

### Explicit

explicit conversion is when the coder manually tell the compiler to cast a type to another, this follows the following syntax:

```c
(type) val;
```

for example:

```c
int x = 10;
float y = (float) x;
```

type casting can be used to demote a greater type to a lower one

### Function casting

the `stdlib.h` includes many useful functions that can be used to cast a type to another.

```c
//atoi -> convert strings and chars to int
int num = atoi("123"); //num = 123
//iota -> convert an int to a null-terminated string
char* str = iota(123); // str = "123\0"
```

---

## Constants

a constant unlike a variable is immutable, once they are assigned a value, they won't change it, they cannot be reassigned

a constant is declared using the `const` keyword

```c
const int x = 0;
x = 10; //ERROR
```

we also can use the `#defined` directive for constants

```c
#define PI 3.1
```

it’s common with constants that their name is all caps.

note that constant made using `#define` are considered macros, and hence are not handled by the compiler, rather their values are substituted at run-time

also note that even though constants are immutable, you still can modify their value using a pointer to the constant, this is only doable to constants defined via `const`

---

## Constant qualifier

the `const` keyword can also be used to alter the behavior of certain things, like for example:

```c
const type* ptr = &var;
```

this defines a pointer to a constant/variable, this pointer can point to a read-only or a write-read address, however regardless of which it’s pointing to, the value at that address cannot be modified via this pointer, so for example:

```c
int x = 10, y = 12;

const int* ptr = &x;
*ptr = 13; //ERROR
ptr = &y; //OK
```

also can be used to define a constant pointer to a variable, this time the pointer itself can point to nothing else, it’s value -the address of the variable- is constant, for this behavior use:

```c
type* const prt;
```

so for example:

```c
int i = 10, j = 20;
int* const ptr = &i;

*ptr = 100; //OK
ptr = &j; //ERROR
```

we can also mix both the create a constant pointer to a constant:

```c
const type* const ptr;
```

for example:

```c
int i = 10;
int j = 20;
const int* const ptr = &i;
ptr = &j;// error
*ptr = 50;// error
```

---

## Type qualifier

type qualifiers are keyword that are used to add constraints to a variable, this includes:

- const (discussed)
- volatile
- restrict
- \_Atomic

### Volatile

the `volatile` keyword is used mainly with hardware related application of C, specifically with interrupts, memory-mapped I/O and multi-threading, it tells the compiler that this variable may change at any time, the compiler will then avoid doing any optimizing away memory read/writes

`volatile` tells the compiler any time a read/write is done to this variable, do it in the exact program order without assuming the value stay the same in-between accesses

the compiler often caches the variable in the CPU’s registries, to improve speed, `volatile` variable are excluded from this, also the compiler may often combine load/store operations or multiple read/writes if it sees no intervening changes, this also doesn’t happen to `volatile` variables, also the variable my do some operation reordering to improve performance, well not to the `volatile`

note that volatile only affect the compiler, not CPU-level memory fences, modern CPUs effectively don’t care, to enforce these fences use memory barriers like `mfence` or atomic primitives

also `volatile` variables are **not thread-safe**, race conditions are still possible

```c
volatile int x;
```

### Restrict

the `restrict` is a qualifier for pointers, it basically tells the compiler that _”No other pointer will be used to access the same pointed-to data during the lifetime of the pointer”_

with `restrict` the compiler will optimize the variable, improving performance

```c
int* restrict p;
```

### \_Atomic

the `_Atomic` is used together with the `stdatomic.h` header file, it’s used to avoid race-conditions

there are 2 ways to define an atomic variable:

```c
_Atomic int var;
atomic_int var;
```
