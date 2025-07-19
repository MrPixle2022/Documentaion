# LINQ:

c# linq has a set of useful extension methods that help with extracting & filtering data.

most of these methods return `IEnumerable`s so they can be chained on one another

---

## Where<T>:

the `Where` method is used to filter an enumerable based on a predicate method.

```csharp
// where is not static method this is just to demonstrate
IEnumerable<T>.Where<T>(Func<T, bool> predicate)
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// Where<T>(Func<T, bool> predicate) -> IEnumerable<T>
collection.Where(num => num > 2); // [3 -> 10]
```

---

## OfType<T>:

the `OfType` method is used to only include data that are of type `T` in the enumerable.

```csharp
// T can be object while K a string for example
IEnumerable<T>.OfType<K>(); // returns IEnumerable<K>
```

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];
// only include int -> numbers bigger than 2
collection.OfType<int>().Where(num => num > 2)
```

---

## Skip<T>:

the `Skip` is used to `n` number of elements from the start of the enumerable.

```csharp
IEnumerable<T>.Skip<T>(int n); //IEnumerable<T>
```

for example we can use it like:

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];
// [4 -> 10]
collection.OfType<int>().Skip(3);
```

---

## Take<int>:

the `Take` method is the opposite of `Skip`, where it only includes `n` number of elements from the start of the enumerable.

```csharp
IEnumerable<T>.Take<T>(int n); //IEnumerable<T>
```

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

// [1 -> 2]
collection.OfType<int>().Take(2);
```

---

## SkipLast<T>:

the `SkipLast` -just like `Skip`- excludes `n` number of elements from the **end** of the enumerable.

```csharp
IEnumerable<T>.SkipLast<T>(int n); //IEnumerable<T>
```

for example:

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

collection.OfType<int>().SkipLast(2);
collection.OfType<int>().TakeLast(2).Dump("Take Last");
```

---

## TakeLast<T>:

the `TakeLast` method is the opposite of `SkipLast` where it includes `n` number of element but from the **end** of the enumerable.

```csharp
IEnumerable<T>.TakeLast<T>(int n); // IEnumerable<T>
```

```csharp
using Dumpify;

IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

collection.OfType<int>().TakeLast(2);
```

---

## SelectWhite<T>:

the `SkipWhile` includes the elements of the enumerable as long as they meet the predicate.

```csharp
IEnumerable<T>.SkipWhile<T>(Func<T, bool> predicate); // IEnumerable<T>
```

for example:

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

collection.OfType<int>().SkipWhile(x => x < 5);
```

---

## TakeWhile<T>:

the `TakeWhile` method is the opposite of `SkipWhile`, it only includes the elements when they meet the predicate.

```csharp
IEnumerable<T>.TakeWhile<T>(Func<T, bool> predicate); // IEnumerable<T>
```

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

collection.OfType<int>().TakeWhile(x => x < 5)
```

---

## Select<T, K>:

the `Select` method is used to project elements or transform them. it takes a callback method.

```csharp
IEnumerable<T>.Select<T, K>(Func<T, K> mapper); // IEnumerable<K>
// int -> the index
IEnumerable<T>.Select<T, K>(Func<T, int, K> mapper); // IEnumerable<K>
```

for example:

```csharp
IEnumerable<object> collection = [1, "one", 2, "two", 3, "three", 4, 5, 6, 7, 8, 9, 10];

collection.Select<object, string?>(x => x.ToString());
// with index
collection.Select((x, index) => $"{index} -> {x}");
```

---

## SelectMany<T, K>:

the `SelectMany` is used to flatten nested sequences into a single one or an enumerable.

it will take each element and transform it into a sequence then merge all into one.

```csharp
IEnumerable<T>.SelectMany<T, K>(Func<T, IEnumerable<K>> mapper); //IEnumerable<K>
// int -> index of element in the original sequence
IEnumerable<T>.SelectMany<T, K>(Func<T, int, IEnumerable<K>> mapper); //IEnumerable<K>
```

```csharp
IEnumerable<List<int>> collection =
[
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
];

collection.SelectMany(x => x); // 1 -> 9
collection.SelectMany((x, index) => x.Select((num) => $"{index}:{num}"));// 0: 1 -> 3, 1: 4 -> 6,
```

---

## Cast<K>:

the `Cast` methods is used to cast all elements of the sequence into type `K`.

```csharp
IEnumerable<T>.Cast<K>(); // IEnumerable<K>
```

