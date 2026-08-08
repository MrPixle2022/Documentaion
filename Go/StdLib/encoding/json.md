# Json

the `encoding/json` package is used to handle parsing json object into structs and vice versa.

this package works will with `struct tags`, for example:

```go
type User struct {
    Name string `json:"user_name"`
    Age  int    `json:"age,omitempty"`
    Password string `json:"-"`
}
```

using `json:` tag we define what field name does this filed map to.

`omitempty` means ignore this field if it was empty in which case it will use the `zero value` of that type

> [!NOTE]
> struct fields must be exported i.e start with **Capital letter**.

---

## Go to json

to convert go structs to json object use the `json.Marshal` function, passing it the struct, the function will return the parsed json as `[]byte` and an `error`.

```go
type Product struct {
    Name  string  `json:"name"`
    Price float64 `json:"price"`
}

func main() {
    p := Product{Name: "Espresso Machine", Price: 299.99}

    // json.Marshal returns a byte slice ([]byte) and an error
    jsonData, err := json.Marshal(p)
    if err != nil {
        fmt.Println("Error encoding JSON:", err)
        return
    }

    // Convert byte slice to string to print it nicely
    fmt.Println(string(jsonData))
    // Output: {"name":"Espresso Machine","price":299.99}
}
```

also there is `MarshalIndent`, this is used to indent data and make each key on it's own line, unlike `Marshal` which compresses the data into a single compact line.

the `MarshalIndent` takes, the struct, a `prefix` which is almost always `""` and finally an `indent` which is how to indent the keys usually `"  "` or `"\t"`

```go
var config Config = Config {
    Port: 8080,
    Domain: "example.com",
    ApiKey: "",
}
newConfigData, err := json.MarshalIndent(config, "", "\t")
```

---

## Json to go

to un-parse the json object use the `Unmarshal` function, pass it the json data as `[]byte`, and a pointer to the struct to which the data is assigned, it returns the `error` only.

```go
func main() {
    jsonString := `{"name":"Mechanical Keyboard","price":89.50}`

    // Create an empty instance of your struct
    var p Product

    // Convert string to byte slice, and pass the pointer to p
    err := json.Unmarshal([]byte(jsonString), &p)
    if err != nil {
        fmt.Println("Error decoding JSON:", err)
        return
    }

    fmt.Printf("Parsed Product: %+v\n", p)
    // Output: Parsed Product: {Name:Mechanical Keyboard Price:89.5}
}
```

---

## Encode and decode

go has a `json.Encoder` and `json.Decoder` types which wraps around `io.Reader` and `io.Writer`, often used with handling actively-streaming data as in the case with websockets and http requests.

```go
type UserRequest struct {
	Username string `json:"username"`
	Email    string `json:"email"`
}

func createUserHandler(w http.ResponseWriter, r *http.Request) {
	var user UserRequest

	// 1. Create a decoder tied to the request body stream
	decoder := json.NewDecoder(r.Body)

	// 2. Decode directly into the struct pointer
	err := decoder.Decode(&user)
	if err != nil {
		http.Error(w, "Invalid JSON data", http.StatusBadRequest)
		return
	}
}
```

decoding is for reading while encoding is for sending, to use the encoder we can:

```go
type APIResponse struct {
	Status  string `json:"status"`
	Message string `json:"message"`
}

func statusHandler(w http.ResponseWriter, r *http.Request) {
	response := APIResponse{
		Status:  "success",
		Message: "System operational",
	}

	w.Header().Set("Content-Type", "application/json")

	// 1. Create an encoder tied directly to the network response stream
	encoder := json.NewEncoder(w)

	// 2. Encode the struct straight into the stream
	err := encoder.Encode(response)
	if err != nil {
		http.Error(w, "Failed to encode JSON", http.StatusInternalServerError)
	}
}
```
