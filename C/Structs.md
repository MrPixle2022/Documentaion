# Structs

in c a struct is a user-defined type that is used to group related values into on place, each variable in a struct is referred to as **member**

structs -unlike arrays- can hoist values of different types

a named struct is defined and used always proceeded with the `struct` keyword, members can be accessed simply using the struct object the `.`:

```c
struct Coordinate{
    int x;
    int y;
    int z;
}

struct Coordinate coordinate = {
    1, //x
    2, //y
    3 //z
};
coordinate.x = 0;
coordinate.y = 1;
coordinate.z = 3;
```

if you wish to get rid of having to write `struct` each time then consider using typedef on an anonymous struct or a named one.

```c
typedef struct{/*fields*/} name;
name var = value;

typedef struct oldName newName;
newName var = value;
```

the `sizeof` returns the sum of the size of all fields in a struct + the padding, to get rid of the padding it's recommended to order your fields from the largest to the smallest.

---

## Initialization

to initialize a struct we have multiple method to do so:

```c
struct Coordinate c1 = {1,2,3}; //x=1, y=2, z=3 (positional initialization)
struct Coordinate c2 = {0}; //(zero initialization) x=0, y=0, z=0 -> this way can be used with arrays
struct Coordinate c3 = {
    .x = 1,
    .y = 2,
    .z = 3
} // designated initialization
```

---

## Struct pointer

struct pointer can be used to pass structs by reference rather then by value, specially as an argument to a function

a struct pointer can be de-referenced as usual to access the actual struct, however note that the `.` operator takes precedence over the `*` operator, hence the pointer dereferencing must be enclose within a pair of `()` and outside the pair is where the data is accessed

```c
struct Coordinate* ptr = &coordinate;
*ptr.x; //Invalid
(*ptr).x; //valid
```

we can also shorten this by using the `->` operator directly on the pointer, which allows us to extract a field without having to dereference the pointer ourselves:

```c
ptr->x=12;
```
