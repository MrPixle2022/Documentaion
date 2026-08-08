# Setup

for testing the built-in `testing` package includes all that we need, for testing in go, test files end in `_test.go`, each testing function starts with the prefix `Test` and takes a `*testing.T` as it's first parameter.

for example, let's assume we have 2 function to test:

```go
package calculator

func Add(a, b int) int {
    return a + b
}

func Subtract(a, b int) int {
    return a - b
}
```

we can write a test case as follows:

```go
package calculator

import "testing"

func TestAdd(t *testing.T) {
    x, y := 5, 3
    expected := 8
    result := Add(x, y)

    if result != expected {
        //failure message
        t.Errorf("Add(%d, %d) = %d; expected %d", x, y, result, expected)
    }
}

func TestSubtract(t *testing.T) {
    x, y := 5, 3
    expected := 2
    result := Subtract(x, y)

    if result != expected {
        t.Errorf("Subtract(%d, %d) = %d; expected %d", x, y, result, expected)
    }
}
```

we can run a test using one of the following:

```bash
go test ./...  ## Run tests in current and subdirectories
go test -v     ## Verbose output
go test -cover ## Show code coverage
```

---

## Errors

we can use mainly 2 types of error found on the `testing.T` in our test function:

- `Errorf`: report an error without stopping the test
- `Fatal`: stop the test immediately
- `Fatalf`: report an error and stop at this current state

---

## Test coverage

test coverage tracks the percentage of code that the tests have run, it's essential to monitor for blind spots in our tests and so on, in go this can be monitored using:

```bash
go test -coverprofile=coverage.out
# view in the browser
go tool cover -html=coverage.out
```

---

## HttpTest

the `net/http/httptest` library is part of Golang's standard package, it can be used to test many things like request, clients and so on.

it provides many useful type such as:

- `httptest.Server` -> simulates an http server
- `httptest.RoundTripper` -> used for low-level client logic and testing network/timeout error without opening network sockets

### Mocking http servers

we can use the `httptest.Server` to create a lightweight HTTP server on a random loopback port, we can point our HTTP client to it using the `URL` property.

let's assume we have the following struct that resembles a user:

```go
type User struct {
	ID   int    `json:"id"`
	Name string `json:"name"`
}
```

the following function fetches the users, which is gonna be the focus of our tests:

```go
func FetchUser(baseURL string, userID int) (*User, error) {
	client := &http.Client{Timeout: 5 * time.Second}
	resp, err := client.Get(baseURL + "/users")
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()

	var u User
	if err := json.NewDecoder(resp.Body).Decode(&u); err != nil {
		return nil, err
	}
	return &u, nil
}
```

we can create a test function called `TestFetchUser`, inside this function we would:

1. mock the server by using `httpTest.NewServer`, this function expects an `http.HandlerFunc` which will also take the handler:

```go
server := httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
    // Assert request details
    if r.Method != http.MethodGet {
        t.Errorf("expected GET, got %s", r.Method)
    }
    if r.URL.Path != "/users" {
        t.Errorf("expected path /users, got %s", r.URL.Path)
    }

    // Write mock response
    w.Header().Set("Content-Type", "application/json")
    w.WriteHeader(http.StatusOK)
    json.NewEncoder(w).Encode(User{ID: 42, Name: "Alice"})
}))
defer server.Close() // Clean up server after test
```

2. call the function, passing it the needed parameters:

```go
user, err := FetchUser(server.URL, 42)
```

3. finally we can assert the results

```go
if err != nil {
    t.Fatalf("unexpected error: %v", err)
}
if user.Name != "Alice" {
    t.Errorf("expected Alice, got %s", user.Name)
}
```
