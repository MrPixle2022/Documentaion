# Control flow

---

## If

just the same as every other language, what is new is:

```go
if num := 9; num < 0 {
    fmt.Println(num, "is negative")
} else if num < 10 {
    fmt.Println(num, "has 1 digit")
} else {
    fmt.Println(num, "has multiple digits")
}
```

using `if num:=9 ...` declares a local variable of name `num` that is available only inside the `if` block and blocks related to it i.e. the `else if` and `else` blocks, it dies outside these blocks.

sadly there is no ternary operator :(.

---

## Switch

same as usually, but here we can compare values:

```go
i := 2
fmt.Print("Write ", i, " as ")
switch i {
case 1:
    fmt.Println("one")
case 2:
    fmt.Println("two")
case 3:
    fmt.Println("three")
}
```

use conditions within the cases:

```go
t := time.Now()
switch {
    case t.Hour() < 12:
        fmt.Println("It's before noon")
    default:
        fmt.Println("It's after noon")
}
```

or compare types:

```go
whatAmI := func(i interface{}) {
    switch t := i.(type) {
        case bool:
            fmt.Println("I'm a bool")
        case int:
            fmt.Println("I'm an int")
        default:
            fmt.Printf("Don't know type %T\n", t)
    }
}
```

off course the value of the case is assigned to `t` and `i.(type)` is the what is being checked against the cases