```csharp
IEnumerable<object> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Cast<int>();
```

---

## Chunk<T>:

the `Chunk` method is used to split the sequence into multiple sequences of size `n`.

```csharp
IEnumerable<T>.Chunk<T>(int n); // IEnumerable<T[]>
```

```csharp
IEnumerable<object> collection = [1, 2, 3, 4, 5, 6, 7, 8];
collection.Chunk(3); // [[1, 2, 3], [4, 5, 6], [7, 8]]
```

the effect can be cancelled by using the `SelectMany`

---

## Immediate and differed:

differed execution means that the LINQ query won't apply until we enumerate or iterate over the result.

using differed execution means that in the we just declare the query but that it won't be executed until the enumerable is iterated over.

immediate execution means that the method is fired immediately, but immediate method may or may not iterate over the enumerable them selves

differed execution methods -because of their nature- will run every time you iterate over the enumerable, this may cause some performance issues, so it's recommended to materialize the method using `toList` for example when the query may be executed multiple times.

most of the LINQ methods -including all the previous- are differed execution.

any method that is immediate execution will be marked, but differed won't.

---

## All<T>:

the `All` is an immediately executed method that checks if all elements in the sequence meet the predicate, keep in mind it checks the sequence not the child sequences.

```csharp
IEnumerable<T>.All<T>(Func<T, bool> predicate); // bool
```

for example:

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.All(x => x % 2 == 0); //checks if all elements in the sequence meet the predicate
```

---

## Any<T>:

the `Any` method is an immediately executed method that check if -at least- one or more element meet the predicate, it behaves just like `All` but stops it's iteration on first element that meets the predicate.

```csharp
IEnumerable<T>.Any<T>(Func<T, bool> predicate); // bool
```

for example:

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Any(x => x > 4); //checks if at least one element meets the predicate.
```

---

## Contains<T>:

the `Contains` method is an immediately executed method that is used to check if the sequence includes the given element.

```csharp
IEnumerable<T>.Contains<T>(T value); // bool
```

for example:

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];
collection.Contains(3);
```

---

## Append<T>:

the `Append` method is an immediately executed method that is used to append an element at the end of the sequence.

```csharp
IEnumerable<T>.Append<T>(T value); // IEnumerable<T>
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Append(9);
```

---

## Prepend<T>:

the `Prepend` method is an immediately executed method that is used to append an element at the start of the sequence.

```csharp
IEnumerable<T>.Prepend<T>(T value); // IEnumerable<T>
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Prepend(0);
```

---

## Count<T>:

the `Count` method is an immediately executed method that returns the number of elements in the sequence or the number of elements that meet the predicate.

```csharp
IEnumerable<T>.Count<T>(); // int
IEnumerable<T>.Count<T>(Func<T, bool> predicate); // int
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Count(); //how many elements
collection.Count(x => x > 2 && x < 6); // how many are between 2 : 6
```

there is also a `LongCount` which is identical just that it always returns a `long`

---

## TryGetNonEnumeratedCount<T>:

the `TryGetNonEnumeratedCount` is an immediately executed method that is used to get the number of elements in the sequence without enumerating or iterating over it.

```csharp
IEnumerable<T>.TryGetNonEnumeratedCount<T>(out int count); // bool
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];
collection.TryGetNonEnumeratedCount(out int count);
```

---

## Max<T, K>:

the `Max` is an immediately executed method that gets the biggest value of the sequence or the biggest value gotten by the selector callback.

```csharp
IEnumerable<T>.Max<T>(); // T
IEnumerable<T>.Max<T, K>(Func<T, K> selector); // K?
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Max(); // 8
collection.Max<int, int>(x => x * 2); // 16
```

---

## MaxBy<T, K>:

the `MaxBy` method is an immediately executed method that gets the element with the biggest value based on the callback, but unlike `Max` it gets the element it self instead of the callback's result.

```csharp
IEnumerable<T>.MaxBy<T, K>(Func<T, K> selector); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.MaxBy<int, int>(x => x * 2);
```

`Min` and `MinBy` are identical just picks the smallest.

---

## Sum<T>:

the `Sum` sums all values in the sequence, but if the sequence is a list of objects for example it can take a callback to convert before summing up.

```csharp
IEnumerable<T>.Sum<T>(); // T
IEnumerable<T>.Sum<T>(Func<T, pickType> selector); // K
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

