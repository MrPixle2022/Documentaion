<!-- @format -->

# Pseudo classes:

a `pseudo class` is a keyword with a `:` added to the end of the selector, like:

```css
selector:pseudo-class {
}
```

---

## State pseudo classes:

the `state pseudo classes` are used to dynamically style an element based on user interaction, usually used with hyper links.

this includes:

- :link -> hyperlinks that are yet to be visited
- :visited -> hyperlinks that have been visited
- :hover -> active on hover (useless on touchscreens)
- :active -> active on click
- :focus -> active on focus
- :valid -> when the input is valid
- :invalid -> when the input is invalid
- :user-valid -> when input is valid -after user input-
- :user-invalid -> when input is invalid -after user input-
- :required -> when the input is required
- :checked -> when the checkbox is checked
- :disabled -> when the element is disabled

---

## Conditional pseudo classes:

the `conditional pseudo classes` apply styling based on an element's position in relation to other elements.

this includes:

- :first-child -> when the element is the first child of it's parent
- :last-child -> when the element is the last child of it's parent
- :only-child -> when the element is the only child of it's parent
- :nth-child(n) -> when the element is the nth child of it's parent
- :nth-last-child(n) -> when the element is the nth last child of it's parent

for the `nth` classes we can pass either a number or an equation where the variable is `n`:

```css
selector:nth-child(n + 1) {
}
```
