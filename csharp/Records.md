# Records

records are special reference-type that is used to store immutable fields that use value-equality rather than reference equality

```csharp
//a course definition + constructor
public record Course(
  string Title,
  string Description,
  int Credits
);
// object creation
Course course = new (
  Title: "Introduction to Programming",
  Description: "Learn the basics of programming using C#.",
  Credits: 3
);
//member access
System.Console.WriteLine($"Course Title: {course.Title}");
```

also note we can have dynamic and static members in a record, just use `{ }` and define all members inside

---

## Deconstruct

we can extract values from a record using `deconstruction`, we have 2 method of doing so:

### Positional

we extract fields by position and to ignore a field or more use `_`

```csharp
//ignore 1st and 3rd fields, get 2nd only
var (_, description, _) = course;
```

### Property

this is used to extract a single/multiple field only, usually used with `switch` statement and if condition

```csharp
//checking if `course != null` then extraction the `Credits` field into var `x`
if(course is { Credits: int x}) System.Console.WriteLine($"Credits: {x}");
```

---

## Property validation

we can use properties of a record to check if they equal a value, or fall in a range for example:

```csharp
//if the value of course.Score is > 2 then return true.
if(course is {Score: > 2}) return true;
```
