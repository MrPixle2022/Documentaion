<!-- @format -->

# Control flow:

---

## If statement:

the if statement is used to execute a block of code based on a condition:

```c
if(condition)
    //one-line-thing

if(condition)
{
    //block
}
```

for more control we can use `else if` for another statement in case the first is false, we can have as many as we need.

```c
else if(condition)
{
    //block
}
```

and at the end we can have an `else` which runs when every other condition is false.

```c
else
{
    //what to do
}
```

---

## Switch:

the `switch` statement allows you to define logic related to a variable's value.

```c
switch(variable){
    case value1:
        //what to do
        break;//required
    case min ... max:
        //this one uses ranges for the condition
        //what to do
        break;
    default: //if no case matches
        //what to do
        break;
}
```
