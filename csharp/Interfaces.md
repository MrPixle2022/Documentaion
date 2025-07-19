# Interfaces:

just like an abstract class interfaces are non-instantiable types that define what will the inheriting types at least have, they enforce the existence of every property and method on the extending type.

unlike an abstract class, interface methods don't require `abstract` and `override` you just have to include a method with the same name as the one in the interface.

---

## Creating an interface:

interfaces are marked by the `interface` keyword and usually describe adjectives, starting by `I` then a capital letter like `IRidable`, `IEnumerable` etc...

```csharp
using System;

namespace Project_0.Vehicles;

// interfaces define the shape of the inhering class
// interfaces have abstract methods and can have properties
public interface IDrivable
{
    // interface properties
    int Wheels { get; set; }
    double Speed { get; set; }

    // interface method
    void Move();
    void Stop();
}
```

the process then is very simple:

```csharp
using System;

namespace Project_0.Vehicles;

public class Vehicle : IDrivable
{
    // from the interface
    public int Wheels { get; set; } = 0;
    public double Speed { get; set; } = 0;

    public String Brand { get; set; }

    public Vehicle(int wheels = 0, double speed = 0, string brand = "none")
    {
        Wheels = wheels;
        Speed = speed;
        Brand = brand;
    }

    // from the interface
    public void Move()
    {
        System.Console.WriteLine("{0}: Moving @{1}Km/H", Brand, Speed);
    }
    // from the interface
    public void Stop()
    {
        System.Console.WriteLine("{0}: Stopping", Brand);
    }
}

```
