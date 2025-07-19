# ArrayList:

arrayLists are a collection of data whose length is dynamic, arrayLists are included in the `System.Collections` namespace and can hold data of any type as it stores all as `object` which may cause some performance issues with boxing and boxing values.

```csharp
using System.Collections;

// array list is an array whose size is dynamic requires(System.Collection &.Generic)
ArrayList aList = new ArrayList();

var len = aList.Count; // number of elements in the collection

var cup = aList.Capacity; //number of containable elements before resizing is required
```

the `ArrayList` extends the `ICollection` interface and can copy content of other non-generic `ICollection` types like:

1. Array
1. ArrayList
1. Queue
1. Stack
1. HashTable

```csharp
int[] x = { 1, 2, 3, 4 };
// using values of x as the initial data in the aList
ArrayList aList = new ArrayList(x);
```

note you can optionally pass a integer for the capacity to the constructor and it will be used as the initial capacity.

```csharp
ArrayList arrayList = new ArrayList(10);
var capacity = arrayList.Capacity; //10, but could change if count > 10
```

---

## Add(object v):

adds the given values -of any type- to the end of the arrayList.

```csharp
aList.Add(3);
```

---

## AddRange(ICollection c):

the `AddRange` method -**shallow**- copies the values of the ICollection c into the current ArrayList.

```csharp
aList.AddRange(new object[] { 1, 2, 3, 4 }); //-> aList = {1, 2, 3, 4}
```

---

## Insert(int index, object value):

the `Insert` method adds the value at the given index.

```csharp
aList.Insert(1, 4); //insert 4 at index 1
```

---

## InsertRange(int index, ICollection c):

**shallow** copies the `c` into the arrayList starting at `index`.

```csharp
aList.InsertRange(0, new int[] {1,2,3,4});
```

---

## Remove(object value):

the `Remove` method removes the first occurrence of the given value.

```csharp
aList.Remove(2); //removes the first 2 in the array list
```

---

## RemoveAt(int index):

the `RemoveAt` method removes the element at the given index.

```csharp
aList.RemoveAt(3); //removes the element at index 3
```

---

## RemoveRange(int index, int count):

remove `count` number of elements starting from `index`:

```csharp
aList.RemoveRange(0, 2); //remove 2 elements starting from 0
```

---

## IndexOf(object value):

the `IndexOf` method returns the index of the first occurrence of the given value.

if the value is not found it returns `-1`

```csharp
aList.IndexOf(1); // gets the index of '1';
```

---

## Reverse():

reverses the order of the elements in the arrayList.

```csharp
aList.Reverse();
```

---

## Clear():

empties the arrayList.

```csharp
aList.Clear(); //removes all elements
```
