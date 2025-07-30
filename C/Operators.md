# Operators:

---

## Arithmetic operators

arithmetic operators are used for simple mathematical operations, they are:

- \+
- \-
- /
- %
- \*
- \+\+
- \-\-

note that when dividing using integers we can't store decimals, instead we get lose all values after the `.`, so for example:

```c
int x = 2;
int y = 3;
int z = x / y; //0
float z2 = x / y; //0.0000000

float y2 = 3;
float z3 = x / y2; //0.666667
```

another example:

```c
int x = 5;
int y = 3;
int z = x / y; // 1
```

lastly we have the increment `++` & the decrement `--`, both update the value by `1`, BUT, take note how you use them, because they can be used before and after a variable and they behave slightly different.

if used after a variable, then this means:

use the old value, the update it by 1.

for example:

```c
int x = 5;
printf("%d\n", x++); // 5
//here x = 6
```

while if used before the variable it means:

update the value then use the variable.

so for example:

```c
int y = 3;
printf("%d", ++y); // 4
// here y = 4
```

---

## Augmented assignment operators:

augmented assignment operators are used for re-assigning the value of the same variable, in this category we have:

- +=
- -=
- *=
- /=
- %=

each is like the following:

```c
int x = 0;
x += 1;// x = x + 1
x -= 1;// x = x - 1
x *= 4;// x = x * 4
x /= 5;// x = x / 5
x %= 2;// x = x % 2
```

---

## Relational operators:

relational operators are used to compare values to gether, for conditions & boolean checks, this list includes:

- == -> true if both sides are equal
- !== -> true if both side are **not** equal
- \> -> true if left is greater than right
- < -> true if right is greater than left
- \>= & <= -> same,but also if equal

---

## Logical operators:

logical operators are used to combine conditions into one.

- && -> `AND`, true if both conditions are
- || -> `OR`, true if **at least one** condition is
- ! -> `NOT`, flips true into false and vice versa

---

## Bitwise operators:

bitwise operators are used to preform operations on individual bits.

in this list we have:

**&**:

the **AND** operator check every bit of the two arguments, if both are `1` it returns `1` else returns `0`.

```c
int x = 5; // 00 000 101
int y = 7; // 00 000 111

printf("%d \n", x & y); // 5
```

so what happened is as follows:

```text
00 000 101 -> 5
AND
00 000 111 -> 7
----------
00 000 101 -> 5
```

**|**:

the **OR** operator looks if at least one bit is `1` it returns 1 otherwise it's 0.

```c
int x = 5; // 00 000 101
int y = 7; // 00 000 111

printf("%d \n", x | y); // 7
```

so what is happing is:

```text
00 000 101 -> 5
OR
00 000 111 -> 7
----------
00 000 111 -> 7
```

**^**:

the **XOR** or exclusive or operator returns one only if the two bits are different

```c
int x = 5; // 00 000 101
int y = 7; // 00 000 111

printf("%d \n", x ^ y); // 2
```

so what is happing is:

```text
00 000 101 -> 5
XOR
00 000 111 -> 7
----------
00 000 010 -> 2
```

**~**:

the **NOT** operator basically inverts 1 -> 0 & 0 -> 1

```c
printf("%d \n", ~255); // -256 (since we it's a 32 bit we are using)
```

**>>** and **<<**:

the **RIGHT-SHIFT >>** & the **LEFT-SHIFT <<** are used to move the bits by `n` number of steps in the given direction.

```c
printf("%d", 6 >> 1); // 3
printf("%d", 6 << 1); // 312
```

so what happens is:

```tex
00 000 110 -> 6
>> 1
00 000 011 -> 3
```
