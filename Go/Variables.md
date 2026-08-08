# Variables

in go variables are declared using `var`, though go is a statically-typed we don't need to explicitly state the type as very often go can infer it.

```go
var a = "initial"

var b,c int = 1, 2
var e int //default value = 0

f := "apple" //shorthand, same as
//var f string = "apple"
```

note that `:=` is available inside functions only

go also has constants declared via the `const` keyword:

```go
const n string = "thi is a constant"
```

numeric constant however if not given an explicit type will be `untyped` they will be treated according to the value but a value of `5` for example won't make the constant an `int`, it will be an `untyped constant of value 5`, the type is given when the constant is used in a position where 1 can be inferred as in passing it to a function that expects a value of type `T` for example, in this case go will try and evaluate the constant as being of type `T`.

should the inferring fail go will assume a type based on the value, for example `5` becomes `int` and so on.

variables **must be used**, or else the compiler throws an error, this applies for imported modules and so on..., by default each value will -if not defined be-:

- 0 or 0.0
- ""
- false
- nil (reference type)

---

## Data types

1. int
    - int8
    - int16
    - int32
    - int64

int is usable itself, please note that overflow errors are not caught on compile time, the program will run but the value will behave in an unexpected way.

there is also the same as `uint` for non-negative values and they come in the same sizes as `int`

- float32
- float64

please note that operation between mixed types can't happen, we can't do arithmetics between an `int16` and a `float32` for example, for this to be done conversion is required.

also note that `int` division is floored, in other words rounded down so `2.5` will evaluate to `2` not `3`.

- string

strings can be declared using `" "` and `\` \``, using the later allows for multiline strings just as in the case in javascript.

strings can be concatenated via the `+`.

for the `length` of a string use the `len` function but note that it returns the **number of bytes in the string**, characters out side ASCII characters are often stored in more then 1 byte hence they would through the calculation off.

however we can get the actual length using the `utf8.RuneCountInString` by importing the `unicode/utf8` package.

a rune is a single character between `' '`, when printed we get the ASCII code of the character not the character itself.

- bool

---

## Conversion and Assertion

in go converting to the predefined types like `int32` and so on can be done using the type as a function:

```go
var float float32 = 12.532;
myInt := int32(float); //drops the 12.532 aka floors the number, or rounds down
fmt.Println(myInt); //12
```

type assertion can be used to convert a variable of an interface type into any type that implements it.

this works with empty interfaces:

```go
var i interface{} = "Hello World"

str, ok := i.(string); //converts i into a string, returns ok (bool) and str (string)
```

this snippet converts an empty interface into a string, this results in 2 variables:

- ok: a boolean for wether the operation was a success
- str: the actual value

note that in this example since the value is not an integer using `i.(int)` will cause a panic at runtime, hence it's important to check if `ok` is false before using the value.

this also works with structs that implement an interface, or an interface to interface assertion:

```go
type Shape interface {
	Area() float64
}

type Circle struct {
	Radius float64
}
```

type assertion can work:

```go
var sh Shape = Circle{Radius: 5}
c, ok := sh.(Circle)
```

we can also expect multiple values:

```go
func process(i interface{}) {
	switch v := i.(type) {
	case int:
		fmt.Printf("Twice the int is %d\n", v*2) // v is scoped as an int here
	case string:
		fmt.Printf("The string length is %d\n", len(v)) // v is scoped as a string here
	case bool:
		fmt.Printf("The boolean value is %t\n", v)
	default:
		fmt.Printf("Unknown type: %T\n", v)
	}
}
```

in this example we use the `.(type)` se we can examine the type against the cases.

this is called `type switching` which is a special use case of the `switch` case.

---

## Enums

go has no official support for enums, however we can mimic one using `type` and a bunch of constants:

```go
type SERVER_STATE int;

const (
    IDLE SERVER_STATE = iota; //0
    CONNECTED SERVER_STATE; //1
    ERROR SERVER_STATE; //2
    RETRYING SERVER_STATE; //3
); //iota = 0
```

with in this `const` block we used what is known as `iota`, this is a constant the is being incremented by 1 each line in this const block starting at `0` and resets when it exists this scope, the `iota` is part of the language.

it's also often that we would have either a map or a method on the enum type to convert the values to a more human-readable type:

```go
import "fmt";

//implements the fmt.Stringer interface
func (s SERVER_STATE) String() string{
    switch s{
        case IDLE:
            return "idle";
        case CONNECTED:
            return "connected";
        case ERROR:
            return "error";
        case RETRYING:
            return "retrying";
        default:
            return "unknown"
    }
}
```
