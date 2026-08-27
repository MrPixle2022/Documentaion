# Pointers & Memory

we can think of memory is a locker room consisting of rows upon rows of lockers

when defining a variable and assigning it the program will ask for a locker in which it will store the data, the address -number of- this locker matters not, as long as it is empty, and by empty it means not reserved to another program, empty places in memory aren’t actually empty, not all the time, very often they have junk values, left there by the previous program that rented that address, so when allocating or using any memory assume a junk value is there previously, hence assigning an initial value to a variable is recommended

when declaring a variable like:

```c
int x = 10;
```

and assuming the `int` is of size `4 bytes` an appropriate locker to store an integer will be reserved and tagged by the name `x`, so now `x` references that locker

similar things is done with functions, when the compiler reads a function definition it will reserve appropriate places for the parameters, and for the return value should there be any

this pack of variables belong to the function and can only -in most cases- be only accessed via that function aka the one that owns them

after the call the memory for that function is then released, aka they become available for other functions or programs to rent, the data may not be cleaned or emptied at all

## Stack and Heap

the stack is and the heap and 2 places in memory each used to house data in it’s own way, as a data structure the stack is `LIFO` structure, meaning last-in-first-out

the stack is simpler, faster but is limited compared to heap

the heap is on the other hand slower but and more complex but allows us to store complex data structure

when calling a function a new stack frame is created, we get a **return address** which is basically the address to which the stack-pointer returns on the function return, the stack pointer is where we are, first arguments are copied into the stack-frame, then function’s inner variables, when done we free the stack frame and return to the returns-address

on the heap, we must manually free the memory and manually allocate the data ourselves, in spite of this, the heap is useful for many states like when we don’t know the size of our data, for example how big should this array be, we don’t know that so we allocate memory on the heap, and when we need more we allocate more

### Create a stack type in C

the stack is a `Last-in-first-out` type of structure, even though it’s not defined in C we can define a one ourselves

often with stack we expect some functions:

- peek → see the the last item (first to be removed)
- pop → remove the last item
- push → add to the end

at it’s core the stack contains a collection of elements with strictly controlled access patterns, we can only interact with the last element aka the the top of the stack

```c
#include <stdio.h>
#include <stdlib.h> // For malloc and free
#include <limits.h> // For INT_MIN

// A structure to represent a stack
struct Stack {
    int top;
    unsigned capacity;
    int* array;
};

// Function to create a stack of given capacity.
struct Stack* createStack(unsigned capacity) {
    struct Stack* stack = (struct Stack*)malloc(sizeof(struct Stack));
    if (!stack) {
        return NULL;
    }
    stack->capacity = capacity;
    stack->top = -1;

    stack->array = (int*)malloc(stack->capacity * sizeof(int));
    if (!stack->array) {
        free(stack);
        return NULL;
    }
    return stack;
}

int isFull(struct Stack* stack) {
    return stack->top == stack->capacity - 1;
}

int isEmpty(struct Stack* stack) {
    return stack->top == -1;
}

void push(struct Stack* stack, int item) {
    if (isFull(stack)) {
        printf("Stack Overflow\n");
        return;
    }
    stack->array[++stack->top] = item;
    printf("%d pushed to stack\n", item);
}

int pop(struct Stack* stack) {
    if (isEmpty(stack)) {
        printf("Stack Underflow\n");
        return INT_MIN;
    }
    return stack->array[stack->top--];
}

int peek(struct Stack* stack) {
    if (isEmpty(stack)) {
        printf("Stack is empty\n");
        return INT_MIN;
    }
    return stack->array[stack->top];
}

void freeStack(struct Stack* stack) {
    if (stack) {
        free(stack->array);
        free(stack);
    }
}
```

---

## Pointers

pointers are variables whose value is the address of another variable, they basically store the address of another variable.

but why?, in c data is passed by value, their are no reference passed types for a complex struct the entire thing will be copied, pointers allows us to pass the memory reference and extract those values and free them when they are not needed.

pointer can be declared as follows:

```c
type* name = &value;
type *name = &value;
```

where type must be the same type as what you reference, the `&` extracts the address.

addresses are like indexes used as an index to some data in memory, usually they are represented in `hexadecimal` format

---

