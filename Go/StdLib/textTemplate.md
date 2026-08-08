# Text/Template

the `text/template` package is used to define a reusable string structure for dynamic strings.

---

## New

`New` is used to define a new allocated string template, returns the a pointer to the `Template` struct.

```go
//name
temp := template.New("template")
//sets the template
temp, err := temp.Parse("Value is {{.}}")
t2 := template.Must(temp.Parse("value: {{.}}")) //panics on failure
```

we can write the output of the template using `temp.Execute`, passing it the `io.Writer`, then the value that are to be inserted.

---

## Actions

the `template package` replaces each `{{ }}` by a value, but inside them we can additional keywords to have more control over the string generated.

- `.` replace by any value

```go
"value: {{.}}"
```

- `.Field` replace by a specific field -field in this case-

```go
"value of name: {{.Name}}"
```

- `if . -` and `else . -` if value is considered false -equals the type's zero value-, can also work on specific fields

```go
//first if isAdmin is not empty writes `admin`
//if not then does the same with `Email` if not-empty writes `userEmail`
//else writes none and ends
"{{if .IsAdmin}} admin {{else if .Email}} userEmail {{else}} none {{end}}"
```

we can also use some functions like `le`, `gt` and `ge` or logical ones like `and`, `or` and `not`:

```go
"{{ if gt .Score 50 }}You passed!{{ end }}"
```

- `{{range}}` loops over slices, maps, arrays & channels

```go
// will write each element individually with `->` beforehand
"{{range .}} -> {{.}} {{end}}"
```

we can also capture some variables inside the string by using `$` beforehand:

```go
"{{ range $index, $element := .}} -> @index {{$index}}, @value: {{$element}} {{end}}"
```

- `{{- }}` and `{{ -}}` trims the spaces from start, end in order
