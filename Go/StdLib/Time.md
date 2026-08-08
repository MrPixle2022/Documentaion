# Time

the `time` package contains types and function that can be used to handle time, sleeps and date math.

---

## Now

the `Now()` function returns the current **local-time** as a `time.Time` value, to get the `UTC` time just use the `UTC` function, value returned by `UTC` can be converted into local time again using the `Local` method on it.

```go
// something like 2021-08-15 14:30:45.0000001 -0500 CDT m=+0.000066626
current := time.Now()
```

on the `Time` type we can get a specific portion like:

- hour
- month
- day
- second

and so on. for each of theses we have a method for that:

```go
current.Year()
current.Month() //time.Month
current.Day()
current.Hour()
current.Minute()
current.Second()
```

---

## Date

the `Date` is used to create a new `Time` value of a specific time, we define the year,month, day, hours ... until the location:

```go
//y, m. d, h, m, s, ms
t := time.Date(2021, 8, 15, 14 ,30 ,45 ,100, time.Local)
```

---

## Format

the `Format` method takes a formatted string to define how the date value is displayed

```go
//default value 1/02 03:04:05PM '06 -0700
//yyyy-m-d hr:min:sec
t.Format("2006-1-2 14:4:5")
```

we can also use presanctified formats like `RFC3339Nano`.

---

## Parse

the `Parse` is used to parse strings into `Time` values, the function returns the time value and the error if occurred, also we pass it first the format of the date:

```go
str := "2012-12-4 12:03:12"
//first format, then string
t, e := time.Parse("2026-01-02 04:12:12", str)
```

---

## Before, after

the `Before` and `After` are used to compare 2 `Time` values:

```go
firstTime := time.Date(2021, 8, 15, 14, 30, 45, 100, time.UTC)
secondTime := time.Date(2021, 12, 25, 16, 40, 55, 200, time.UTC)

firstTime.Before(secondTime) //returns bool
firstTime.After(secondTime)
```

---

## SUb

the `Sub` will subtract two `Time` values and return a `Duration` type:

```go
...

func main() {
firstTime := time.Date(2021, 8, 15, 14, 30, 45, 100, time.UTC)
secondTime := time.Date(2021, 12, 25, 16, 40, 55, 200, time.UTC)

//Duration between second and first time is 3170h10m10.0000001s
fmt.Println("Duration between second and first time is", secondTime.Sub(firstTime))
```

`Duration` can be defined using things like `time.Hour`, or `time.Minute` which can be multiplied by numbers:

```go
twoMin := time.Minute * 2
twoMin += time.Minute //now is 3 minutes
```

subtraction also works.

---

## Adding durations to time

use the `Time.Add` to add a duration to a date:

```go
theTime := time.Date(2021, 8, 15, 14, 30, 45, 100, time.UTC)
newTime := theTime.Add(24 * time.Hour)
```

to subtract just use a negative value.

---

## Sleep

the `Sleep` function stops the function for the given duration -not gonna give an example, am to lazy-
