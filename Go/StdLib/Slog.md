# Slog

the `log/slog` package provides structured logging in go, this package exports a default `Logger` which is the frontend of our logs providing high-level methods such as: `Info` & `Error` and so on.

also we have `Record`s which are representation of self-contained logs created by a `Logger`.

a `Handler` is an interface that control the formatting and destination of each `Record`, the `log/slog` includes 2 of these by default being `TextHandler` and `JSONHandler`.

---

## New Logger

to create a new logger use the `slog.New` function, provide the function with a handler and it returns a reference to the logger:

```go
func main() {
    //slog.NewJSONHandler(io.Writer, *slog.HandlerOptions)
    logger := slog.New(slog.NewJSONHandler(os.Stdout, nil))
    logger.Debug("Debug message")
    logger.Info("Info message")
    logger.Warn("Warning message")
    logger.Error("Error message")
}
```

the result of these would look something like:

```json
{"time":"2023-03-15T12:59:22.227408691+01:00","level":"INFO","msg":"Info message"}
{"time":"2023-03-15T12:59:22.227468972+01:00","level":"WARN","msg":"Warning message"}
{"time":"2023-03-15T12:59:22.227472149+01:00","level":"ERROR","msg":"Error message"}
```

we can also use this new logger as `slog`'s default using `slog.SetDefault`:

```go
slog.SetDefault(logger)
slog.Info("Info message")
```

---

## Adding context attributes

we can provide additional context to our logs, this can be valuable for troubleshooting and so on.

```go
logger.Info(
  "incoming request", //msg
  "method", "GET", //method: GET
  "time_taken_ms", 158,//time_taken_ms: 158
  "path", "/hello/world?q=search",
  "status", 200,
  "user_agent", "Googlebot/2.1 (+http://www.google.com/bot.html)",
)
```

this works with all log levels.

also we can a strongly-typed contextual attribute:

```go
logger.Info(
    "incoming request", //msg
    slog.String("method", "GET"), //method: GET (and so on)
    slog.Int("time_taken_ms", 158),
    slog.String("path", "/hello/world?q=search"),
    slog.Int("status", 200),
    slog.String(
    "user_agent",
    "Googlebot/2.1 (+http://www.google.com/bot.html)",
    ),
)
```

for even tighter control and more type-safety use `LogAttrs`, this function takes a `context`, `log level`, `msg` and as many attributes as you might need:

```go
logger.LogAttrs(
  context.Background(),
  slog.LevelInfo,
  "incoming request",
  slog.String("method", "GET"),
  slog.Int("time_taken_ms", 158),
  slog.String("path", "/hello/world?q=search"),
  slog.Int("status", 200),
  slog.String(
    "user_agent",
    "Googlebot/2.1 (+http://www.google.com/bot.html)",
  ),
)
```

---

## Grouping contextual attributes

the `slog.Group` is useful for grouping related attributes together:

```go
logger.LogAttrs(
  context.Background(),
  slog.LevelInfo,
  "image uploaded",
  slog.Int("id", 23123),
  slog.Group("properties",
    slog.Int("width", 4000),
    slog.Int("height", 3000),
    slog.String("format", "jpeg"),
  ),
)
```

the output would look like:

```json
{
    "time": "2023-02-24T12:03:12.175582603+01:00",
    "level": "INFO",
    "msg": "image uploaded",
    "id": 23123,
    "properties": {
        "width": 4000,
        "height": 3000,
        "format": "jpeg"
    }
}
```

for when using `TextHandler` it would look like:

```bash
time=2023-02-24T12:06:20.249+01:00 level=INFO msg="image uploaded" id=23123 properties.width=4000 properties.height=3000 properties.format=jpeg
```

---

## Child loggers

child loggers can be used to create loggers that have a context that inherits from the parent logger's context.

```go
handler := slog.NewJSONHandler(os.Stdout, nil)
buildInfo, _ := debug.ReadBuildInfo()

logger := slog.New(handler)

child := logger.With(
    slog.Group("program_info",
        slog.Int("pid", os.Getpid()),
        slog.String("go_version", buildInfo.GoVersion),
    ),
)
```

the `logger.With` takes the attributes that will be included with the child logger without needing explicit adding:

