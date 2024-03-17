# Enums:

enums allow you to create a consent set of values,
so any variable with type of this enum can't have a value not defined in the enum, also it's useful for values that are limited to multiple choices like week days.

```typescript
enum State{
    hungry = 'hungry',
    thirsty = 'thirty',
    asleep = 'asleep'
}

const myState1:State = "not hungry" //error
const myState2:State = State.hungry;

```
