<!-- @format -->

# Mathematical operators:

in c# we can the normal `+ - * /* ` for math, but also we have a couple of other important ones we can make use of:

```csharp
int x = 0;
Console.WriteLine(x++);//0, but x after this line will be = 1
Console.WriteLine(++x);//2, because x previously = 1
```

here we use the `++` to increment our variable by one. we see that it can be used before and after the variable with a difference in result.

using the `++` or `--` before a variable will update the value then use the variable, whilst inserting the operator afterwards will use the old value then update it.

```csharp
x += 4;
Console.WriteLine(x);// 6
x -= 2;
Console.WriteLine(x);// 4
```

and here we use the `+=` and `-=` which uses the value of the variable.

for example `+= 2` means update to the value of the variable + 2.

we also have a version for those for multiplication and division

```csharp
x *= 2;
Console.WriteLine(x);// 8

x /= 3;
Console.WriteLine(x);// 2
```

be aware that since this is an integer, if the operation returns a float or a decimal it will be rounded

we also has the `%` for the reminder of a division.

> [!NOTE] using the `+=` on strings will concatenate them, whilst with chars will ge the sum of the Unicode values of the two chars resulting in a single new char
