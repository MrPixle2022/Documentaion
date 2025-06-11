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

- `Exception` -> general exception
- `DivideByZeroException` -> when dividing by zero error
-
