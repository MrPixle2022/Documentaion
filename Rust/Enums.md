# Enums

enumerations or `enums` are user-defined-types that allows us to define a type which can only be a set of defined values.

```rust
enum IpAddrKind {
    V4,
    V6,
}
```

this snippet defines that any value of type `IpAddrKind` can either be the value of `V4` or `V6`.

then we can use these values:

```rust
let four = IpAddrKind::V4;
let six = IpAddrKind::V6;
```

---

## Value enums

enums in addition to limiting the choices to a set number of values, they can also store values passed to them:

```rust
enum IpAddr {
    V4(String),
    V6(String),
}
```

which we apply using:

```rust
let home = IpAddr::V4(String::from("127.0.0.1"));

let loopback = IpAddr::V6(String::from("::1"));
```

in this case the values of the enums become like function that construct an instance of the enum.

note that the types those functions take can be different for each:

```rust
enum IpAddr {
    V4(u8, u8, u8, u8),
    V6(String),
}
```

also note that enums can have functions and methods on them using the `impl` block

---

## Option enums

the `Option` enum is a part of the std library, it's used to represent wether a value is something or nothing.

option is used to handle when a value is null which rust doesn't support.

```rust
enum Option<T> {
    None,
    Some(T),
}
```
