<!-- @format -->

# Setup:

setup java by using a public class whose name **must** match the name of the java file, i.e in `HelloWorld.java` we would have:

```java
public class HelloWorld{
  //
}
```

inside this class we have the `main` method in lowercase:

```java
public class HelloWorld {
  // args here are what is passed to the app on running form the terminal -for instance-
  public static void main(String[] args) {

  }
}
```

now that in modern java we can just use:

```java
void main(){}
```

but we wouldn't be able to define methods inside this file

of course you can run the code using either the run button in your ide or using the `javac` command:

```bash
javac HelloWorld.java
# this generated a `HelloWorld.class` file which is a binary executable via the jvm
java HelloWorld #we are running the .class binary executable.
```
