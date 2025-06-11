<!-- @format -->

# Arrays:

defining arrays in c# is a bit different than other language, you usually have to define the type, use the `new` keyword and use `{}` instead of `[]`.

the syntax is:

```csharp
//type[] name = new type[length] {---};
//type[] name = {---} //length is dynamic;
```

```csharp
int[] faveNums = { 0, 1, 2, 3, 4, 5 }; //dynamic length
int[] fixedArray = new int[3]; //[0, 0, 0]s, static length

faveNums[2];
//index: 2 -> 2
```

> [!IMPORTANT] on fixed arrays `Append` and `Prepend` don't work.

> [!IMPORTANT] When using var as a type all elements must be of same type.

---

## Matrixes:

we can define a multi-dimensional array using `[,]` in the type and defining rows and columns:

```csharp
//a matrix, this matrix is [2rows(child arrays),2columns(content of child arrays)]
int[,] matrix = new int[2, 2] {
{ 1, 2 }, //<row0>
{ 4, 5, } };//<row1>
//matrix(0, 1) -> 0 is [1,2], 1 is [2]
System.Console.WriteLine(matrix[0, 1]);
```

---

## Sort(array):

the `Sort` is an array static method that can sort an array.

```csharp
int[] array1 = { 1, 2, 3, 4 };
Array.Sort(array1);
```

---

## Reverse(array):

the `Reverse` is a static array method that reverses the order of an array.

```csharp
int[] array1 = { 1, 2, 3, 4 };
Array.Reverse(array1);
```

---

## IndexOf(array, element):

the `IndexOf` is a static method that returns the index of an element in the given array, if not found it returns `-1`.

```csharp
int[] array1 = { 1, 2, 3, 4 };
Array.IndexOf(array1, 1); //0
```

---

## SetValue(value, index):

the `SetValue` is a method that updates the value at `index`.

```csharp
int[] array1 = { 1, 2, 3, 4 };
array1.SetValue(10, array1.Length - 1);// 4 -> 10
```

---

## Copy(source, destination, number):

the `Copy` is a static method used to copy a portion of an array onto another one.

```csharp
int[] array1 = { 1, 2, 3, 4 };
int[] array2 = new int[array1.Length];
Array.Copy(array1, array2, 1); //copy array1 onto array2 taking the first -1- element -> {1, 0, 0, 0,}
```

---

## Fill(array, value):

the `Fill` is a static method that can fill an array with `value`.

```csharp

int[] array3 = new int[4];
Array.Fill(array3, 10);//array3: [10, 10, 10, 10]
```
