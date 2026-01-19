<!-- @format -->

# Map:

the `Map` class is a special collection imported from `java.util.Map`, it's used to fold key-value pairs where the value of the key maps to a value.

```java
Map<Key, Value> map = new HashMap<>();
Map<Key, Value> map = new HashTable<>(); //synchronized
```

for example:

```java
Map<String, Integer> http = new HashMap<>();

//key: success, value: 200
http.put("success", 200);
//gets the value by the key
http.get("success"); //200

//a collection of all the values
http.values();
// a collection of all keys
http.keySet();
```
