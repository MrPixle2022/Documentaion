# Utility types:

navigation:

- [Partial](#partialt)
- [Required](#requiredt)
- [Readonly](#readonlyt)
- [Record](#recordt-k)
- [Pick](#pickt-k)
- [Omit](#omitt-k)
- [Exclude](#excludet-k)
- [Extract](#extractt-k)
- [NonNullable](#nonnullablet)
- [ReturnType](#returntypet)
- [Parameters](#parameterst)
- [Awaited](#awaitedt)

---

## Partial\<T>:

`Partial<T>` : makes a new version of type `T` where all properties are *optional*

```typescript
interface Assignment {
  studentId: string;
  title: string;
  grade: number;
  verified?: boolean;
}

function updateAssignment(
  assign: Assignment,
  propsToUpdate: Partial<Assignment>
): Assignment {
  return { ...assign, ...propsToUpdate };
}
```

---

## Required\<T>:

`Required<T>`: a type based on `T` where all properties on type `T` are required

```typescript
function recordAssignment(assignment: Required<Assignment>): Assignment {
  return { ...assignment };
}
```

---

## Readonly\<T>:

`Readonly<T>` : makes all keys on type `T` readonly

```typescript
function assignVerified(assignment: Readonly<Assignment>): Assignment {
  // Readonly<T> makes all properties on `T` a readonly
  return { ...assignment, verified: true };
}
```

---

## Record<T, K>:

`Record<T, K>` : creates a new type where all keys are of type `T` & values are of type `K`

```typescript
const hexColorMap: Record<string, string> = {
  //the Record<K, T> creates a new type where keys are of type `K` and values are of type `T`
  red: "FF0000",
  green: "00FF00",
  blue: "0000FF",
};

type Students = "amr" | "ali";
type Grades = "A" | "B" | "C" | "D" | "U";

const finalGrades: Record<Students, Grades> = {
  amr: "A",
  ali: "A",
};

interface Grade {
  assignment1: number;
  assignment2: number;
}

const finalAssignmentScore: Record<Students, Grade> = {
  amr: { assignment1: 92, assignment2: 100 },
  ali: { assignment1: 97, assignment2: 99 },
};

```

---

## Pick<T, K>:

`Pick<T, K>` : creates a new type that has only the specified `K` properties in `T`

```typescript
type AssignResult = Pick<Assignment, "studentId" | "grade">;
//AssignResult: {studentId: string, grade:number}
```

---

## Omit<T, K>:

`Omit<T, K>` : same as `Pick<T, K>` but removes `K` from `T` in the returned types

```typescript
type AssignPreview = Omit<Assignment, "grade" | "verified">;
```

---

## Exclude<T, K>:

`Exclude<T, K>` : similar to `Omit` but only for literal types

```typescript
type AdjustedGrade = Exclude<Grades, "U">;
//AdjustedGrade: 'A' | 'B' | 'C' | 'D'
```

---

## Extract<T, K>:

`Extract<T, K>` : similar to `Pick` but only for literal types

```typescript
type HighGrades = Extract<Grades, "A" | "B">;
//HighGrades: 'A' | 'B'
```

---

## NonNullable\<T>:

`NonNullable<T>` : returns a type based on `T` excluding `null | undefined`

```typescript
type AllPossibleGrades = "Dave" | "John" | null | undefined;

type NamesOnly = NonNullable<AllPossibleGrades>;
```

---

## ReturnType\<T>:

`ReturnType<T>` : returns a new type based on the return type of the given function

```typescript
function createNewAssign(title: string, points: number) {
  return { title, points };
}

type newAssign = ReturnType<typeof createNewAssign>;
```

---

## Parameters\<T>:

`Parameters<T>` : returns a new tuple type based on the parameters of the given function
```typescript
type assignParams = Parameters<typeof createNewAssign>;

```

---

## Awaited\<T>:

`Awaited<T>` : Awaited is useful when working with async code & promises

```typescript
interface User {
  id: number;
  name: string;
  username: string;
  email: string;
}

async function fetchUser(): Promise<User[]> {
  const data = await fetch("https://jsonplaceholder.typicode.com/users")
    .then((value) => {
      return value.json();
    })
    .catch((err) => {
      if (err instanceof Error) console.log(err);
    });
  return data;
}

type FetchUsersReturnType = Awaited<ReturnType<typeof fetchUser>>;
```
