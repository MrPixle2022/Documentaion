# Context.md

the `context` package of the standard library is used to further control goroutines and concurrency, it can be used to propagate cancellation, values and deadlines.

---

## WithTimeout

the `WithTimeout` can be used to initialize a root context with a max waiting time.

this function returns the `context` and a `cancel` function which should be used when done with the context.

the cancel can also be used to force-cancel the context and abort any task using it.

```go
import (
    "context"
    "fmt"
    "time"
)

func main(){
    //2-second timeout
    ctx, cancel := context.WithTimeout(context.Background(), 2 * time.Second);
    defer cancel()
}
```

this context object can be given to goroutines:

```go
func slowDatabaseQuery(ctx context.Context) {
	select {
	case <-time.After(5 * time.Second):
		// This simulates the query finishing normally
		fmt.Println("Query finished successfully!")
	case <-ctx.Done():
		// This triggers if the 2-second timeout happens first
		fmt.Println("Query aborted:", ctx.Err())
	}
}
```

the `Done` function on the `context.Context` type returns a chanel which after the timeout is done is closed.

---

## WithDeadline

the `WithDeadline` is ued to set the canceling at some time, like saying 3:14pm.

```go
deadlineCtx, cancelDeadline := context.WithDeadline(rootCtx, time.Now().Add(1*time.Second))
defer cancelDeadline()
```

---

## WithCancel

the `WithCancel` is used to define a context which is manually cancelled

```go
ctx, cancelFunc := context.WithCancel(context.Background())
```

the `cancelFunc` can be executed to halt any goroutine running -provided it uses the context and checks the `Done()` chanel.

---

## WithValue

the `WithValue` is used to add a value to the context as a key-value pair:

```go
ctx := context.WithValue(context.Background(), "id", 12);
```

the value of this context can be retrieved using `ctx.Value()` but type assertion is required here.

```go
id := ctx.Value("id").(int)
```

---

## Combining context

the context can be used to create a hierarchy of context, by replacing the `context.Background()` by another context object we create a new context based of that object, for example:

```go
//the basis object
rootCtx := context.WithValue(context.Background(), "id", 1231)

//deadline after 1 minutes
deadlineCtx, cancelDeadline := context.WithDeadline(rootCtx, time.Now().Add(1 * time.Minute))

//cancel context
cancelCtx, cancelFunc := context.WithCancel(rootCtx)
```

now when a task needs the value `id` and we want to give a `1-minute` room, use `deadlineCtx`, or if we want to manually cancel it use `cancelCtx`.
