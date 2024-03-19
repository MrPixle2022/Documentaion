# Objects
---
object are used to store special data that has a name [ **key** ] and a [ **value** ]

#### creating an object:
it's a simple operation to do so,  
objects can hold any data like

- strings
- numbers
- booleans
- functions
- other objects

```javascript
let obj = {
    key1: "value1",
    key2: 2,
    key3: true,
    key4: function(){console.log('inside an object')},
    key5: {data1: "value", data2:"value"}
}
```


---
#### access data in an object:
there are two ways to access a data in an object
first way is:

```javascript
let obj = {
    firstName: "amr",
    lastName: "yasser",
}

console.log(obj.firstName); //amr
console.log(obj.lastName); //yasser
```

second way is:
```javascript
let obj = {
    firstName: "amr",
    lastName: "yasser",
}

console.log(obj["firstName"]); //amr
console.log(obj.["lastName"]); //yasser
```
the second way is used when the key isn't accessible due to it's name like if the key name has a space it must be called like this

```javascript
let obj = {
    "first name": "amr",
    lastName: "yasser",
    callName: () => console.log(`name: is amr yasser`)
}

console.log(obj["first name"]); //amr
obj.callName(); //name: is amr yasser
```


> [!WARNING]
> if the key doesn't exist in the object the key will be created and given the value of [ **undefined** ] by default unless you assign it a value

```javascript
let obj = {
    firstName: "amr",
    lastName: "yasser",
}

console.log(obj.age); //undefined
obj.mark = 5;
console.log(obj.mark) //5
```

---
#### deleting a key from the object:
just use the `delete` keyword


```javascript
let obj = {
    firstName: "amr",
    lastName: "yasser",
}

delete obj.firstName
console.log(obj.firstName) //undefined
```