<!-- @format -->

# Dates and times:

---

## NOW:

the `NOW` function can be used to get the current timestamp, it then can be converted into date using `::DATE` or time using `::TIME` like shown in [NOW](Functions.md#now)

---

## Subtractions and additions:

using the `INTERVAL` keyword we can use increment or decrement times, for example:

```sql
-- from (now) remove 1 month
SELECT NOW () - INTERVAL '1 MONTH';
-- or MONTHS
```

you can also use `YEAR` ,`DAY` and both `YEARS` ,`DAYS` also work, also you can use this with casting.

---

## Time extraction:

using the `EXTRACT` function we can extract some fields from the time for example:

```sql
-- get the year
SELECT EXTRACT(YEAR FROM NOW());
-- get the month
SELECT EXTRACT(MONTH FROM NOW());
-- get the day
SELECT EXTRACT(DAY FROM NOW());
-- get the hour
SELECT EXTRACT(HOUR FROM NOW());
-- get the minute
SELECT EXTRACT(MINUTE FROM NOW());
-- get the seconds
SELECT EXTRACT(SECOND FROM NOW());
```

---

## AGE(current, original):

the `AGE` function can be used to get the age of a field using the starting time and the actual date of the field, for example to get the age of users from now to the date of birth:

```sql
-- from now to date of birth is the age
SELECT *, AGE(NOW(), date_of_birth) AS age FROM person;
-- x years y months z days hh:mm:ss.ms
```
