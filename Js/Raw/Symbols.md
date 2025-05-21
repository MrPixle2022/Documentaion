<!-- @format -->

# Symbol:

symbols are a unique and immutable primitive -doesn't require new- data type added in es6, and it's used to identify object properties to avoid name conflicts, they are guaranteed to be unique

```javascript
const symbol = Symbol("this is a symbol");

console.log(symbol); //Symbol(this is a symbol)
```

note that even if the same string is used the two symbols will be different 100%

---

## using symbols:

symbols can be used in objects as keys to uniquely define a key value pair even if two or more symbols share the same string

```javascript
const id1 = Symbol("id");
const id2 = Symbol("id");

const user = {};
user[id1] = "hey it's an id1"; // both refer to id, but neither is equal to one another
user[id2] = "hey it's an id2"; // both refer to id, but neither is equal to one another

console.log(user);
```
