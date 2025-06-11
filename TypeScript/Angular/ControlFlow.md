# Control flow:

---

## @For:

using the `@For` we can create a block of ui for each element in an array or any enumerable type directly within the template

```typescript
//todos() because todo is a signal
@for (todo of todos()) {
  <h1>{{todo.title}} -> {{todo.completed}} | {{todo.userId}} </h1>
}
```

now for the unique key we can use `track` with the index:

```typescript
@for (todo of todos(); track $index) {
  <h1>{{todo.title}} -> {{todo.completed}} | {{todo.userId}} </h1>
}
```

or depend on our own custom unique key:

```typescript
@for (todo of todos(); track todo.id) {
  <h1>{{todo.title}} -> {{todo.completed}} | {{todo.userId}} </h1>
}
```

---

## @If:

the `@if` is used to conditionally display ui, along with `@else if` and `else`:

```html
@if(todos().length === 0){
<p>Loading...</p>
} @else{ @for (todo of todos(); track todo.id) {
<h1>{{todo.title}} -> {{todo.completed}} | {{todo.userId}}</h1>
} }
```
