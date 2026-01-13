<!-- @format -->

# Strings:

in java strings resemble a datatype storing multiple characters, we can define a string as follows:

```java
String str1 = "";
String str2 = "";
String str3 = String.valueOf(12.2); //"12.2"
```

---

## length():

the `length` method returns how long a string is:

```java
String str = "Hello";
System.out.print(str.length());
```

---

## charAt(int index):

the `charAt` returns the character at the given index:

```java
String str = "Hello, World!";
char x = str.CharAt(str.length() - 1); // x = '!'
```

---

## equals(String str):

```java
String str1 = "Hello";
String str2 = "Hello";
String str3 = "hello";

System.out.println(str1.equals(str2));//true
System.out.println(str1.equals(str3));//flase
```

to ignore character case use `equalsIgnoreCase(String str)`

---

## startsWith(String str) & endsWith(String str):

`startsWith` and `endsWith` are used to check wether the string starts/ends with the given substring:

```java
String str = "Hello, World!";
str.startsWith("H"); // true
str.endsWith("World!"); // true
```

---

## trim():

the `trim` function returns a new copy of the string after trimming the whitespaces for both start and end.

```java
String str = "    Hello   ";
String newStr = str.trim();
System.out.println(str);//     Hello
System.out.println(newStr);// Hello
```

---

## toLowerCase() & toUpperCase():

just simply switches the character case in the string, needs no explanation

---

## replace(String old, String new):

returns a new string after replacing `old` with `new`

```java
String str = "Hello, java";
String newStr = str.replace("java", "world");
System.out.println(str); // Hello, java
System.out.println(newStr); //Hello, world
```

---

## subString():

the `subString` method is used to extract a portion of a string using one of it's 2 overloads:

```java
String.subString(int startIndex) // from startIndex -> end
String.subString(int startIndex, int endIndex) // from startIndex -> endIndex (inclusive)
```

```java
String str = "Hello, java";
System.out.println(str.substring(2));// from 2 -> end = llo, java
System.out.println(str.substring(0, 5)); // 0 -> 5 = Hello
```

---

## indexOf():

the `indexOf` is used to get the first occurrence of the given in the string

```java
String.IndexOf(string target);
String.IndexOf(target, int startingIndex, int endIndex);
```

for example:

```java
String str = "Hello";
int index = str.indexOf('H'); // 0
```

---

## isEmpty():

the `isEmpty` method checks if a string is empty or not:

```java
String str = "some massage";
str.isEmpty(); //false
```

---

## lastIndexOf():

the `lastIndexOf` function is used to find the last occurrence of the given substring in the string and can optionally
be given an index to start looking from:

```java
String.lastIndexOf(String str);
String.lastIndexOf(String str, int fromIndex);
String.lastIndexOf(int chr) //unicode of character
String.lastIndexOf(int chr, int fromIndex)
```

the function returns the index or -1 if the given substring doesn't exist in the string.

```java
String str = "Hello, java";
System.out.println(str.lastIndexOf('a')); // 10
System.out.println(str.lastIndexOf('e', 6)); // 1
System.out.println(str.lastIndexOf('x')); //-1
```

---

## Concat(String str2):

the `Concat` method is used to attach strings together:

```java
"Hello".concat(" World"); //Hello World
```