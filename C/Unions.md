# Union:

a union is a type that can be one of several types, so it behaves like a `sum type` but a less stricter one.

a union is defined using `typedef union` and you define what it could be:

```c
typedef union AgeOrName {
    int age;
    char* name;
} age_or_name_t;
```

then we use it to create variables:

```c
age_or_name_t age_or_name = {.age = 29};
age_or_name.age; // 29
```

ok!, but what would happen if we... say tried to access the name?

we get undefined behavior... no error, no warning, but why?

this is actually because the `union` allocates the size of the **largest type** and uses this allocated memory for any type it may possibly be.

so what happens is, we defined a union for a `char* ` and `int`, when we set `age` we wrote that value in the union memory, and when we tried to access `name` latter what happened is that we read the value of `age` but tired to interpret it as a `char* ` so we get garbage data.

the sizeof a union is the size of the biggest possible type.
