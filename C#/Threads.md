# Threads

we can access data about the current working thread, thread id, process id and more via the `Process` and `Thread` classes:

```csharp
//gets the current process ID
var PID = Process.GetCurrentProcess().Id;
//gets the thread ID of the current running -main- thread
var TID = Thread.CurrentThread.ManagedThreadId;
Thread.CurrentThread.Name = "Main thread"; //good practice for debugging
//gets the processor ID (the core) the thread is running on
var processorId = Thread.GetCurrentProcessorId();
```

---

## New thread object

we create a thread by passing the method's reference to the `Thread` constructor

```csharp
//a method on object represent the process running on thread t1
var t1 = new Thread(wallet.RandomTransaction);
t1.Name = "Transaction thread1";
```

or also by passing the reference to a Thread starter object:

```csharp
Thread t2 = new(new ThreadStart(wallet.RandomTransaction));
t2.Name = "Transaction thread2";
```

even though we created the threads, they are in memory yet won't run, if we check:

```csharp
Console.WriteLine($"t1 State{t1.ThreadState}"); //Unstarted
```

because it has yet to start, to start the thread use `t1.Start()`:

```csharp
t1.Start(); //runs the thread process
```

---

## Bg and Fg threads

a thread can either be a **foreground** (default) thread, or a **background** thread:

- foreground: the app will resume until all foreground threads are destroyed
- background: the app will stop regardless wether they have ended or not

we can check this using:

```csharp
//false by default, foreground threads keep the application alive until they complete
Console.WriteLine($"is background thread: {t1.IsBackground}");
```

---

## Join

the `Join` method on a thread object is used to make the main thread wait for that thread to finish:

```csharp
t1.Join(); //main thread await t1 to complete
```

---

## Sleep

the `Sleep` is a static method that pauses the current running thread for the specified number of **milliseconds**:

```csharp
//pause for 1sec
Thread.Sleep(1000);
```

---

## Race condition

sometimes when multiple threads access the same value it may happen that they access it on the very same time, receiving the same value and editing it which may cause a lot of problems.

think of a bank account, a transfer from this account can't happen if the amount is greater then what is in the bank, seems logical, so let's say we have 30$ , 2 threads want to withdraw 20$ and 20$, you would assume that one of them would fail as there wouldn't be enough for one of the 2 to happen, but if by a mere coincidence the 2 threads read the amount at the very same time, both would read the amount as being **30$**, to both 30 is > 20, so they would subtract 20 and leave the amount **-10$**.

this is called a race condition, to avoid this we use the `lock` block:

```csharp
lock(referenceObject){
  /*
    accessible by 1v thread at a time
  */
}
```

to the `lock` we pass a reference object, this object becomes in accessible as long as a thread is accessing the object.

for example we can make a class that is responsible for handling the transfer, in the transfer method we can lock the account object so only one transaction can happen at a time.

---

## Deadlocks

some times when we `lock` multiple object, the threads will pause as each one is trying to access a locked resource and is waiting for the other thread to release it, this is called a `deadlock`.

to avoid a deadlock a common solution is to use `Monitor.TryEnter(lockObj, timeoutInMs)`:

```csharp
lock (account1)
{
  if (Monitor.TryEnter(account2, 1000))
  {
    try
    {
      account1.Withdraw(amount);
      account2.Credit(amount);
    }
    finally
    {
      //releases the lock
      Monitor.Exit(wallet2);
    }
  }
}
```

in this example we will try to `lock` the `account2`, after 1 second the operation fails and exits, if we were successful however the transaction would occur and the object will be released for the next thread inline.

---

## Thread Pool

threads usually have an overhead in time and memory, for this the `CLR` common-language-runtime has created a pool of pre-created reusable threads, this helps performance by reducing the number of threads.

```csharp
ThreadPool.QueueUserWorkItem(new WaitCallback(Print));

public static void Print(object? state){
  Console.WriteLine($"Bg: {Thread.CurrentThread.IsBackGround}");
  Console.WriteLine($"Pool: {Thread.CurrentThread.IsThreadPoolThread}");
}
```

pool threads are always **background** threads and are not nameable, they are ideal for short running processes.

also we can use the `Task.Run` method:

```csharp
Task.Run(
  () => Console.WriteLine("Using task");
);
```

we can `await` the return of the `Run`'s callback.
