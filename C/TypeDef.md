# Typedef

in `c` we can use the `typedef` keyword to rename some pre-existing types like renaming `char x[]` to `string`, or simplify one of the user-defined types.

```c
typedef char* string
typedef enum {SAT, SUN, MON, TUE, WED, THU, FRI} DAY;
```

the new names `string` and `DAY` in the previous examples can be used as types
