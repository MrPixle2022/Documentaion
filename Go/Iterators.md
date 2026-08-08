# Iterators

we can create a custom iterator in go using `iter.Seq[T]` type, import the `iter` package and declare a function of the following structure:

```go
func MyIterator() iter.Seq[int]{
    return func(yield func(T) bool) bool(){
        for i:= 0; i < 3; i++{
            if !yield(10){
                return false
            }
        }
        return true;
    }
}
```

the `iter.Seq[T]` is a special signature that say the type is a function that returns a boolean an take another callback function -named yield- that takes a value of type `T`.

this `yield` is what runs when using `for...range`, basically the `bool` value it returns is `false` if the loop is broken early as in using `break`, while `true` means we are ready for the next loop.

this loop can be used as:

```go
for i := range MyIterator(){
    //use the value
}
```

what happens is behind the scenes the function returned by `MyIterator` -let's call it `generator`- is wrapped inside a `yield` function.

the `generator` as the name implies generates the data using an internal loop, passes the data to the `yield` -basically a closure-, the yield tells us if the loop was stopped early or not, if so `generator` returns false, else it continues on and returns `true` when it's done.

---

## Key-value iterators

for an iterator that checks 2 fields pass the 2 types to the `Seq` type:

```go
// returns the index and the element
func MyIterator[T any](s []T) iter.Seq2[int, T]{
    return func(yield func(int, T) bool) bool{
        for i:= 0; i < len(s); i++{
            if(!yield(i, s[i])){return false;}
        }
        return true;
    }
}
```
