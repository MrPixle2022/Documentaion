# Dictionary:

Dictionary are a sequence of key-value pairs included in the `System.Collections.Generic` namespace.

to create a new dictionary use:

```csharp
Dictionary<Key, Value> dictionary = new Dictionary<Key, Value>();
Dictionary<Key, Value> dictionary = new();
```

where `Key` is the type of the keys and `Value` is the type of the values.

for example:

```csharp
Dictionary<string, string> superHeros = new()
{
    // KEY ------ Value
    { "Superman", "Clark Kent" },
    { "Batman", "Bruce Wayne" },
    { "Wonder Woman", "Diana Prince" }
};
```

---

## Add(T key, K value):

the `Add` method adds a new pair to the sequence.

```csharp
superHeros.Add("Superman", "Clark Kent");
```

---

## Remove(T key, out K value):

the `Remove` method removes the pair using the key to find it, it requires one parameter only but has an overload that uses an out parameter to return the value associated with the `key`:

```csharp
superHeros.Remove("Batman");
```

---

## ContainsValue(K value):

the `ContainsValue` method returns a boolean, it check if the `value` is in the sequence or not.

```csharp
superHeros.ContainsValue("Clark Kent");
```

---

## ContainsKey(T key):

the `ContainsKey` method returns a boolean, it check if the `key` is in the sequence or not.

```csharp
superHeros.ContainsKey("Batman");
```

---

## GetValueOrDefault(T key, T defaultValue):

the `GetValueOrDefault` tries to find the `key` in the sequence, if not found it returns the `defaultValue`.

```csharp
var unknownHero = superHeros.GetValueOrDefault("SomeDude", "not-found");
```

---

## TryGetValue(T key, out K? value):

the `TryGetValue` method returns a boolean if the value of the key exists, if so it returns the value in the `value`.

```c#
superHeros.TryGetValue("Superman", out string? supermanIdentify);
```

---

## Clear():

the `Clear` method empties the dictionary.

```csharp
superHeros.Clear();
```
