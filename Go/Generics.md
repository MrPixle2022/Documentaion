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
[T comparable] //only types that support `==` and `!=` (int, floats, strings, bool)
[T ~t1] //t1 or any type that is based of ~t1 like for example:

type MyInt int;
[T ~int] //this type and all underlying types, int or MyInt would work
```

custom constrains can be defined using interfaces:

```go
// Integer constraint allowing only int and int64
type Integer interface {
    int | int64
}

func Add[T Integer](a, b T) T {
    return a + b // Legal because both int and int64 support '+'
}
```
