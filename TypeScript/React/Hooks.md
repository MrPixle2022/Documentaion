# Hooks:

---

## useState<T?>(initialValue:T);

similar to how it is used in js the `useState` hook didn't change, the only change is that it now accept a generic type to more accurately specify the type, it's inferred based on the `initialValue` but for more accuracy use `generics`