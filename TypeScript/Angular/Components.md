<!-- @format -->

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

> [!NOTE] angular uses css modules, wether you use a septate style or inline style, the style will be scoped to that component and it's children only

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

> [!Note] in the input's options we can use the `alias` to change the name of the attribute in the template.

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

now you can change -in_code- this using the `.update` method

```typescript
increment() {
  // Update the model input with a new value, propagating the value to any bindings.
  this.value.update(oldValue => oldValue + 10);
}
```

now in the template use the two-way binding to attach this value to a local signal on your parent component:

```html
<custom-slider [(value)]="volume" />
```

---

## Accepting children:

to accept children in angular you can use the `ng-content` element. it works as placeholder for elements that may be passed.

for example:

```typescript
@Component({
	selector: "custom-card",
	template: '<div class="card-shadow"> <ng-content></ng-content> </div>',
})
export class CustomCard {
	/* ... */
}
```

since we used the `ng-content` we can insert content their:

```html
<custom-card>
	<p>This is the projected content</p>
</custom-card>
```

and angular will place the `p` in the very place of that `ng-content`.

---

## Multiple placeholders:

angular's `ng-module` can be used as a placeholder for a specific part using the `select` attribute, by using this attribute we can separate the passed content into smaller chunks.

for example if this is our template:

```html
<!-- Component template -->
<div class="card-shadow">
	<!-- placeholder 1 -->
	<ng-content select="card-title"></ng-content>

	<div class="card-divider"></div>

	<!-- placeholder 2 -->
	<ng-content select="card-body"></ng-content>
</div>
```

then we can use that in the parent as:

```html
<custom-card>
	<!-- card-title -> same as the select -->
	<card-title>Hello</card-title>
	<!-- card-body -> same as the select -->
	<card-body>Welcome to the example</card-body>
</custom-card>
```

> [!NOTE] if you have more then one `ng-content` but the last one doesn't have a `select` attribute, then it will take any remaining content

> [!TIP] between the `ng-content` tags you can add fallback values that are shown if no content is provided

if you don't want to use the `card-title` as an element and just use a normal html tag you can use the `ngProjectAs` attribute.

for example:

```html
<custom-card>
	<h3 ngProjectAs="card-title">Hello</h3>
</custom-card>
```

the `h3` will be considered a `card-title` element, and will thus will be placed in the `ng-content` with the `card-title` as the select.

> [!NOTE] > `ngProjectAs` only support static value and the value can't be dynamic
