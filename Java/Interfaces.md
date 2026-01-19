<!-- @format -->

# Interfaces:

an interface includes a blueprint for all classes based of it, every thing in the interface is mandatory to implement in a subclass as by default all interface-members are `public abstract` for the methods and for the variables they are `final static` but that is on the interface itself.

```java
interface A{
  int x = 1;
  void y();
}

A.x;// 1
A.y(); //ERROR
```

interfaces are not stored on the heap, unlike classes.

> [!TIP] most interfaces in java end in `able`, i.e. `Comparable`

---

## Interface inheritance:

an interface and a class can both inherit from another interface, however the keyword differs:

```java
interface B extends A{
  /* B content*/
};
```

and in this case we don't have to re-state the contents of `A`.

with classes we use:

```java
class C implements A{
  /* implement all content of A */
}
```

it's worth noting that that an abstract class doesn't need to implement an interface even if it extends it.

in a class all interface methods must be declared `public` and must match the signature of the interface.

also know that you can implement more then one interface, unlike inheriting classes:

```java
class D implements A, B{
  // implement A & B
}
```

---

## Types of interfaces:

interfaces have 3 type:

1. normal
1. function / SAM: an interface with a singular `public abstract` method
1. marker: a blank interface with no method
