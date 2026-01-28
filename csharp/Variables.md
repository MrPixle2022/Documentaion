<!-- @format -->

# Variables

variables in c# can be defined by a type, have a dynamic type or be a constant.

the syntax for defining them is as follows:

```csharp
// type name = value;
// var name = value; (implicit type, lets the compiler set the type for you)
// const type name = value; (immutable value);
```

a `var`'s type is implicitly set by the compiler, whilst a `const` is assigned once at initialization and after wards becomes mostly a read-only value.

---

## Built in types

in c# we have a set of types we can make use of, from integers to floating points and decimals and booleans.

```csharp
// BOOLEAN
bool isBoolean = true;

// INTEGERS
short shortInt = 12;
int integer = 12;
long longInt = 12000;

byte byteValue = 0; //0 -> 255 (8-bit) (unsigned by default)

//DECIMALS AND FLOATS
float floatNumber = 12.0F;
double doubleValue = 12.0D;
decimal decimalValue = 12.2M;

// TEXT BASED
string stringValue = "hello this is a string";
char character = 'a';
```

on numeric type like integers and longs we have access to static properties for the max and min values named `MaxValue` and `MinValue` which we can display to the console.

```csharp
Console.WriteLine("maxInt: {0}, minInt: {1}", int.MaxValue, int.MinValue);
Console.WriteLine("maxLong: {0}, minLong: {1}", long.MaxValue, long.MinValue);
Console.WriteLine("maxShort: {0}, minShort: {1}", short.MaxValue, short.MinValue);

Console.WriteLine("maxFloat: {0}, minFloat: {1}", float.MaxValue, float.MinValue);
Console.WriteLine("maxDecimal: {0}, minDecimal: {1}", decimal.MaxValue, decimal.MinValue);
Console.WriteLine("maxDouble: {0}, minDouble: {1}", decimal.MaxValue, decimal.MinValue);
```

we also have some **unsigned** types, unsigned means that the value can't be a negative value. unsigned type have a `u` before the name, while some **signed** one have an `s` before it depending on what the default behavior of the type is.

```csharp
uint uInteger = 1209211; //unsigned integer 0 -> 4,294,967,767
ulong uLong = 1231;//~ long 0 -> ulong.MaxValue (huge)
ushort uShort = 12; //~ short 0 -> 65,535

sbyte smallByte = -128;//signed -128 -> 127
```

it's worth noting that `object` is the basis for every type in c#, meaning a variable with type of `object` can work with any type of data.

---

## Nullables

by default a type can't store null unless you explicitly allow it to be, this is done using the `?` after the type marking the variable as nullable.

```csharp
int? x = null;
```

remember that you must check for nullables before using them to avoid warning and potential errors.

---

## Anonymous types

anonymous types are used with the `var` keyword, using the following:

```csharp
var anonymous = new {/*Properties here*/}
var anonymousArray = new[]
{
    new{/*---*/},
    new{/*---*/},
    new{/*---*/},
}
```
