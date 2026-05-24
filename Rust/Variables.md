# Variables

in rust variables are **immutable** by default but can be made mutable at declaration, in both cases it would look like:

```rust
let var_name: type = value;
let mut mutable_var: type = value;
```

the value can be implicit, but having it explicitly mention can be helpful.

note that in rust scopes can be reduced to a value, the last line which is not followed by a `;` is the yield of the scope:

```rust
let x = {
  let y = 12;
  y + 1
};

//x = 13
```

this way of using scopes can also be used to return a value from a function without needing to use `return`.

---

## Constants

in rust constants are -unlike- variables **always** immutable and must have their type **explicitly** stated, constants also can't equal to expressions that are computed at runtime.

define a constant using the `const` keyword, for example:

```rust
const MY_CONSTANT: i32 = 12;
```

this constant can't be re-assigned at all.

---

## Shadowing

we can re-use a variable name when converting it's value from one type to another, for example:

```rust
let mut guess:String = "Hello";
let guess: u32 = match guess.trim().parse() {
    Ok(num) => num,
    Err(_) => continue,
};
```

here the same variable `guess` is used twice once as a string and once as a `unsigned int of 32 bytes` in the same scope, this is valid rust code.

shadowing can also be used with reassignment, for example:

```rust
let x = 5;
let x = x + 1; //over-shadowing 1
{
    let x = x * 2; //over-shadowing 2
    println!("The value of x in the inner scope is: {x}");
}
// x = x + 1 = 6 (from line 2)
println!("The value of x is: {x}");
```

using shadowing we can modify our variables by creating a new variable with that very name and ensure that this new variable still is immutable, note that trying to do something similar without `let` will cause an error as `x` is immutable variable, also type conversion via shadowing can't be done with mutable variables and requires the use of `let` and overshadowing to reuse the same name.

---

## Data types

in rust we the type can be implicit, very often you don't need to manually define the type however you still can be explicit with the type as shown at the start of this file.

data types differ by category as in:

- scalar/value types
-

for example:

### integers (scalar)

in rust integers can be signed `i` or unsigned `u`, unsigned means >= 0, so no negative numbers allowed, then after this letter the size of it, by default rust falls to `i32` which is like `long` in C.

- i8, u8
- i16, u 16
- i32, u32
- i64, u64
- i128, u128
- isize, usize (architecture dependent, 64bit, 32bit, etc...)

the range of integers is: `-(2^(n-1)) to (2^(n-1))-1`

integers can use `_` for digit separation

### Decimal

rust also has 2 types for floating point types them being:

- f32
- f64 (default)

### Boolean, Char

we also have a `bool` type to store true/false values as well as a `char` type.

### Tuples

a `tuple` is a scalar type that can store multiple values of different types into one compound type, tuples have **fixed length**:

```rust
let tup: (i32, f64, bool) = (500, 3.1415, true);
```

tuples support destructuring, so we can extract the values of the tuple, for example:

```rust
let (x, y, z) = tup;
```

also we can access them by index but using `.` rather than `[ ]`:

```rust
let elem1 = tup.0;
let elem2 = tup.1;
```

an empty tuple `( )` is called a `unit`.

### Arrays

arrays are yet another scalar type that let's us combine multiple values into 1 value but this time of **one type**, arrays also have a fixed size.

```rust
let arr1 = [1, 2, 3, 4];
//an array of 4 elements, all of value 0
let arr2 = [0;4]; //arr2 = [0, 0, 0, 0];
```

the previous example was implicitly typed, for explicit types we can define an array as follows:

```rust
let array_name[type; size];
```

arrays can be accessed using `index` with `[ ]`.
