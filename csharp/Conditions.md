<!-- @format -->

# Conditions:

conditions allows control over the application's behavior if a condition is met or not.

---

## If:

using the `if` your are allowed to define a code block that is to run when the condition is true.

```csharp
int x = 10;

if(x >= 10){
  Console.WriteLine("x >= 10")
}
```

now the message will only be printed if x is >= 10 -which is true in this case-.

---

## Else if:

for more control over the app we can add another block that checks another condition after an `if` block.

```csharp
int x = 10;

if(x == 10){
  Console.WriteLine("x >= 10")
}
else if (x >= 20){
  Console.WriteLine("x >= 20, the first is false")
}
```

so this will only run if the first condition is false.

---

## Else:

in some cases we may want to control what happens if no condition is met. this is done in a `else` block, which runs after every `if` and `else if` block

```csharp
int x = 0;

if(x == 10){
  Console.WriteLine("x >= 10")
}
else if (x >= 20 && x <= 30>){
  Console.WriteLine("x >= 20 and is less then 30")
}
else{
  Console.WriteLine("ok, all conditions are wrong")
}
```

this will run the `else` block since the other two conditions are false.

---

## Combining conditions:

to combine multiple conditions into one we use one of the following:

-   `&&` and -> true if both sides are true
-   `||` or -> true if at least one side is true
-   `!` not -> doesn't combine but used to control conditions, it inverts true to false and vice versa

---

## Switch:

the `switch` statement allows you to depend on a variables value for a condition.

the syntax is like:

```csharp
switch(variable){
  case condition:
    //block
    break;
  default:
    //block
    break;
}
```

where `case` identifies a block, while the `default` defines a block thar runs when no case is met.

for example:

```csharp
int x = 11;

switch (x)
{
  case 0: // if x = 0
      Console.WriteLine("it is w");
      break;
  case > 10: // if x > 10
      Console.WriteLine("it is larger");
      break;
  default: // else
      Console.WriteLine("Wrong");
      break;
  }
```

also you can combine multiple cases:

```csharp
int x = 10;

switch (x)
{
  case 10:
  case 11:
    System.Console.WriteLine("10 or 11");
    break;

  default:
    System.Console.WriteLine("default case");
    break;
}
```

---

## Ternary operator:

ternary operator is a one-line conditional expression that can be used for assignments and checks.

the syntax is

```csharp
condition ? ifTrue : ifFalse;
```

for example:

```csharp
int x = 0;

int y = x > 10? 1 : 0; // y =0
```
