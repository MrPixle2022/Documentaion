# Array Methods
---
navigation:
- [pop](#pop)
- [shift](#shift)
- [includes](#includestarget)
- [concat](#concatsecondarray)
- [push](#pushvalue)
- [unshift](#unshiftvalue)
- [slice](#slicestart-end)
- [forEach](#foreachcallbackfunction)
- [map](#map-callbackfunction)
- [reduce](#reducereducerfunction-initilavalue)


# toString:
```javascript
let arr = [1,2,3,4,5];
let newArr = arr.toString();
console.log(newArr); //"1,2,3,4,5"
```
the [**toString**] returns a string version of the array each value is separated via a comma

---

# pop:
```javascript
let arr = [1,2,3,4,5];
console.log(arr.pop());
console.log(arr); //[1,2,3,4]
```
the [**pop**] removes the last element in the array and returns it

---

# shift:
```javascript
let arr = [1,2,3,4,5];
console.log(arr.shift());
console.log(arr); //[2,3,4,5]
```
the [**shift**] removes the first element in the array and returns it

---

# includes(target):
```javascript
let arr = [1,2,3,4,5];
console.log(arr.includes(1)); //true
```
the [**includes**] checks if the target exist in the array

---

# concat(secondArray):
```javascript
let arr = [1,2];
let secArr = [3,4];
let newArr = arr.concat(secArr);
console.log(newArr); //[1,2,3,4]
```
the [**concat**] method takes an array as an argument and returns a new array by combining the the array with the secondArray

---

# push(value):
```javascript
let arr = [2,3,4,5];
arr.push(1)
console.log(arr); //[2,3,4,5,1];
```
the [**push**] method returns the new length of the array after it takes a value as an parameter puts it at the end of an array

---

# unshift(value):
```javascript
let arr = [2,3,4];
let newArr = arr.unshift(1);
console.log(newArr); //[1,2,3,4]
```
the [**unshift**] method returns the new length of the array after it takes a value as an parameter puts it at the start of an array

---

#### slice(start, end):
the [**slice**] method takes returns a section in an array between `start` and `end`, both are excluded.

---

# sort(sortFunc):
the [**sort**] method takes a comparison function which it uses to mutate the array, the comparison function  takes two params `a, b` and returns:
- negative value: indicates that `a` must be before `b`
- zero: indicates that `a` is equal to `b`
- positive value: indicates that `b` must be before `a`

---

# forEach(callbackFunction):
> [!IMPORTANT]
> the forEach overwrites the array
```javascript
let arr = [2,3,4];
arr.forEach((x)=> x+1);
console.log(arr); //[2,3,4,5]
```
the [**forEach**] method loops over every element in the array and applies the callback function to it

the callback function can take some values:

|param  |usage  |necessity|
|:---------:|:-------:| :----:|
|value     |the current value| needed|
|index    | the index of the current value|optional|
|array    |  the array the foreach is being invoked on| optional|

---


# map (callbackFunction):
```javascript
let arr = [2,3,4];
let newArr = arr.map((x)=> x+1);
console.log(newArr); //[2,3,4,5]
```
the [**map**] returns a version of the array after applying the call back function to each element

---

# reduce(reducerFunction, initialValue):
```javascript
let arr = [1,2,3,4,5];
let res = arr.reduce((prev, cur)=> prev+cur, 0)
console.log(res) //15
```
the [**reduce**] method calls the reducer function on all the element in the array until it's only one value and the returns it, on each element it passes this element as the current value to the reducer function and uses, the previous value is the one returned when it was on the previous element, the initial value is the value passed as the previous on the first element

| parameter |usage|need case|
|:---------:|:---------:|:---------:|
|previous value|the previous value|   needed      |
|current value|the current value|needed|
|current index|the index of the current value|optional|
|array|the array |    optional     |

---
