<!-- @format -->

# Methods:

---

## Declare a method:

declare a method using:

```csharp
//accessSpecifier returnType Name(params){---}
```

accessSpecifier:

1. public -> accessible anywhere
2. private -> in-class access only
3. protected -> can't be accessed in-class but in inheriting -aka derived- classes

`returnType` -> void (no return) can use

```csharp
return; to exit
```

then any where in the app call the method:

```csharp
//methodName //the method reference
//methodName(params);//calling the method (if the method returns a value this becomes a value)
```

for example:

```csharp
//static means it's only callable on the class itself not an instance
static void PrintArray(int[] array, string message)
{
  foreach (int k in array)
  {
    System.Console.WriteLine(message, k);
  }
}
PrintArray([1, 2, 3, 4], "{0} is the element");
```

---

## Params with default values:

to define a param with a default value use `=` in the param declaration.

```csharp
static int SumInt(int x = 1, int y = 2)
{
    return x + y;
}
```

now when we call the method we can either override one, both or none.

```csharp
SumInt();
SumInt(2, 4);
```

---

## Unknown number of params:

add the keyword `params` before the last param's type turns it into an array that takes any number of parameters.

```csharp
static double GetSumM(params double[] nums)
{
    return nums.Sum();
}
```

then we pass those params directly:

```csharp
GetSumM(1, 2, 3, 4, 5);
```

---

## In, out and ref params:

we can optionally add `in`, `ref,` or `out` before a param to indicate that this will be passed by **reference** not by value.

- in -> the param is readonly
- ref -> the param may be altered (overwritten)
- out -> the param will be altered

another notable difference is that `ref` requires pre-initialized variables to be passed whilst `out` can declare new ones.

```csharp
static void DoubleIt(int baseValue, out int x)
{
    x = baseValue * 2;
}

static void Swap(ref int x, ref int y)
{
    //add readonly before ref to deny overwrite
    x += y; //2 +3 -> x = 5
    y = x - y; // 5 - 3 -> y =2
}
```

for out params:

```csharp
DoubleIt(15, out int doubleResult);
System.Console.WriteLine(doubleResult);

int s1 = 1;
int s2 = 3;

System.Console.WriteLine("pre swap s1: {0}, s2:{1}", s1, s2);
Swap(ref s1, ref s2);
System.Console.WriteLine("pre swap s1: {0}, s2:{1}", s1, s2);
```

for in params:

to showcase how an `in param` can be used since it's a readonly i created a custom class to demonstrate

```csharp
class Vector3
{
    public double x,
        y,
        z;

    public Vector3(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}

```

```csharp
static void SomeMethod(in Vector3 vector)
{
  //vector itself is imitable in this method but it's content is changeable
  vector.x = 10;
  vector.z *= 10;
}
```

```csharp
Vector3 vector3 = new(1, 2, 3);
SomeMethod(vector3);
System.Console.WriteLine("this is the original {0}", vector3); //(10, 2, 30)
```

---

## Named params:

parameters can be passed without order **if** their names are used.

the syntax is:

```csharp
//param: value
```

for example:

```csharp
static void PrintInfo(string name, int zip)
{
    System.Console.WriteLine("{0} {1}", name, zip);
}
PrintInfo(name: "amr", zip: 10);
```

---

## Method overloading:

overloading means defining different methods with the same name.

```csharp
static double Sum2(double x, double y)
{
    return x + y;
}

int Sum2(int x, int y)
{
    return x + y;
}
```

then the compiler will determine which is the correct method passed on the params (their type in this case).

```csharp
// will use the second overload
int x = 10;
int y = 10;
Sum2(x, y);
```
