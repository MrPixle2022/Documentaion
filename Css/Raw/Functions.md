# Functions

css has some useful function that has their use cases.

---

## var

the `var` function is used to access the value of a variable within a rule.

```css
selector {
  property: var(--var-name);
}
```

---

## min, max

the `min` and `max` functions are used to get the smallest/biggest value in a set of values.

```css
selector {
  property1: min(v1, v2, v3); /*returns the smallest*/
  property2: max(v1, v2, v3); /*returns the biggest*/
}
```

---

## url

the `url` is used to get the content of the given url, used with font family rules and external images as backgrounds.

```css
selector {
  background-image: url("path");
}
```

---

## calc

the `calc` is used to run a calculation that contains variable values or complex to calculate manually.

```css
selector {
  width: calc((100vw - 12px +) / 1rem);
}
```
