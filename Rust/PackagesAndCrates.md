# Rust module system

as projects grow we will need to split the source code between files and directories for better organization and to make it easier to maintain and modify.

in a cargo managed project we can have many binary creates and only on library crate.

---

## Packages and crates

a crate is the smallest code that the rust compiler considers at runtime, that includes the `main.rs` file even if you have only a `println!` in it.

the rust compiler considers this a crate, a crate can also contain `modules` which themselves may be defined in another file yet they are compiled along side the crate.

a crate can either be a:

1. **binary create**: can be compiled into runnable executables, each must have a `main` function.
1. **library create**: lacks the `main` function hence they don't compile into runnable executables, these are used to define shared functionality among multiple projects.

packages however contain one or more crates, it contains a `cargo.toml` that describes how to build those crates.

packages can have as many binary crates and at most 1 library crate but must contain at least 1 crate regardless of type.

when using:

```bash
cargo new <package_name> # binary crate
cargo new <package_name> --lib # library crate
```

rust will create a new package for us, the rust compiler will look and find an `src/main.rs` file, it will deduce that this is a binary crate with the same name as the package's and that `main.rs` is it's root, same with use `lib.rs` but this time it will be a library crate.

we can have multiple binary crates by combining them under `src/bin/` and each file will be considered a crate.

---

## Modules

to declare sub/modules in rust we have 2 ways, in one file using `{ }`, or by using files and folder named after the `module`.

### Blueprint (recommended)

say we are creating a garden module, the garden has 2 submodules it contain mainly: `vegetables` and `flowers`, we would have a folder structure as:

```text
my_project/
├── Cargo.toml
└── src/
    ├── main.rs (contains the declaration of the module, can be lib.rs if library crate)
    └── garden/ (joins submodules under their parent)
        ├── vegetables.rs
        └── flowers.rs
    └── garden.rs (hey i tell you what is a sub module to me)
```

then in the `main.rs` file we would have:

```rust
// Declare the top-level module
mod garden;

fn main() {}
```

then in the `garden.rs` file use:

```rust
// Declare the sub-modules inside the parent module file
pub mod vegetables; //pub means public, in rust every thing is private by default
pub mod flowers;
```

then finally the actual functionality of those submodules can be implemented in their own files:

```rust
pub fn harvest() {
    println!("Squash harvested!");
}
```

and now we can use this functionality in the root:

```rust
mod garden;

fn main() {
    garden::vegetables::harvest();
}
```

so basically, for a module, you:

1. declare it's name inside it's parent module or in the root of the project
1. create a `.rs` file with the same name
1. if that module has a submodule or more declare them using `mod` in that `.rs` file
1. create a directory with the same name as the `parent module` and a `.rs` file named after each sub-module

### Inline method

we can also define all of this in one file, however this is not recommended as it can easily turn into spaghetti code

```rust
// Parent Module
mod garden {

    // Sub-module nested inside
    pub mod vegetables {
        pub fn harvest() {
            println!("Tomatoes harvested!");
        }
    }

    // Another sub-module
    pub mod flowers {
        pub fn bloom() {
            println!("Roses are blooming!");
        }
    }
}

fn main() {
    // Navigating the nested path
    garden::vegetables::harvest();
    garden::flowers::bloom();
}
```

## Navigating modules

you have noticed that to access the `harvest` or `bloom` we had to navigate down the module tree just to reach them, you probably see how this can get messy with huge modules, however, rust provides a solution for this using the `use` keyword.

with the `use` keyword we can shorten the path we write by bringing it into scope, for example:

```rust
use garden::flowers;
```

this would expose the content of the `flowers` sub-module, now all content inside it can be accessed using `flowers::`.

but what if `flowers` also has sub modules?, say `sunflower` submodule, then we would use `flowers::sunflowers::` or just add another `use` if we still need functionality under `flowers` directly.

we can also target a specific part to get rid of the `submodule::` part, like using:

```rust
use garden::flowers::harvest;
```

this will expose the `harvest` function directly to us so no need for `flowers::harvest`.

