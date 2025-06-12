<!-- @format -->

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

you can also define a fallback if the list is empty using the `@empty` block:

```typescript
@for (item of items; track item.name) {
  <li> {{ item.name }}</li>
} @empty {
  <li aria-hidden="true"> There are no items. </li>
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

---

## @Switch:

the `@switch` can be used to define a switch-case conditional tree that displays some element based on their values like a normal switch block.

along with it use the `@case` to define cases and `@default` to define the fallback case

```typescript
@switch (userPermissions) {
  @case ('admin') {
    <app-admin-dashboard />
  }
  @case ('reviewer') {
    <app-reviewer-dashboard />
  }
  @case ('editor') {
    <app-editor-dashboard />
  }
  @default {
    <app-viewer-dashboard />
  }
}
```