collection.Sum();
collection.Sum(element => (int)element);
```

---

## Aggregate<T>:

the `Aggregate` method is an immediately executed method that aggregates the sequence into a single value.

```csharp
// prev, current, returnType -or use `T` only for 3
IEnumerable<T>.Aggregate<T, K>(Func<K, T, K> callback) //K

IEnumerable<T>.Aggregate<T, K>(K initialValue, Func<K, T, K> callback)// K

IEnumerable<T>.Aggregate<T, k>(K initialValue, Func<K, T, K>, Func<K, K>);
```

note that if the `initialValue` is not passed that on the first iteration the `previous` is `collection[0]` while `current` is `collection[1]`, and if it was provided then it's `initialValue` is `previous` & `current` is `collection[0]`

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8];

// prev at the first iteration = collection[0], curr = 2
collection.Aggregate((prev, curr) => prev + curr);
// initial value = -9
collection.Aggregate(-9, (prev, curr) => prev + curr);


// the third method runs after the aggregation, it takes the result runs the method on it and returns the value
collection
    .Aggregate(0, (prev, curr) => prev + curr, (aggregated) => Math.Abs(aggregated));
```

---

## First<T>:

the `First` is an immediately executed method that is used to get the first value of the sequence or the first one to meet the predicate.

if no element was found it will throw an `InvalidOperationException`.

```csharp
IEnumerable<T>.First<T>(); // T
IEnumerable<T>.First<T>(Func<T, bool> predicate); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.First(); //1
collection.First(num => num == 11);//ERROR
```

---

## FirstOrDefault<T>:

the `FirstOrDefault` is identical to `First`, but it in the case of no element being found it would returns a default value, this can be the default value of the type like `0` for `int`, or a specified value.

```csharp
IEnumerable<T>.FirstOrDefault<T>();
IEnumerable<T>.FirstOrDefault<T>(T);
IEnumerable<T>.FirstOrDefault<T>(Func<T, bool>);
IEnumerable<T>.FirstOrDefault<T>(Func<T,bool> ,T);
```

```csharp
collection.FirstOrDefault(); //returns the first value or the type's default
collection.FirstOrDefault(10); //return 10 if sequence is empty
collection.FirstOrDefault(x => x == 11); //first to meet the predicate, else use the default of the type
collection.FirstOrDefault(x => x == 11, 100); //first element to meet the predicate, if none found use 100
```

both `First` & `FirstOrDefault` function exactly like `Last` & `LastOrDefault` but from the start instead of the end

---

## Single<T>:

the `Single` is a method that expects only **one** value to be in the sequence, or **one** value that meets the predicate.

if the sequence is empty or has more then one element or the predicate found more then one element that are valid it will thro an `InvalidOperationException`.

```csharp
IEnumerable<T>.Single<T>(); // T
IEnumerable<T>.Single<T>(Func<T, bool> predicate); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.Single(); // ERROR
collection.Single(x => x > 9); // 10
```

---

## SingleOrDefault<T>:

the `SingleOrDefault` is identical to `Single` but it has a default value **only** for `empty` collections.

```csharp
IEnumerable<T>.SingleOrDefault<T>(); // T
IEnumerable<T>.SingleOrDefault<T>(T); // T
IEnumerable<T>.SingleOrDefault<T>(Func<T, bool> predicate); // T
IEnumerable<T>.SingleOrDefault<T>(Func<T, bool> predicate, T); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.SingleOrDefault();//ERROR
collection.SingleOrDefault(10);// ERROR

// only one element must meet the predicate
collection.SingleOrDefault(x => x > 9);// 10

// same, but with a fallback
collection.SingleOrDefault(x => x > 9, -1); // 10
```

---

## ElementAt<T>:

the `ElementAt` is an immediately executed method that looks for the element at the given index.

if the index is out of range it throws a `ArgumentOutOfRangeException`.

```csharp
IEnumerable<T>.ElementAt<T>(int index); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

//finds the element at index 2
collection.ElementAt(2); //throws ArgumentOutOfRangeException
```

---

## ElementAtOrDefault<T>:

same as the `ElementAt` but uses the type's default if not found, only takes the index.

```csharp
IEnumerable<T>.ElementAtOrDefault<T>(int index); // T
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.ElementAtOrDefault(2); // @index 2
```

---

## DefaultIfEmpty<T>():

the `DefaultIfEmpty` is a differed execution method that returns the elements of the sequence, if it's empty it will fallback to the type's default or the given default.

