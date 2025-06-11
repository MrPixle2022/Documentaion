# Events:

listing to events in angular is pretty simple, for any event we use:

```html
<component (event)="handler()" />
<!-- passing the event object -->
<component (event)="handler($event)" />
```

for example, let's create an input with an event listener:

first let's create the handler:

```typescript
import { Component, signal } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { Home } from "./home/home";
import { Header } from "./components/header/header";
import { Button } from "./components/button/button";

@Component({
  //----
})
export class App {
  // the handler
  handleKeyPress(e?: KeyboardEvent) {
    if (e) {
      console.log(e.key);
    }
    console.log("something is pressed");
  }
}
```

```html
<input (keypress)="handleKeyPress($event)" />
```

> [!IMPORTANT]
> Make sure the event is the same type as `$event`

---

## Custom event:

we can emit our own custom events using the `output` function.

```typescript
@Component({
  /**/
})
export class TodoElement {
  todo = input.required<TodoType>();
  //the event object is of type TodoType
  todoToggled = output<TodoType>();

  todoClicked() {
    //when emitted the $event = this.todo();
    this.todoToggled.emit(this.todo());
  }
}
```

having done this we can emit this in the template:

```html
<div appHighlightCompletedTodo [isCompleted]="todo().completed">
  <h1>{{todo().id}}</h1>
  <input type="checkbox" (change)="todoClicked()" />
  <p>{{todo().title}}</p>
</div>
```

now we can create a method to handle this event in the parent component:

```typescript
updateTodo(todoItem: TodoType) {
this.todos().map((todo) => {
  if (todo.id === todoItem.id)
    return { ...todoItem, completed: !todoItem.completed };
  return todo;
});
```

and use it in the template:

```html
<todo-element [todo]="todo" (todoToggled)="updateTodo($event)" />
```
