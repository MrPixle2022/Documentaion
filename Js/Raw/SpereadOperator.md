<!-- @format -->

# Spread operator:

the spread operator is used to make a **shallow** copy of iterables and objects, by spreading the values into elements, this can be done to arrays and objects for example.

```javascript
// "..." the spread operator
...iterable
```

in javascript objects are shared by reference not value, meaning:

```javascript
const obj1 = { name: "obj1" };
const obj2 = obj1;
```

both `obj1` and `obj2` refer to the very same object, so a change on one is a change to both, however using the spread operator can help avoid this:

```javascript
const obj1 = { name: "obj1" };
const obj2 = { ...obj1 };
```

now both are different objects, however they are a **shallow** copy, meaning that nested objects will be shared by reference:

```javascript
const o1 = { o2: { name: "o2" } };
const o3 = { ...o1 };
```

in this example `o1` and `o2` are two different objects but the `.o2` in both is the very same object

---

## With functions:

you can use a spread operator to easily assign values of params:

```javascript
function spread4(p1, p2, p3, p4) {
	console.log("p1 ", p1, " p2 ", p2, " p3 ", p3, " p4 ", p4);
}

// p1 =1, p2 =2, p3 =3, p4 =4
spread4(...[1, 2, 3, 4]);
```

---

## With arrays:

with arrays the spread operator you can spread the values of an array into another one or join two arrays without concatenation:

```javascript
const arr1 = [1, 2, 3, 4];
const arr2 = [...arr1, 5, 6, 7, 8];
//[1,2,3,4,5,6,7,8]
console.log(arr2);
```

---

## With objects:

the spread operator can be used to create shallow copies of objects

```javascript
const obj1 = { name: "obj1" };
const obj2 = { ...obj1 };
```
