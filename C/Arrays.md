# Arrays:

arrays are zero-indexed and fixed-sized collection of data of the same type, arrays are stored as a contiguous block of memory just like structs.

we can define an array by using `[]` after the name of the variable and the values are defined between `{}` and are separated by commas:

```c
int x[5] = {0};//an array of 5 integers, all initialized to 0
```

arrays are very similar to pointers, as a matter of fact the array name is used as a pointer to the first element of the array and the next element's address just uses the first's address and increments it by the size of each element which is type-dependent.

despite being similar to pointers, they actually have different sizes, the size of an array is dependent on it's size and type, while a pointer is **usually** just `4` bytes.

> [!TIP]
> to get the length of an array divide it's total size by that of an element.

```c
int x[10] = {0};
int length = sizeof(x) / sizeof(x[0]);
```

---

## Updating values:

we can update the value of an element by it's index, for example:

```c
int arr[5] = {1,2,3,4,5};
arr[0] = 2; //{2,2,---}
arr[4]; //5
```

---

## Matrix:

a matrix or a 2D array is an array of arrays.

to create one specify at the very least either the height or width of it, the syntax is as follows:

```c
type name[height][width];
```

for example:

```c
int mat[2][3] = {{1,2,3},{4,5,6}};
// 2 arrays -row- each with 3 elements -column-
```

then we can access the values using `[row][col]`

```c
mat[0][2]; // 3
```

---

## Index:

the index represents the position of an element in the array, it ranges from `0 -> size - 1`, actually:

```c
//array[index]
arr[2];
// also possible -but not recommended-
// index[array]
2[arr];
```

is the same as

```c
*(arr+2);
```

the line above adds two on top of the value of the array which behaves like a pointer to the first element and moves 2 steps, this is gives us the third element.

to give more clarity:

```c
int arr[5] = {1,2,3,4,5};
int* ptr = arr;

arr[0] == *(arr+0) == *ptr == 0[arr];
```

---

## Elements offset:

if we have for example an array of structs, each with 3 integers and we have an array of lets say 3, the offset can be calculated as follows:

```text
    n1  n2  n3
s1   0   4   8
s2  12  16  20
s3  24  28  32
```

---

## Arrays casting:

let's assume we have a struct called `coordinate` which has 3 integers, and we have an array of that struct.

```c
struct coordinate{
    int x;
    int y;
    int z;
};

struct coordinate c[3] = {{1,2,3},{4,5,6},{7,8,9}};
```

and since arrays are like pointers -in most part- and since structs are contiguous in memory we can actually cast this `c` array into an array of `integers` as follows:

```c
int *ptr = (int *)c;
ptr[0]; // 1
ptr[1]; // 2
ptr[2]; // 3
ptr[3]; // 4
```

the number of elements in `ptr` = elements per structs * number of structs so in this case 9

---

## Array decay:

an array name may decay into pointer, meaning then name becomes just a pointer to it's first element.

```c
int arr[5] = {0};
int *ptr = arr;          // 'arr' decays to 'int*'
int value = *(arr + 2);  // 'arr' decays to 'int*'
```

also they decay when passed to functions.

```c
void core_utils_func(int core_utilization[]) {
    printf("%zu", sizeof(core_utilization)); //4
}

int x[10] = {0}; //sizeof x == 40
core_utils_func(x); // 4, because x decays to int*
```

but when doesn't it decay?, well in the following cases:

- sizeof -> returns the size of the entire array, not the pointer
- & -> returns the location of the entire array, &array is a pointer, just for the entire array not only the first element

for example:

```c
int (*)[5] // a pointer to an **array** of 5 integers
```

- initialization -> on initializing an array it's allocated fully in memory and doesn't decay into a pointer
