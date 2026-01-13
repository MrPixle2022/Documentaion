<!-- @format -->

# Methods:

methods are OOP's equivalent to functions, to define a method your file must use the class form:

```java
public class Program{ /*or whatever your file is called*/
    public static void main(String[] args){}
}
```

under the `main` method we can create a new method using the following format:

```java
[access-modifier] [static] [return-type] [name]([params]){
    //body
}
```

for example to create a method that sums 2 integers and returns their sum then we would have:

```java
int sum(int a, int b){
    return a + b;
}
```

in this case the default `access-modifier` is private making this method in-accessible outside this class.

of course a method is useless if we can't use it, so to call a method use:

```java
[name]([arguments]);
```

so for example:

```java
//inside static void main(){}
sum(1, 2); // 3
```

it's important to note that using `sum` refers to the function while `sum()` refers to the return value

> [!IMPORTANT] only static methods can directly be called inside another static method, so you may want to make all methods in you main java file static for now

---

## Arguments:

parameters/arguments are optional data that may be provided to a method, put between `( )` as:

```java
(type name, type name)
```

you can choose not to add them but having `()` is must in the definition and the execution.

for situations where you want to get a huge number of arguments but are unsure of how many use the `...` operator:

```java
static int sum(int...number){
    int total = 0;
    for(int i: number) total += i;

    return total;
}
```

for `numbers` is like it's type is `int[]`, now using it is simple:

```java
sum(2, 3, 5, 10);
```

---

## Return type:

the `return type` of the method can be a lot of things, a method may not return any thing hence it's return type is `void`, or a whole number `int`, etc...

sometimes it returns objects, arrays, and other complex Data structures.

---

## Method Overload:

in java multiple methods can share the same `name` but not the signature-name + params-, this makes it easy as we can define 2 methods for example with the same name but each handles different type/number of arguments.

```java
//method
int sum(int a, int b){
    return a + b;
}
//overload 0
int sum(int... numbers){
    int total = 0;
    for(int n: numbers) total += i;
    return total;
}
//overload 1
String sum(String a, String b){
    return a + b;
}
//overload 2
double sum(double a, double b){
    return a + b;
}
```

now which method will be called will depend on the type of arguments
