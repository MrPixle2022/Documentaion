# Classes:

classes represent the basis of the c# as it is an Object-Oriented language, Classes can extend one another and represent a blueprint for their own instances and even other classes.

---

## Creating a class:

create a class using the `class` keyword followed by it's name and can optionally define an access modifier before `class` for more control if needed:

```csharp
class Animal{}
```

then define your fields, fields are the data with in the class and the syntax is:

```csharp
//accessModifier type name;
//accessModifier type name = value;
```

access modifiers like `public`, `protected` and `private`, the default for all is `private`.

now define the `constructor`, a `constructor` is a **public** method whose name is the same as the `class`'s, you don't specify the return type.

a `constructor` is the method responsible for creating objects of a class.

```typescript
class Animal {
    public Animal() {
        //assign fields here
        //this: refers to the object not the class here
    }
}
```

> [!NOTE]
> Constructors support overloading.

---

## Access modifiers:

Access modifiers are keywords that define the accessibility or scope of a type (like a class) or a member (like a method or field). They are a fundamental part of encapsulation in C#.

There are 6 access modifiers in C#:

-   `public`: The type or member can be accessed by any other code in the same assembly or another assembly that references it. This is the least restrictive access level.

```csharp
public class Car
{
    // Accessible to anyone
    public void StartEngine() { /* ... */ }
}
```

-   `private`: The type or member can be accessed only by code in the same `class` or `struct`. This is the most restrictive level and is the **default** for members inside a class or struct.

```csharp
public class Car
{
    // Only accessible inside the Car class
    private void IgniteFuel() { /* ... */ }
}
```

-   `protected`: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.

```csharp
public class Vehicle
{
    protected int speed;
}

public class Car : Vehicle
{
    public void Accelerate()
    {
        // Can access 'speed' because Car derives from Vehicle
        speed += 10;
    }
}
```

-   `internal`: The type or member can be accessed by any code in the same assembly, but not from another assembly. Top-level types (non-nested) are `internal` by default.

-   `protected internal`: The type or member can be accessed by any code in the same assembly, OR by any derived class in another assembly.

-   `private protected`: The type or member can be accessed by types derived from the containing class, but only within its containing assembly.

---

## Statics:

any class member marked with the `static` keyword is a callable by **only** the class it self, not by any object or instance of it.

for example, if the `Animal` class has a:

```csharp
static int count = 0;
```

and in the constructor we add 1 to the `count`, then we can only access this count using:

```csharp
Animal.count;
```

**methods** can be static as well, and follows the same principles and if a `class` is set to be static then it becomes non-insatiable.

---

## Creating objects of a class:

to create an object of class use the class as a type.

```csharp
Animal animal1 = new Animal(/*constructor params*/);
Animal animal2 = new(/*constructor params*/);
Animal animal3 = new Animal(){/*set Properties*/};
```

now these objects has access to every **public** not-static fields and methods

> [!Note]
> Classes can be created inside one another.

and when used we use:

```csharp
Wrapper.ClassName variable = new();
```

for example:

```csharp
Animal.AnimalHealth getHealth = new();
```

---

## Structs:

structs are data strictures that are pretty similar to a class but they use the `struct` keyword instead of the class, and they are passed by value not by reference.

---

## Inheritance:

we can set a class to inherit from another using `:` after the class name, then when we create the constructor use `: base(--)` -if the parent requires some data- just before the `{}`.

```csharp
namespace Project_0;

// Dog extends Animal
public class Dog : Animal
{
    public string Sound2 { get; set; } = "Grrr";
    public string Name { get; set; }

    // overriding a virtual method in the parent
    public override void MakeSound() { }

    // creating an object of the parent class -Animal- on instantiation
    public Dog(string name, string sound = "grrrr", string sound2 = "Grrr")
        : base(name, sound)
    {
        Sound2 = sound2;
        Name = name;
    }
}
```

as a matter of fact we can create a variable of type `Animal` but is actually of type `Dog`:

```csharp
// can only access what the `Animal` class has, to access the full data cast dog into `Dog`
Animal dog = new Dog("Hello");
```

inheritance is not limited to classes, you can also inherit interfaces but you won't need the `base` keyword.

note we can also check for inheritance using the `is` word, since a base class can use a child's instance we can use that to check for inheritance:

```csharp
// Interfaces
Vehicle buick = new(4, 160, "Buick");

if (buick is IDrivable) //Polymorphic check
    System.Console.WriteLine("buick is Drivable");
else
    System.Console.WriteLine("buick is not Drivable");

// Classes
Rectangle rect = new(10, 20);

if (rect is Shape)
    System.Console.WriteLine("rect is Shape");
else
    System.Console.WriteLine("rect is not Shape");
```

---

## Virtual and override:

marking a method as `virtual` allows any inheriting class to **override** that method.

for example:

```csharp
public virtual void MakeSound()
{
    Console.WriteLine($"{name} says {sound}");
}
```

this method will be available to any inheriting class to use as it is or redefine it as needed, but to do so the method must be marked as `override`

```csharp
public override void MakeSound() {
    //new logic
}
```

---

## Abstract classes:

abstract classes are classes marked by the `abstract` keyword, abstract classes defined a basis for other classes to inherit but they them selves are not instantiatable themselves.

for example:

```c#
namespace Project_0.Shapes;

public abstract class Shape
{

    // abstract methods (overridable by sub-classes)
    public abstract double Area();

    // none-abstract methods
    public virtual void LogInfo()
    {
        Console.Write("{0}: ", Name);
    }
}
```

in this example we have an abstract class with two methods:

-   none-abstract(LogInfo) -> overriding is optional by sub-classes
-   abstract(Area) -> override is mandatory, the method can't have a body in the abstract class.

now let's make use of the abstract class:

```csharp
public class Rectangle : Shape
{
    // ---

    // the abstract method
    public override double Area()
    {
        return Length * Width;
    }

    // the virtual method
    public override void LogInfo()
    {
        base.LogInfo();
        Console.WriteLine(
            $"Length: {Length}, Width: {Width}, Area: {Area()}, Circumference: {Circumference()}"
        );
    }
}
```
