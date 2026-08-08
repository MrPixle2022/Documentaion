# Sync

the `sync` built in package in go allows us to handle synchronizing concurrently-running part of the program.

it can be used to wait for some task to finish, lock some resource to avoid race condition and so on.

---

## Mutex

the `Mutes` is a struct used to lock some part of program's access, as to prevent race conditions.

the mutex can lock that using `mutex.Lock()` and unlocked using `mutex.Unlock()` functions.

```go
type SafeCounter struct {
	mu    sync.Mutex
	value int
}

func (c *SafeCounter) Increment() {
	c.mu.Lock()
	defer c.mu.Unlock()
	c.value++
}

func (c *SafeCounter) Value() int {
	c.mu.Lock()
	defer c.mu.Unlock()
	return c.value
}
```

in this example the `SafeCounter` when altered using either `increment` or `value` will lock the goroutine.

for goroutines that modify one piece of data or shared data, use a single `mutex` object across them all.

---

## RWMutex

a `RWMutex` is a more specific version of the `Mutex`, a regular `Mutex` locks goroutines from reading or writing, while an `RWMutex` can either deny both, or allow reading.

it basically ensures that only one goroutine can write while the other can read.

the `RWMutex` can use the `Lock` and `Unlock` functions, but it can also use the `RLock` and `RUnlock` for read-only locks.

```go
type SafeCounter struct {
	mu    sync.RWMutex
	value int
}

func (c *SafeCounter) Increment() {
	c.mu.Lock() //no read nor write
	defer c.mu.Unlock()
	c.value++
}

func (c *SafeCounter) Value() int {
	c.mu.RLock() //read-only
	defer c.mu.RUnlock()
	return c.value
}
```

---

## WaitGroup

a `WaitGroup` is a struct that contains a counter that resembles currently running goroutines that belong to it.

it ensures that the process continues only once all goroutines finish.

we till the wait group to pause using `Wait()`, while we can append an operation to the wait group by using `Add(1)` which tells it another operation will join the group, once this process finishes we decrement the counter using `Done()`.

---

## Once

the `sync.Once` is used to ensure that an action occurs only once.

for example say we have:

```go
type Database struct {
	connection string
}

var (
	dbInstance *Database
	once       sync.Once
)
```

we have an operation that must be done once, we can use the `Once.Do()` and pass it the function that will be done once:

```go
func getDatabaseInstance() *Database {
	once.Do(func() {
		dbInstance = &Database{
			connection: "Successfully connected to DB!",
		}
		fmt.Println("CRITICAL: Initialization run exactly once.")
	})
	return dbInstance
}
```

we share this `Once` object between goroutines, any goroutine that tries to use the `once.Do` when it has already happened, the `Do` will not run.
