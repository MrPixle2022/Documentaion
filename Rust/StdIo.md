# Std IO

a part of the rust's std crate we find the io part, this contains many pre-defined function that allows us to read and show data from and to the user via the terminal.

import using:

```rust
use std::io;
```

---

## stdin

the `stdin` method is used to create a standard input handle which we can use:

### read_line(&address)

`read_line` attempts to append an input string at the given address, this method returns an enum that represents wether the operation has failed or not.

```rust
let mut myVar = String::new();

//reads a line from the standard input.
io::stdin()
  .read_line(&mut myVar)
  .expect("Error message if failed");
```
