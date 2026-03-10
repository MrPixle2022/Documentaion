# Queues:

Queues are a first-on-first-out variable size collection.

Queues are type-safe as they accept a pre-defined type through generics.

create a queue using:

```csharp
Queue<int> numbers = new();
```

---

## Enqueue(T value):

the `Enqueue` method adds `value` to the end of the queue.

```csharp
numbers.Enqueue(1);
```

---

## Dequeue():

the `Dequeue` method removes the first element in the queue.

```csharp
numbers.Dequeue();
```

---

## Contains(T value):

returns true if `value` is in the queue, otherwise returns false

```csharp
numbers.Contains(1);
```

---

## Peek():

the `Peek` method returns the first element in the queue but doesn't remove it:

```csharp
numbers.Peek();
```
