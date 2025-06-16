# Reactive forms:

reactive forms are model-driven forms, they use observables to react to changes.

to use them import the `ReactiveFormsModule` from `@angular/forms` and add the module to the `imports` array.

---

## Form control:

the `formControl` class represents a single element of the form.

```typescript
import {Component} from '@angular/core';
import {FormControl, ReactiveFormsModule} from '@angular/forms';
@Component({
  ...
  imports: [ReactiveFormsModule],
})
export class NameEditorComponent {
  name = new FormControl('');
...
}
```

then in the template add an input and use bind the `formControl` directive:

```html
<label for="name">Name: </label> <input id="name" type="text" [formControl]="name" />
```

also we can display the value of the `name` in-template using `name.value`

```html
<h1>{{nameControl.value}}</h1>
```

and also `name.value` can be used to get the value in the code

it's worth noting that reactive forms are use observables, and actually on the `name` control we have a `valueChange` observable we can subscribe to

```typescript
this.nameControl.valueChanges.subscribe((value) => console.log(value));
```

---

## Updating form controls:

we can update a from control in code using the `.setValue` method:

```typescript
this.nameControl.setValue("hello");
```

---

## From groups:

form groups define static and pre-defined forms, they are composed of form controls and other form groups for more complex forms.

to use a `form group` use the `FormGroup` class and define your forms as key value pairs:

```typescript
myGroup = new FormGroup({
  firstname: new FormControl("" /*validators*/),
  lastname: new FormControl(""),
  age: new FormControl(0),
  pro: new FormControl(false),
});
```

now we will have to create a template matching our form group.

after doing this we will use the `formGroup` and `formControlName` directives to bind the from the group:

```html
<form [formGroup]="myGroup"">
  <input type="text" name="firstname" formControlName="firstname">
  <input type="text" name="lastname" formControlName="lastname">
  <input type="number" name="age" formControlName="age">
  <input type="checkbox" name="pro" formControlName="pro">
  <button type="submit">sub</button>
</form>
```

now to read the values we can make use of an event handler:

```typescript
onSubmit(event: Event) {
  // TODO: Use EventEmitter with form value
  event.preventDefault();
  console.warn(this.myGroup.value);
}
```

```html
<form [formGroup]="myGroup" (submit)="onSubmit($event)">
  <input type="text" name="firstname" formControlName="firstname" />
  <input type="text" name="lastname" formControlName="lastname" />
  <input type="number" name="age" formControlName="age" />
  <input type="checkbox" name="pro" formControlName="pro" />
  <button type="submit">sub</button>
</form>
```

the result is an object where each control is mapped to it's value

---

## Nested from groups:

to nest form groups you just add them in the parent group as you would with a from control:

```typescript
myGroup = new FormGroup({
  firstname: new FormControl(""),
  lastname: new FormControl(""),
  age: new FormControl(0),
  pro: new FormControl(false),

  address: new FormGroup({
    country: new FormControl(""),
    state: new FormControl(""),
    city: new FormControl(""),
  }),
});
```

then update the template.

but this time we will use the `formGroupName` for nested groups and use divs instead:

```html
<form [formGroup]="myGroup" (submit)="onSubmit($event)">
  <input type="text" name="firstname" formControlName="firstname" />
  <input type="text" name="lastname" formControlName="lastname" />
  <input type="number" name="age" formControlName="age" />
  <input type="checkbox" name="pro" formControlName="pro" />
  <hr />
  <div formGroupName="address">
    <input formControlName="country" placeholder="country" />
    <input formControlName="state" placeholder="state" />
    <input formControlName="city" placeholder="city" />
  </div>
  <hr />
  <button type="submit">sub</button>
</form>
```

the result is that the group's control's values are in the `address` object in the parent group's `.value`

so if we want to display the values of the form group:

```html
<pre>
  name: {{myGroup.value.firstname}} - {{myGroup.value.lastname}}
  age: {{myGroup.value.age}}
  pro: {{myGroup.value.pro}}
  address:
    country: {{myGroup.value.address?.country}}
    state: {{myGroup.value.address?.state}}
    city: {{myGroup.value.address?.city}}
</pre>
```

---

## Updating values in code:

to update the from model we use either `setValue` or `patchValue`.

the different being:

- `setValue` requires all controls in a group -or array- to be defined.
- `patchValue` allows you to manually pick controls to override their value.

---

## Form builder:

the `FormBuilder` class is an injectable service that can be used to create reactive forms.

first import it from `@angular/forms` and inject it in the class:

```typescript
import { Component, inject } from "@angular/core";
import { ReactiveFormsModule, FormBuilder } from "@angular/forms";

@Component({
  selector: "reactive-form",
  imports: [ReactiveFormsModule],
})
export class ReactiveForm {
  private formBuilder = inject(FormBuilder);
}
```

now we can use it to define the form structure:

```typescript
myFrom = this.formBuilder.group({
  name: this.formBuilder.group({
    firstname: [""],
    lastname: [""],
  }),
  age: [0],
  pro: [false],
});
```

notice we define the control as an array, that's actually because the first value is used as the initial and other elements are the validators.

having defined the form , we can repeat the process -of building and assigning- for the template:

```html
<form [formGroup]="myFrom"">
  <div formGroupName="name">
    <input placeholder="first" formControlName="firstname" />
    <input placeholder="last" formControlName="lastname" />
  </div>
  <input type="number" formControlName="age" />
  <input type="checkbox" formControlName="pro" />
  <button type="submit">Sub</button>
</form>
```

we can get the value also using:

```typescript
myFrom.value;
```

---

## Validators:

first import `Validators` from `@angular/forms`.

```typescript
import { Validators } from "@angular/forms";
```

having done that we can make use of angular's built-in validators in our form builder:

```typescript
myFrom = this.formBuilder.group({
  name: this.formBuilder.group({
    firstname: ["", Validators.required],
    lastname: ["", Validators.minLength(4)],
  }),
  age: [0, Validators.min(10)],
  pro: [false],
});
```

we have things like:

- `required` -don't call- makes sure the control is not empty
- `requiredTrue` -don't call- makes sure the control is true -checkboxes-
- `min(n)` makes sure the value is at least n -for numbers-
- `max(n)` makes sure the value is at max n -for numbers-
- `minLength(n)` makes sure the number of element is at least n -for arrays and strings-
- `maxLength(n)` makes sure the number of element is at max n -for arrays and strings-

having done that we can see wether the form is `VALID` or `INVALID` using:

```html
<p>{{myFrom.status}}</p>
<!-- VALID if valid else INVALID -->
```

and as a matter of fact we can detect what is invalid using:

```typescript
console.log(this.myFrom.controls.name.controls.firstname.errors);
```

it's bad that we have to target the very control to get the errors, so we can create a `getter` for those controls we want to validate.

```typescript
get firstName() {
  return this.myFrom.controls.name.get('firstname')
}
```

just make sure to target the very control you want, but now we have direct access to that very control and we can update, read or validate it directly

know that you can create custom validators, you usually create them as function factories:

the factory takes the options and the returned method takes the control -of type `AbstractControl`- and returns null if accepted, else it would return something

```typescript
/** An actor's name can't match the given regular expression */
export function forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const forbidden = nameRe.test(control.value);
    return forbidden ? { forbiddenName: { value: control.value } } : null;
  };
}
```

---

## Async Validators:
