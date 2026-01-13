# Array List:

the `ArrayList<T>` is a a dynamic array meaning it can remove/add elements to it, when using the `ArrayList` we can only pass it a reference type that extends `Object` so primitive types such as:

- int
- long
- float

won't work, instead we use `Integer`, `String,` , etc...

import the `ArrayList<T>` via:
```java
import java.util.ArrayList;
```

then we can define a new one in a couple of ways:

```java
ArrayList<Integer> arr = new ArrayList<>(); //empty list
ArrayList<String> arr2 = new ArrayList<String>(4); //a list of 4 string
ArrayList<Double> arr3 = new ArrayList<>(Arrays.asList(1.2, 2.4, 4.5));
```

---

## Accessing and reassigning elements:

when using `ArrayList<T>` we can't just use `list[index]` instead we use `.get(index)` and `.set(index, value)` methods for that or use `replaceAll` to modify every element at once:

```java
ArrayList<String> arr = new ArrayList<>(Arrays.asList("Hello"));

arr.get(0); //Hello
arr.set(0, 'World'); //arr[0] is now World

arr.replaceAll(element -> element.toLowerCase());
```

---

## Size of list:

we can easily check for a list's size using the `.size()` method, also we can check if it's empty using `.isEmpty()`.

---

## Adding and removing elements:

we can add or remove elements using either the `.add()` ,`addAll()`, `remove()`, `removeIf()` and `clear()`:

```java
ArrayList<T>.add(T element); //add one element
ArrayList<T>.add(int index, T element); //add one element
ArrayList<T>.addAll(Collection<T> source); // add elements from another list
ArrayList<T>.addAll(int index, Collection<T> source); // add elements from another list

ArrayList<T>.remove(int index); //remove one element by index
ArrayList<T>.remove(T target); // remove 1st elements with this value
ArrayList<T>.removeAll(Collection<T> target); //remove all shared between target and the list
ArrayList<T>.removeIf(Predicate<T> filter); //uses a lambda function to filter and delete values

ArrayList<T>.clear()//removes all values
```

---

## Finding an index and validating an element existence:

```java
arr.indexOf(Object target); //returns the index of the first target
arr.contains(Object target); //checks if target occurs at least once in the list
```