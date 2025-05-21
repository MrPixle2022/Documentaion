<!-- @format -->

# Set:

a set is an iterable es6 data structure which represents a set of unique values and duplicates are automatically removed

```javascript
const set = new Set([1, 1, 2]);
console.log(set); //{1, 2} the other 1 was removed
set.size; //2
```

---

## add(value):

the `add` adds a new value to the set:

```javascript
set.add(3); // appends 3 to the set
```

---

## has(value):

the `has` checks for the value in the set and returns true if it's found else false:

```javascript
set.has(2);
```

---

## delete(value):

the `delete` removes the given value from the set:

```javascript
set.delete(1);
```

---

## clear():

the `clear` method empties the set and removes all values in it:

```javascript
set.clear();
```
