<!-- @format -->

# Times:

---

## DateTime:

the `DateTime` class can be used to handle times in years, months and days even to milliseconds.

the `DateTime` is included in the `System` namespace.

```csharp
//2007/12/5
DateTime someData = new(2007, 12, 5);
```

now we can access parts of this date time object:

```csharp
var day = someData.Day;
var dayOfWeek = someData.DayOfWeek;
var dayOfYear = someData.DayOfYear;
```

or add times to it:

```csharp
someData.AddDays(2);
someData.AddHours(2);
someData.AddMonths(2);
someData.AddYears(2);
someData.Add(new(10, 5, 12)); //+ TimeSpan(10h 5m 12s)
```

---

## TimeSpan:

the `TimeSpan` can be used to handle times over a small span like hours and minutes:

```csharp
TimeSpan span = new(12, 30, 0); //12:30
```

and access properties on it:

```csharp
var d = span.Days;
var h = span.Hours;
var m = span.Minutes;
```

and add times:

```csharp
span.Add(new(10, 12, 0)); //add 10h 12m 0s
```
