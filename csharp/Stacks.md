# Stacks:

stacks are a last-in-first-out variable size collection which is type-safe as it accepts a pre-defined type through generics.

```csharp
Stack<int> ints = new();
```

---

## Push(T value):

the `Push` method adds `value` to the top -end- of the stack.

```csharp
ints.Push(1);
```

---

## Pop():

the `Pop` removes the element at the top of the stack and **returns** it's value.

```csharp
ints.Pop(); // ints = [1,2], -> 3
```

---

## Peek():

the `Peek` method returns the element at the top of the stack but doesn't remove it.

```csharp
ints.Peek();
```
