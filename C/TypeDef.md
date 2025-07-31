# Typdef:

in `c` we can use the `typedef` keyword to rename some pre-existing types like renaming `char x[]` to `string`.

```c
typedef type newName;
newName name = value;
```

for example:

```c
typedef char* string;
```

also typedef can be used to name anonymous strcuts or enums, for example:

```c
typedef struct{/*fields*/} name;
typedef enum {/*values*/} name;
```

> [!TIP]
> the convention is that any type renamed using typedef ends with `_t` like `typedef char* string_t`
