<!-- @format -->

# Console:

the `System.Console` allows you to interact with the app console and modify it.

---

## ForegroundColor and BackGroundColor:

on the `Console` we can modify the `ForegroundColor` and `BackGroundColor` directly from code. we can use the `ConsoleColor` enum to pick one of the defined colors.

```csharp
Console.ForegroundColor = ConsoleColor.Green; //text will be green
Console.BackgroundColor = ConsoleColor.Black; //background will be black
```

we can later reset them using the `Console.ResetColor()`

```csharp
Console.ResetColor();
```

---

## WriteLine(string format, object?[]? params):

the `WriteLine` -and by extent the `Write`- is used to log a line to the console, it can take log a value or be used like a `string.Format` method.

the difference between `WriteLine` and `Write` is that `Write` doesn't end a line whist the other does.

```csharp
Console.Write("hello ");
Console.WriteLine("on the same line");
```

---

## ReadLine():

the `ReadLine` is a method that a waits a user to input a line of text and then press `enter`. the input is returned as a string -or null- meaning it can be stored in a variable.

```csharp
Console.Write("enter input > ");
string response = Console.ReadLine();
```

---

## ReadKey():

the `ReadKey` like the `ReadLine` awaits input, but this time it awaits a button press.

```csharp
Console.ReadKey();
```

---

## Clear():

the `Clear` method is used to clear any prompt on the console.

```csharp
Console.Clear();
```
