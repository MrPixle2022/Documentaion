<!-- @format -->

# OOP:

java is an `OOP` language, meaning its basis is objects, objects are reference-types that hold data -attributes- and do actions -method-.

an object is usually based of a class that acts as the blueprint to all objects based of it.

---

## Class:

define a class using the following:

```java
//[access-modifier] class [name]
class SomeClassName{
  //define attributes and method
}
```

for example:

```java
public class Car{
  String model = "unknown";
  int wheels = 4;
  int hp = 260;

  double acceleration = 3.4;
  double topSpeed = 213;

  void move(){
    System.out.println("Car is moving!");
  }

  void stop(){
    System.out.println("Car is stopping!");
  }
}
```

using the class as a blueprint we can create objects using the `new` keyword:

```java
//an object
Car car = new Car();

car.move(); //Car is moving!
System.out.println(car.topSpeed); //213
```

> [!NOTE] if we print the object itself, **by default** this invokes the `.toString` method which **by default** will log:

```text
[type]@[address]
```

of course the insist on **by default** is to alert you that the `toString` method can be overridden to alter its behavior.

---

## Constructors:

a `constructor` is a special method that is used to initialize objects, they are helpful in many ways like passing data to an object to use for its attributes.

since they are methods they support overloading.

to define a constructor use:

```java
class ClassName{
  ClassName(/* additional arguments */){
    // post-initialization logic
  }
}
```

it's important to know that inside the constructor's body methods and attributes -**which aren't static**- of the object are accessed from the `this` object which is just the object being instantiated, for example:

```java
class Car{
  int wheels = 4;
  int gears = 7;
  boolean auto = false;

  Car(int wheels, int gears, boolean isAuto){
    this.wheels = wheels;
    this.gears = gears;
    this.auto = isAuto;
  }
}
```

then we pass them to the object as follows:

```java
Car car = new Car(4, 6, false);
```

---

## Wrapper classes:

wrapper classes allow primitive types -i.e. int, float, boolean, etc...- to become objects and allows them to be used with the collections frameworks -i.e. ArrayList<T>, etc...-.

this list includes:

- Integer
- Double
- Boolean
- Character
- etc..

```java
// notice using `new` is not required
Integer integer = 12;
Double dbl = 14;
```

> [!Note] using `new` is not needed here, this is called **auto-boxing**, which is the same when using type `String`

also we can do the opposite and **unbox** those classes:

```java
Integer x = 10;
int y = x;
```

wrapper classes can be used to parse values into their type, stringfy them, validate their type:

```java
String x = Integer.toString(12);
int y = Integer.parseInt("123");
// Character alone
boolean z = Character.isLetter('A');
boolean w = Character.isUpperCase('A');
```

---

## Static:

the `static` keyword is used to define attributes/methods that belong to the class and don't require an object to be accessible, for example this is our class:

```java
class Car{
  int topSpeed  = 300;

  Car(int speed){
    this.topSpeed = speed;
  }

  static int getTopSpeed(Car car){
    return car.topSpeed;
  }
}
```

```java
Car car = new Car(450);

car.getTopSpeed(); //ERROR
Car.getTopSpeed(car); //450
```

static is used for utility methods and shard resources between objects where it makes no sense that a member belongs to the object rather then the class, think of the `Math` class whose methods and fields are mostly static.

there is also what is called a `static` block, which is used to initialize static fields once, so as not to re-initialize them on each object instantiation:

```java
public class MyClass{
  public static int myField;

  static{
    //this block is executed only once, on class saved into memory
    myField = 12;
  }
}
```

---

## Inheritance:

inheritance is a concept in OOP where multiple types share a singular basis like a class or an interface, in java we can declare an inheritance using the `extends` keyword, for example:

```java
//parent class (super class)
class Animal{ /* code */ }

//Cat (sub class) is Animal + more
class Cat extends Animal{
  /* */
}
```

when using inheritance with a super class we must initialize an object of the super class in the constructor of the sub class using the `super` keyword which just is like a constructor for the parent class:

```java
Class Animal{
  Animal(String type){}
}

class Cat extends Cat{
  Cat(String type){
    super(type);
  }
}
```

