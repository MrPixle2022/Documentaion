<!-- @format -->

# IEnumerable:

the `IEnumerable` interface is the shared base by the native collections like:

- `Array`
- `List<T>`
- `ArrayList`
- `Queue<T>`
- `Stack<T>`

etc ..., the IEnumerable allows a type to be enumerable, meaning it can be used not only as a collection, but also in a `foreach` loop.

---

## Custom Enumerable:

to create a custom enumerable create a class that inherits from the `IEnumerable` interface.

doing so requires the class to have a:

- `GetEnumerator` method
- `IEnumerable.GetEnumerator` method

the `GetEnumerator` creates the enumerators which is used to iterate over the collection.

another thing to consider is the indexer, using an indexer allows us to use the `collection[i]` syntax.

the way you create an index is with the following syntax:

```csharp
//T -> type of each element in the collection
public T this[int index]
{
    get {return ---}
    set{---}
}
```

so let's combine all this into a new collection called `AnimalFarm` which includes multiple `Animal` objects.

```csharp
using System.Collections;

// IEnumerable collection of `Animal` objects
public class AnimalFarm : IEnumerable<Animal>
{
    // the internal collection
    private List<Animal> animalList = new();

    // constructor tha extract the elements from a list
    public AnimalFarm(List<Animal> animals)
    {
        animalList = animals;
    }

    // default constructor
    public AnimalFarm() { }

    //the indexer
    public Animal this[int index]
    {
        get { return animalList[index]; }
        // allows mutation using collection[i] = value
        set { animalList.Insert(index, value); }
    }

    // readonly count
    public int Count
    {
        get { return animalList.Count; }
    }

    public IEnumerator<Animal> GetEnumerator()
    {
        return animalList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

```
