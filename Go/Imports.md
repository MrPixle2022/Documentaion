# Imports

we can use the `import` word to import package and modules as follows:

```go
import (
    . "fmt" //import standard fmt package, exposes all it's exports directly
    //no need for `fmt.` any more

    id "github.com/google/uuid" //import a 3rd-party package ang give it an alias
    //without alias use uuid

    _ "github.com/go-sql-driver/mysql" //executes the init() of the pkg without exposing it's content
)
```
