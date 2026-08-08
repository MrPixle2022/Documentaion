# Strings

the `strings` package contains many useful utility functions for handling strings.

---

## Contains

the `Contains` function returns a boolean that checks if the given strings contains the given substring:

```go
contains_es := strings.Contains("test", "es")
fmt.Println(contains_es) //true
```

---

## Count

the `Count` function returns the number of time a substring was repeated in a string:

```go
count := strings.Count("test", t)
fmt.Println(count) //2
```

---

## HasPrefix

the `HasPrefix` checks if the substring exists at the start of the string:

```go
prefixFound := strings.HasPrefix("test", "te")
fmt.Println(prefixFound) //true
```

---

## HasSuffix

the `HasSuffix` does the same as `HasPrefix` but checks the end of the string:

```go
suffixFound := strings.HasSuffix("test", "es")
fmt.Println(suffixFound) //true
```

---

## Index

the `Index` returns the index of the first instance of the given substring, returns `-1` if not found:

```go
index := strings.Index("test", "e")
fmt.Println(index) //1
```

---

## Join

the `Join` is used to combine a string-slice and adds a separating letter between all slice elements in the final string:

```go
final := strings.Join([]string{"a", "b"}, "-")
fmt.Println(final) //a-b
```

---

## Repeat

the `Repeat` repeats the given string `n` number of times and returns the result

```go
repeated := strings.Repeat("a", 5)
fmt.Println(repeated) //aaaaa
```

---

## Replace

the `Replace` replace a portion of a string by another part and does that `n` number of times, using a `< 0` value sets no limit to the replacements

```go
text := "banana"
fmt.Println(strings.Replace(text, "a", "o", 2))
// Output: bonona

fmt.Println(strings.Replace(text, "a", "o", -1))
// Output: bonono
```

however if we intend to replace all instances use `ReplaceAll` instead, which has the same signature excluding the int `n` parameter.

---

## Split

the `Split` is used to split a string into a slice at each encounter of the separator character:

```go
fmt.Println(strings.Split("a-b-c-d", "-"))
//[a, b, c, d]
```

---

## TrimSpacing

the `TrimSpacing` is used to clear whitespaces, taps and newlines from a string

```go
userInput := "   \t hello world!   \n "
cleanInput := strings.TrimSpace(userInput)
fmt.Printf("%q\n", cleanInput)
// Output: "hello world!"
```

---

## ToLower & ToUpper

converts all letter to either lower or upper case.
