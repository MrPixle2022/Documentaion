# Functions

to define a function in rust use the `fn` keyword, return type must be defined if the function returns a type:

```rust
//implicit type
fn another_function(){
  println!("In Another function");
}

fn some_function(param1: type1, param2: type2) -> return_type {
  return_value //no semi-column
  //same as `return return_value;`
}
```
