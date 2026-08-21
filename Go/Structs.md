# Structs

a struct is a complex datatype which stores related values.

define a struct using the `type` keyword then the name and then `struct`:

```go
type GasEngine struct{
    mpg uint8
    gallons uint8
}
```

we can declare a struct without initializing the values in which case the zero-value of each field will be used which off course is type-dependent.

we can also define the struct's values:

```go
var myEngine GasEngine = GasEngine {mpg: 25, gallons: 15};
fmt.Println(myEngine.mpg, myEngine.gallons);
```

we can also omit the field names, in which case values will be assigned in order:

```go
//same as the previous snippet
var myEngine GasEngine = GasEngine {25, 15};
```

we can access the fields using `.` notation:

```go
mpg := myEngine.mpg;
```

when using another struct in a struct we can declare it with no name, this is like providing our wrapper struct with all fields of the other one, for example

```go
type Vehicle struct{
    fuel string
    tankSize uint8
}

type Car struct{
    color string
    year int
    Vehicle
}
```

and the use would be:

```go
// if no value is defined each field receives the zero value of it's type, this can also be done using obj := new(T) where T is the struct type
car1 := Car{"yellow", 2012, Vehicle{"petrol", 25}};
car1.tankSize;
```

the same can be done with other fields, for example using:

```go
type myType struct{
    /*some code*/
    int
}
```

this will give us a field named `int` of type `int`.

---

## Anonymous structs

we can declare anonymous structs but they must be initialized on declaration:

```go
customStruct := struct {
    field1 int
}{12};
```

---

## Methods

methods are struct-associated function that access the struct's instances:

```go
func (e GasEngine) milesLeft() uint8 {
    return e.gallons * e.mpg;
}
```

and as usual the method is available using `.` notation.

but generally speaking it's better to use a pointer to the struct to avoid `copying` the value, or to mutate the very same instance of the struct.

---

## Struct tags

using the `reflect` or `encoding/json` pkg we can append metadata to our structs, next to any field using **\` \`**, this is very often use the map values of the struct to json keys:

```go
type Person struct {
	Name string `json:"name"` //the field of name on json objects maps to this
	Age  int    `help:"age of the person"` //additional info
}
```

these tags can be read or used when converting the struct to json -for example- or through using reflection:

```go
p := Person{Name: "Alice", Age: 30}
// Convert struct to JSON
jsonData, err := json.Marshal(p);

if(err == nil){
    fmt.Println(string(jsonData))
}

// Use reflection to read struct tags
t := reflect.TypeOf(p);
for i := range t.NumField() {
    field := t.Field(i)
    fmt.Printf("Field: %s, JSON Tag: %s, Help Tag: %s\n", field.Name, field.Tag.Get("json"), field.Tag.Get("help"))
}
```

more struct tags for the json package:

- `json:"-"` ignore this field
- `json:"-,"` name of the field is `-`
- `json:",omitempty"` skips if the value is the zero value of it's type
- `json:",string"` forces encoding into string
- `json:",omitzero"` skip if the value equals zero of it's type
