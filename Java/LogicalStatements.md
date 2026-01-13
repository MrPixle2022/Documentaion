# Logical Statements:

in java like most other languages we can use logic to run blocks of code only when a certain predefined condition is met, we use `if`, `else if`, `else` and `switch` statements for those.

for the first three nothing new, just like any other language:

```java
if(condition){
    //runs when true
}
else if(condition2){
    //runs ONLY if condition is false, and condition 2 is true
}
else{
    //when neither condition nor condition2 is true
}
// runs anyway, out of statement
```

of course you can ditch `{}` for onliners.

---

## Switch:

a `switch` statements though not as regullarly used they are helpful as they group multiple checks associated with a single variable's value:

```java
switch(varialble){
    case value1:
        //block
        break;
    //simple expression
    case value2 -> /*return*/;
    // same resutl differnet values
    case value3:
    case value4:
        //block shared for value3 & value4
        break;
    //another one
    case value5, value6:
        //block
        break;
    //no match
    default:
        //block, also can use ->
        break;
}
```