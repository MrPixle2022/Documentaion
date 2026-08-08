# Arrays

arrays in `go` have a fixed length and all it's element must be of a set type:

```go
var a [5]int //5 elements all set to 0
fmt.Println("emp:", a)
```

we can access the data using `[index]`, also there is a short format for the array declaration:

```go
b := [5]int{1, 2, 3, 4, 5}
```

we can also ask the compiler to count the element for us:

```go
c = [...]int{1, 2, 3, 4, 5}
fmt.Println("dcl:", b)
```

and we can define a matrix:

```go
//[rows][columns]type
var twoD [2][3]int
twoD = [2][3]int{
    {1, 2, 3},
    {1, 2, 3},
}
```

we can ge the length of the array using the `len` function and passing it the array.

---

## Slices

a `slice` is an array-wrapper that allows for dynamically-sized arrays, it has a `length` and a `capacity`, should the length be bigger then the capacity the slice would then be re-allocated.

slices can be made using the array syntax and omitting the `size` or using the `make` function:

```go
slice := []int{1,2,3,4,5}; //a slice of integers (dynamic array, array wrapper)
//make(type, length, capacity)
slice2 := make([]int, 5, 10) //make creates a slice with specified length and capacity

slice = append(slice, 6) //append adds an element to the end of the slice and returns a new slice (if capacity is exceeded, it creates a new underlying array)
slice = append(slice, slice2...) //spreads the element and appends them to the end
fmt.Println("Slice: Length: ", len(slice), "Capacity: ", cap(slice))
```

please not that an un-initialized slice is `nil` and it's length is `0`, also slices are accessed as arrays are using `[index]`.

slices can be copied using `copy`:

```go
slice1 := []int {1,2,3,4};
slice2 := make([int], 4, 4);

copy(slice2, slice1);
```

also we can use the `slice` operator to slice a slice:

```go
slice1[1:]; //from 1 -> len (exclusive)
slice1[:3]; //from 0 -> 3 (exclusive)
slice[1:4]; //from 1 -> 4 (exclusive)
slice[:]; //all of it
```

this syntax can also be used on arrays to make a slice of them, just note that they share the data being sliced, hence altering one affects both, but note that the indexes don't necessarily match between either, the first element in the slice can be the 3rd in the array.

we can have a multi-dimensional slice, in this case the inner slices can be of **variable length**.

please also note that since slices are allocated they are passed by reference not value.

---

## Maps

a map is a dictionary like structure storing key-value pairs.

defined using the `map` type or the `make` function.

```go
var myMap map[string]uint8 = make(map[string]uint8)
fmt.Println("Map: ", myMap, " Length: ", len(myMap));

var myMap2 map[string]uint8 = map[string]uint8{"one": 1, "two": 2, "three": 3}
fmt.Println("Map2: ", myMap2, " Length: ", len(myMap2));
fmt.Println("Value for key 'two': ", myMap2["two"]);
//! be careful as a non-existent key will return the default of the key type
var val, exists = myMap2["four"]
fmt.Println("Val", val, "Exists", exists);

//removes by reference, no need to reassign
delete(myMap2, "two") //delete removes a key from the map

//clear the map
clear(myMap)

//access keys
myVal, ok := myMap2["one"];

//checks equality
n := map[string]int{"foo": 1, "bar": 2}
    fmt.Println("map:", n)
n2 := map[string]int{"foo": 1, "bar": 2}
if maps.Equal(n, n2) {
    fmt.Println("n == n2")
}
```

> [!TIP]
> Only slices, maps, channels, function are passed by reference, with `slices` sharing the `header` aka it's pointer, length and capacity.

modifying the content of the slice will affect both but appending will only affect the slice in the array.
