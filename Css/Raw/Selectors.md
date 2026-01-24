<!-- @format -->

# Selectors & rules

navigation:

- [rules](#rules)
- [element selector](#element-selector)
- [class selector](#class-selector)
- [id selector](#id-selector)

---

## Rules:

the `css rule` is an entire block, composed of the selector, `{ }` -deceleration block-, properties & values.

```css
/*all of this is a rule*/
selector {
  property1: value; /*declaration*/
  property2: value; /*declaration*/
}
```

> [!TIP] multiple selectors can share a rule, separate each with a `,`

```css
/* pick each p that is a children of a div & also pick every ul */
div p,
ul {
  /* your css here */
}
```

---

## Element selector:

the `element selector` other ways know as `typed selector` allows you to target all elements of a specific type, this is the least specific form of a selector -the `*` being the only one below it- and is used for setting default styles.

```css
tag-name {
  /*your css here*/
}
```

for example:

```html
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
```

```css
/** Element Selector -> tag */
p {
  color: red;
}
```

---

## Class selector:

using the class selector you can target multiple elements that have the `class` attribute equals the class being targeted.

```css
.class-name {
  /* your css here */
}
```

for example:

```html
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
<p class="specialP">This is a paragraph with class</p>
```

```css
/** Class selector -> .Class-name  */
.specialP {
  color: blue;
}
```

> [!NOTE] For more specificity you can nest classes to be more specific.

```css
/* the element with both class1 and class2 together*/
.class1.class2 {
  /*your css here*/
}
```

---

## Id selector:

the id selector allows you to target an element with a specific value to the `id` attribute.

```css
/* nestable */
#id-name {
  /*your css here*/
}
```

for example:

```html
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
<p>This is a normal paragraph</p>
<p class="specialP">This is a paragraph with class</p>
<p id="specialP">This is a paragraph with id</p>
```

```css
/** Id selector -> #Id-name*/
#specialP {
  color: green;
}
```

---

## Combinator selector:

`combinator` selectors or `relative` selectors are used to target elements based on their position relative to each other.

in this category we have:

### descendant selector:

the `descendent selector` aka the ` ` allows you to target specific element based on it's parent.

```css
selector1 selector2 {
  /*css here*/
}
```

the `selector2` is the one we are targeting, we are targeting `selector2` that is a child of `selector1`.

```html
<div>
  <h2>Title</h2>
  <p>Paragraph inside div</p>
</div>
<p>Paragraph outside div</p>
```

```css
/* div.p (In OOP style) */
div p {
  color: red;
}
```

also this can be nested:

```css
div {
  /* div style */
  p {
    /* p style */
  }
}
```

for example:

```css
div {
  color: #00f;
  ul {
    color: #f00;
  }
}
```

### child selector:

this is a `>` between two selectors, it picks any element that is a **direct** child of the first selector.

for example:

```css
/* every li that is -directly- a child to a ul */
ul > li {
}
```

### next sibling selector:

this is a `+` between two selectors and is used to pick an element which is the next -directly- to the first selector.

for example:

```css
/* each button that is the next direct sibling to a ul */
ul + button {
}
```

### subsequent sibling selector:

this is a `~` between two selectors and is used to pick an element which comes after the first selector but both **must** share the same direct parent no matter the distance between them.

for example

```css
/* every button that is a sibling to an h1 and comes after it */
h1 ~ button {
}
```
