<!-- @format -->

# Annotations:

annotations are like metadata, they are meant to communicate with the compiler.

---

## @Override:

used to mark that a method is overriding that of the super class

---

## @Deprecated:

marks a class, methods as outdated and warns on use.

---

## @SuppressWarning:

tells the compiler to ignore the warnings on methods

```java
//suppress deprecated warnings
@SuppressWarnings("deprecated")
public int sum(int a, int b){
  return a + b;
}
```

---

## @Retention:

used to mark the level of annotations like runtime, compiler, etc...

---

## @FunctionInterface:

a function interface has one method in it, used to mark interfaces.

functional interfaces are used together with lambada expressions:

```java
@FunctionalInterface
interface A{
  void show();
}
// using a lambda function with a functional interface
A obj = () -> {}

obj.show();
```
