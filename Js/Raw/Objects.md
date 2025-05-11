<!-- @format -->

# Objects

---

object are used to store special data that has a name [ **key** ] and a [ **value** ]

## Creating an object:

an object is defined by `{}`, on an object you store proprieties as key-value pairs, a key can hold a:

- strings
- number
- boolean
- function -called **methods**`
- other object

```javascript
let obj = {
	key1: "value1",
	key2: 2,
	key3: true,
	key4: function () {
		console.log("inside an object");
	},
	key5: { data1: "value", data2: "value" },
};
```

note that fields which value is same as their name can use their name once for key & value like for example:

```javascript
let key1 = 0;
let key2 = "string";
let key3 = true;
let key4 = function () {
	console.log("this is an object");
};

let newObj = {
	key1,
	key2,
	key3,
	key4,
};
/*
newObj= {
  key1: key1,
  key2: key2,---
}
*/
console.log(newObj);
```

also object methods can use their name as well for definition:

```javascript
// newObj = {objetFunction: () => "hello")}
let newObj = {
	objectFunction() {
		return "hello";
	},
};
```

> [!NOTE] things like arrays are considered of type object

---

## Accessing and updating properties:

reading a property of an object can be done in one of two ways, the usual `object.key`:

```javascript
let obj = {
	firstName: "amr",
	lastName: "yasser",
};

console.log(obj.firstName); //amr
console.log(obj.lastName); //yasser
```

or the `object['field']`, this can be used optionally for normal keys or mandatory for keys defined as string like `"key": value`

```javascript
let obj = {
    firstName: "amr",
    lastName: "yasser",
}

console.log(obj["firstName"]); //amr
console.log(obj.["lastName"]); //yasser
```

the second way using strings to define properties whose name may cause an error cause of spaces ,etc...:

```javascript
let obj = {
	"first name": "amr",
	lastName: "yasser",
};

console.log(obj["first name"]); //amr
```

for updating or even creating more keys later in the file use `object.key = value` to update an existing key or create a new propriety name `key` with value of `value`

> [!WARNING] if the key doesn't exist in the object the key will be created and given the value of [ **undefined** ] by default unless you assign it a value

```javascript
let obj = {
	firstName: "amr",
	lastName: "yasser",
};

console.log(obj.age); //undefined
obj.mark = 5;
console.log(obj.mark); //5
```

> [!IMPORTANT] when using the dot notation trying to read non-existing properties you get value `undefined` while bracket `["key"]` notation throws a reference error

---

## Deleting a key from the object:

using the `delete` followed by the field like

```javascript
let obj = {
	firstName: "amr",
	lastName: "yasser",
};

delete obj.firstName;
console.log(obj.firstName); //undefined
```

will remove the key from the object
