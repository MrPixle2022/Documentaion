# ICollection:

the `ICollection` interface is the shared base by the native collections like:

-   `Array`
-   `List<T>`
-   `ArrayList`
-   `Queue<T>`
-   `Stack<T>`

etc ...

it has some useful methods -that are shared between all those data-structures-.

---

## All<T>(Func<T, bool> predicate):

the `All` method returns a **boolean**, it checks if all elements of the collection meet a certain condition which is defined by the `predicate` callback.

```csharp
bool allAreEven = newSum.All(x => x % 2 == 0);
```

---

## Any<T>(Func<T, bool> predicate):

the `Any` method returns a **boolean**, it checks if **any** element in the collection meets the predicate.

```csharp
//it checks if any element is even
bool anyAreEven = newSum.Any(x => x % 2 == 0);
```

also it can be used with no params, in this case it will check if the collection has any actual elements.

---

## Where(Func<int, bool> callback):

the `Where` method filters the collection by the result of the `callback`, true means included, else false.

the `Where` returns an **IEnumerable** that can be converted into a list using the `.ToList<T>()` method.

```csharp
//extract all even numbers
List<int> evens = ints.Where(x => x % 2 == 0).ToList();
```

---

## Select<T, K>(Func<T, K> mapper):

the `Select` method returns an **IEnumerable**, it maps the callback to the collection, it runs the method on every element and returns the result.

```csharp
var doubleNumbers = ints.Select(x => x * 2).ToList();
```

---

## Zip<T, K, S>(IEnumerable<K> second, Func<T, K, S> callback):

the `Zip` method returns an **IEnumerable**, it combines two -IEnumerable- collections into one using the `callback`, each time it takes an element from this collection and the counterpart -by index- from `second` and runs the callback on them and returns the result.

```csharp
 var result = list1.Zip( //Runs the callback on both methods combining them into one
list2, //the second list
// fl1 -> from list1
// fl2 -> from list2
(fl1, fl2) => fl1 + fl2;)
```

---

## Aggregate<T>(Func<T,T,T> callback):

the `Aggregate` method returns an **IEnumerable**, it aggregates -reduces- the collection into a single value of type `T`.

on each loop it takes the value of the previous run, the current value in the collection, and returns a value that ill be used as the previous in the next call.

```csharp
var sum = newSum.Aggregate((prev, curr) => prev + curr);
```

---

## Distinct<T>():

the `Distinct` method returns an **IEnumerable**, it returns a new version of the collection after removing any duplicates.

```csharp
var onlyDistinct = newSum.Distinct();
```

---

## Except<T>(IEnumerable<T> second):

the `Except` method returns an **IEnumerable**, it returns a collection of the elements found in this collection that don't exist in `second`.

```csharp
var nList2 = new List<int> { 2 };
var exceptResult = newSum.Except(nList2); //all but 2
```

---

## Intersect<T>(IEnumerable<T> second):

the `Intersect` method returns an **IEnumerable**, it returns a collection of the elements found in both collections.

```csharp
var intersectResult = newSum.Intersect(nList2);
```
