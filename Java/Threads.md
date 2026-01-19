<!-- @format -->

# Threads:

threads are process that allow application to run multiple process in parallel to one another.

we know that normally code runs in a cascading way, where the first to be called is the first to be executed, threads allows for multitasking by running process parallel to the application.

---

## Make objects into threads:

we can make objects into threads by extending the `Thread` class:

```java
public class A extends Thread{
  public void run(){
    /*what to execute on the thread*/
  }
}

A obj = new A();

obj.start(); //calls the `run` method
```

> [!NOTE] the `Thread` class implements the `Runnable` functional interface.

another way to create threads:

```java
Thread t1 = new Thread(Runnable obj);

t1.start();
```

for example:

```java
Runnable r = () -> {
  int x =0;
  while(x <= 1000){
    System.out.println("x: "+ x);
    x++;
    Thread.sleep(10);
  }
}
Thread t1 = new Thread(r);
t1.start();
```

---

## Schedular:

the `Schedular` is a part of the OS that is responsible for controlling and scheduling threads execution and resource sharing.

---

## Thread priority:

we can read a thread priority using:

```java
//obj from the very first example
obj.getPriority();
```

the value is 1 : 10, and is by default 5.

the higher the value the higher the priority

we can update the priority using:

```java
obj.setPriority(Thread.MAX_PRIORITY); //10
```

---

## Sleep(long ms):

the `Sleep` is a static method used to halt a thread for the given time in **milliseconds**, during this time the thread enter a waiting state.

note that the method also throws an `InterruptedException`

```java
class A extends Thread{
  public void run(){
    for(int i = 0; i <= 1000; i++){
      try{
        System.out.println("I: " + i);
      }
      catch(InterruptedException){
        System.out.println("interrupted the thread!");
      }
      Thread.sleep(100); //halt for 0.1s
    }
  }
}
```

---

## Join():

we can ask the main method to wait for the threads to finish by using the `join` method:

```java
t1.join();
```

---

## Synchronized:

the `synchronized` keyword is used on methods to make it so only one thread can execute this method at a time.

lets assume we have 2 threads, t1 and t2 and a method `increment` which increments value of `c` by `1` each call.

if we were to print the final value of `c` and both threads call the increment function in a for-loop that goes for 1000 iterations, then the final value of `c` is ...

random, that is because what happens is since the 2 threads started we jumped to the next line so we only got the value resulting from both threads during the time it took the compiler to run the next line.

you may assume that the solution is to use the `join` method and wait for both threads to finish, however we still don't get the expected value of `2000`, that is because when we try to execute the method there is a chance that both threads call it at the very same time, in this case both try to overwrite `c` to `c + 1` so if `c = 4` both threads try to reassign `c` to `5` so it's like one incrimination is happing.

the solution is actually using the `synchronized` keyword:

```java
public static int c = 0;
public synchronized void increment(){
  c++;
}
```

---

## Thread state:

on a thread creation it's in the `new` state, then it becomes `runnable` on calling `start`.

once it calls the `run` method and is actually running on the CPU it enters the `running` state.

then later we may want to pause the thread using either the `wait` and `sleep` methods in this case the thread enters the `waiting` state, we can go back using `notify` but it will return to being `runnable` not `running`.

lastly using `stop` we can send it into the `dead` state.
