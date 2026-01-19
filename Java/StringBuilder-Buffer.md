<!-- @format -->

# String builder and string buffer:

the classes of `StringBuilder` and `StringBuffer` are used to create mutable strings in java, they are very very similar but have a slight difference between them

`StringBuffer` is thread safe, while `StringBuilder` is not.

---

## StringBuffer (both have the same methods):

```java
StringBuffer sb = new StringBuffer("MutableData");

//the capacity of the buffer
sb.capacity();
//how long is the string
sb.length();
//append strings
sb.append(" in buffer");
//remove char at index
sp.deleteCharAt(0);
//insert string at index
sp.insert(0, "this is ");
//set the length of the string, overflow are nulled
sb.setLength(12);
```