```go
child.Info("image upload successful", slog.String("image_id", "39ud88"))
child.Warn(
    "storage is 90% full",
    slog.String("available_space", "900.1 mb"),
)
```

using the previous snippet we would get something like:

```json
{
  "time": "2023-02-26T19:26:46.046793623+01:00",
  "level": "INFO",
  "msg": "image upload successful",
  "program_info": {
    "pid": 229108,
    "go_version": "go1.20"
  },
  "image_id": "39ud88"
}
{
  "time": "2023-02-26T19:26:46.046847902+01:00",
  "level": "WARN",
  "msg": "storage is 90% full",
  "program_info": {
    "pid": 229108,
    "go_version": "go1.20"
  },
  "available_space": "900.1 MB"
}
```

also we can make a new child logger whose attributes are all joint under a single group using `WithGroup`:

```go
handler := slog.NewJSONHandler(os.Stdout, nil)
buildInfo, _ := debug.ReadBuildInfo()
logger := slog.New(handler).WithGroup("program_info")

child := logger.With(
  slog.Int("pid", os.Getpid()),
  slog.String("go_version", buildInfo.GoVersion),
)

child.Warn(
  "storage is 90% full",
  slog.String("available_space", "900.1 MB"),
)
```

```json
{
    "time": "2023-05-24T19:00:18.384136084+01:00",
    "level": "WARN",
    "msg": "storage is 90% full",
    "program_info": {
        "pid": 1971993,
        "go_version": "go1.20.2",
        "available_space": "900.1 mb"
    }
}
```

---

## Custom Log levels

by default log levels in slog are:

- Debug -4
- Info 0
- Warn 4
- Error 8

this is made so that we can make custom levels in between another 2, for example a level between `Debug` and `Info` can have level 1, 2 or 3.

creating a new level for a logger is done through the `HandlerOptions` struct, the logger's handler takes a reference to one:

```go
func main() {
    opts := &slog.HandlerOptions{
        Level: slog.LevelDebug,
    }

    handler := slog.NewJSONHandler(os.Stdout, opts)

    logger := slog.New(handler)
    logger.Debug("Debug message")
    logger.Info("Info message")
    logger.Warn("Warning message")
    logger.Error("Error message")
}
```

and we get the output:

```json
{"time":"2023-05-24T19:03:10.70311982+01:00","level":"DEBUG","msg":"Debug message"}
{"time":"2023-05-24T19:03:10.703187713+01:00","level":"INFO","msg":"Info message"}
{"time":"2023-05-24T19:03:10.703190419+01:00","level":"WARN","msg":"Warning message"}
{"time":"2023-05-24T19:03:10.703192892+01:00","level":"ERROR","msg":"Error message"}
```

also we can make the minimum level dynamically vary using `LevelVar`:

```go
func main() {
    logLevel := &slog.LevelVar{} // INFO

    opts := &slog.HandlerOptions{
        Level: logLevel,
    }

    handler := slog.NewJSONHandler(os.Stdout, opts)
}
```

this level can be changed using:

```go
logLevel.Set(slog.LevelDebug)
```

custom levels can also be defined using types that implement the `Leveler` interface, those types must have a `Level` function that returns a `Level`, or simply use the `slog.Level`:

```go
const (
    LevelTrace  = slog.Level(-8)
    LevelFatal  = slog.Level(12)
)
```

those custom levels are usable only through `Log` ro `LogAttrs`:

```go
opts := &slog.HandlerOptions{
    Level: LevelTrace,
}

logger := slog.New(slog.NewJSONHandler(os.Stdout, opts))

ctx := context.Background()
logger.Log(ctx, LevelTrace, "Trace message")
logger.Log(ctx, LevelFatal, "Fatal level")
```

the output of these logs would be:

```json
{"time":"2023-02-24T09:26:41.666493901+01:00","level":"DEBUG-4","msg":"Trace level"}
{"time":"2023-02-24T09:26:41.666602404+01:00","level":"ERROR+4","msg":"Fatal level"}
```

but notice the level is decided with respect to the default, we don't want that, we want both to log their specific level as a string, for that define the `ReplaceAttr` function on the `HandlerOption` of our logger:

```go
. . .

var LevelNames = map[slog.Leveler]string{
    LevelTrace:      "TRACE",
    LevelFatal:      "FATAL",
}

func main() {
    opts := slog.HandlerOptions{
        Level: LevelTrace,
        ReplaceAttr: func(groups []string, a slog.Attr) slog.Attr {
            if a.Key == slog.LevelKey {
                level := a.Value.Any().(slog.Level)
                levelLabel, exists := LevelNames[level]
                if !exists {
                    levelLabel = level.String()
                }
                a.Value = slog.StringValue(levelLabel)
            }
            return a
        },
    }
}
```

let's explain this big chunk of code, first the `ReplaceAttr` method can be used to replace an attribute both key and value, but here we only concern ourselves with a value, first we check if the attribute we are targeting is the `slog.KeyLevel` aka the `level` of the log, then we extract the value, first as an any type then we manually cast it into a `slog.Level` type, after that we extract the corresponding label from our map to that very level, if the value doesn't exist we reuse the original value from the attribute, and if not then it will already be assigned as the return from the map.

the last step is using `StringValue` to convert the regular string value into a type that slog can handle, assign it to the attribute and return the final version.

for the `groups` is a slice containing each group name, so for example:

```json
{
    "g1": {
        "g2": {}
    }
}
```

the `groups` would contain `g1` and `g2`.

---

## Customizing the handler

in addition to what we done previously we can also configure the handler beyond what we had done.

setting the `AddSource` to true adds a `source` group that includes the `function` calling the log, `file` path and the `line`.

```go
opts := &slog.HandlerOptions{
    AddSource: true,
    Level:     slog.LevelDebug,
}
```

---

## Custom handler

a handler must implement the `Handler` interface, to do so it needs to implement the following:

```go
type Handler interface {
    Enabled(context.Context, Level) bool //do we handle this level of logs
    Handle(context.Context, r Record) error //if so then let's do it
    WithAttrs(attrs []Attr) Handler //to create another handler with a specific set of attributes based of an existing one
    WithGroup(name string) Handler //a new handler from an existing one and assigning it a group name
}
```

for example:

```go
// 1. Define the custom handler struct
type AwesomeAPIHandler struct {
	// We wrap an existing handler so we don't have to rewrite JSON formatting from scratch
	next slog.Handler
	// A custom attribute unique to our handler
	startTime time.Time
}

// 2. Implement the Enabled method (The Gatekeeper)
func (h *AwesomeAPIHandler) Enabled(ctx context.Context, level slog.Level) bool {
	// Forward the check to the underlying JSON handler
	return h.next.Enabled(ctx, level)
}

// 3. Implement the Handle method (The Interceptor/Mutator)
func (h *AwesomeAPIHandler) Handle(ctx context.Context, r slog.Record) error {
	// Add a custom calculated attribute: uptime duration
	uptime := time.Since(h.startTime).String()
	r.AddAttrs(slog.String("uptime", uptime)) //we add our attributes to the record

	// Forward the mutated record to the actual printer (JSON handler)
	return h.next.Handle(ctx, r)
}

// 4. Implement WithAttrs (For child loggers)
func (h *AwesomeAPIHandler) WithAttrs(attrs []slog.Attr) slog.Handler {
	return &AwesomeAPIHandler{
		next:      h.next.WithAttrs(attrs),
		startTime: h.startTime,
	}
}

// 5. Implement WithGroup (For nested child loggers)
func (h *AwesomeAPIHandler) WithGroup(name string) slog.Handler {
	return &AwesomeAPIHandler{
		next:      h.next.WithGroup(name),
		startTime: h.startTime,
	}
}
```

---

## LogValuer interface

the `LogValuer` interface allows for controlling what gets logged and what doesn't on a certain type, for example we can use to hide sensitive data about the user and instead log their id:

```go
func (u User) LogValue() slog.Value {
    //replacing the entire user value with it's id in the logs
    return slog.StringValue(u.ID)
}
```

or to join attributes that will be show:

```go
func (u User) LogValue() slog.Value {
    return slog.GroupValue(
        slog.String("id", u.ID),
        slog.String("name", u.FirstName+" "+u.LastName),
    )
}
```
