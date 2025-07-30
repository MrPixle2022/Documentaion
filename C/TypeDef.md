# Typdef:

in `c` we can use the `typedef` keyword to rename some pre-existing types like renaming `char x[]` to `string`.

```c
typedef type newName;

newName name = value;
```

so for example:

```c
typedef char string[50]; // a 50-byte(50 characters max) string
```

not only can we rename types but also define custom complex data types.

---

## Enums:

using the `enum` keyword we can define our own enums, enums contain a list of constant so they are usually all in uppercase always.

usually each value represents an integer starting at 0 and increments for each element, but we can define the first value and it will increment for the rest.

there are two ways to define enums, the first is:

```c
enum DAY {
  SUNDAY = 1,
  MONDAY, //2
  TUESDAY, // 3
  WEDNESDAY,// 4
  THURSDAY,// 5
  FRIDAY,// 6
  SATURDAY // 7
};
```

then use them :

```c
enum DAY today = SATURDAY;
```

or using `typedef enum`:

```c
typedef enum {
  SUNDAY = 1,
  MONDAY,
  TUESDAY,
  WEDNESDAY,
  THURSDAY,
  FRIDAY,
  SATURDAY
} DAY;
```

you will notice here the name `DAY` is defined after the enum, and also -since we used `typedef`- we won't require the `enum` for variables:

```c
DAY today = SATURDAY;
```
