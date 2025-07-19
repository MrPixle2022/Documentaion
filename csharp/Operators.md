<!-- @format -->

# Operators

## Arithmetic operators:

arithmetic operators allow us to urn basic mathematical operations, like summing, subtracting, multiplying and dividing.

the operators in question are:

-   `+` -> adds the values to the left and the right
-   `-` -> subtracts the values to the left and the right
-   `*` -> multiplies the values to the left and the right
-   `/` -> divides the values to the left and the right
-   `%` -> returns the reminder of the division

we also have `++` and `--` which adds or subtracts **one** from the value, but depending on their position, they may cause a slight difference.

for example:

```csharp
int  x = 0;
x++; //use the value of x(0) then increment
++x; //increment the value of x then use it(1) //ignoring the previous line
```

so to put into perspective:

```csharp
int x = 0;
Console.WriteLine(x++);//0, but x after this line will be = 1
Console.WriteLine(++x);//2, because x previously = 1
```

here we use the `++` to increment our variable by one. we see that it can be used before and after the variable with a difference in result.

---

## Assignment operators:

assignment operators allow us to assign a value to a variable, we have `+=`, `-=`, `*=`, `/=`, `%=` all do the operation using the variable's value.

for example:

```csharp
x += 4;
Console.WriteLine(x);// 6 => x = x + 4
x -= 2;
Console.WriteLine(x);// 4 =>  x = x - 2

x *= 2;
Console.WriteLine(x);// 8 => x = x * 2

x /= 3;
Console.WriteLine(x);// 2 => x = x / 3 R = 1
```

be aware that since this is an integer, if the operation returns a float or a decimal it will be rounded

> [!NOTE] using the `+=` on strings will concatenate them, whilst with chars will ge the sum of the Unicode values of the two chars resulting in a single new char

---

## Relational Operators:

relational operators allow us to compare values.

in this list we have:

-   `==` -> equal to
-   `!=` -> not equal
-   `>` -> greater than
-   `<` -> less than
-   `>=` -> greater than or equal to
-   `<=` -> less then or equal to

relational operators returns a boolean.

---

## Logical Operators:

logical operators allow us to combine multiple conditions together.

-   `&&` -> and -> true if both sides are true
-   `||` -> or -> true if at least one side is true
-   `!` -> not -> doesn't combine but used to control conditions, it inverts true to false and vice versa

---

## Miscellaneous Operators:

Miscellaneous are special operators that don't fall under any of the other categories.

-   `sizeof(x)` -> returns the size of `x`
-   `typeOf(type)` -> returns the type of a class
-   `? :` -> the ternary operator is used to create simple condition checks that return a value based on the condition.
-   `value is Type` -> checks if a `value` is a of type `Type`
-   `as` -> the `as` is used to cast values into other type.
