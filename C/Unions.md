# Union

a union is a custom-defined type, similar to a struct it stores members of different types, however in a union, all members **share the same memory**, meaning we can only use one value at a time

just like a struct, a union is required to be preceded by `union` at any use, unless of course it's given an alias via `typedef`

```c
union MyUnion {
    int num;
    char letter;
    char str[30];
};
```

then we can use that union as follows:

```c
union MyUnion u1;
u1.num = 10; // u1 has the value of 10
u1.letter = 'h'; //u1 has the value of h, no longer has 10
```

the size of a union is always that of it's biggest member, in this case it's **30 bytes** as the biggest member is `str`
