# Structs

a struct is the a user defined type that is composed of multiple related values.

---

## Define and use a struct

a struct is defined using the `struct` keyword:

```rust
struct User{
  active: bool,
  username: String,
  email: String,
  sign_in_count: u64,
}
```

now to use this struct we do as follows:

```rust
let user1 = User {
  active: true,
  username: String::from("my username");
  email: String::From("email@example.com"),
  sign_in_count: 1
};
```

the data inside a struct is accessed using `.`:

```rust
user1.email;
```

as in the case with javascript, if a field and a variable have the same name, we can use the variable directly to shorten the definition:

```rust
let email = "example@site.com";
let user2 = User {
  email;
  /* rest of the fields*/
};
```

rust also has the unpack operator from javascript, which allows us to use the values of a different struct and dump them into a new one:

```rust
let user3 = User{
  email: String::from("MyEmail@site.com");
  ..user2; //must be last
};
```

note that using this will move the ownership of `user2.username` from `user2` to `user3`, however we still can access `user2.email` since it's value wasn't moved, for `user3` has it's own value for that, also note that `active`, `sign_in_count` are still valid on the `user2` as they implement the `Copy` trait.

---

## Struct methods

we can define functions that are associated with a struct, their first parameter is always `&self` which represents the instance of the struct being created.

```rust
#[derive(Debug)]
struct Rectangle {
    width: u32,
    height: u32,
}

impl Rectangle {
    //short for self: &Self
    fn area(&self) -> u32 {
        self.width * self.height
    }
}

fn main() {
    let rect1 = Rectangle {
        width: 30,
        height: 50,
    };

    println!(
        "The area of the rectangle is {} square pixels.",
        rect1.area()
    );
}
```

note that a method can be made to take ownership of the object, in this case the first param is `self` not `&self`, in which case the object would be invalidated after the method finishes.

there is also the possibility to define `associated functions`, these are functions defined inside the `impl` block but do not take `self` or `&self` as parameters, hence they are independent from any instance of the structs -like static methods-, these are accessed using `StructName::function()`:

```rust
impl Rectangle {
    fn square(size: u32) -> Self {
        Self {
            width: size,
            height: size,
        }
    }
}
```

```rust
let sqr = Rectangle::square(3);
```

---

## Tuple structs

tuple structs are basically structs that are named as their own type to differentiate them from other tuples, they lack field names and are very similar in the style of writing to regular tuples.

```rust
struct Vector3(i32, i32, i32);
struct Color(i32, i32, i32);
```

and for their use:

```rust
let vec1 = Vector3(0, 0, 0);
let color1 = Color(0, 0, 0);
```

note that here type of `Vector3` and `Color` are not the same, even though they are exactly that.

an all other ways this type of struct is used exactly like tuples.

---

## Unit like structs

these are structs that have no fields, often used with traits:

```rust
struct AlwaysEqual;
```

```rust
let subject = AlwaysEqual;
```
