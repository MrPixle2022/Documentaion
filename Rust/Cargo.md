# Cargo

cargo is the package manager of rust and it's build system, we can check for cargo's version using:

```bash
cargo --version
```

---

## New project

to create a new project via cargo use the command:

```bash
cargo new <project_name>
cd <project_name>
```

this command will:

1. generate a new directory with the given name
1. initialize a new git repo -unless the directory exists within an already existing git repo

for the project structure we will have:

- src/: contains the source code
- cargo.toml: the package.json of rust

also if you have an already existing rust project that doesn't use cargo we can convert it into a cargo project using:

```bash
cargo init
```

---

## Building and running projects

to build a project we can use:

```bash
cargo build
# specify target build
cargo build --release #target/release (more optimized build)
```

this command will -by default- compile the code into the `target/debug` directory as debug is our default build.

this built executable can be run either:

```bash
<path_to_exe>
# or alternatively
cargo run
```

cargo run would also re-build the code if the file was changed, else it will just run the compiled version.

---

## Check

another command we can use with cargo is `check`, it will validate that the code will compile with no problems but **won't actually compile**:

```bash
cargo check
```

---

## Adding a new crate

to add a new crate using cargo use the `add` command following the shown syntax:

```bash
# add a new dependency:
# if you have already installed the dependency you can use the --offline flag
cargo add <crate-name>@<version>
```

importing crates in code is done using the `use` keyword as follows:

```rust
use crate_name; //requires file::function
use crate_name::file_name; //requires file::function
use crate_name::file_name::function;
```

if you just stop at `crate_name` or `file_name` you will have to use the following syntax to access functions:

```rust
use std::io;

fn main(){
  io::stdin()./*some code*/;
}
```

we can get rid of the `io` part by being explicit with what we want to import:

```rust
use std::io::stdin;
```

meaning we no longer need `io::` before each function.
