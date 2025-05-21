<!-- @format -->

# Maps:

maps are a built in iterable data structure add with es6 that allows the storage of key value pairs -like objects- where both the key and value can be of any type

```javascript
const map1 = new Map();
```

and to read the size

```javascript
console.log(map1.size);
```

---

## set(key, value)

the `set` is used to insert a new value with the given key in the map, if the key exists already it updates it's value:

```javascript
//key (true) value(false)
map1.set(true, false);
```

---

## get(key):

the `get` method is used to real the value of the given key:

```javascript
console.log(map1.get(true)); //false
```

---

## has(key):

the `has` is used to check if the map has this key:

```javascript
console.log(map1.has(true)); //true
console.log(map1.has(false)); //false
```

---

## entries():

the `entries` method returns all the key value pairs in the map

```javascript
console.log(map1.entries()); //{[true, false]}
```

---

## keys():

the `keys` returns an iterable object containing all keys in the map

```javascript
console.log(map1.keys()); //{true}
```

---

## values():

the `values` method returns all values in the map:

```javascript
map1.values(); // {false}
```

---

## delete(key):

the `delete` method is used to delete the key and it's value form the map

```javascript
map1.delete(true);
```

---

## Iterating over Maps:

we can iterate over the `map` using a for of loop and destructure the key and value:

```javascript
const map1 = new Map();

map1.set("key1", 1);
map1.set("key2", 2);
map1.set("key3", 3);
map1.set("key4", 4);

for (const [key, value] of map1) {
	console.log(key);
}
```

another option is looping over `map.keys()` or `map.values()`
