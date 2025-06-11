# Signals:

signals are the reactive data inside angular, they are a value container that makes a value reactive, they can accept any type of data.

---

## Writable signals:

writable signals are defined using the `signal` function and are of type `WritableSignal<T>`:

```typescript
myNumber = signal<number>(0); //the signal stores a number -> default = 0
```

using signals in templates we treat them like functions, because the actual -stored- value is the return value.

for updating signals we have to options, the `.set` and `.update` each do the same thing but in different ways, the `set` takes a direct value and assigns it while the `update` takes a callback which inturn takes the **previous** value as a param

```typescript
myNumber.set(10); //myNumber is now 10
myNumber.update((prev) => prev + 1); //myNumber is now 11
```

---

## Computed signals:

computed signals are signals are **read-only** signals whose value is dependent on other signals.

computed signals are defined by the `computed` method and will automatically update on dependencies change

```typescript
const count: WritableSignal<number> = signal(0);
const doubleCount: Signal<number> = computed(() => count() * 2);
```

---

## Effects:

effect are methods that run on signal change, we are taking about signals whose values where read in the effect callback.

```typescript
effect(() => console.log(count()));
```

> [!NOTE]
> don't use effects directly under the class, use it in a constructor or assign the effect to a class field so that you are in the `injection` scope

the `effect` returns an `EffectRef` on which we can find the `.destroy` method to destroy the effect manually
