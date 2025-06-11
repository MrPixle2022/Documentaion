<!-- @format -->

# Conversion:

to convert one type to another we can make use of one of the following methods:

---

## Convert:

the `Convert` class has a set of method that converts one type into another.

```csharp
int x = Convert.ToInt32("10");
bool boolean = Convert.ToBoolean("true");

Console.WriteLine($"{x} {boolean}");
```

---

## Parse(value):

on each type there exists a static parse method which tries to parse the given value and throws an exception if failed.

```c#
int x = int.Parse("10");
bool boolean = bool.Parse("true");

Console.WriteLine($"{x} {boolean}");
```

---

## TryParse(value, out result):

similar to `Parse` the `TryParse` is a static method that parses a value of another type into another. but it actually functions as a check and a converter, the `TryParse` actually returns a boolean that is false if the conversion is false and true if successful, the actual conversion is in the second out param which is the final result.

```csharp
bool check = int.TryParse("12", out int result);

System.Console.WriteLine($"{check} {result}");
```

---

## Cast conversion:

`explicit` conversion can be used to convert a type of data into another one where you convert a bigger type into a smaller one losing some value in the process and the `implicit` where the opposite happens. the syntax is:

```csharp
(type1) value;
```

```csharp
double d = 10.23D;
int x = 10;

System.Console.WriteLine($"{(int)d}"); //this is explicit as we lose values after the `.`
System.Console.WriteLine($"{(long)x}"); //this is implicit we lose no value
```
