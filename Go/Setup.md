# Setup

install the go language from the official website, the create a new module using:

```bash
go mod init <module_name>
```

the `module name` will resemble the root of our project, this is often used with github repos, it doesn't really do anything except setting the module root name.

this will create a `go.mod` this file contains the go version, dependencies adn their version, basically it's the `package.json` of go.

now we create a new `.go` file of any name we want to resemble our entry-point.

for this entry point define:

```go
package main

func main(){

}
```

we can run this project using:

```bash
go run <path_to_file>
```
