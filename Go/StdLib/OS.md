# OS

the `os` package is used to:

- handle files
- work with directories
- read ans set env variables
- user permissions
- paths
- platform specifics
- signals
- error handling

---

## Reading files

the `os.Open` can be used to open a file **read-only**, it takes a `path` string returning both an `error` and a `*File` which is a struct that can be read from and written to.

```go
file, err := os.Open("data.txt")

if(err != nil){
    return
}
```

also we can get more control using `os.OpenFile`, like:

```go
file, err := os.OpenFile("log.txt", os.O_APPEND|os.O_WRONLY, 0644)
```

this function takes the `path`, file mode, and file permission.

for file mode we can use:

- os.O_RDONLY: readonly
- os.O_WRONLY: write only
- os.O_RDWR: write and read
- os.O_APPEND: append to end of file
- os.O_CREATE: create file

for unix-permissions use:

- 0666 read and write for all users
- 0600 read and write for owner only
- 0444 readable by everyone

the mod can be altered using `os.Chmod` passing it the path and the unix code in order:

```go
err := os.Chmod("text.txt", 0600)
//changes owner
err := os.Chown("text.txt", os.Getuid(), os.Getgid())
```

having ensured that the files was opened we can now read it's content.

it's generally recommended to initialize a `4k` byte slice as a buffer, this will store the data read by `file.Read`

```go
data := make([]byte, 4096)
//count is how many bytes were read
count, err := file.Read(data)

//reached end of line
if(err == io.EOF) return
```

the last step is how to convert the bytes into human-readable strings, for that we can use:

```go
fmt.Println(string(data[:count]))

// Line by line (import bufio)
scanner := bufio.NewScanner(file)
for scanner.Scan() {
  fmt.Println(scanner.Text())
}

// Read byte-by-byte
b, err := file.ReadByte()
for err == nil {
   fmt.Print(string(b))
   b, err = file.ReadByte()
}
```

> [!IMPORTANT]
> use `file.Close()` when done

if however the file is small an size use `ReadFile` which doesn't need to be closed.

also we can use `io.Copy` to copy a file.

```go
data, err := os.ReadFile("config.json")
//how many bytes were copied
n, err := io.Copy(dstFile, srcFile)
```

---

## Writing files

to write files use `File.Write`:

```go
data := []byte("Go is nice")
//count is number of bytes written
count, err := file.Write(data)
```

we can also use the `os.WriteFile`:

```go
//path, []byte, permission
err = os.WriteFile("config.json", newConfigData, 0644)
```

---

## Directory management

for managing directories the os has:

- Mkdir(): fails if path didn't exist
- MkdirAll(): creates the path if it doesn't exist

```go
err := os.Mkdir("logs", 0755)
if err != nil {
    fmt.Println(err)
}

err := os.MkdirAll("project/src/configs", 0755)
if err != nil {
    fmt.Println(err)
}
```

when it comes to reading directories use `ReadDir`:

```go
entries, err := os.ReadDir("project")
if err != nil {
    log.Fatal(err)
}

for _, entry := range entries {
    fmt.Println("Name:", entry.Name())
    fmt.Println("Is Directory?:",entry.IsDir())
}
```

to remove directories we can use:

- Moddir for empty directories only
- RemoveAll to clear any directory

```go
//fails if not empty
err := os.Moddir("logs")

//recursive deletion (erases all)
err := os.RemoveAll("project")
```

as for navigating directories we can use the `path/filepath` package specifically the `Walkdir` function.

it takes a `root` path -mostly the current position- and a function to handle the process of what to do with the files, and returns an error in case we want to `skip` or encountered an error.

```go
package main

import (
	"fmt"
	"io/fs"
	"os"
	"path/filepath"
)

func main() {
	root := "."

	err := filepath.WalkDir(root, func(path string, d fs.DirEntry, err error) error {
		if err != nil {
			return err
		}

		// Skip hidden directories
		if d.IsDir() && len(d.Name()) > 0 && d.Name()[0] == '.' {
			return filepath.SkipDir
		}

		// Process only .go files
		if !d.IsDir() && filepath.Ext(path) == ".go" {
			info, _ := d.Info()
			fmt.Printf("Found Go file: %s (%d bytes)\n", path, info.Size())
		}

		return nil
	})

	if err != nil {
		fmt.Println("Walk error:", err)
	}
}
```

---

## IO.Reader & Writer

the `io.Reader` and `io.Writer` interfaces are used to define the entire go composable I/O ecosystem.

the `Reader` requires a single method of `Read` with the following signature:

```go
func Read(p []byte) (n int, err error);
```

this can be used -for example- to create a function that can use any reader:

```go
func processReader(r io.Reader) error {
	buf := make([]byte, 1024)

	for {
		n, err := r.Read(buf)
		if n > 0 {
			// Process data
			fmt.Printf("Processed %d bytes\n", n)
		}

		if err == io.EOF {
			return nil // Normal end of stream
		}
		if err != nil {
			return err // Actual error
		}
	}
}
```

---

## Env vars

we can read, set environment variables using the os package:

```go
//val == "" if key doesn't exist
val := os.Getenv("key")

//boolean check if the key exist
exists := os.LookupEnv("key")

//sets the env variables
os.Setenv("key", someVlaue)
//deletes the env var
os.Unsetenv("key")

//returns a string slice containing all evn vars
env := os.Environ()
```

---

## Metadata

we can use `os.Stat` on a path to get it's metadata without opening it:

```go
//info of type os.FileInfo (interface)
info, err := os.Stat("report.pdf")

fmt.Println("File Name:", info.Name())
fmt.Println("Size in Bytes:", info.Size())
fmt.Println("Permissions:", info.Mode())
fmt.Println("Last Modified:", info.ModTime())
fmt.Println("Is Directory:", info.IsDir())
```

or we can get more specific info about the os:

```go
//returns the current directory
os.GetWd()
//returns the home directory of the current user
home, err := os.UserHomeDir()
//changes the working directory
os.Chdir(home)
//returns the tmp directory
os.TempDir()
```

all of the above return the directory as well as an error.

---

## Process and program lifecycle

we can get the `args` passed to the program, process id of the app, find processes, create ones ...:

```go
pid := os.Getpid()
fmt.Println("Current Process ID:", pid)

args := os.Args
fmt.Println("Total arguments passed:", len(args))
fmt.Println("Program Path:", args[0])

if len(args) < 2 {
    fmt.Println("Error: Missing required argument.")
    os.Exit(1)
}

fmt.Println("Argument received:", args[1])
os.Exit(0)
```
