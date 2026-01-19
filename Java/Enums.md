<!-- @format -->

# Enums:

enums allow you to have a set of pre-named values so we don't have to write them manually, say HTTP codes, we can use enums to get autocompletion for values to avoid typos.

define an enum using the `enum` keyword:

```java
enum STATUS{
  //objects of status
  RUNNING, FAILED, PENDING, SUCCESS;
}

STATUS s = STATUS.RUNNING;
// the order of the value
s.ordinal();
// access all of the values
STATUS[] sValues = status.values();
```

enums values are `public static final`, by default enum values are numbers starting from `0`, so what we have is:

- RUINING: 0
- FAILED: 1,
- etc...

enums can't be extended, however they themselves extend the `Enum` class, also you can define methods and variables inside them.

---

## Enum constructor:

we can define a constructor for the enum, and pass some values depending on what value is chosen:

```java
enum DIFFICULTY{
  //EASY -> multiplier = 1
  EASY(1),
  //MEDIUM -> multiplier = 5
  MEDIUM(5), HARD(10);

  int multiplier;

  public DIFFICULTY(int multiplier){
    this.multiplier = multiplier;
  }
}
```

the enum constructor supports overloading, the constructor is executed for each object.
