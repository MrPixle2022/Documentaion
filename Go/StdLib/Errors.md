# Errors

in go errors are not treated as worst-case scenarios that are thrown without you even knowing they can, no no, in go errors are explicitly mentioned and are explicitly handled.

so what is an error in go?, an error is **any type the implements the `error` interface**.

how do you implement this interface?, you only need this on your struct:

```go
func Error() string{
    //returns string
}
```

now yes i said struct, as very often custom-errors are structs the implement the `error` interface, how ever we don't necessarily need to create a custom type every time, we can declare our own errors with simple static messages if we wish so.

often when handling errors we use the `errors` package which include a lot of useful function to handle errors.

for example use `errors.New` to create a simple error value with a static message:

```go
var PowerError = errors.New("new error message")
```

this error can be used where ever an `error` type can as it basically is an error with a string message:

```go
func throwErr() error{
    return PowerError
}
```

off course we check for errors by using `!= nil` for if there is an error, we can be more specific and target different types of error, we will see this a bit later.

---

## Wrapped errors

this time with the `fmt` package we can use `Errorf`, this is a special function allows us to declare a formatted error message -support format specifiers- and wraps our errors with additional data before returning them.

```go
func throwAndLog() error{
    return fmt.Errorf("%w", PowerError)
}
```

in the example above the returned error by `Errorf` is a wrapper around the `PowerError`, it adds additional data and creates a trace-stack like system, `%w` is the wrapping verb.

wrapped errors are checked using functions of the `errors` package, this package also allows us to un-wrap errors.

---

## Error unwrapping

to unwrap an error we implement the `Unwrap` function on it.

though using `Errorf` will all ready create this function for us, each unwrap goes up 1 layer, so for example:

```go
base := errors.New("base");
mid := fmt.Errorf("layer 1 %w", base)
out := fmt.Errof("layer 2 %w", mid)
```

unwrapping `out` returns `mid`, `mid` returns `base` and `base` returns nil as it doesn't have the `Unwrap` function

```go
fmt.Println("base: ", errors.Unwrap(base));
fmt.Println("layer 1: ", errors.Unwrap(mid));
fmt.Println("layer 2: ", errors.Unwrap(out));
```

to add a custom wrapping logic we can do as in this example:

```go
type NetworkError struct {
	Host string
	Err  error // the base wrapped-error
}

/*implement Error here*/

func (n *NetworkError) Unwrap() error {
	return n.Err
}
```

that wrapped error can be provided on initialization.

also note that unwrapped errors can be checked using `==`.

---

## Error checking

this section describes the process of how do i know this error is `x` not `y`.

let's assume we have the following errors:

```go
//base error
var operationFails = errors.New("operation failed")
//wrapper error
var divisionByZero = fmt.Errorf("Can't divide by zero, %w", operationFails);

//custom struct error
type InputError {
    field string
    msg string
}

func (e *InputError) Error() string{
    return fmt.Sprintf("invalid input '%s' : '%s'", e.field, e.msg)
}
```

and say we have the following function:

```go
func Calculate(a, b int) (int, error) {
	if a < 0 || b < 0 {
		return 0, InputError{
			Field: "numerator/denominator",
			Msg:   "negative numbers are not allowed",
		}
	}
	if b == 0 {
		return 0, fmt.Errorf("cannot divide %d by zero: %w", a, ErrOperationFailed)
	}
	return a / b, nil
}
```

as we can see this function can return 2 types of error, when handling them how do we know which is which, well first let's extract the errors:

```go
val, err := Calculate(10, 0);
```

now we check for the errors, first using `errors.Is`:

```go
if errors.Is(err, operationFails){
    fmt.Printf("yep, operation error, unwrapping was a success")
}
```

this snippet using the `Is` function, this check that `err` is of type `operationFails` or a wrapping type.

basically it checks if the error in the 2nd argument is present in the first's error chain -wrappers create this chain-.

we can also extract the inner error type and treat our error as if it were of that type using `errors.As`:

```go
//this is where we store the error data
var inputError InputError
if errors.As(err, &inputError){
    fmt.Printf("Input error: %s : %s", inputError.field, inputError.msg);
}
```

the `As` function looks if it can treat `err` as of type` InputError` -in this case-, if so it will unwrap the error, and transfer that layer's data to our `inputError`'s struct, hence the use of a pointer.

---

## Panics

a `panic` is an error that halts the app's execution, these often occur with:

- out of bound array index
- wrongly using mutexes
- sending data to closed channels
- calls with nil pointers
- wrong type assertion

the thing with panics is that they can't be captured during compile-time, the compiler has no idea they may occur, so we only discover them at runtime.

panics are composed of a `cause message` and a `stack trace` so we can know more about the error.

optimally panics can be explicitly ordered using the `panic` function which takes a single string being the panic message:

```go
panic("PANICKING")
```

though panics usually stop the execution, `defer` functions will run regardless.

when it comes to handling panics our one and only choice is `recover`, this is a build in function that intercepts panics while they propagate up the trace stack and prevents them from terminating the app.

```go
go func(){
    defer func(){
        if err := recover(); err != nil{
            fmt.Println("Recovered from a panic")
        }
    }

    panic("panic in progress")
}()
```

note that:

- recover can be used in defer functions only
- recover can't see panics from other goroutines -even if they are within our function-
- if you re-panic the panic goes through
