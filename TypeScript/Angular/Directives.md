# Directives:

---

## Generate a new directive:

using the cli, we can create a new directive using:

```bash
ng g directive -name-
```

this will generate a directive file, where we have a class decorated by the `@Directive` decorator:

```typescript
import { Directive } from "@angular/core";

@Directive({
  selector: "[appCustomDirective]",
})
export class CustomDirective {
  constructor() {}
}
```