## Virtual memory

when a c program is running, it doesn't get direct access to the physical ram, instead the os provides the application with an abstraction layer called the v-ram or the virtual ram.

though if the c app is running on embedded systems for example it may be granted access to the physical ram stick.

providing virtual memory gives the process -the app is it's running- a chunk of memory which is the `v-ram` which helps for security, isolation and makes memory management easier.

---

## Using pointers

we said that pointers can be used to pass references, will functions can accept pointers, but using pointers like:

```c
void increment_integer(int* x){
    x++;
}
```

will update the reference not the value of what is being referenced, to modify what the pointer references we use the `*` again this is called dereferencing:

```c
(*x)++;
int fromPointerOfX = *x; //also valid
```

this is what it should be like.

---

## Void pointers

void pointers are a **generic pointers**, they are used to point to a value of god-knows-what type.
we can use them when we know there is a data at that address and we don't know what possible type is it, or we just don't care what type it's -until you want to get the value-, when using a void pointer it is very important to type-cast on dereference.

```c
int x = 0;
void* ptr = &x; //C-compiler: it's a pointer, but to what?!

int* y = (int*)ptr; //cast it into a pointer to an integer
printf("%d\n", *y); //dereference the casted pointer
```

---

## NULL pointers

a null pointer is a pointer that points to an invalid memory address, trying to dereference these pointers causes undefined behavior or a crash

often pointers will be initialized to `NULL` before they are assigned an address

also a pointer will be often be assigned `NULL` once it's no longer used

> [!TIP]
> functions like `malloc` return `NULL` when allocation fails  
> [!NOTE]
> `NULL` equals `0` however this `0` is not equal to the integer `0`

---

## Double pointers

double pointers or pointers pointers are pointers to another pointer, they define a chain of references to a value, you can define the using `**`:

```c
int x = 0;
int* ptr = &x;
int** ptr_ptr = &ptr;
```

now we can use the `*` or `**` to dereference the double pointer:

```c
//*ptr_ptr = ptr;
//**ptr_ptr = x;
```

a possible use case for them is when working with an array of strings, a string is just a `char *` so an array of them would be `char**`, and by extent they can be used for dynamic 2D arrays of type x, for example:

```c
int** arr = calloc(5 * sizeof(int*)); // a 2D array of integers
```

> [!NOTE]
> we can add as many `*` as we need, and it will take the same number of `*` to reach the value

---

## Struct pointer

a struct pointer can be used to store/pass a reference to a struct, we can extract fields from that struct by:

1. dereferencing the pointer
1. accessing the field

but note that dereferencing must be done within `( )` as the `.` operator takes precedence over `*`:

```c
(*ptr).field;
```

however we can easily simplify this by directly extracting a field using `->` after the pointer:

```c
struct Student{
    int age;
    char *name; //string
    char grade;
};
struct Student student = {0};
struct Student* pStudent;
```

we can extract the fields using `->`:

```c
pStudent->grade;//extracting the grade
```

---

## Forward Declaration

forward declaration is when we declaration the precedes the actual definition, it can be used with functions -function prototype- and structs, often the case with structs it's used with structs that has a pointer in them to another of their type

```c
struct Node; //declaration

struct Node{ //definition
    int data;
    struct Node *next;
}
```

---

## Memory allocation

in C there are 2 type of memory:

- Static memory: allocated for variables before run-time (compile time memory allocation)
- Dynamic memory: allocated during run-time

we have full control over dynamic memory, we can allocate a portion of it, free it and so on

allocation is mainly handled by the `stdlib.h` using methods like:

- malloc: reserve a portion on the heap
- calloc: same as malloc but initialize all bits to 0
- realloc
- free: releases memory

### maloc

the `malloc` function allocates a portion of memory on the heap, it takes 1 argument that is the size of memory to be allocated in **bytes**, it returns the address to the first byte of that allocated memory, or `NULL` if it fails to allocate any.

```c
int *ptr1, *ptr2;
ptr1 = malloc(sizeof(*ptr1));
ptr2 = calloc(1, sizeof(*ptr2));
```

> [!NOTE]
> `sizeof` cannot measure dynamic memory's size

---

## calloc

the `calloc` function does the same as `malloc`, however it differs in 2 ways:

