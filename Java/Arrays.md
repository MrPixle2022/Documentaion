# Arrays:

arrays can are data structures that hold multiple values -often of same type- and uses an index for position which almost always start at `0`, it's also worth noting that an array is a fixed structure meaning you can't add/remove elements from it, for that use `ArrayList<T>`.

define an array in one of the following ways:

```java
type[] name = new type[size];
type[] name = {a, b, c, d};

type[] x;
x = new type[size];
```

note that there is a difference between:

```java
array[index];
// and
array;
```

the first is reference to a value meaning we can essentially replace `array[index]` with the value at index while the later line is the array it self:

```java
String[] names = {"Guy1", "Guy2", "Guy3"};

names[2].toLowerCase();
```

this yields `guy3` since it is simply getting the value at index `2` which is `Guy3` and just calling the `toLowerCase` method on it.

---

## length:

the `length` is property whose value is the size of an array, the last index is always = **length - 1**:

```java
int[] arr = new int[5];

arr.length; //5
```

> [!IMPORTANT]:
> java doesn't support negative index, and will throw a boundary error

---

## Matrices:

a matrix or what is known as `2D arrays` is basically an array of arrays, we can define a matrix as follows:

```java
type[][] name = new type[rows][columns];
type[][] name = {
        {c1, c2, c3, c4}, //row 1
        {c1, c2, c3, c4, c5}, //row 2
}
```

the second example is called a `jagged array` or an array arrays of different lengths.

to access a value in a matrix we access the array containing it then the member:

```java
arr[3][4]; //take the 4rd aray and it's 5th element
```

for instance:

```java
int[][] m = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};
//row 1, column 1 -> 1
m[1][1] = 99; //accessing value of 1 and turning it to 99
```

you can also declare a `3D array` by adding another one inside the columns, so you would have something like:

```java
int[][][] arr = new int[4][4][4]; // a 4 * 4 * 4 matrix
```

---

## Coping arrays:

arrays are passed by reference so we can't just simply use `=` since both variables will be referencing the very same array, instead we can either loop over each individual value or use `arrayCopy` method on the `System` class:

```java
System.arrayCopy(source, startIndex, distentaion, startIndex, length);
```

to the method you pass:

- source: the original array
- startIndex: where to start on the original
- destination: the array to copy to
- startIndex: where to start placing in the destination
- length: how many to copy from original

```java
int[] original = {1,2,3,4,5};
int[] copy = new int[5];

System.arraycopy(original, 0, copy, 0, original.length);
```

---

## toString():

the `toString` is method fond on almost every class and object in java and it's purpose is to simply parse the object into a string value, keep in mind to get human-readable strings use the static **toString** which is found on the `Arrays` class:

```java
int[] arr = {1, 2, 3 ,4 ,5};
System.out.println(Arrays.toString(arr)); //[1, 2, 3, 4, 5]
```