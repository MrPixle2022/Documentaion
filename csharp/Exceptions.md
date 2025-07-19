<!-- @format -->

# Exceptions:

we can handle exceptions using a `try catch` block.

```c#
try{
  //code that may throw an exception
}
catch(Exception e){
  //what to do on exception
}
finally{
  //this is optional
  //what happens after success and exceptions
}
```

note that the `Exception` type is general and is not specific, it's recommended to use the correct exception type or use multiple catch block if the code may throw multiple exceptions

> [!TIP] you can `throw new Exception()`

---

## Exception types:

-   `Exception`: The base class for all exceptions. Catching this will catch everything, but it's often better to catch more specific exceptions.
-   `NullReferenceException`: Thrown when you try to access a member (like a method or property) on a variable that is `null`.
-   `IndexOutOfRangeException`: Thrown when you try to access an element of an array or collection using an index that is less than zero or greater than the size of the collection.
-   `InvalidOperationException`: Thrown when a method call is invalid for the object's current state. For example, trying to read from a `StreamReader` after it has been closed.
-   `ArgumentException`: The base class for errors related to method arguments.
    -   `ArgumentNullException`: A more specific version thrown when a method receives a `null` argument but doesn't allow it.
    -   `ArgumentOutOfRangeException`: Thrown when the value of an argument is outside the allowable range of values.
-   `FormatException`: Thrown when the format of an argument is incorrect for the method. For example, `int.Parse("hello")`.
-   `IO.IOException`: The base class for exceptions that occur during input/output operations.
    -   `IO.FileNotFoundException`: Thrown when you try to access a file that does not exist.
    -   `IO.DirectoryNotFoundException`: Thrown when you try to access a directory that does not exist.
-   `DivideByZeroException`: Thrown in integer or decimal arithmetic when you attempt to divide a number by zero.
-   `OutOfMemoryException`: Thrown when the .NET runtime cannot allocate enough memory to continue executing a program.
-   `StackOverflowException`: Thrown when the execution stack overflows, usually due to excessively deep or infinite recursion. This exception is generally not catchable.
-   `NotSupportedException`: Thrown when a method or operation is called that is not supported by a particular object. For example, trying to write to a read-only stream.
-   `NotImplementedException`: Thrown to indicate that a method or property has not been implemented yet. It's often used as a placeholder during development.
