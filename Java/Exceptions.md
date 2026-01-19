<!-- @format -->

# Exceptions:

exceptions are errors that occur in the program, errors are split into:

1. compile time error -> easy to detect as they prevent to compiling of the source code
1. logical error -> bugs in logic, required testing and debugging
1. runtime errors -> only captured during runtime

---

## Handling exceptions:

we handle exceptions using a `try-catch` block.

```java
try{
  /*potentially exception-throwing code*/
}
catch(Exception e){
  //do on exception
}
finally{
  //happens wether an exception happens or not
}
```

using `Exception` type is not recommended as it's very general and doesn't help knowing what was wrong, instead you can use the type of exception, also note you can have **multiple catch blocks with one try statements** and if you want to use `Exception` as a fallback ensure it is in the very last catch block.

---

## Exceptions types:

we have multiple exceptions available under the `java.lang` package:

- ArithmeticExceptions: catches arithmetic errors
- ArrayIndexOutOfBoundsException: on trying to access an element outside the array's boundary
- FileNotFoundException: the file you tried to open was not found
- InputMismatchException: when given input of different type than expected

and many others

---

## Throwable:

the throwable is the parent class to 2 classes:

1. Exception
1. Error

Exception are handel-able unlike `Error` which includes things like: `IOError`, `ThreadDeath` or `VirtualMachineError` which it self is a parent to `OutOfMemory`.

`Exception` on the other hand has: `SQLException`, `IOException`,`RunTimeError` which has `Arithmetic`, `NullPointer` , etc..., all of `RunTimeExceptions` are unchecked exceptions while SQL and IO are checked.

checked exceptions are often caught at compile time forcing the developer to fix them while unchecked exceptions are found only at runtime

---

## throw:

the `throw` keyword is used to issue an exception manually:

```java
throw new Exception(String msg);
```

of course you can use the specific type of exception you want.

---

## throws:

`throws` is used to indicate that a method may throw an exception but handling it will be done else where:

```java
public void something() throws Exception{}
```

---

## Custom exceptions:

we can define our own exception by extending a type of exception i.e. RuntimeException:

```java
class MyException extends Exception{
  public MyException(String msg){
    super(msg);
  }
}
```
