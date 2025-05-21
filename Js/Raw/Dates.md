<!-- @format -->

# Dates:

using the `Date` class we can store dates efficiently and handle date related math.

---

## New date:

```javascript
// y: 2020, m:10, d:2, h: 20, m:1 s:2 ms:1
const date = new Date(2020, 10, 2, 20, 1, 2, 1);
//this defaults to today
const date2 = new Date();
```

---

## Get time:

from a date object we can get years, hours, months, etc..., using the `.getDay()` for example for the days.

following the new date example:

```javascript
date.getTime(); //returns time in ms
date.getDate(); //returns the day
date.getFullYear(); //returns the year
date.getMonth(); // returns the month
```

there are other useful methods on the date object as well.

---

## Stringification:

to turn a date object into a string we can use some built in methods and the choice is based on the date format for instance:

```javascript
const date = new Date();

console.log(date.toISOString()); // yyyy-mm-dd:hh:mm
console.log(date.toDateString()); // day_name(3c) month_name(3c) day year
```

the `toISOString` for example would return **2025-12-4:22:10** whilst the `toDateString` would return **Wed Feb 10 2010**.

there are some other formats on the date type.

note that those strings can be given to date constructor and it will extract the years & months, etc...
