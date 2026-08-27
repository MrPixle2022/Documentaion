# Memory model

---

## Segments

when a C program is compiled and loaded into memory -as a running process- the OS organizes the address space into distinct segments with specific permissions and purposes, the layout is structured to balance security, performance and memory efficiency

the layout is primarily made up of 5 primary contiguous segments:

```text
[cmd args, env args] (High address) [0xffffffff]

[stack] (grows downwards)

[Heap] (grows upwards)
[BSS]
[Data segment]
[Text segment] (Low address) [0x00000000]
```

the `text segment` houses the actual machine instruction generated via the compiler, as they should not change during execution the OS typically marks this memory as `read-only` and `executable`, should a program attempt to write to this segment the hardware would trigger a segmentation fault

the `data segment` stores global and static variables that are **explicitly** initialized by the programmer like:

```c
int x = 10;
```

these values must exist for the lifetime of the program, and since they are defined at compile time, the storage requirement is fixed

the `BSS` or block started by symbol contains global and static variables that are not initialized or initialized to `0`, they are separated for optimization purposes, since some of them are initialized to `0` the binary doesn't need to store them as individual zeros, the OS reserved a block of memory of the required size and clears it to `0` upon the start of the program

the `Stack` handles automatic storage, it contains local variables, function parameters and return addresses, this segment is handled by the CPU and the compiler, memory is pushed onto the stack on function call and popped on return, the stack grows towards lower memory addresses

the `Heap` is the dynamic part, it's the part we handled ourselves, the heap is a larger pool that we can request and release parts of on need, the heap grows opposite the stack -towards high memory address-

```c
#include <stdio.h>
#include <stdlib.h>

int global_initialized = 50;   // Data Segment
int global_uninitialized;      // BSS Segment

void function_example() {
    int local_var = 10;        // Stack
    static int static_var = 5; // Data Segment
}

int main() {
    int *heap_ptr = malloc(sizeof(int)); // Pointer is on Stack, target is on Heap
    return 0;
}
```

---

## Analyzing executable layout

if we have the following code:

```c
#include <stdio.h>

int global_init = 10;     // Stored in .data
int global_uninit;        // Stored in .bss

int main() {
    static int local_static = 5; // Stored in .data
    printf("Hello, Memory Model.\n");
    return 0;
}
```

we can analyze the different segments using 2 UNIX utilities:

### size

using:

```bash
gcc main.c -o demo
size demo
```

we would receive:

```text
text    data     bss     dec     hex filename
1187     560       8    1755     6db demo
```

`dec` and `hex` just give us the total size of the segments

### nm

for a deeper inspection use `nm`:

```bash
nm demo
```

now the result would be:

```text
0000000000004010 D global_init
0000000000004018 B global_uninit
0000000000001149 T main
0000000000004014 d local_static
```

the output has the following:

- virtual address
- symbol type
- name

the 2nd column points to the segment:

- **T** -> text segment
- **D** -> data segment
- **d** -> local static variable
- **B/b** -> bss

`nm` basically shows you the map the linker creates, if you define a constant for example it will be moves from `data` to `rodata` which read only data and is flagged often as `R/r`

---

## How the OS maps memory

each running process is given a portion of memory, but is not handed full-access to it, rather it's given an abstraction layer provided by the OS called virtual memory, the OS decouples the addresses the program uses from the physical RAM addresses, so the app doesn't interact with ram directly, rather the abstraction layer that is the virtual memory, it's a contiguous, private address space managed by the kernel and the CPU's memory management unit

the OS maintains page tables for every running process, when our code accesses a pointer as in writing to local variables, the CPU treats that address as a virtual address, the MMU searches the page tables to find the corresponding physical address in the RAM, if the required page is not in the physical memory the CPU triggers a page fault, the OS will pause the program, fetch the data from disk or allocate new physical frames, update the page table and restarts the instruction

the OS uses a mapping mechanism to enforce security and isolation, as the OS defines the mapping, it can marks specific segments of the program's memory with different permissions, like the `text` segment being marked as **read-only** and **executable**, if the code attempts to write to this segment the MMU detects that, the hardware permission bits do not match the operation and the kernel immediately kills the process with a segmentation fault `SIGSEGV`

modern OSs also have and address space layout randomizer `ASLR`, even if the program's segment always exists in a specific logic order, the actual base virtual addresses are randomized on start

this makes it harder for attackers to predict the location of a specific function or buffer in memory

when a program runs, the OS's loader -`execve` on linux- performs a sequence of steps:

1. validate the executable format
1. maps the file's contents into the virtual address spaces base on their segments
1. initializes the stack pointer
1. maps the dynamic libraries
1. jumps to the entry point -usually `_start`-

---

## Stack frames

the stack is a contiguous block of memory managed in LIFO order or last-in-first-out

on a function call a new frame is allocated at the top of the stack, the frame acts as a function's private workspace for that instance, this frame contains parameters, local vars and meta data required to return control to the caller when done

the stack frame is defined by 2 registers, the stack pointer (SP) and the frame pointer/base pointer (FP), the SP points to the current top of the stack, while FP is a fixed reference within the current frame

when a function call happens the following takes place:

1. **Calling convention**: the caller pushed arguments onto the stack or places them in specific registers the executes the `call` instruction, this pushed the return address onto the stack
1. **Prologue**: the callee saves the previous frame pointer, sets the new frame pointer to the current stack pointer then shifts SP to reserve space for local variables
1. **Epilogue**: before returning the callee restores the SP to the FP, pops the saved FP and executes `ret` instruction and jumps back to the return address

the calling convection dictates how the data is passed between functions, on a modern OS the first sex integer/pointer args are passed via registers which reduces stack traffic and remaining args are pushed to the stack

for example, the following function:

```c
int add_numbers(int a, int b) {
    int sum = a + b;
    return sum;
}
```

when compiled would result in the following assembly instructions:

```asm
add_numbers:
    pushq   %rbp            # Save caller's frame pointer
    movq    %rsp, %rbp      # Set new frame pointer to current stack top
    movl    %edi, -4(%rbp)  # Store 'a' (from register edi) in local stack space
    movl    %esi, -8(%rbp)  # Store 'b' (from register esi) in local stack space
    movl    -4(%rbp), %eax  # Move 'a' to register for addition
    addl    -8(%rbp), %eax  # Add 'b' to 'a'
    popq    %rbp            # Restore caller's frame pointer
    ret                     # Return to caller
```

the return address saves the address of where to return when done, as the CPU executes instruction linearly and needs to know where to go when done with the instruction in hand.

the CPU also automatically pushed the address of the next instruction to the stack if the value is corrupted the execution jumps to an arbitrary memory location
