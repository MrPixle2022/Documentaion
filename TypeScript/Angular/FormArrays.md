# Form arrays:

form arrays are special class used in `reactive forms` along side `FormGroup` and `FormControl`.

so it requires the `ReactiveFromModule`

start by importing the `FormArray` class from `@angular/forms`.

```typescript
import { FormArray } from "@angular/forms";
```

---

## Creating a Form Array:

we will use the `FormArray` in a from builder service in this example, we will create a form where a user can add multiple emails dynamically.

in a builder we can define a from array using:

```typescript
this.builder.array([]);
```

so in our example:

```typescript
import { Component, inject } from '@angular/core';
import { ReactiveFormsModule , FromBuilder, FormArray, FormBuilder} from '@angular/forms';

@Component({
  ---
  imports: [ReactiveFormsModule],
})
export class FormArrayComponent {
  private builder = inject(FormBuilder);

  myGroup = this.builder.group({
    username: '',
    emails: this.builder.array([])
  });

  get emails() {
    return this.myGroup.get('emails') as FormArray;
  }
}
```

now lets create the ui template, make sure that the container has the `formArrayName` directive assigned to `emails` so that we can target the array:

```html
<form [formGroup]="myGroup">
  <input formControlName="username" />
  <button>Add email</button>
  <div formArrayName="emails">
    <!-- for the array -->
  </div>
</form>
```

---

## Pushing elements:

to push controls into the arrays we need a function to do that, and a place to display all controls.

first let's create the push function:

```typescript
pushEmail() {
  this.emails.push(this.builder.control(''));
}
```

now let's attach the function to the button on click:

```html
<form [formGroup]="myGroup">
  <input formControlName="username" />
  <button (click)="pushEmail()">Add email</button>
  <div formArrayName="emails"></div>
</form>
```

now for the arrays it self we will use `@for` to loop over -not the emails array- but the `emails.controls`

```html
<form [formGroup]="myGroup">
  <input formControlName="username" />
  <button (click)="pushEmail()">Add email</button>
  <div formArrayName="emails">
    @for(control of emails.controls; track $index;){
    <input type="email" placeholder="Email" [formControlName]="$index" />
    }
  </div>
</form>
```

---

## Removing controls:

first will start by creating a method to remove an item based on it's index:

```typescript
removeEmail(index: number) {
  this.emails.removeAt(index);
}
```

then we will edit the template a little, we will contain the input and a newly added button with a section, the button will be responsible for triggering the `removeEmail` method:

```html
<section>
  <input type="email" placeholder="Email" [formControlName]="$index" />
  <button (click)="removeEmail($index)">remove</button>
</section>
```

> [!TIP]
> We can also make use of the `.clear()` method on the from array class
