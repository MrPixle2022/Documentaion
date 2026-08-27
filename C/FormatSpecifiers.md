# Format Specifiers

format specifiers are special tokens that begin with a `%` and a letter that specifies the data type and optional modifiers like width, precision & flags.

for each place we want to place a value we place an FS with the datatype, for example we can use:

| Format specifier |                Type                 |
| :--------------: | :---------------------------------: |
|        %c        |                char                 |
|        %s        |               string                |
|        %d        |                 int                 |
|     %u or %i     |            unsigned int             |
|       %hu        |           unsigned short            |
|       %hi        |            signed short             |
| %l or %ld or %ld |                long                 |
|        %f        |                float                |
|     %e or %E     | scientific representation of floats |
|       %lf        |               double                |
|       %Lf        |             long double             |
|       %lu        |            unsigned long            |
|   %lli or %lld   |              long long              |
|       %llu       |         unsigned long long          |
|        %o        |            octal format             |
|     %x or %X     |         hexadecimal format          |
|        %p        |       pointer/memory address        |

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

for the other options like width, precision, etc..., we can follow the following template

```c
//% [flag] [width] [.precision] [length] specifier
```

of course with no spaces, we can use the following:

|  flag   |    name     |                                  usage                                   |
| :-----: | :---------: | :----------------------------------------------------------------------: |
| -{num}  | left align  |            aligns the output to the left by the given number             |
|  {num}  | right align |                        opposite the previous one                         |
| (space) | space sign  |                   adds a space before positive values                    |
|    +    |  show sign  |        explicitly adds `+` before positives and `-` for negatives        |
|    #    |  alt form   | adds prefixes for octal/hex formats and forces decimal points for floats |
