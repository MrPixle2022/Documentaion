# Pointers:

pointers are variables whose value is the address to another variable, they basically store the address of another variable.

but why?, in c data is passed by value, their are no reference passed types for a complex struct the entire thing will be copied, pointers allows us to pass the memory reference and extract those values and free them when they are not needed.

pointer can be declared as follows:

```c
type* name = &value;
type *name = &value;
```

where type must be the same type as what you reference, the `&` extracts the address.

addresses are like indexes used as an index to some data in memory, usually they are represented in `hexadecimal` format

---

## Virtual memory:

when a c program is running, it doesn't get direct access to the physical ram, instead the os provides the application with an abstraction layer called the v-ram or the virtual ram.

though if the c app is running on embedded systems for example it may be granted access to the physical ram stick.

providing virtual memory gives the process -the app is it's running- a chunk of memory which is the `v-ram` which helps for security, isolation and makes memory management easier.

---

## Using pointers:

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

## Struct pointer:

when creating a pointer to a struct their is a simple shortcut we can take, lets say this is our struct:

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

using the `*` is also possible, but the problem is that the `.` operator has higher priority & precedence then `*` so using `()` is required.

---

## Forward Declaration

A forward declaration is a declaration of an identifier (like a variable, function, or a data type) for which the compiler has not yet seen a complete definition. It's essentially a way of saying, "trust me, this thing exists, and I'll provide the full details later."

This is most commonly used to resolve circular dependencies, especially with structs. Imagine you have two structs that need to contain pointers to each other. The compiler would fail because one struct would be used in the other before it has been defined.

forward declaration is used with nodes which hold a reference for the next node, like in linked lists and tree structures.

for example:

```c
typedef struct StructName name_t;

typedef struct StructName{
    name_t* next;
} name_t;
```

note that `StructName` and `name_t` must match the actual definition, we forward declare the typedef, then we reuse the names in the actual definition.

also forward declaration can be useful for relations, think like a person `a` has a computer `b` and the computer`b` a has an owner `a`.

in this case they both reference each other, this will look like:

```c
typedef struct Computer computer_t;
typedef struct Person person_t;

struct Person {
  char *name;
  computer_t *computer;
};

struct Computer {
  char *brand;
  person_t *owner;
};
```
