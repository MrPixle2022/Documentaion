# Scanner

the `Scanner` class is used to get input from the user and can be found in the `java.util.Scanner` package.

to use it first initialize a new scanner:

```java
Scanner scanner = new Scanner(System.in); //source of input is the terminal
```

note that if you are reading from a file for instance then you must use `scanner.close()` to close the stream when reading is done:

```java
File myObj = new File("filename.txt");
Scanner myReader = new Scanner(myObj);
/*some code*/
myReader.close();
```

on the scanner we can read some data and parse it using:

- nextBoolean() → read a boolean
- nextLong() → read a long
- nextShort() → read a short
- nextByte() → read a byte
- nextLine() → read a string
- nextDouble() → read a double
- nextFloat() → read a float

> **NOTE**
> in case of a type unmatch the scanner will throw an error like "InputMismatchException"