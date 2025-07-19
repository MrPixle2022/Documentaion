# Operator overloading:

to overload an operator use:

```csharp
public static T operator /*operator*/(/*params*/){
    return;
}
```

for example we have this class:

```csharp
public class Box
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public Box()
        : this(1, 1, 1) { }

    //Other operators:
    // + - * / % ! == != > >= < <= ++ --
}
```

we want to allow two objects of `Box` objects to add up, to do that we add the following method to the class:

```csharp
namespace Project_0;

public class Box
{
    //----
    //define what `+` do
    public static Box operator +(Box box1, Box box2)
    {
        Box box = new()
        {
            Length = box1.Length + box2.Length,
            Width = box1.Width + box2.Width,
            Height = box1.Height + box2.Height,
        };

        return box;
    }
}
```

and if we want to subtract them use:

```csharp
namespace Project_0;

public class Box
{
    //---
    //define what `-` does
    public static Box operator -(Box box1, Box box2)
    {
        Box box = new()
        {
            Length = box1.Length - box2.Length,
            Width = box1.Width - box2.Width,
            Height = box1.Height - box2.Height,
        };

        return box;
    }
}
```

also we can overload the following operators:

-   \+
-   \-
-   \*
-   /
-   %
-   !
-   == -> return a **boolean**
-   != -> return a **boolean**
-   \> -> return a **boolean**
-   \>= -> return a **boolean**
-   < -> return a **boolean**
-   <= -> return a **boolean**
-   ++
-   \--

---

## Conversion:

using operator overloading we can determine the behavior of a class on conversion from or to.

for example, use the `explicit operator` followed by the type to determine how the object converts into another type.

for example:

```csharp
public static explicit operator int(Box b)
{
    return (int)(2 * (b.Length * b.Width + b.Width * b.Height + b.Height * b.Length));
}
```

this static method on the `Box` class defines how a `Box` is coveted into an integer.

also to define how you convert into the `Box` use `implicit operator`:

```csharp
public static implicit operator Box(int i)
{
    return new(i, i, i);
}
```

this will sets the conversion behavior from integer to box.
