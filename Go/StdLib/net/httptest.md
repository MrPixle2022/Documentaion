# Http test

the `net/http/httptest` package is go's included solution to test http projects, it can be used to mock servers, requests and clients

---

## NewRequest and NewRecorder

the package includes functions like `NewRequest` and `NewRecorder` to mock requests and response writers

suppose we have the following HTTP handler function

```go
package main

import (
	"encoding/json"
	"net/http"
)

type User struct {
	ID   string `json:"id"`
	Name string `json:"name"`
}

func GetUserHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodGet {
		http.Error(w, "Method not allowed", http.StatusMethodNotAllowed)
		return
	}

	user := User{ID: "123", Name: "Alice"}

	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(user)
}
```

we want to test that the handler works as expected, we will create a new test file, declare a new request using `NewRequest` and a new mock response writer using `NewRecorder`

the `NewRequest` takes the method, target path and the body in this order

```go
package main

import (
	"encoding/json"
	"net/http"
	"net/http/httptest"
	"testing"
)

func TestGetUserHandler(t *testing.T) {
	// 1. Create a simulated HTTP request
	req := httptest.NewRequest(http.MethodGet, "/user", nil)

    // appending a path value
    req.SetPathValue("id", "123")

    // setting a new context
    ctx := context.WithValue(req.Context(), "role", "admin")

	// 2. Create a ResponseRecorder to record the handler's response
	rec := httptest.NewRecorder()

	// 3. Directly call the handler
	GetUserHandler(rec, req.WithContext(ctx))

	// 4. Inspect the recorded response
	res := rec.Result()
	defer res.Body.Close()

	// Assert Status Code
	if res.StatusCode != http.StatusOK {
		t.Errorf("expected status 200 OK, got %d", res.StatusCode)
	}

	// Assert Content-Type Header
	contentType := res.Header.Get("Content-Type")
	if contentType != "application/json" {
		t.Errorf("expected Content-Type application/json, got %s", contentType)
	}

	// Assert Response Body
	var user User
	if err := json.NewDecoder(res.Body).Decode(&user); err != nil {
		t.Fatalf("failed to decode response body: %v", err)
	}

	if user.ID != "123" || user.Name != "Alice" {
		t.Errorf("unexpected body content: %+v", user)
	}
}
```

---

## NewServer

we can mock external servers using `NewServer` function:

```go
func TestExternalAPICall(t *testing.T) {
	// 1. Start a local mock server
	mockServer := httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		// Mock the third-party endpoint response
		w.WriteHeader(http.StatusOK)
		w.Write([]byte(`{"status": "success"}`))
	}))
	defer mockServer.Close() // Clean up when the test finishes

	// 2. Pass mockServer.URL into the code under test
	resp, err := http.Get(mockServer.URL + "/v1/charge")
	if err != nil {
		t.Fatalf("failed to make request to mock server: %v", err)
	}
	defer resp.Body.Close()

	if resp.StatusCode != http.StatusOK {
		t.Errorf("expected 200 OK, got %d", resp.StatusCode)
	}
}
```
