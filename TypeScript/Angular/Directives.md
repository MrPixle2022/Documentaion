<!-- @format -->

# Directives:

---

## Generate a new attribute directive:

for our example we will create a directive that will highlight an element.

using the cli, we can create a new directive using:

```bash
ng g directive -name-
```

this will generate a directive file, where we have a class decorated by the `@Directive` decorator.

```typescript
import { Directive, ElementRef, inject } from "@angular/core";

@Directive({
	selector: "[highlightOnHover]",
})
export class HighlightOnHoverDirective {}
```

now in the class inject the `ElementRef` and apply the styles in the `constructor`

```typescript
// inject a reference to the element on which this directive is used
private element = inject(ElementRef);

constructor() {
  // will change the background color to yellow
  this.element.nativeElement.style.backgroundColor = 'yellow';
}
```

now to use it import the directive and apply it to an element:

```typescript
import { ChangeDetectionStrategy, Component } from "@angular/core";
import { HighlightOnHoverDirective } from "../highlightOnHover.directive";

@Component({
	selector: "highlightAble",
	imports: [HighlightOnHoverDirective],
	template: `<h1 highlightOnHover>Hello</h1>`,
	changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HighlightAbleComponent {}
```

---

## Accepting values:

to allow our directive to accept values we can use the `input` method to create a signal of a given value.

also we want to make it reactive, so in the constructor we will use an effect to update the value of the background on the element.

```typescript
@Directive({
	selector: "[highlightOnHover]",
})
export class HighlightOnHoverDirective {
	// ignore the type it was hardcoded purely for this case
	private element: { nativeElement: HTMLParagraphElement } = inject(
		ElementRef<HTMLParagraphElement>,
	);

	hightLightColor = input<string>("");

	constructor() {
		effect(
			() =>
				(this.element.nativeElement.style.backgroundColor =
					this.hightLightColor()),
		);
	}
}
```

now we can pass it a value and even bind it using `[highlightOnHover]`:

```typescript
@Component({
	selector: "highlightAble",
	imports: [HighlightOnHoverDirective],
	template: `<p
		highlightOnHover
		[hightLightColor]="color">
		{{ color() }}
	</p>`,
})
export class HighlightAbleComponent {
	color = "red";
}
```

notice that to bind the `hightLightColord` we had to use the `highlightOnHover` directive.

---

## Responding to events in directives:

to listen to event in directives we use the `HostListener` decorator to decorate a method that will run on a certain event.

the `HostListener` takes the event name as a string param and we can make use of that to apply our styles.

first create the method to apply the styles:

```typescript
applyHighLight() {
  (this.element.nativeElement.style.backgroundColor = this.hightLightColor())
}
```

now we can use the `@HostListener`.

```typescript
@HostListener('mouseenter')
onMouseEnter() {
  this.applyHighLight();
}
```

---

## Built in directives:

this part will discus `ngClass` & `ngStyle`.

- `ngClass` allows you to assign classes dynamically
- `ngStyle` allows you to assign inline styles.

we will use the two together as both are almost the same in usage.

first import `NgClass` and `NgStyle` from `@angular/common` and add them to the `imports` this gives you access to both directives.

```typescript
import { NgClass, NgStyle } from "@angular/common";
import { Component, signal } from "@angular/core";

@Component({
	selector: "app-root",
	imports: [NgClass, NgStyle],
	template: `<h1
			[ngClass]="getClassName()"
			[ngStyle]="createStyle()">
			Hello component
		</h1>
		<button (click)="toggle()">toggle</button>`,
	styles: `
  .blue{color: blue};
  .red{color:red};
  `,
})
export class App {
	color = signal("blue");

	toggle() {
		this.color.update((color) => (color === "blue" ? "red" : "blue"));
	}

	getClassName() {
		return {
			blue: this.color() === "blue",
			red: this.color() === "red",
		};
	}

	createStyle() {
		return {
			"font-size": "20px",
		};
	}
}
```
