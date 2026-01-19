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

---

## How java runs:

the java code runs on the `JVM` or the java virtual machine, using the `jvm` means the code becomes platform-independent, keep mind that in spite of this fact `jvm` is platform-dependent.

jvm runs `byte-code`, but your code isn't in byte-code, is it?, well we have the java compiler `javac` which will compile the source code into byte code and then it runs on the jvm.

note that jvm only runs **1 single file**, the main file, aka the file with the `main` method.

in addition to `JVM`, `JRE` OR Java runtime environment runs which has tools for storing classes and libraries, etc..., it also checks your bytecode and does some other things.
