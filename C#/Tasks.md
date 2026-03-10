# Tasks

the `Task`/`Task<T>` classes are used to define async operations that utilizes the `ThreadPool`.

- Task -> running tasks
- Task\<T> -> running tasks with return value

```csharp
Task.Run(
  () => Console.WriteLine("Hello from a Task!")
);

Task<DateTime> taskWithResult = Task.Run(() => DateTime.Now);
```

---

## Task vs Thread

comparing Tasks vs thread shows the following:

1. Level: Tasks are high level compared to the low level thread
1. return value: a task can return data while the thread can't
1. chainable: threads are chainable unlike threads
1. exceptions: thread propagate errors, they rise in the call stack until caught unlike threads
1. Cancellation: a task can be cancelled unlike a thread

---

## Task result

a task's result can be accessed in multiple ways:

```csharp
// --------- method 1 ------------
Console.WriteLine(taskWithResult.Result);

// --------- method 2 ------------
taskWithResult.GetAwaiter().GetResult();

// --------- method 3 ------------
taskWithResult.GetAwaiter().OnCompleted(() =>
{
  System.Console.WriteLine("Task completed via awaiter!");
  System.Console.WriteLine(taskWithResult.Result);
});

// --------- method 4 ------------
taskWithResult.ContinueWith((t) =>
{
  System.Console.WriteLine("Task completed via ContinueWith!");
  System.Console.WriteLine(t.Result);
}).Wait();
```

the disadvantage of those ways is that they block the main thread until the task is finished.,

---

## Async await

to ease the way we handle tasks and to avoid writing huge amounts of code as in the case of the previous examples, we can use `async/await`, mark a method `async` to till the compiler that this method may take time to finish, in this case the method must return `Task` if the return is void or `Task<T>` to define a type.

```csharp
async Task<string> PrintSomethingAsync()
{
  await Task.Delay(1000);
  return "Hello, World!";
}
```

calling the method will start it and return an in-complete task object, to get the final result use `await`:

```csharp
var promise = PrintSomethingAsync();
/*
code here executes while the task still runs
*/
var result = await promise; //execution waits here -thread is not blocked-
```

> [!TIP]
> to use `await` in the main method make it `async Task`.

---

## Cancellation token

a `cancellation token` is used as a way to stop a task mid-process.

```csharp
CancellationTokenSource tokenSource = new();
var token = tokenSource.Token;
```

the `token` can be passed to different task methods as a second argument like `Task.Delay`.

at any point we can simply use the `tokenSource.Cancel` and end all tasks using the token.

---

## Combinators

combinators allow us to combine a sequence of tasks, they include `WhenAny` which yields the `Task` object of the first task to finish, while `WhenAll` returns a `Task[]` or `Task<T[]>`.

```csharp
Task<string> task1 = GetRoomStatusAsync(101);
Task<string> task2 = GetRoomStatusAsync(102);
Task<string> task3 = GetRoomStatusAsync(103);

// This returns Task<string[]>
string[] results = await Task.WhenAll(task1, task2, task3);
//waits for the first one to finish
Task<string> finishedTask = await Task.WhenAny(task1, task2);
```

we can await the combinator's return object to get the result immediately.
