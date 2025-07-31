# Stack and Heap:

when we think of the memory we think of it like a huge array of bytes with addressees to various offsets.

this opinion is true but also lacks some additional structure, memory is divided into two main sections:

- stack -> simpler, faster, more limited size
- heap -> complex, slower, useful for storing sophisticated and complex data structures

---

## The stack:

the stack is a place in memory where all the local variables are stored.

when you call a function a `stack frame` is created to store the function's parameters and local variables, when the function returns the `stack frame` is de-allocated.

the stack -as the name implies- is a `last-in-first-out` meaning the last element to enter is the first to leave, a stack is like a column of dirty plates where the last put on top -the end of the stack- will be the first one taken to be cleaned.

when a function is called a new `stack frame` is pushed into the stack, and when we get the returns value the frame is **popped** from the stack.

when the stack frame is created and the function is called the `stack pointer` will be moved to make room for:

- return address -> to pick up execution after the function returns, or where the stack pointer should be when function is done
- arguments to the function
- local variables of the function's scope

the `stack pointer` points to the position in-which the next element will be added.

when functions are called in-sequence they are more likely to reuse the same stack space, as it will be created then removed, called then removed, ...

all this is good talk, but why use the `stack` and why is it useful?, well for many reasons like:

- efficient pointer management -> the stack's allocation is much faster the heap's as it just incrementing or decrementing a pointer

- cache-friendly access -> stack memory is stored in a contiguous block, making it easy to cache.

- auto memory management -> each thread has it's own stack

> [!NOTE]
> note that function arguments are passed by values, so each time the arguments are getting copied.

> [!IMPORTANT]
> the stack has a limited size, if you keep **pushing** frames to it it may cause a `stack overflow`, specially with recursion without any `tail-call optimization`.

---

## The heap:

the heap is a part of memory which is slower, more complex and may cause a memory leak, but it allows for dynamic allocation, storing complex data structures.

we work with the heap and allocate memory in it using functions like `malloc`, `calloc`, `realloc` and `free` all of which are included in the `stdlib.h` library.

for example:

```c
int* newArray(int size){
    int* newArr = (int*)malloc(size * sizeof(int));
    if(newArr == NULL) exit(1); //avoids NULL pointer exception
    return newArr;
}

int* nArr = newArray(4);

//deallocation memory
free(nArr);
nArr = NULL; //avoid dangling pointers
```

> [!IMPORTANT]
> `malloc` doesn't initialize the bytes, it only allocates them, so the values may be garbage data, for initializing them use `calloc`, also `free` will not clear the pointers, so you need to make them null manually to avoid dangling pointers.
