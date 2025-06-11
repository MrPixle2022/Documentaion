<!-- @format -->

# Enums:

enums allows for the definition of a custom type that has a set of pre-defined values. meaning they are helpful for things with limited options that we want to have predefined.

the syntax of creating an enum is by using the `enum` keyword, usually enums and there value are all in uppercase:

```csharp
enum CAR_COLOR : byte
{
    RED = 1,
    GREEN, //2
    BLUE, //3
    BLACK,
    GRAY,
}
```

as shown enums auto increment value -if number- like integers and bytes.

now we can use this value:

```csharp
static void getColor(CAR_COLOR color)
{
    System.Console.WriteLine(color);
}

getColor(CAR_COLOR.RED);
```
