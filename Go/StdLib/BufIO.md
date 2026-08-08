# BufIO

the `bufio` package aids in read/write operations on input/output streams in a more efficient way.

buffers simply work by reading a big chunk of bytes rather then byte by byte reading.

---

## Scanner

when handling line by line inputs, as in the case with reading data from files or getting input from terminal, we can use the `scanner` which wraps around `io.Reader`s like `os.Stdin` or files reading them one token at a time using an under-hood buffer for speed.

```go
package main
import (
    "bufio"
    "fmt"
    "os"
)
func main() {
    //initialize the scanner
    scanner := bufio.NewScanner(os.Stdin)
    fmt.Println("What's your name?")

    //reads the line
    if scanner.Scan() {
        //returns the result as a string
        fmt.Printf("Hello, %s!\n", scanner.Text())
    }

    //if error occurs
    if err := scanner.Err(); err != nil {
        fmt.Println("Error reading input:", err)
    }
}
```

---

## Reader

the `Reader` is used to read files line-by-line:

```go
package main
import (
    "bufio"
    "fmt"
    "os"
)
func main() {
    file, err := os.Open("largefile.txt")
    if err != nil {
        fmt.Println("Error opening file:", err)
        return
    }
    defer file.Close()
    //defines a new reader attaching it to the file stream
    reader := bufio.NewReader(file)
    for {
        // reads a line as a string
        line, err := reader.ReadString('\n')
        if err != nil {
            break
        }
        fmt.Print(line)
    }
}
```

---

## Writer

for output streams use a `Writer`:

```go
package main
import (
    "bufio"
    "fmt"
    "os"
)
func main() {
    file, err := os.Create("output.txt")
    if err != nil {
        fmt.Println("Error creating file:", err)
        return
    }
    defer file.Close()
    writer := bufio.NewWriter(file)
    writer.WriteString("Hello, Go with Buffered Output!\n")
    writer.Flush() // Don't forget to flush!
}
```

the `Flush` ensures that the write buffer is emptied when done
