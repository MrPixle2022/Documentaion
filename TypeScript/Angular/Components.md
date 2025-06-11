# Component:

a component is a class decorated with the `@Component` decorator and has the options defined in the decorator factory:

```typescript
import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: "app-root", //the component-name in html
  imports: [RouterOutlet], //what modules used by this component
  //template: `<your-html/>`
  templateUrl: "./app.html", //the url of template file
  // style: ['{your-css;']
  styleUrl: "./app.scss", //the url of the style file
})
export class App {
  protected title = "angular-90"; //a property
}
```

if the component is a single file component it may look like:

```typescript
import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: "app-root",
  imports: [RouterOutlet],
  template: `<h1>{{ title }}</h1>`,
  style: [`p {color:red;}`],
})
export class App {
  title = "angular-90";
}
```

> [!NOTE]
> angular uses css modules, wether you use a septate style or inline style, the style will be scoped to that component and it's children only

---

## Create a new component

using the `ng` cli:

```bash
# alias for the command
ng g c -name-
#name can be nested -> component/hero -> creates a component folder and hero component in it
```

and depending on your configuration you either get a `.html`, `.css` -if you chose css- and a `.ts` file or a single `.ts` file that contains the template, style and logic.

---

## Importing components

if you have a component that you want to use import it and add it to the `imports` array:

```typescript
import { Component, signal } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { Home } from "./home/home";

@Component({
  selector: "app-root",
  imports: [---, Home],
})
export class App {
  //----
}
```

this allows us to use that component in the template by the component's selector.

```html
<h1>This is app.ts</h1>
<!-- the imported component -->
<app-home></app-home>
```

---

## Passing data to components:

to pass data from parent to child we use the `input` or the `@input` decorator.

let's assume we have `greeting` which is a child to the `home` component.

```typescript
@Component({
  // ---
})
export class Greeting {
  //this message will be passed via the parent, default is 'Undefined'
  message = input<string>("Undefined", {
    /*options*/
  });
}
```

now -after importing the `greeting` in the `home`- in the template of the parent we can assign this `message` value.

but we have to ways to do so.

> [!Note]
> in the input's options we can use the `alias` to change the name of the attribute in the template.

- hardcoded -> we pass the data just like an html attribute

```html
<!-- hardcoded -->
<app-greeting message="hello"></app-greeting>
```

- js expression -> contain the attribute between `[]` and between the `""` add a js expression

```html
<!-- as js expression -->
<app-greeting [message]="'hello My component'"></app-greeting>
```

in this case we hade to use `''` to pass a string.

---

## Required inputs:

to make an attribute required use the `input.required`:

```typescript
value = input.required<number>();
```

this makes it required, if not provided angular will throw a build-time error.

---

## Modal inputs:

modal inputs are special inputs the propagate the change to their parent via two-way binding, defined by the `model` function:

```typescript
value = model(0);
```

now you can change this using the `.update` method

```typescript
increment() {
  // Update the model input with a new value, propagating the value to any bindings.
  this.value.update(oldValue => oldValue + 10);
}
```

now in the template use the two-way binding to attach this value to a local signal:

```html
<custom-slider [(value)]="volume" />
```
