# Interfaces

interfaces are defined as the same as `structs` replacing the `struct` keyword we use `interface`.

interfaces can be used as a generic placeholder type, where it's used we expect a type with at least the bare-minimum being a matching signature.

for example

```go
type myInterface interface{
    myV int
    someFunc() uint8
}
```

this can be used to pass any type that has a `myV` value of type `int` such as the following struct:

```go
type myStruct struct {
    myV int
    myV2 float32
}

func (s myStruct) someFunc() uint8{
    return 2;
}
```

using the interface type we can call the methods on it as they will be present on all valid types that implement this interface.

---

## Empty interfaces

empty interfaces or `interface{}` is an alias of `any` that represent a generic holder for any value.

this basically means that any variable of this type is like a `void*` in c:

```go
var inter1 interface{} = "hello";
inter1 = 12; //no problem

var inter2 any;
inter2 = true;
inter2 = 123;
```

---

## Embedded interfaces

just as the case with embedded structs we can have an interface extend another without using inheritance

```go
type Reader interface {
	Read() string
}

type Writer interface {
	Write(data string)
}

type ReadWriter interface {
	Reader
	Writer
}
```

the `ReadWriter` now has direct access to both `Read()` and `Write(data string)`.
