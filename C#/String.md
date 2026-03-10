<!-- @format -->

# Strings:

a string is an enumerable data type which is like an array of characters, it has a set of methods and properties like `Length` representing how long is the string, or `Empty` which is equal to `""`, and since it's a like an `array` we can actually use the `[index]` to access the character at the position of index

---

## Strings interpolation:

by adding the `$` before `""` we can turn a normal string into an interpolated string, it allows for dynamic insertion of values without depending on methods like `string.Format`.

```csharp
int x = 10;

Console.WriteLine($"x is equal to {x}") //x is equal to 10
```

---

## Verbatim string:

by adding `@` before the `""` we can ignore `\` and escape characters, we can use `""` inside other stings.

```csharp
string str = @"C:\Users\Somebody\Desktop\File";//C:\Users\Somebody\Desktop\File

Console.WriteLine(str);
```

---

## Concatenation:

we can join string using `+=` for example

```csharp
string s1 = "s1";
string s2 = "s2";
s2 += s1; //s2 = "s1s2"
```

---

## String format:

string formatting works with both string interpolation and the normal format in `string.Format` and `Console.Write`.

```csharp
float price = 12.56124F;

Console.WriteLine("{0:c}", price); //currency format adds a symbol of the currency detected by the current culture
Console.WriteLine("{0:f3}", 12.238471D); //3 numbers after decimal
Console.WriteLine("{0:n3}", 12238471); //add comma every 3 digits
```

---

## ToUpper() and ToLower():

the `ToUpper` returns a new version of the string where all letters are in upper case, the `ToLower` does the opposite.

```csharp
string message = "this is a string for testing";
//case change
System.Console.WriteLine(message.ToUpper());
System.Console.WriteLine(message.ToLower());
```

---

## Format("txt", ...args):

the `Format` is a `string` type static method that allows you to insert values in a string in order of their position.

in the string use `{n}` where n is the index of your choice for example `0`, then the very first param after the text will be inserted @`{0}`, and so on.

```csharp
string.Format("{0} {1}", 10, 100) // "10 100"
```

> [!NOTE] you can reuse indexes.

```csharp
Console.WriteLine(string.Format("{0} + {1} != {0}", 10, 12)); // 10 + 12 != 10
```

---

## Concat(secondValue):

the `Concat` method allows you to merge strings together.

```csharp
string s1 = " msg1";
string s2 = "msg2";

s2.Concat(s1);//msg2 msg1
```

---

## Contains(string sub):

the `Contains` is method allowing you to check if the `sub` substring exists on the string, it returns a boolean:

```csharp
string x = "a b c";

Console.WriteLine(x.Contains("a b")); //true
Console.WriteLine(x.Contains("ab")); //false
```

---

## IsNullOrEmpty(string str):

the `IsNullOrEmpty` is a static string method that checks if the given string is empty `""` or has a value of null, this method returns a boolean value.

```csharp
string y = string.Empty;

Console.WriteLine(string.IsNullOrEmpty(y)); //true
```

---

## IndexOf(value):

the `IndexOf` method checks for `value` in the string and returns the first index at which it occurs.

if the value is not found it returns **-1** and **0** if the string is empty:

```csharp
string message = "this is a string for testing";

//indexOf -> -1 not found, 0 -> first or string is empty
System.Console.WriteLine(message.IndexOf("is")); //2 -> th[is]
```

---

## Remove(start, count):

the `Remove` returns a new version of the string after removing a section of it, from `start` and moving `count - 1` step.

```csharp
string message = "this is a string for testing";
//Remove(start, count) -> from start remove count -> returns a new string
System.Console.WriteLine(message.Remove(0, 5));// removes five characters [0 -> 4] (total is 5)
```

---

## Insert(index, value):

the `Insert` value returns a new string after inserting `value` at the given index.

```csharp
string message = "this is a string for testing";

//Insert(index, value) -> returns a new string in which value is inserted at index
System.Console.WriteLine(message.Insert(message.Length, " And this is inserted"));
```

---

## Replace(old, new):

the `Replace` method allows you to create a new string based on another one after replacing `old` with `new`.

```csharp
string message = "this is a string for testing";

//Replace(old, new) -> replaces the old with new in a new string
System.Console.WriteLine(message.Replace("string", "message"));
```

---

## string.Compare(a, b):

the `Compare` is a string static method that compares the order of each character in both `a` and `b` to one another.

returns:

- 0 -> `a` and `b` are in the same order
- \> 0 -> `a` proceeds `b` in order
- < 0 -> `b` proceeds `a` in order

```csharp
System.Console.WriteLine(string.Compare("a", "A", StringComparison.OrdinalIgnoreCase));
```

---

## string.Equals(a, b, stringComparison?):

the `Equals` is a static method that is used to check for equality between two strings base on `stringCompassion`, the `StringComparison` enum is used for that.

```csharp
// checks if a is the same as b ignoring letter case
System.Console.WriteLine(string.Equals("a", "A", StringComparison.OrdinalIgnoreCase));
```

---

## Trim():

the `Trim`, `TrimStart` and `TrimEnd` are used to remove whitespaces from both sides, start or end of a string.

```csharp
System.Console.WriteLine("   a lot of white    spaces  ".Trim());
```
