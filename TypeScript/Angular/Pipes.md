<!-- @format -->

# Pipes:

---

## Built in pipes:

to use any of the built-in pipes you must import them from `@angular/common`.

in template use pipes in the a binding `{{}}` by using the pipe symbol `|`.

```typescript
import { UpperCasePipe } from "@angular/common";
import { Component } from "@angular/core";

@Component({
	selector: "app-root",
	imports: [UpperCasePipe],
	template: `<h1>{{ title | uppercase }}</h1>`,
})
export class App {
	title = "my-app-is-in-lower-case";
}
```

as seen we don't call the pipe, we just place the reference.

> [!TIP] you can use multiple pipes, septate each with `|`

some built in pipes are:

- `UpperCasePipe` -> turns all letters into uppercase
- `LowerCasePipe` -> turns all letters into lowercase
- `TitleCasePipe` -> turns only the first letter into uppercase while other are in lower.
- `JsonPipe` -> turns a json object into a string using `json.stringify`.

---

## Passing data to pipes:

to pass data to pipes we can use `:` to pass the values, for example using this with the `DatePipe`:

```typescript
@Component({
	selector: "app-root",
	imports: [DatePipe],
	// will only display hours and minutes
	template: `<h1>{{ date | date : "hh:mm" }}</h1>`,
})
export class App {
	date = new Date(2020, 3, 3, 12, 30, 23);
}
```

---

## Custom pipes:

generate a new pipe using:

```bash
ng generate pipe -name-
```

this will create a class with the `@Pipe` decorator and implements the `Transform` interface.

```typescript
import { Pipe, type PipeTransform } from "@angular/core";

@Pipe({
	// the in-template name
	name: "custom",
})
export class CustomPipe implements PipeTransform {
	// the function called by angular
	transform(value: unknown, ...args: unknown[]): unknown {
		return `value is: ${value} and args are: ${args}`;
	}
}
```

we can enforce a value type or remove args, but value must be used.

now we can use this pipe:

```typescript
@Component({
	selector: "app-root",
	imports: [CustomPipe],
	template: `<h1>{{ value | custom : "arg" }}</h1>`,
})
export class App {
	value = "hello";
}
```
