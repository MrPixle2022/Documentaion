<!-- @format -->

# Delegates:

delegates are a special type that allows you to define the signature of a method, and since it's a type after all it allows you to create variables storing methods instead of their return values.

delegates are type-safe as they enforce a return type and params.

create a delegate using the `delegate` keyword and follow it up with with the return type, delegate name & params the `;`, no method body.

```csharp
public delegate void Arithmetic(double num1, double num2);
```

this `Arithmetic` delegate will only accept void method that takes two doubles, for example:

```csharp
public static void Add(double num1, double num2)
{
    Console.WriteLine("ADD = {0}", num1 + num2);
}

public static void Subtract(double num1, double num2)
{
    Console.WriteLine("SUBTRACT = {0}", num1 - num2);
}
```

now we can link those methods as follows:

```csharp
// DelegateType name = new(Method);
Arithmetic add = new Arithmetic(Add);
```

having done this we can know use the `add` delegate as if it were a method:

```csharp
add(0, 12);
```

also those delegates allows you to use methods as params.

```csharp
// the Add method
RunAdd(Add);
```

---

## Multicast delegates:

multicast delegates allows you to combine methods and delegates, on execution they run every method **in order**.

```csharp
Arithmetic add,
    sub,
    addSub;
add = new Arithmetic(Add);
sub = new Arithmetic(Subtract);
addSub = add + sub; // Multicast delegate
```

also note we can use the `+=` operator to do the same.

---

## Func & Predicate:

the `Func` delegate is used to simply define a signature for a method -usually a lambada-, it take any number of generics with each defining a parameter type, but **always** the last generic is the return type.

```csharp
// function takes 2 integers as params and returns a bool
Func<int, int, boo>
// function takes 1 string and returns a bool
Func<string, bool>
```

Func is used a lot when callbacks are to be provided like with LINQ extension methods

there is also `Predicate` which takes any number of generics and returns a bool **always** so all the defined types are for params only.

```csharp
// takes 2 int returns bool
Predicate<int, int>
```
