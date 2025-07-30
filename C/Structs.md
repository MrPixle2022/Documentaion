# Structs:

in c a struct is a custom-defined block that holds related data, the order of those fields does matter as it may affect your memory layout and thus hurt the performance of your program.

a named struct is defined and used always proceeded with the `struct` keyword.

```c
struct Coordinate{
    int x;
    int y;
    int z;
}
// returns a struct of Coordinate
struct Coordinate make_coordinate(int x, int y, int z);
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

## Extracting values:

as a struct is a block of data, we will for sure want to get those values, we have two ways to do so, one with a struct and one with a struct pointer.

```c
structName.filed;
structPointer->filed;
```

> [NOTE] we can update the values on a struct.
