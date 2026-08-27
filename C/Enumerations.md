# Enumerations

Enumeration or `enum` is a user-defined type that represent a set of possible constant values, basically an enum can be one of a set of defined values

just like `unions` and `structs` an enum must be preceded with `enum` unless again we use `typedef` to give it an alias

```c
enum LEVEL {
    LOW, // 0
    MEDIUM, // 1
    HIGH// 2
}
```

using the enum can be done as follows:

```c
enum LEVEL lvl = HIGH; // lvl = 2
```

we can if -we want to- alter the values of each field or just the starting field:

```c
enum LEVEL {
    LOW = 10,
    MEDIUM, //11
    HIGH // 12
}
```

we can also enforce our own values on each possible value

```c
enum LEVEL {
    LOW = 10,
    MEDIUM = 12,
    HIGH = 123,
}
```