```csharp
IEnumerable<T>.DefaultIfEmpty<T>(); // IEnumerable<T>
IEnumerable<T>.DefaultIfEmpty<T>(T); // IEnumerable<T>
```

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.DefaultIfEmpty()
collection.DefaultIfEmpty(-1);
```

---

## ToArray<T>:

the `ToArray` is an immediately executed method that casts the enumerable into an array.

```csharp
IEnumerable<T>.ToArray<T>(); //T[]
```

---

## ToList<T>:

same as `ToArray`.

```csharp
IEnumerable<T>.ToList<T>(); //List<T>
```

---

## ToDictionary<T, Key, Value>:

the `ToDictionary` just like `ToArray` & `ToList` but creates a dictionary.

```csharp
IEnumerable<T>.ToDictionary<T, Key, Element>(Func<T, Key>, Func<T, Element>)
```

so both methods are passed the current element in the iteration, the first is supposed to generate the `key` and the second generates the `value`.

```csharp
IEnumerable<int> collection = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

collection.ToDictionary<int, int, string>(key => key, value => $"Hi {value}");
```

---

## AsEnumerable<T>:

the `AsEnumerable` method is a differed method that casts the collection into an `IEnumerable<T>`.

---

## Distinct<T>:

the `Distinct` method is used to create a new version of the sequence where all duplicate values are removed.

```csharp
IEnumerable<int> collection = [1,2,2,3];

// removes duplicated
collection.Distinct(); // [1,2,3]
```

---

## Union<T>:

the `Union` is used to combine two enumerable together.

```csharp
IEnumerable<T>.Union<T>(IEnumerable<T>); //IEnumerable<T>
```

```csharp
IEnumerable<int> collection = Enumerable.Range(10, 100);
IEnumerable<int> collection2 = Enumerable.Range(1, 5);

collection.Union(collection2); // collection , collection2
```

---

## Intersect<T>:

the `Intersect` method returns a sequence of shared values between two enumerables.

```csharp
IEnumerable<T>.Intersect<T>(IEnumerable<T>); //IEnumerable<T>
```

```csharp
IEnumerable<int> collection = Enumerable.Range(0, 10);
IEnumerable<int> collection2 = Enumerable.Range(1, 5);

collection.Intersect(collection2).Dump(); //[ 1- > 5]
```

---

## Except<T>:

the `Except` method is used to return the used to remove shared value between two enumerables.

```csharp
IEnumerable<T>.Except<T>(IEnumerable<T>)
```

```csharp
IEnumerable<int> collection = Enumerable.Range(0, 10);
IEnumerable<int> collection2 = Enumerable.Range(1, 5);

collection.Except(collection2);//[0, 6 -> 9]
```

---

## UnionBy<T, K>:

the `UnionBy` joins two enumerables by a key that is generated by the `keySelector` callback.

```c#
IEnumerable<T>.UnionBy<T, K>(IEnumerable<T>, Func<T, K>); //IEnumerable<T>
```

for example:

```csharp
IEnumerable<Person> collection = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Person> collection2 = [new(0, "You", 15)];
record Person(int id, string Name, int age);

collection.UnionBy(collection2, person => person.id); // YOU(1) & ME(1)
```

---

## IntersectBy<T, K>:

the `IntersectBy` is used to find the intersect of two enumerables by a key generated also by the `keySelector` callback.

```csharp
IEnumerable<T>.IntersectBy<T, K>(IEnumerable<T>, Func<T, K>);// IEnumerable<T>
```

the first enumerable is actually an enumerable of the key used for the intersection, which will be extracted from the second enumerable.

```csharp
IEnumerable<Person> collection = [new(0, "You", 15), new(1, "Me", 16)];

IEnumerable<Person> collection2 = [new(0, "You", 15)];

collection
    .IntersectBy<Person, int>(collection2.Select(person => person.id), person => person.id);
```

---

## ExceptBy<T, K>:

same idea as `IntersectBy` just picks the difference

---

## Zip<T, K>:

the `Zip` method is used to combine 2 enumerables -can also be used with 3- into one as an enumerable collection tuples, where each element represent the an element from each source at an index.

```csharp
IEnumerable<T>.Zip<T, K>(IEnumerable<k>) //IEnumerable<(T, K)>
```

```csharp
IEnumerable<Person> collection = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Product> collection2 = [new(0, "PS4"), new(0, "PS5"), new(1, "Tomato")];

record Person(int id, string Name, int age);
record Product(int PersonId, string Name);

