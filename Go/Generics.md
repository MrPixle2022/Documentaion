# Generics

generics in go defined between `[ ]`, not only that but we can actually limit the choice to a set of types only.

for example:

```go
func sumSlice[T int | float32 | float64](slice []T){
    var sum T;

    for _, v := range slice{
        sum += v;
    }

    return sum;
}
```

when calling this function we do that as:

```go
sumSlice[int](mySlice);
```

there are some ways to define generic:

```go
[T any] //any type
[T t1 | t2] //either of type t1 or t2
[T Numeric] //int or float64 only
[T ~t1] //t1 or any type that is based of ~t1 like for example:

type MyInt int;
[T ~int] //int or MyInt would work
```
