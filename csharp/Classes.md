<!-- @format -->

# Classes:

---

## Creating a class:

create a class using the `class` keyword followed by it's name:

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

```csharp
class Animal{
  public string name;
  public string sound;
  //if none provided create an object where -two fields- are assigned these values
  public Animal(string name) : this(name, "no-sound")
  {
      numOfAnimals++;
  }
}
```

> [!NOTE] Constructors support overloading.

---

## Statics:

any thing -field or method- marked with the `static` keyword is a member of the class callable by **only** the class, not by any object or instance of it.

for example, if the `Animal` class has a:

```csharp
static int count = 0;
```

and in the constructor we add 1 to the `count`, then we can only access this count using:

```csharp
Animal.count;
```

methods can be static as well, and follows the same principles.

---

## Creating objects of a class:

to create an object of class use the class as a type.

```csharp
Animal animal1 = new Animal(/*constructor params*/);
Animal animal2 = new(/*constructor params*/);
Animal animal3 = new Animal(){/*constructor params*/};
```

now these objects has access to every **public** not-static fields and methods

---

## Getters and setters:

getters and setters are special method that controls how a field's value is read or updated.

we usually define them by associating them to a `private` field, the we create a property -usually same name but first-letter is capital- on which we define the getter and setter

```csharp
// this is called a field, class-fields
private string sound;

public string Sound
{
    get
    {
        // on read log value and return it
        Console.WriteLine("Sound accessed");
        return sound;
    }
    set
    {
        //on set log and assign
        Console.WriteLine($"new sound {value}");
        // don't update the property of `Sound` itself
        sound = value;
    }
}
```

we can also define one or the other.

also we can just define the property directly using the shorthand:

```csharp
//short hand
public string Owner { set; get; }
```

in this example we don't have to create a private `owner` field which is the actual field.

---

## Structs:

structs are data strictures that are pretty similar to a class but they use the `struct` keyword instead of the class, and they are passed by value not by reference.

---

## Access modifiers:

access modifiers are additional constraints allowing you to alter the behavior of a field, method, etc..

- `public` -> visible everywhere on the object or class
- `private` -> visible to the class only, not objects, not inheriting classes
- `readonly` -> value can be read not set
- `protected` -> visible in the class and inheriting classes only
