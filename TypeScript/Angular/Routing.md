# Routing:

routing is added by default in the project, by default the `app.ts` has the `router-outlet` component imported in it and there is an `app.routes.ts` file for routing.

> [!IMPORTANT]
> the `router-outlet` must be used to display the corresponding components

---

## Creating routes:

in the `app.routes.ts` you will find:

```typescript
import { Routes } from "@angular/router";

export const routes: Routes = [];
```

in this `routes` array we define our routes.

a route object has to define:

- `path`: the corresponding url
- `loadComponent`: a function that returns an import statement with the component's class

for example:

```typescript
import { Routes } from "@angular/router";

export const routes: Routes = [
  {
    path: "", //the root
    pathMatch: "full", // a must for the root
    loadComponent: () => import("./home/home").then((module) => module.Home),
  },
  {
    path: "todos",
    loadComponent() {
      //the component to import.
      //the Todo class from the todo module
      return import("../app/pages/todo/todo").then((m) => m.Todo);
    },
  },
];
```

using `loadComponent` will lazy load it. though we can use `Component` to import it directly.

```typescript
{
  path: 'todos',
  component: Todo, //directly import it
},
```

we can also define some other data like:

- `title`: the new title of the new page
- `redirectTo`: the url to redirect a visit to

> [!IMPORTANT]
> for the `path` use `:param` to define a dynamic path param, `**` for a wildcard which is useful for not-found pages

---

## Nested Routes:

on each route we have a `children` route, which in itself is an array of child routes:

```typescript
{
  path: 'todos',
  component: Todo,
  title: 'todos',
  children: [
    {
      path: 'info', //todos/info
      pathMatch: 'full',
      component: Info,
    },
  ],
},
```

but it requires the parent to have a `router-outlet` component.

---

## Displaying routes:

in a component that has nested routes import the `router-outlet` component from `@angular/router` and use it in the template.

```typescript
import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
  imports: [RouterOutlet],
})
export class MyComponent {}
```

```html
<router-outlet />
```

---

## Navigation:

to navigate between routes in angular import the `RouterLink` in the component.

this allows the use of the `routerLink` attribute in the template

```html
<nav class="flex w-full h-full items-center justify-start gap-3">
  <button class="" routerLink="/">Home</button>
  <button class="" routerLink="todos">Todos</button>
</nav>
```

---

## Reading params and queries:

to read params and queries use the ``, inject it in the constructor then use it in the `ngOnInit` method:

```typescript
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  //----
})
export class Info {
  constructor(private activatedRoute: ActivatedRoute) {}

  params: any;
  query: any;

  ngOnInit() {
    this.params = this.activatedRoute.params;
    this.query = this.activatedRoute.queryParams;
    console.log("params");
    console.table(this.params._value);
    console.log("queries");
    console.table(this.query._value);
  }
}
```
