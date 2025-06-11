# Data binding:

dynamic data can be embedded in the template using `{{ }}`.

for example:

```html
<!-- if property -->
<h1>{{ title }}</h1>
<!-- if signal -->
<h1>{{ titleSignal() }}</h1>
```

## Class properties:

using `class properties` is the old way of binding data in angular.

just by defining a property on the component class we can access them in the template:

```typescript
@Component({
  //---
})
export class Header {
  title = "hello";
}
```

now in the template:

```html
<header class="w-screen h-20 px-2 bg-gray-800 text-white">
  <nav class="flex w-full h-full items-center justify-start">{{title}}</nav>
</header>
```

---

## Signals:

signals are the new binding method in angular, they can store data of a defined type using generics.

signals are reactive, on change they update the ui with them

to use them import `signal` from `@angular/core`:

```typescript
@Component({
  //----
})
export class Header {
  title = signal<string>("hello");
}
```

then in the html template:

```html
<header class="w-screen h-20 px-2 bg-gray-800 text-white">
  <nav class="flex w-full h-full items-center justify-start">{{title()}}</nav>
</header>
```

signal can be update using the `set` method on the signal or use the `update` to use from the previous value.

```typescript
myNumber = signal<number>(0);

myNumber(); //0

myNumber.set(10); // the value is now 10
myNumber.update((prev) => prev * 2); //value is now 20
```
