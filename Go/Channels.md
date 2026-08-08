# Channels

channels allow goroutines to pass around data, they are heap-allocated as we define them using the `make` function.

channels are thread-safe, hence we won't have to worry about race-conditions.

define a chanel using

```go
c := make(chan int); //a chanel that shares a single int value
close(c); //closes the chanel
```

we can add and extract values from the chanel using `<-`:

```go
c <- 12; //adds 12 to the chanel
<-c; //pops 12 from the chanel, now it's empty
```

what we have created is called an `unbuffered chanel` it's a chanel with `0 capacity`.

for that very reason the receiver and sender **must** meet at the exact same time, or else it's blocked until this happens, so the following code will not run:

```go
func main(){
    c := make(chan int);
    c <- 10;
    d := <-c;
    fmt.Println(d);
}
```

why? because of the line of pushing the value to the chanel. we created an unbuffered chanel, hence we must send and receive the data at the same time, so the chanel blocks the code.

for this to work we can use a goroutine:

```go
func main() {
    c := make(chan int) // Unbuffered

    go func() {
        c <- 10
    }()

    d := <-c
    fmt.Println(d)
}
```

closed channels are **read-only** we can still read there data but we can't send more.

```go
package main

import "fmt"

func main() {
	// Create a buffered channel and pack it with data
	ch := make(chan int, 2)
	ch <- 10
	ch <- 20

	// Close the channel—no more data can be sent!
	close(ch)

	// Read the remaining values out of the closed channel
	val1, ok1 := <-ch
	fmt.Printf("Read 1: %d, Open: %t\n", val1, ok1) // Prints: 10, true

	val2, ok2 := <-ch
	fmt.Printf("Read 2: %d, Open: %t\n", val2, ok2) // Prints: 20, true

	// NOW the channel is completely empty (drained)
	val3, ok3 := <-ch
	fmt.Printf("Read 3: %d, Open: %t\n", val3, ok3) // Prints: 0, false
}
```

---

## Range with a chanel

say we have a goroutine that loops, and each loops pushes a value into the unbuffered channel, in this case each value will block the goroutine until it's read, so the receiver will have to read each and every value.

seems simple enough just use a `for loop`, but how many?, will we can use `range` with channels and not worry about this.

```go
func main(){
    //initialize the
    c := make(chan int)
    //define the anonymous goroutine
    go func(){
        defer close(c);
        for i := range 11{
            c <- i;
        }
    }();

    for i := range c{
        fmt.Println(i);
    }
}
```

it's important to close the `chanel` here as if we don't the main function will await a new value to be pushed to the chanel as the chanel is still active, hence we must close it.

channels actually has a second `ok` value, for wether the channel is still open or not, closed channels return the `zero-value of their type`

```go
val, ok := <-ch
if !ok {
    fmt.Println("The channel is closed and empty!")
}
```

---

## Buffered channels

a buffered channel has a capacity, this channel won't block until it's full, and since the unbuffered chanel had a capacity of `0` the blocking behavior should make more since.

define an unbuffered channel using:

```go
//5 is the max capacity
c := make(chan int, 5);
```

---

## Select with channels

when a function listens to multiple channels we can use a select statement to control the behavior that happens when channel x has a new value and when y has a new value:

```go
func listenToChannels(c1 chan string, c2 chan int){
    select{
        case msg1 := <- c1:
            //some code
        case msg2 := <-c2:
            //some other code
        case <-time.After(1 * time.Second):
            fmt.Println("timeout bois");
    }
}
```

the `select` blocks until a ces wins, the `time.After` defines how long to wait for each case before moving on.

a `default` case can also be used to avoid chanel-blocking behavior, for example:

```go
select{
    //receive
    case msg := <- messageChanel:
        //some code
    default:
        fmt.Println("received nothing")
}
//somewhere else
select{
    case messageChanel <- val:
        //some code
    default:
        fmt.Println("can't write to channel");
}
```

if no value is received through the `messageChanel` we would go to the `default` case.

the `default` doesn't wait, if no value is ready it exits, it checks if the chanel is ready to receive or accept data or not, also if we have multiple cases for multiple ready channels one would be picked at random.

---

## Chanel direction

when passing a chanel of type `T` to a function, we can be more specific, wether let the function only receive data from the chanel, only write, or do both.

- chan T: regular, read and write
- chan<- T: send only, no writes
- <-chan T: only receive