also we can use absolute and relative paths to navigate the modules tree:

1. **absolute path**:

starts with `crate` till the specific target:

```rust
crate::garden::flowers;
crate::garden::flowers::bloom();
```

1. **relative path**:

```rust
flowers::bloom(); //valid relative path
super::vegetables::harvest();//relative bath that goes to the parent module then to the `vegetables` module
```

## Bringing paths to scope using `use`

we can use the `use` keyword to bring paths, modules, functions, etc... to scope, it helps to get rid of the repetitive paths:

```rust
use crate::garden::flowers;
use garden::vegetables;
```

we can also select specific parts, let's look at an example, we have a module called `front_end` with the following structs:

```rust
//* for type struct waiter */
pub struct Waiter {
    name: String,
    age: u32,
    pub orders: Vec<String>,
    pub table: u32
}

impl Waiter{
    pub fn new(name: String, age: u32) -> Waiter {
        Waiter {name,
        age,
        orders: Vec::new(),
        table: 0
        }
    }

    pub fn take_order(&mut self, orders: Vec<String>, table_number: u32){
        self.orders= orders;
        self.table = table_number;
    }
}

//* for type struct guest */
pub struct Guest {
    name: String,
    pub table: u32,
    pub orders: Vec<String>
}

impl Guest{
    pub fn new(name: String, table: u32) -> Guest{
        Guest{
            name,
            table,
            orders: Vec::new()
        }
    }

    pub fn make_order(&mut self, orders: Vec<String>){
        self.orders = orders;

        let mut waiter = Waiter::new(String::from("Jhon"), 32);
        waiter.take_order(self.orders.clone(), self.table);
    }
}

/* more content */
```

we only want to use these 2 structs, or even we want those and then we want to go even deeper in the tree, we don't want to have to rewrite the entire path, instead we can use `nested paths`:

```rust
use front_end::{Guest, Waiter, cashier::Cacher_man}; //brings Guest and Cacher_man
use std::io{self, Write}; //brings std::io and std::io::Write
```

note that `use` only brings those paths to scope within their scop, so for example:

```rust
mod front_of_house {
    pub mod hosting {
        pub fn add_to_waitlist () {}
    }
}

use crate::front_of_house::hosting;

mod customer {
    pub fn eat_at_restaurant () {
        hosting::add_to_waitlist();
    }
}
```

this code will actually not compile as `customer` has no idea what is `hosting`

also note we can give an alias to imported modules using `as`:

```rust
use std::io::Result as IOResult;
```

we can also `re-export` things, as a way to shorten the path using `pub use`.

basically we have a struct found at `crate::restaurant::frontend::Waiter`, this is a very long way to reach, what `pub use` allows us to do is to re-expose this path from another module and expose it.

for example if in the `main.rs` or `lib.rs` files we use:

```rust
pub use crate::restaurant::frontend::Waiter;
```

then in any module we can access that struct using:

```rust
use crate::Waiter;
```

at this point you know what would be better, how about we bring all public items, well we can use the `*` at the end to do so:

```rust
use std::collections::*;
```

## Publicity of modules and their content

by default every module and it's content is private, accessible only within itself and to it's children modules, a parent can't access it's child modules.

since every thing is private by default we can't access it's content, be it structs, enums, constants, functions or methods, to overwrite this use `pub` keyword on modules to expose them.

note that making a module public **won't expose it's content** they still are private so using `pub` on them is also required.

```rust
mod front_of_house {
  pub mod hosting {
    pub fn add_to_waitlist () {}
    }
}
```

also for `pub struct` you would have to mark each and every single field as `pub` as well.

for ease of use we can implement a function on the struct that assigns default values to the private fields of said struct.

```rust
pub struct Waiter {
    name: String,
    age: u32,
    pub orders: Vec<String>,
    pub table: u32
}

impl Waiter{
    pub fn new(name: String, age: u32) -> Waiter {
        Waiter {name,
        age,
        orders: Vec::new(),
        table: 0
        }
    }
}
```

for enums defining them as `pub`lic makes all their possible values `pub`lic as well.
