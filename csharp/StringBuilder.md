<!-- @format -->

# String builders:

string builder are string like classes that you can use -to dynamically alter a string- instead of creating a new string using string.methods, when appending or prepending these change the actual string's value and allows for predefined max capacity.

---

## Initialization:

first include the `System.Text` namespace to be able to use the `StringBuilder` class

```csharp
using System.Text;
```

then create a new `StringBuilder`:

```csharp
StringBuilder sb = new StringBuilder("This is a string builder");
// StringBuilder sb = new ("This is a string builder"); works
```

we can also set a capacity:

```csharp
//32 is the maximum
StringBuilder sb2 = new("this has limited capacity", 32);
```

---

## Length & Capacity:

on a string builder we can access the values of both `Length` and `Capacity`.

```csharp
System.Console.WriteLine("{0} -> {1}", sb2.Capacity, sb2.Length);
```

-   `length` -> how many characters held by the string
-   `capacity` -> how many can't hold before re-allocation is required.

on the builder there are methods like `Equals` to check for equality as well.

---

## Append(value):

the `Append` allows the insertion more text to the builder at the end

```csharp
sb.Append("hello this is a value");
```

---

## AppendLine(value):

the `AppendLine` appends the given value and inserts the new line character afterwards.

```c#
sb.AppendLine("A new line will be inserted here ->");
```

---

## Replace(old, new):

the `Replace` is used to replace a part of the builder with the new value

```csharp
sb2.Replace("has", "still has");
```

---

## Remove(start, count):

we can use the `Remove` method to remove a part of the builder

```csharp
// 6th -in index- is excluded
sb2.Remove(0, 6);
```

---

## Insert(index, value):

the `Insert` is used to add `value` at `index`:

```c#
//adds `this is interesting` to the start of the builder
sb2.Insert(0, "this is inserting");
```

---

## Clear():

the `Clear` can be used to empty the builder:

```csharp
sb2.Clear();
```
