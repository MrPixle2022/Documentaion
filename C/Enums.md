# Enums:

enums or enumerations, are a list on named-numbers, it's an enumerated list of possible values.

enums makes easier when working with data that may have a known range of values, enums work as a type, and they themselves can be used accordingly.

to define an enum use `typedef enum`, values then the name:

```c
// method one
typedef enum {
    SUNDAY, // 0
    MONDAY, // 1
    TUESDAY, // 2
    WEDNESDAY, // 3
    THURSDAY, // 4
    FRIDAY, // 5
    SATURDAY
} days_of_week_t;
```

> [!NOTE]
> enums are case sensitive

also we can define a starting value for the enum:

```c
//yes you can provide a name and a typedef name
typedef enum Color {
    RED = 55,
    GREEN = 176,
    BLUE = 83
} color_t
```

note that if only `RED` was given a value, the other values would increment, so `GREEN` would be `56`.

> [!TIP]
> enums are very useful for switch cases

---

## Sizeof enums:

enums are mostly integers, but if for any reason one of the values is larger then what an integer can store, then type of the values will be the smallest type that can store that big value.

the size of will return the size of the possible values, but the type may differ if -for any reason- an int isn't enough to store an enum's possible value.
