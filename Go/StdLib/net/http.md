# HTTP package

the `net/http` is go's own http package that has almost all the things you need to built a backend server

---

## Server setup and routing

we can use the `http.Server` type to create a server, even though their exists the `http.ListenAndServe`, using the `http.Server` allows us more control over the server.

we can use the `http.ServerMux` which is go's built-in router that supports HTTP method matching and path parameters natively

```go
package main

import (
	"fmt"
	"net/http"
	"time"
)

func main() {
	mux := http.NewServeMux()

	// Registering routes
	mux.HandleFunc("GET /health", healthHandler)
	mux.HandleFunc("GET /users/{id}", getUserHandler)
	mux.HandleFunc("POST /users", createUserHandler)

	// Configure the server with safety timeouts
	server := &http.Server{
		Addr:         ":8080",
		Handler:      mux,
		ReadTimeout:  5 * time.Second,  // max time to read request headers/body
		WriteTimeout: 10 * time.Second, // max time to write response
		IdleTimeout:  15 * time.Second, // max time for keep-alive connection
	}

	fmt.Println("Server running on http://localhost:8080")
	if err := server.ListenAndServe(); err != nil {
		fmt.Printf("Server stopped: %v\n", err)
	}
}

func healthHandler(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusOK)
	w.Write([]byte("OK"))
}
```

for each end point we want we can use the `HandleFunc` and pass it a function that takes a `http.ResponseWriter` and a pointer to an `http.Request`, like in the previous code, we have multiple handlers defined after the main function

for routing we can:

- use the path only, this means that it accepts all methods
- define the method at the start, all caps, then a space as serration between the URL and the verb
- encapsulate dynamic path parameters using `{ }`

---

## Extracting parameters

we can extract different types of parameters form the request using the `http.Request` object, `r` as it's named in the previous code

### Path

to extract path parameters use `r.PathValue()` as pass it a string of the key's name, it will extract it:

```go
userID := r.PathValue("id") // Extract path parameter
```

### Query

to extract query parameters use the `r.URL.Query()`, we can chain to it the `Get` function, passing it the parameter name as a string, if the parameter was not found we get an empty string

we can also read the value without `Get` using `["keyname]`, this can be used to read multiple keys at once simply by `["k1", "k2"]`

```go
// GET /search?q=golang&limit=10
func searchHandler(w http.ResponseWriter, r *http.Request) {
	query := r.URL.Query().Get("q")        // Returns "" if missing
	limit := r.URL.Query().Get("limit")    // Returns "10"

	// For multiple values with the same key, e.g. ?tag=go&tag=web
	tags := r.URL.Query()["tag"] // []string{"go", "web"}
}
```

### Headers anc cookies

we can read headers using the `Header` object, then using `.Get` on it to get a specific header.

some headers as well have helpers that exists directly on the request object as we will see

fir cookies we can use `r.Cookie`

```go
func headerHandler(w http.ResponseWriter, r *http.Request) {
	// Read headers
	authHeader := r.Header.Get("Authorization")
	userAgent := r.UserAgent() // Helper method for User-Agent header

	// Read cookies
	cookie, err := r.Cookie("session_id") //cookie name
	if err != nil {
		// Cookie not found
	}

	_ = authHeader
	_ = userAgent
	_ = cookie
}
```

### Body

finally for body parameters we can't read them directly as it's a stream, it requires a decoder to be attached to it, something we can find in the `encoding/json` for example:

```go
type CreateUserRequest struct {
	Username string `json:"username"`
	Email    string `json:"email"`
}

func createUserHandler(w http.ResponseWriter, r *http.Request) {
	var req CreateUserRequest

	// Always limit body size to prevent Denial-of-Service attacks
	r.Body = http.MaxBytesReader(w, r.Body, 1048576) // 1MB limit

	dec := json.NewDecoder(r.Body)
	dec.DisallowUnknownFields() // Reject unexpected fields

	if err := dec.Decode(&req); err != nil {
		http.Error(w, "Invalid JSON payload", http.StatusBadRequest)
		return
	}

	fmt.Fprintf(w, "User %s created", req.Username)
}
```

---

## Writing responses

for writing responses we use the `http.ResponseWriter`, this has many function that we can make use of to writer headers and body of response

```go
type UserResponse struct {
	ID    string `json:"id"`
	Email string `json:"email"`
}

func jsonResponseHandler(w http.ResponseWriter, r *http.Request) {
	resp := UserResponse{ID: "usr_123", Email: "alex@example.com"}

	// 1. Set headers
	w.Header().Set("Content-Type", "application/json") //setting the header value

	// 2. Set HTTP Status (must be called BEFORE writing body)
	w.WriteHeader(http.StatusOK) //adding the header

	// 3. Encode body directly to ResponseWriter
	if err := json.NewEncoder(w).Encode(resp); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
	}
}
```

