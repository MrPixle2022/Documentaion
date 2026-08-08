# Go CLI

the `go` command is a versatile all-in-one tool, it can be used to initialize modules, run, build, test, format code and add/remove dependencies.

---

## mod

used to initialize a new module, it takes a name that represents the root, like for example:

```bash
go mod init com.my_project
```

the root of my module would be considered `com.my_project`.

```bash
go mod download
```

used to download modules to local cache without building

```bash
go mod graph
```

prints the module requirement graph.

```bash
go mod tidy
```

adds missing dependencies and removes unused ones

```bash
go verify
```

verifies that dependencies have their expected content

```go
go mod why
```

explains why packages/modules are needed

---

## get

the `get` is used to install, update and manage installed packages

```bash
go get <module_url>@none #remove it
go get <module_url>@latest #latest version
go get <module_url>@patch #latest patch
go get <module_url>@v<x.y.z >#install version x.y.z
go get <module_url>@<branch> #install latest commit to specific branch
go get <module_url>@<commit-hash> #install a specific commit
go get -u <module_url> #update
```
