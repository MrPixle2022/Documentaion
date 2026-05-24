# Loops

---

## loop

the `loop` keyword is used to define a block that runs in an infinite loop, this loop must be stop explicitly.

```rust
loop {
  println!("infinite loop");
}
```

we can of course use both `break` and `continue` as in any other language, but in rust we can also use them to return a value from the loop block:

```rust
let mut sum = 0;
let result = loop {
  sum += 1;

  if sum > 10{
    brake sum;
  }
};
```

another feature rust is provides is **loop labels**, they allow us to target a specific loop with `continue` and `break` as their default behavior is to target the inner most loop.

a loop label is defined as:

```rust
let mut count = 0;
'my_label : loop{
  println!("count: {count}");

  loop{
    println("inside inner: {}", 10 - count);

    if count == 5{
      break; //breaks the inner loop
    }
    else if count == 3{
      break 'my_label; //breaks the labeled loop
    }
  }
}
```

---

## While loop

```rust
let a = [10, 20, 30, 40, 50];
let mut index = 0;

while index < 5 {
    println!("the value is: {}", a[index]);

    index += 1;
}
```

---

## For loop

```rust
let a = [10, 20, 30, 40, 50];

for element in a {
    println!("the value is: {element}");
}

for element in (1..=4){
    println!("element {}", element);
}
//same but reversed and the 4 is not included
for element in (1..4).rev(){
  println!("element {}", element);
}
```