---

## Middlewares

middleware are `http.Handler` wrappers, they are function that execute code before/after each request, they are used for things like logs, authentication and CORS

to create a new middleware, create a function that returns an `http.Handler` and takes a `next` as a parameter of the same type `http.Handler`

```go
// Middleware signature: takes http.Handler, returns http.Handler
func LoggingMiddleware(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		start := time.Now()

		// Call the next handler in the chain
		next.ServeHTTP(w, r)

		fmt.Printf("[%s] %s %s took %v\n", r.Method, r.URL.Path, time.Since(start))
	})
}

```

as for using the middleware

```go
mux := http.NewServeMux()
mux.HandleFunc("GET /items", itemsHandler)
wrappedMux := LoggingMiddleware(mux)
http.ListenAndServe(":8080", wrappedMux)
```

---

## HTTP client

we can use http client to send http request from our codes to a certain API

the http package has the `http.DefaultClient` though it's not recommended to use, rather we are encouraged to define our own client to have more control over it

it's also important for clients to close the body using `.Body.Close()`, and drain the body if you won't read them

```go
package main

import (
	"context"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
	"time"
)

type GitHubUser struct {
	Login string `json:"login"`
	Name  string `json:"name"`
}

func FetchGitHubUser(ctx context.Context, username string) (*GitHubUser, error) {
	// 1. Create a custom client with explicit timeouts
	client := &http.Client{
		Timeout: 10 * time.Second,
	}

	// 2. Build the request with Context support for cancellation/deadlines
	reqURL := fmt.Sprintf("https://api.github.com/users/%s", username)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, reqURL, nil)
	if err != nil {
		return nil, fmt.Errorf("creating request: %w", err)
	}

	req.Header.Set("User-Agent", "Go-Application")
	req.Header.Set("Accept", "application/json")

	// 3. Execute request
	resp, err := client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("executing request: %w", err)
	}
	// 4. CRITICAL: Always close the body to avoid socket leaks
	defer resp.Body.Close()

	// 5. Check response status code
	if resp.StatusCode != http.StatusOK {
		// Read err body briefly for context
		bodyBytes, _ := io.ReadAll(io.LimitReader(resp.Body, 1024))
		return nil, fmt.Errorf("unexpected status %d: %s", resp.StatusCode, string(bodyBytes))
	}

	// 6. Decode payload
	var user GitHubUser
	if err := json.NewDecoder(resp.Body).Decode(&user); err != nil {
		return nil, fmt.Errorf("decoding response: %w", err)
	}

	return &user, nil
}
```

---

## Context propagation

context with HTTP is primarily used for cancellation signalling and request scoped values, carrying them through the call stack without polluting the function signature

it's recommended that you only pass a context as an argument and never a part of a struct, secondly use typed keys for `WithValue`

```go
package main

import (
	"context"
	"fmt"
	"net/http"
	"time"
)

// 1. Define custom, unexported types for context keys to prevent collisions
type contextKey string

const (
	userIDKey    contextKey = "userID"
	requestIDKey contextKey = "requestID"
)

// 2. Helper functions for type-safe context reading/writing
func WithUserID(ctx context.Context, userID string) context.Context {
	return context.WithValue(ctx, userIDKey, userID)
}

func GetUserID(ctx context.Context) (string, bool) {
	val, ok := ctx.Value(userIDKey).(string)
	return val, ok
}

// 3. Service layer using context propagation
type OrderService struct{}

func (s *OrderService) ProcessOrder(ctx context.Context, item string) error {
	// Extract user ID from context
	userID, ok := GetUserID(ctx)
	if !ok {
		return fmt.Errorf("unauthorized: missing user id in context")
	}

	// Simulate a slow database operation that listens for cancellation
	select {
	case <-time.After(2 * time.Second): // Normal work completes
		fmt.Printf("Order for item '%s' processed for user %s\n", item, userID)
		return nil
	case <-ctx.Done(): // Triggered if client closes connection early!
		fmt.Printf("Aborted order processing for user %s: %v\n", userID, ctx.Err())
		return ctx.Err()
	}
}

// 4. HTTP Handler
func handleOrder(w http.ResponseWriter, r *http.Request) {
	// Inject a mock User ID into the request context (simulating Auth middleware)
	ctx := WithUserID(r.Context(), "usr_9981")

	// Create service and pass the enriched context down
	service := &OrderService{}
	err := service.ProcessOrder(ctx, "MacBook Pro")

	if err != nil {
		if ctx.Err() == context.Canceled {
			// Client disconnected before completion
			http.Error(w, "Client closed connection", 499) // Client Closed Request
			return
		}
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
	w.Write([]byte("Order placed successfully"))
}
```
