# Format Specifiers:

format specifiers are special tokens that begin with a `%` and a letter that specifies the data type and optional modifiers like width, precision & flags.

for each place we want to place a value we place an FS with the datatype, for example we can use:

- %d & %i -> singed integers
- %u -> unsigned integers
- %hd & %hi -> short integers
- %hu -> unsigned short integers
- %ld -> long integers
- %lu -> unsigned long integers
- %lld & lli -> long long integers
- %llu -> unsigned long long integers
- %f -> float & double
- %lf -> double -usually with `scanf`-
- %Lf -> long doubles
- %c -> char
- %s -> char x[]
- %p -> pointers & memory address
- %zu -> sizeof results

```c
int age = 17;
printf("You are %d\n", age);

float gpa = 2.256;
printf("Your gpa %.2f\n", gpa);

double euler = 2.7182818284590;
printf("Euler constant = %.15f\n", euler);

char a = 'A';
printf("Your grade is %c\n", a);

char name[] = "Amr";
printf("Your name is %s\n", name);

bool isTrue = 1;
printf("Is it true %d", isTrue);
```

---

## Min width:

before the type letter we can add a number that represents how many space should be inserted before, for example:

```c
// prints 1 with 10 spaces before
printf("%10d", 1);
//         1
```

you can use a negative values to space from the other side

---

## Flags:

also we can add zeros to replace spaces:

```c
printf("%04d", 1);
//0001
```

we can add a `+` which will add a sing before positive `+` & negative `-` value.

```c
printf("%+d, %+d", -1, 1);
// -1, +1
```

we can use `.n` to determine how many digits should appear after the point, note that the number will be rounded:

```c
printf("%.1f", 1.2563);
// 1.3
```

we can merge width with precision and the `+` flag:

```c
printf("%+10.2f", 19.191989121);
//    +19.19
```
