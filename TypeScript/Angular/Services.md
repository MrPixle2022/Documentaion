<!-- @format -->

# Services:

services are the injectable part responsible for data fetching. they can be generated from the cli using:

```bash
ng g service -name-
```

the service class is decorated with the `injectable`, some of them must be included in a component's `providers` array, while some are globally available.

```typescript
import { Injectable } from "@angular/core";
import type { TodoType } from "../../Models/todo.type";

Injectable({
	providedIn: "root", //means that this doesn't need to be in the `providers` of every component -this is a global injectable-
});
export class TodoService {
	todoItems: TodoType[] = [
		/*--*/
	];
	constructor() {}
}
```

> [!NOTE] you can also make it component based by including the service in the component's `providers` array.

now this `TodoService` is provided in the root, so it's available to the entire project. to use it we pass the class to the `inject` method.

```typescript
import { Component, inject, signal, type OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { TodoService } from "../../services/todo";
import type { TodoType } from "../../../Models/todo.type";

@Component({
	selector: "app-todo",
	imports: [RouterOutlet],
	templateUrl: "./todo.html",
	styleUrl: "./todo.css",
})
export class Todo implements OnInit {
	todoService = inject(TodoService);

	todos = signal<TodoType[]>([]);

	ngOnInit(): void {
		this.todos.set(this.todoService.todoItems);
	}
}
```

---

## Http calls via services:

first let's add the `HttpClient` to the project.

in the `app.config.ts` add:

```typescript
import { provideHttpClient } from "@angular/common/http";

export const appConfig: ApplicationConfig = {
	providers: [provideHttpClient() /*---*/],
};
```

this provides the app with the `HttpClient`. now we can inject it in our service, with that we have access to methods like `get`, `post`, `patch`, etc..

so for example if we want to create a get request we can use:

```typescript
import { HttpClient } from "@angular/common/http";

@Injectable({
	providedIn: "root", //means that this doesn't need to be in the `providers` of every component -this is a global injectable-
})
export class TodoService {
	http = inject(HttpClient);

	getTodos() {
		return this.http.get<TodoType[]>(
			"https://jsonplaceholder.typicode.com/todos",
		);
	}
}
```

now this `get` returns an observable so we must subscribe to it first in our component.

```typescript
import { Component, inject, signal, type OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { TodoService } from "../../services/todo";
import type { TodoType } from "../../../Models/todo.type";
import { catchError } from "rxjs";

@Component({
	/*--*/
})
export class Todo implements OnInit {
	todoService = inject(TodoService);

	todos = signal<TodoType[]>([]);

	ngOnInit(): void {
		this.todoService
			.getTodos() //call it
			.pipe(
				//validate
				catchError((err) => {
					console.log(err);
					throw err;
				}),
			)
			.subscribe((todos) => this.todos.set(todos)); //subscribe to the observable
	}
}
```

now we can use the response of the api.
