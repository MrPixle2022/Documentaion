# Goroutines

concurrency allows an app to run multiple processes at once though not necessarily through parallel execution.

concurrency allows for a program to be split into multiple tasks all executing on a single core, the core switches back and forth between tasks, we describe this as **concurrent but not parallel**.

this is in contrast to parallel execution where each process takes up a cpu core, this is called **concurrent and parallel**.

to use goroutines just use `go` before a function call:

```go
go doSomeThing(); //goroutine
```

the thing is that the app will run the function in the background and just move on, it won't wait for the result of this function.

---

## Wait groups

a wait group is part of the built-in `sync` package, it allows us to tell the app to wait for goroutines to finish:

```go
import "sync"
```

then create a new group using:

```go
var wg = sync.WaitGroup{}
```

using this wait group we can make the app wait using `wg.Wait()` and tell the group the goroutine is done inside the goroutine function using `wg.Done()`

the `WaitGroup` has an internal counter, each `Done` takes away `1` and each `Wait` adds, hence when the counter = `0` it can deduce that all goroutines have finished so the app goes on.

---

## Mutex

using goroutines to modify data can cause a race-condition as it may happen that multiple functions try to modify the same memory address at once.

to overcome this we can create a `Mutex` which is part of the `sync` package as well.

```go
var m = sync.Mutex{}
```

about the part of the code where the race condition may happen -the data being modified- contain it between 2 function calls:

- `m.Lock()`
- `m.Unlock()`

the thing is such mutex locks the access for all goroutines expect the one accessing data now, even if all that is needed is reading the data not modifying it.

---

## RWMutex

a `RWMutex` or a read-write mutex function exactly the same, it has the same method but also has a `RLock` and `RUnlock`.

- `RLock` allows the data to be read, no writes
- `Lock` allows one goroutine to write and no one else can read or write
