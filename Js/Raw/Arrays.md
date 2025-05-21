<!-- @format -->

# Array Methods

---

navigation:

- [Arrays](#arrays)
- [Accessing values:](#accessing-values)
- [toString](#tostring)
- [pop](#pop)
- [shift](#shift)
- [includes](#includestarget)
- [concat](#concatsecondarray)
- [push](#pushvalue)
- [unshift](#unshiftvalue)
- [slice](#slicestart-end)
- [splice](#splicestart-end)
- [sort](#sortsortfunc)
- [find](#findcallback)
- [findIndex](#findindexcallback)
- [forEach](#foreachcallbackfunction)
- [map](#map-callbackfunction)
- [reduce](#reducereducerfunction-initialvalue)
- [every](#everycallback)
- [some](#somecallback)

---

## Arrays

arrays are a data structure allowing the storage of a list of values -doesn't have to be of same type- whose indexing starts at `0`, meaning the first element's index is 0.

array are defined by using `[]` and their each element is separated by `,`

```javascript
const baseArr = [0, 1, 2, 3, 4];
```

> [!TIP] Arrays can be nested in one another, and also can hold functions, etc..

---

## Accessing values:

to access a value in an array based on it's index use `arrayName[index]`

```javascript
console.log(baseArr[0]); // element at index 0 -> 0 -the first-
```

> [!IMPORTANT] js unlike -unlike other languages- doesn't accept negative values to access index, but you can using `arrayName.at(-1)` for example.

```javascript
console.log(baseArr.at(-1)); // element at index length -1 -> 4 -the last-
```

---

## toString():

the `toString` turns the array into a string, it's the same as using `arr.join()` with no params

```javascript
let arr = [1, 2, 3, 4, 5];
let newArr = arr.toString();
console.log(newArr); //"1,2,3,4,5"
```

---

## pop():

the `pop` method on an array removes the last element from the array and returns it, **it modifies the array**

```javascript
let arr = [1, 2, 3, 4, 5];
console.log(arr.pop()); //5
console.log(arr); //[1,2,3,4]
```

---

## shift():

the `shift` removes the first element in the array and returns it, **it modifies the array**

```javascript
let arr = [1, 2, 3, 4, 5];
console.log(arr.shift()); //1
console.log(arr); //[2,3,4,5]
```

---

## includes(target):

the `includes` method checks for the given target in the array and returns `true` if found, else `false`

```javascript
let arr = [1, 2, 3, 4, 5];
console.log(arr.includes(1)); //true
```

---

## concat(secondArray):

the `concat` method work similar like the `string.concat`, it merges this array with the given array and returns the result

```javascript
let arr = [1, 2];
let secArr = [3, 4];
let newArr = arr.concat(secArr);
console.log(newArr); //[1,2,3,4]
```

---

## push(value):

the `push` adds a new element to the array at the end, this method returns the new length of the array after the insertion

```javascript
let arr = [2, 3, 4, 5];
arr.push(1);
console.log(arr); //[2,3,4,5,1];
```

---

## unshift(value):

the `unshift` method appends the given `value` to the beginning of the array, like `push` it returns the new length of the array after the insertion

```javascript
let arr = [2, 3, 4];
let newLength = arr.unshift(1);
console.log(newLength); //4
```

---

## slice(start, end):

the `slice` method returns a part of an array, using a `start` index and an `end` index -which is excluded- it returns the part.

```javascript
const newArr = [1, 1, 1, 3, 4, 2];
console.log(newArr.slice(0, 3)); // [1, ,1, 1]
console.log(newArr); //[1,1,1,3,4,2]
```

---

## splice(start, end):

the `splice` is similar to `slice` but this time it affects the array by removing the selected parts, again the end is excluded.

```javascript
let arr = [1, 2, 3, 4, 5];
//this exceeds the length but won't cause a problem
console.log(arr.splice(0, 10)); // [1, 2,3 ,4,5]
console.log(arr); //[]
```

it also can be used to replace elements, by providing a third argument it will erase the defined range and insert the third argument instead

```javascript
let arr = [1, 2, 3, 4, 5];

console.log(arr.splice(0, 1, 0.5)); //[1]
console.log(arr); // [0.5, 2,3,4,5]
```

> [!NOTE] you can invert the start and end for example splice(1,0) this will start from index 1 -> 0 excluding 0 so it will remove only the second element

---

## sort(sortFunc):

the `sort` method allows you to sort an array using a function, this function takes two value `a` -the current value- and the `b` which is the value next to the current using the return value of this function to define how to sort, if the function returns:

- negative value: indicates that `a` must be before `b`
- zero: indicates that `a` is equal to `b`
- positive value: indicates that `b` must be before `a`

```javascript
const newArr = [1, 2, 3, 4, 5, 6, 7];
console.log(newArr.slice(0, 3));
console.log(newArr.sort((a, b) => b - a)); // [7, 6, 5, 4, 3,2, 1]
```

---

## find(callback):

the `find` method allows you to find an element in an array based on the condition in the callback, the callback takes the current value and it's index as params

```javascript
const mockUsers = [
	{
		id: 0,
		username: "amr yasser",
		displayName: "mr_pixel",
	},
	{
		id: 1,
		username: "ammar tareq",
		displayName: "alpha_1",
	},
	{
		id: 2,
		username: "mohammed abdelmaqsood",
		displayName: "alpha_2",
	},
];

console.log(mockUsers.find((user) => user.id === 0)); //{id: 0, username: "amr yasser", displayName: "mr_pixel"}
```

---

## findIndex(callback):

the `findIndex` is similar to the `find` but instead it return the index instead of the actual element, if not found it returns `-1`, it takes a callback which in turn takes the `value` the current value & `index` the current index

```javascript
const newArr = [1, 2, 3, 4, 5, 6, 7];
let index = newArr.findIndex((val, index) => val ** 2 === 36);
console.log(index); //5
```

---

## forEach(callbackFunction):

the `forEach` method runs on an array, the callback runs on each and every element, the callback takes:

| param |             usage              | necessity |
| :---: | :----------------------------: | :-------: |
| value |       the current value        |  needed   |
| index | the index of the current value | optional  |
| array |    the array original array    | optional  |

```javascript
let arr = [2, 3, 4];
arr.forEach((x) => console.log(x)); //2, 3, 4
```

---

## map (callbackFunction):

the `map` method takes a callback and applies this callback to each and every element in the array, the callback takes the current value, index & the original array, the array returned isn't the original

```javascript
const newArr = [1, 2, 3, 4, 5, 6, 7];
console.log(newArr.map((value, index, arr) => value * 2)); //[2,4,6,8,--]
```

---

## reduce(reducerFunction, initialValue):

the `reducer` method allows you to reduce an array into a single value, by using a reducer function to run an operation on the entire array it returns a single value of any type, the reducer method can take:

|   parameter    |             usage              | need case |
| :------------: | :----------------------------: | :-------: |
| previous value |       the previous value       |  needed   |
| current value  |       the current value        |  needed   |
| current index  | the index of the current value | optional  |
|     array      |       the original array       | optional  |

```javascript
let arr = [1, 2, 3, 4, 5];

console.log(arr.reduce((prev, curr, cIndex, array) => prev + curr, 0)); //15
```

---

## every(callback):

the `every` returns true if all elements in the array passes the callback check and false if one doesn't

the callback as usual takes value, current index, and the array

```javascript
const arr = [1, 2, 3, 5, 5];

console.log(arr.every((val, index, arr) => val % 2 !== 0)); // false
```

---

## some(callback):

the `some` is exactly like every but checks if at least one element does:

```javascript
const arr = [1, 2, 3, 5, 5];

console.log(arr.some((val, index, arr) => val % 2 !== 0));
```