1. takes 2 arguments, amount of data & the size of each element
1. it writes all reserved bytes to 0

> [!NOTE]
> stack memory is also considered dynamic memory that is reserved for variables declared in functions

```c
int *students;
int numStudents = 12;
students = calloc(numStudents, sizeof(*students));
```

### realloc

the `realloc` function is used when the allocated memory needs to change in size, `realloc` changes the allocated chunk's size without altering the data it stores

the function takes 2 parameters:

1. the pointer to the resized memory
1. the new size in bytes

`realloc` will try and reallocate the memory in the same place, if it fails in doing so it will try to reallocate somewhere else

the function returns a pointer to the newly allocated data or `NULL` on fail

```c
int *ptr1, *ptr2;
// Allocate memory
ptr1 = malloc(4);

// Attempt to resize the memory
ptr2 = realloc(ptr1, 8);
```

> [!IMPORTANT]
> all 3 functions above return a `void*`

### free

the `free` function is used to deallocate memory that has been previously allocated, it takes a pointer to the allocated memory and releases the data there

it's important to make the pointer passed to `free` `Null` when done

```c
int *ptr;
ptr = malloc(sizeof(*ptr));

free(ptr);
ptr = NULL;
```

forgetting to call `free` causes memory leaks, that is when dynamic memory is allocated but never released, this can cause slowdowns and crashes

---

## Memory leakage

memory leaks as we said before happens when no-longer needed memory is not released, it remain unused and stack until they cause critical performance issues

---

## Dangling pointers

a dangling pointer is a pointer that points to data that is no longer in use, in other words it's pointing to data that has been released

for example:

```c
int* ptr = (int*)malloc(sizeof(int));
free(ptr);
// ptr still has the address of the allocated data even after it has been released
```

after `free` call, `ptr` still has a memory address whose data has been freed already, to solve this dangling problem we can make `ptr` `NULL` after free

another case for a dangling pointer would be:

```c
int* func(){
    int num = 10;
    return &num;
}
```

in this example something like:

```c
int *ptr = func();
```

would be a dangling pointer, why? because simply the variable `num` will be released on returns, because it's a local variable to the function, meaning we would have an address to an invalid data

---

## More on memory

to further understand, we must consider the bigger image of how code is loaded in memory, all programmes are stored in memory, the OS designates a certain amount of memory in order for our running app -process- to run

memory is assign as follows:

```text
Memory layout (32-bit)
0xffffffff (high memory addresses)
 |-> cmdline args, env vars (on process start)
stack

heap
uninitialized data
initialized data (at compile time)
text (read-only, our code)
|-> 0x00000000 (lower memory addresses)
```

the stack as we have said before is where local variables and function arguments go

both the stack and the heap grow, but opposite to each other, if we flip the memory representation we can see it better:

```text
[HEAP] -(grow)>          <(grow)-[STACK]
```

when a function is called on the stack, this following happens:

- data of caller is added to the stack
- parameters in reverse order
- 2 addition items
- local variables of that function in their order of appearing

for example, the following function:

```c
void someFunc(int var1, int var2, int var3)
{
  char localVar1 [5];
  int localVar2;
}
```

would have the stack frame/activation record like:

```text
            lower address <- -> higher address
[ (localVar2) (localVar1) ( saved frame pointer ) ( return address ) (var1) (var2) (var3) (caller data)]
```

on call, the CPU saves the return address, which is basically the address to which the stack pointer should return once the function is done

a `Prologue` builds the function's on the top of the stack, it does the following:

- saves the old frame pointer
- updates the frame pointer
- makes room for variables

the frame pointer `(EBP)` is an anchor or a fixed address for the current function's memory so the CPU, the old frame pointer is simply that of the caller

`EBP` stays fixed pointing to the address of the functions's internal data (vars, arg, ...) meanwhile the stack pointer `ESP` is constantly on the move, the `EBP` is used so that we can move `ESP` to where the function's internal data is and when the function is done `EBP` becomes the address of the caller's internal data

there is also `EIP` which is a pointer to the address of the next instruction to run

when the call is done the `Epilogues` cleans up the mess, it:

- erases local variables
- restore the old frame pointer
- return to the saved address
