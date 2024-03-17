# Utilities:

navigation:

- 
- 

---

# Omit<T, K>:

the `Omit` utility allows you to inherit from a type while removing some data from it like extending an interface while ignoring one of it's values.


```typescript
interface Person{
    name: string,
    age: number,
    email: string
}

interface PersonWithoutAgeAndEmail extends Omit<Person, 'age'|'email'>{}

const newP:PersonWithoutAgeAndEmail = {
    name: 'amr'
}

```

this will create `PersonWithoutAgeAndEmail` interface which only has `name` in it.

---

# Pick<T, K>:

the `Pick` utility is similar to the `Omit` but instead of excluding values it picks them.

```typescript
interface Person{
    name: string,
    age: number,
    email: string
}

interface PersonWithoutAgeAndEmail extends Pick<Person, 'age'|'email'>{}

const newP:PersonWithoutAgeAndEmail = {
    age: 10,
    email: 'djsjfa@fjalsfja'
}

```

this created a new interface where only values are `age` and `email`