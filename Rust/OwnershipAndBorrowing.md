# Ownership and borrowing

in rust unlike many other language you don't have to manually manage memory risking bugs regarding memory safety nor do you rely on a garbage collector which will cost some performance.

instead rust uses what is known as the borrowing checker.

`ownership` are some rules that rust uses to determine how memory is handled, if those rules are violated the compiler will not compile, these rules are

1. each and every values has an owner (most of the time the very first variable to be assigned this value/reference)
1. there can only be one owner at a time
1. when the owner goes out of scope the value goes boof

but how about when 2 variables both point reference the same allocated memory as in when using reference types.

will in this case going by if it's out of scope clean would cause the remaining variable to be a reference to an invalid memory, instead rust will `drop` the variable that goes out of scope, preserving the allocated memory and the second reference until it also goes out of scope.

rust will never shallow copy -also called move- allocated memory, it will just pass the reference, copying require the use of functions and must be explicit.

also note a move is considered a transfer of ownership

data types which support value copying -shallow copying- or as they are mostly know as **value types** apply the `Copy` trait, this trait can't be applied to any type that applied the `Drop` trait, types that implement the `Copy` trait are:

- all integers
- booleans
- floating point numbers
- characters
- tuples only of types that implements the `Copy` trait

so we don't want to transfer ownership, how do we avoid that, just pass the address, instead of:

```rust
fn calc_length(s1: String) -> (String, usize){
  let size: usize = s1.len();
  (s1, size);
}
```

passing a value to this function would be considered a transfer of ownership, and so would be the use of it's return value, to just pass it the data without giving it ownership we can use `borrowing`, by instead using `&String` for the `s1` type we define that the variable would be given a reference to a string -won't own the actual string- so we can just pass the reference to the function using `&` before the variable name.

what borrowing does is storing a pointer to the actual owner which stores a pointer to the actual data on the heap.

```rust
fn calc_length(s: &String) -> usize{
  s.len();
}
```

keep in mind the `borrow`ed data can't be modified as the borrower has no ownership as references are **immutable by default**, however we can override this behavior using a `mutable reference` which uses `&mut`.

```rust
fn calc_length_and_modify(s: &mut String) -> (String, usize){
  s.push_str("modification to reference");
  (s, s.len())
}
```

the only thing to remember here is that the variable passed to the function must also be **mutable**

> [!IMPORTANT]
> you can have only `1` mutable reference at a time, this is done to prevent race conditions.

so this is invalid

```rust
let mut s = String::from("Hi");

let r1 = &s;
let r2 = &s;
```

while this is valid:

```rust
let mut s = String::from("Hi");

{
  let r1 = &s;
} //r1 is out of scope here
let r2 = &s;
```

also we even though we can have multiple immutable references, we can not mix them with a mutable reference as this will introduce a race condition as that mutable reference may try to overwrite the data.

```rust
//invalid
let mut s = String::from("Hi");

let r1 = &s;
let r2 = &s;
let r3 = &mut s;
```

however rust is smart enough, if we don't use r1 and r2 anymore, after a certain point rust realizes that there lifetime should end, and in this case a mutable reference would be valid since the other 2 immutable borrowers would be dropped, this is called `Non-Lexical lifetime` or `NLL` for short.

---

## Slice type

a slice is a reference to bunch on contiguous sequence of elements stored inside a collection, as in the case with `vectors`, `strings` and `arrays`.

rather then referencing the entire collection we can reference a portion of it, and we said it's a reference so it **borrows** the data.

### String slices

```rust
let s = string::from("Hello, World!");

let hello = &s[0..4];
let world = &s[7..11];
```

for the range we can use the regular range syntax:

```rust
start..end; //exclusive => [start, end[
start..=end; //inclusive => [start, end]
// not in loops
..end; //0 to end (exclusive) (can be inclusive)
start..; //start to end (exclusive)
..; //start to end (exclusive)
```

since this slice is basically a reference to a part of the collection then we can guarantee that as long as the slice is valid, the data is also valid.

remember a slice is a reference, so it's type in this case is `&str` for literals and `&String` for strings.

the same way we did slices for strings we can do it for other collections as well.
