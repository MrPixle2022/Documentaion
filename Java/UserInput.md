<!-- @format -->

# User input:

we know we can show data to the standard output using `System.out.print` and it's variations, so how can we accept use input?!.

we can use :

```java
//reads the ASCI code of the input
int x = System.in.read();
```

but of course their are better solutions.

---

## BufferReader:

the `BufferReader` class is part of the `java.io` package and allows us to read a buffer:

```java
import java.io;
```

then use:

```java
BufferReader bf = new BufferReader(
  new InputStreamReader(System.in)
);

int number = Integer.parseInt(bf.readLine());
```

buffer reader can read info from standard in, files, network, etc...

buffer reader it self is a resource, meaning that after its use you must close it:

```java
bf.close();
```

---

## Scanner:

the `Scanner` class is used to read data from a specified source.

this class is found in the `java.util.Scanner` package.

to use it first initialize a new scanner:

```java
Scanner scanner = new Scanner(System.in); //source of input is the terminal

scanner.close();
```

we can also use it to read from files:

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

> **NOTE** in case of a type mismatch the scanner will throw an error like "InputMismatchException"