---

## Polymorphism:

let's say we have the class `Animal` as a basis to `Cat`, `Dog` and `Fish`:

```java
Class Animal{/* some code */}

class Cat extends Animal {/* code */}
class Dog extends Animal {/* code */}
class Fish extends Animal {/* code */}
```

and we want an array whose content could be objects of `Cat`, `Dog` and `Fish`, but the problem is how can we do so when each type is it's own different type?. Simple, use the basis they all share which is either `Object` -all classes' basis- and `Animal` their direct super class:

```java
Animal[] animals = {new Dog(), new Cat(), new Fish(), new Animal()};
```

since these classes are based of `Animal` we technically consider type `Cat` as type `Animal`.

```java
// valid code
Animal cat = new Cat();
```

but of course doing so deprives us from all the extra things found in the `Cat` and the other classes alone meaning things that are not implemented in the `Animal` class unless we use typecasting, for example with the animals array we can:

```java
Cat cat1 = (Cat) animals[1];
```

this is called `Polymorphism`, for class `Animal` is present in multiple forms being:

1. Animal
1. Cat
1. Dog
1. Fish

> [!TIP] Polymorphism is achievable through interfaces and abstract classes as well

---

## Runtime polymorphism:

runtime polymorphism is like when we use a method inherited from the super class, but it's execution is dependent on the type that is to be decided at runtime.

```java
abstract class Animal{
  abstract void speak();
}
```

then we will have:

```java
class Dog extends Animal{
  @Override
  void speak(){
    System.out.println("Woof Woof");
  }
}
```

and another class

```java
class Cat extends Animal{
  @Override
  void speak(){
    System.out.println("Meow Meow");
  }
}
```

finally our main code:

```java
Animal animal; //generic type
Scanner input = new Scanner(System.in);

int aType = input.nextInt();

if(aType == 1) animal = new Cat(); //assign at run time
else animal = new Dog(); //assign at run time

animal.speak();
```

---

## Abstract classes:

an abstract class is a class that can't be instantiated but is used as a basis for classis to inherit from, it includes methods and fields that either abstract -must be implemented- or concrete -inherited with along with their default implementation-.

now let's look at an example:

```java
public abstract class Shape{
  //Abstract must be implemented
  abstract double area();

  //Concrete uses the current implementation
  void randomMsg(){
    System.out.println('random msg');
  }
}
```

trying to create an object of `Shape` yields an error, since it's an abstract class, instead we will have sub-classes of it:

```java
public class Square extends Shape{
  //code
  @Override
  double area(){
    return width * width;
  }
}
```

and

```java
public class Circle extends Shape{
  // code
  @Override
  double area(){
    return Math.PI * radius * radius;
  }
}
```

---

## Interfaces:

an interface includes a blueprint for all classes based of it, every thing in the interface is mandatory to implement in a subclass:

```java
interface Prey{
  void flee();
}
```

and for the subclass:

```java
class Rabbit extends Prey{
  @Override
  void flee(){
    System.out.println("Fleeing danger");
  }
}
```

an upside to interfaces over abstract classes is that a class can implement more then one interface which will be separated by a `,`:

```java
public class Human extends Prey, Predator{ /* class content*/ }
```

---

## Method Overriding:

method overriding is like overloading a method, however now the method is defined in the parent class and the overload is in the sub class, the `.toString` method is the method that is mostly overridden.

```java
class Parent{
  void doSomething(){
    System.out.println("Parent is doing something");
  }
}

class Child extends Parent{
  @Override
  void doSomething(){
    System.out.println("Child is doing something");
  }
}
```

here we have overridden the `doSomething` method, the `@Override` decorator is optional but is recommended as modern IDE will inform you if misspell or you are trying to override a method that is not in the parent and helps developers know this is overridden.

now, lets look at an actual example using the `toString` method:

```java
class Person{
  @Override
  public String toString(){
    return "this is a person";
  }
}
```

now you may ask what is the parent class of this class if we are not extending anything. you must know that every single class is an extension of Object class, which -in this case- is the source of the `toString` method.
