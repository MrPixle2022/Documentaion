# Fmt

the `fmt` package is shipped with go, and includes a lot of useful methods.

---

## Println

the `println` function is used to print a line to the terminal, it can take any number of data and it will print them in order left to right:

```go
fmt.Println("go" + "lang")
fmt.Println("1+1 =", 1+1)
fmt.Println("7.0/3.0 =", 7.0/3.0)
```

---

## Printf

the `printf` is, yeah we know, use `%v` as a placeholder for a value, or use the general

---

## Sprintf

the `Sprintf` is used to define a formatted string without printing it, rather it returns the final string.

---

## Fprintf

the `Fprintf` is used to write a formatted string to the specified `io.Writer`
