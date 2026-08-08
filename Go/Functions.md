# Functions

a function is defined using `func`, we must place the `{` on the same line, we can't do something like

```go
func someFunc()
{

}
```

this will through an error.

the general example of creating a function in go:

```go
func myFunc(n1 int, n2 int) (int, error){
	var err error = nil;
	return n1 + n2, err
}

//same as
func myFunc2(n1, n2 int) (int, error){
    var err error = nil
    return n1 + n2, err
}
```

and the use:

```go
sum, err := myFunc(10, 20);
```

---

## Variadic functions

a `variadic` function is a function that takes an arbitrary number of argument, of 1 type.

the resultant is an `[]T` type:

```go
func sum(nums ...int) int{
    var total int
    for _, val := range nums {
        total += val
    }

    return total
}
```

---

## Anonymous functions

go allows for anonymous functions, we can use them when a function returns a function and so the name is not important:

```go
func intSeq() func() int {
    i := 0
    return func() int {
        i++
        return i
    }
}
```

this inner function will be assigned to any variable that store the return of the `intSeq`, the inner function will retain access to the `intSeq` scope.

off course we can use anonymous functions elsewhere

---

## Named Returns

in go we can sometimes neglect explicitly stating what variables will be returned, instead using just `return` go can deduce what values to returns based on the function's signature:

```go
func divide(dividend, divisor int) (score int, err error) {
    // 1. Go automatically creates 'score' (0) and 'err' (nil) right here.

    if divisor == 0 {
        err = fmt.Errorf("cannot divide by zero")
        return // 2. Go sees a naked return, looks at the signature,
               // and silently executes: return score, err
    }

    score = dividend / divisor
    return // 3. Silently executes: return score, err
}
```

---

## defer

the `deffer` keyword is used to delay the execution of a function until the function calling it finishes:

```go
func main() {
	defer fmt.Println("World") // This is put on hold

	fmt.Println("Hello")       // This runs immediately
}
```

this will print `Hello` then `World`
