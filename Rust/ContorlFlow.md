# Control Flow

---

## If statements

rust has `if`, `else if` and `else` it doesn't require the use of `( )` for the condition however `{ }` must be there regardless of how many lines are tied to the statement.

```rust
let number = 6;

if number % 4 == 0 {
    println!("number is divisible by 4");
} else if number % 3 == 0 {
    println!("number is divisible by 3");
} else if number % 2 == 0 {
    println!("number is divisible by 2");
} else {
    println!("number is not divisible by 4, 3, or 2");
}
```

the functionality is not limited only to regular logic, we can also make use of `if` as an expression:

```rust
let condition = true;
let number = if condition { 5 } else { 6 };
```

and yes you can use `else if` in there as well.

---

## Match

the `match` is used to compare values against patterns, it compares the value to a series of patterns and executes the code belonging to the valid pattern.

```rust
enum Coin {
    Penny,
    Nickel,
    Dime,
    Quarter,
}

fn value_in_cents(coin: Coin) -> u8 {
    match coin {
        //arm (pattern => experssion)
        Coin::Penny => 1, //this is called an arm
        Coin::Nickel => 5, //another arm
        Coin::Dime => 10,
        Coin::Quarter => 25,
    }
}
```

we can if the code of the arm is more then one line we can use scope expressions:

```rust
fn value_in_cents(coin: Coin) -> u8 {
    match coin {
        Coin::Penny => {
            println!("Lucky penny!");
            1
        }
        Coin::Nickel => 5,
        Coin::Dime => 10,
        Coin::Quarter => 25,
    }
}
```

pattern matching can be done to extract values from the `Option<T>` enum, for example if we have the following enums:

```rust
#[derive(Debug)] // so we can inspect the state in a minute
enum UsState {
    Alabama,
    Alaska,
    // --snip--
}

enum Coin {
    Penny,
    Nickel,
    Dime,
    Quarter(UsState),
}
```

then we can use a function to extract the value of `state`

```rust
fn value_in_cents(coin: Coin) -> u8 {
    match coin {
        Coin::Penny => 1,
        Coin::Nickel => 5,
        Coin::Dime => 10,
        Coin::Quarter(state) => {
            println!("State quarter from {state:?}!");
            25
        }
    }
}
```

for a default backup arm use `_`:

```rust
let dice_roll = 9;
match dice_roll {
    3 => add_fancy_hat(),
    7 => remove_fancy_hat(),
    _ => reroll(),
}
```

though we can make a variable to use should we want to store the variable:

```rust
match dice_roll {
    3 => add_fancy_hat(),
    7 => remove_fancy_hat(),
    other => move_player(other),
}
```

---

## If let, let else

some times the `match` expression is too wordy for a simple pattern check, for those cases where we don't need to list much arms we can use `if...let` and `let...else`:

```rust
let config_max = Some(u8);
if let Some(max) = config_max {
    println!("The maximum is configured to be {max}");
}
```

we can also add in the `else` as a backup case:

```rust
let mut count = 0;
if let Coin::Quarter(state) = coin {
    println!("State quarter from {state:?}!");
} else {
    count += 1;
}
```

for `let...else` it is used to say if the pattern beforehand is invalid, use mine:

```rust
fn describe_state_quarter(coin: Coin) -> Option<String> {
  let Coin::Quarter(state) = coin else {
      return None;
  };

  if state.existed_in(1900) {
      Some(format!("{state:?} is pretty old, for America!"))
  } else {
      Some(format!("{state:?} is relatively new."))
  }
}
```

> [!IMPORTANT]
> Unlike `match` this style is not `exhaustive` meaning that while in a `match` every case must have a pattern that matches it or accepts it, `if...let...else` doesn't
