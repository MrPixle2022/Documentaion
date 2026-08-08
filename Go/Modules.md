# Modules

go modules are a collection of packages, often declared using:

```bash
go mod init <root>
```

when using this command we get our selves a `go.mod` file that contain info about required dependencies, go version and module name.

for example if we create:

```bash
go mod init my_module
```

the `go.mod` file would have:

```go
module my_module
// for instance
go 1.26.3 //minimum version
```

as dependencies are added a `go.sum` file can be of great use, this file stores the cryptographic checksum of the module's dependencies ensuring their integrity.

both `go.mod` and `go.sum` must be committed with the repo.

---

## Packages

in go we have mainly 3 types of packages:

- built in (part of the std lib)
- 3rd party
- custom

for built in they are imported directly like `fmt`, `errors`, `time` and `sync`:

```go
import (
    "fmt"
    "time"
    "errors"
    "sync"
)
```

for 3rd party packages we require an module for a `go.mod` file and the using `go get` we can download them.

```go
import (
    pkg "github.com/someone/somePkg"
)
```

for importing 3rd party packages use their module name.

now for custom packages, for example if we have a module named `mod` and the following file structure:

```text
/
|-> go.mod
|-> main.go
|-> /pkg
    |-> pkg.go
```

the `package` for `pkg.go` will be named `pkg` and imported as `mod/pkg`.

also note that we can have multiple files sharing one package, but in this case their must be no naming conflict as all will be imported at the same time.

in go each **directory** can be considered it's own package, with the exception being `main` package as this marks that this file is to be an executable binary.

> [!NOTE]
> In go the main condition for visibility of the package content is the first letter case, any thing starting with a cap is considered a public, else it's private, hence all functions, structs and interfaces imported from any package all start in uppercase.

```bash
mkdir myPackage
cd myPackage
# the file in the package
touch myPackage.go
```

and in that file we add:

```go
package myPackage

import "fmt"

func PrintHello() {
    fmt.Println("Hello, Modules! This is mypackage speaking!")
}
```

this `PrintHello` can be imported in the main file using:

```go
import (
    "my_module/myPackage"
)
```

and can be used as:

```go
myPackage.PrintHello()
```

---

## Adding remote modules

we can add modules to our project using:

```bash
go get <module_url>
```

for example to add `cobra`:

```bash
go get github.com/spf13/cobra@latest
# target by branch
go get github.com/spf13/cobra@<branch-name>
# by commit hash
go get github.com/spf13/cobra@<commit-hash>
# by version
go get github.com/spf13/cobra@v<n>.<m>.<k>

# preferable, cleans the dependencies and imports
go mod tidy
```

having run both commands the `go.mod` file would have a new segment that looks as follows:

```go
module my_module

go 1.26

require (
    github.com/inconshreveable/mousetrap v1.0.0 // indirect
    github.com/spf13/cobra v1.7.0 // indirect
    github.com/spf13/pflag v1.0.5 // indirect
)
```

`indirect` comment means that this package was not referenced in code.

the `go get` can be used to install or update installed modules.

to specifically update a module use the `-u` option.

---

## Workspaces

using `go work` we can isolate some modules to work on them, we can add work and modify them without needing to alter the `go.mod`.

declare a new works space using:

```bash
go work init
```

this will create a `go.work` file in the current directory, we can add specific modules to this workspace by passing the path:

```bash
go work use ./my_module ./my_lib
```

in the `go.work` we would see:

```go
go 1.26.3

use (
    ./my_module
    ./my_lib
)
```

now using `go run`, `go build` or `go test` inside a workspace, the compiler will read the `go.work` rather then the `.mod` or `.sum`.

---

## Replace

the `replace` directive is used inside `go.mod` or as an option in the cli, it's purpose is to tell the compiler to ignore a package's path and instead use another one, often used with remote modules which have been forked or modified locally.

```go
replace github.com/username/myLib => ../myLib
```

this will use the local `myLib` instead of `github.com/username...`, the original name will still be used, but the content would be that of the `myLib` local module.

to do the same in the cli use:

```bash
# Inside your 'app' directory:
go mod edit -replace github.com/username/mylib=../mylib
```
