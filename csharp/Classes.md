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

> [!NOTE]
> Constructors support overloading.

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

## Structs:

structs are data strictures that are pretty similar to a class but they use the `struct` keyword instead of the class, and they are passed by value not by reference.
