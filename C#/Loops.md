<!-- @format -->

# Loops:

---

## For loop:

a `for loop` is used to repeat a block for **n** number of times.

the syntax is like:

```csharp
for(initialization; condition; step){
  //code
}
```

for example:

```csharp
// i -> [0, 99]
for (int i = 0; i < 100; i++)
{
  Console.WriteLine($"index is {i}");
}
```

---

## While loop:

the `while` loop is used to run a block of code as long as a condition is true.

the syntax is like:

```csharp
while(condition){
  //block
}
```

for example:

```csharp
int i = 0;

while (i <= 100)
{
  Console.WriteLine($"i = {i}");
  i++;
}
```

---

## Do while loop:

the `do while` loop is an inverted while loop where the block runs pre condition check.

the syntax is:

```csharp
do{
  //block
}
while(condition);
```

for example:

```csharp
int i = 0;

do
{
    Console.WriteLine($"i = {i}");
    i++;
}
while (i > 100);
```

this example will log:

```bash
i = 0
```

---

## Foreach

the `foreach` loop allows a loop over the elements of an `Enumerable` data type, on each loop you can access a value of the enumerable.

the syntax is:

```csharp
foreach(var element in enumerable){
  //code
}
```

```csharp
int[] x = new int[3]; //an array of 3 elements [0,0,0]

foreach (int item in x)
{
  Console.WriteLine(item);
}
```

---

## Loop keywords:

for loops we have the `break` and the `continue`, both are used in a loop for different reasons.

- `continue` is used to pass this iteration and directly move to the next.
- `break` is used to exit the loop immediately