collection.Zip(collection2);
```

---

## Join<T, K, I, L>:

the `Join` is used to group elements together based on key from each.

the key is generated by the selector for each.

```csharp
IEnumerable<T>.Join<T,K,I,L>(IEnumerable<T>, Func<T, I>, Func<K, I>, Func<T, K, L>); //IEnumerable<L>
```

it's important to note that if there are duplicates then it will match each to it corresponding once at a time.

```csharp
IEnumerable<Person> collection = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Product> collection2 = [new(0, "PS4"), new(0, "PS5"), new(1, "Tomato")];

record Person(int id, string Name, int age);
record Product(int PersonId, string Name);

collection
    .Join(
        collection2,
        person => person.id, //key1
        product => product.PersonId, //key2
        (person, product) => $"{person.Name} bought {product.Name}" //result
    );
```

this code will result in two message for person with name `You` as `Product.PersonId` matched it's object's `Person.id` twice.

---

## GroupJoin<T, K , I ,L>:

the `GroupJoin` is similar to the `Join` with very similar signature, the difference being that it groups duplicates at once, sense it passes an `IEnumerable<K>` to the final grouping method.

```csharp
IEnumerable<T>.GroupJoint<T, K, I, L>(
    IEnumerable<K>,
    Func<T, I>,
    Func<K, I>,
    Func<T, IEnumerable<K>, L>
); //IEnumerable<L>
```

```csharp
IEnumerable<Person> collection = [new(0, "You", 15), new(1, "Me", 16)];
IEnumerable<Product> collection2 = [new(0, "PS4"), new(0, "PS5"), new(1, "Tomato")];

record Person(int id, string Name, int age);
record Product(int PersonId, string Name);

collection
    .GroupJoin(
        collection2,
        person => person.id,
        product => product.PersonId,
        (person, products) =>
            $"{person.Name} bought {string.Join(",", products.Select(x => x.Name))}"
    );
```

---

## Concat<T>:

the `Concat` method is used to join two enumerables.

```csharp
IEnumerable<T>.Concat<T>(IEnumerable<T>); //IEnumerable<T>
```

```csharp
IEnumerable<int> collection = [1,2,3];
IEnumerable<int> collection2 = [4, 5, 6];

collection.Concat(collection2); //1-> 6
```

---

## GroupBy<T, K>:

the `GroupBy` method is used to group together enumerables based on a key.

```csharp
IEnumerable<T>.GroupBy<T, K>(Func<T, K>) //IEnumerable<IGrouping<K,T>>
```

```csharp
IEnumerable<Person> collection = [new("You", 15), new("Me", 16), new("Them", 16)];
collection.GroupBy(person => person.Id);

record Person(string Name, int Id);
```

---

## Order<T>:

the `Order` method is used to order the elements of the sequence.

```csharp
IEnumerable<T>.Order<T>(); //IOrderedEnumerable<T>
```

there is also `OrderDescending` which does the exact same but the order is reversed.

```csharp
IEnumerable<int> collection = [3, 1, 2, 5, 7, 4, 6];

collection.Order(); //[1 -> 7]
```

---

## OrderBy<T, K>:

the `OrderBy` is used to order objects by a specific key, this is done by the `keySelector` callback.

```csharp
IEnumerable<T>.OrderBy<T, K>(Func<T, K>); //IOrderedEnumerable<T>
```

there is also `OrderByDescending` which does the exact same but in reverse order.

```csharp
IEnumerable<int> collection = [3, 1, 2, 5, 7, 4, 6];

collection.OrderBy(x => x * 2);
```

---

## ThenBy<T, K>:

the `ThenBy` is used to do a sub-order on an `IOrderedEnumerable`, it orders the element that are equal for example to the check of `Order` or `OrderBy`.

```csharp
IOrderedEnumerable<T>.ThenBy<T, K>(Func<T,K>); //IOrderedEnumerable<T>
```

also there is `ThenByDescending` which does the same but in descending order.

```csharp
IEnumerable<Person> people =
[
    new("Ahmed", 0, 20),
    new("Yasseen", 3, 25),
    new("Mohammed", 1, 17),
    new("Ali", 2, 16),
    new("Ammar", 5, 20),
    new("Amr", 4, 20),
];

people
    .OrderBy(person => person.Age)
    .ThenBy(person => person.Id);

record Person(string Name, int Id, int Age);
```

---

## Reverse<T>:

the `Reverse` simply reverses the order of the enumerable, that's it
