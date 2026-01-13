# Random:

the `Random` class in the `java.utils.Random` can be used to generate somewhat random rands and booleans using a random type object.

first import it using:

```java
import java.util.Random;
```

then define the object:

```java
Random random = new Random();
```

on this object we can use methods like `nextInt`, `nextDouble` and `nextBoolean`:

```java
Random random = new Random();

int rand1 = random.nextInt(101);// random from 1 -> 100
System.out.println(rand1);

int rand2 = random.nextInt(1, 6); //random between 1 & 6
System.out.println(rand2);

double rand3 = random.nextDouble(); // 0.0 -> 1.0

boolean rand4 = random.nextBoolean();
```