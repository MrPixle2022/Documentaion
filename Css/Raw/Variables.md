# Variables

custom properties/variables are reusable values that help when we want to control multiple elements using a single value.

a variable is defined as:

```css
/*they are usually defined on the root pseudo class*/
:root {
  --var-name: value;
}
```

then later on we can access that value using the `var` function:

```css
selector {
  property: var(--var-name);
}
```
