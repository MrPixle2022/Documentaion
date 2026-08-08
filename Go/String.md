# String

a string is an array like structure IOW we can access individual letters via index.

the only problem we don't ge the number, rather the equivalent ASCII code, even more surprising that if we print the type using `%T` in `Printf` we would get a type of usually `uint8`.

and if we loop over a word that uses non-ASCII code letters like greek symbols they would be skipped in a regular for loop.

go uses `UTF-8`, in a loop we get the correct UTF-8 representation while using indexes we get the ASCII equivalent, since the index uses the `raw bytes` if the letter doesn't have an ASCII code, go will split right in the middle of it's byte-sequence and return the value.

> [!NOTE]
> Strings are immutable in go, also concatenating strings creates a new string each time, to overcome this we can use the `strings` package:

```go
var strBuilder strings.Builder
strBuilder.WriteString("World")

var castStr = strBuilder.String()
```

---

## Runes

a rune is a unicode code point, they are an alias for `int32`.

a unicode code point just means the unique number associated with some letter.

we can declare runes as single letters or covert an array into a slice of runes

```go
myRune := 'A'
msg := []rune("Hello, World!")
```

---

## String formatting

we can use special characters to format strings in functions like `fmt.Printf`, for example:

- `%v`: generic value in default format
- `%+v`: append the value name -i.e struct fields name-
- `%#v`: syntax representation, includes the type and the field names
- `%T`: the type
- `%t`: boolean
- `%p`: pointers
