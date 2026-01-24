<!-- @format -->

# Display

## block

block elements are elements that:

- default width is the full width of the parent
- adds line breaks before and after the element
- respects padding & margins, width & height

an example of a block-element would be things like:

- div
- section
- h1 -> h6
- p
- nav
- footer

and other container elements

---

```html
<div>Div => Block</div>
<div>Div => Block</div>
<div>Div => Block</div>
```

```css
div {
  display: block;
  background: #ddd;
  padding: 10px;
  margin: 10px;
}
```

![Display block](Images/DisplayBlock.png)

---

## inline

inline elements like `span`, `a`, `img` are elements whose width and height are determined by the content as they take just enough space to fit their content.

inline elements:

- width is set by the content & can't be overwritten -by default-
- no line-break
- doesn't respect width & height, but respects padding & margins **horizontally only**

---

```html
<span>Span => inline</span>
<span>Span => inline</span>
<span>Span => inline</span>
```

```css
span {
  background: #eee;
  width: 1000000px;
  padding: 20px;
}
```

![Display inline](Images/Display%20Inline.png)

---

## inline block

inline-block elements are a mix of `inline` & `block` elements.

inline-block elements:

- allows element to be before & after it
- respects width & height, margin & padding

---

```html
<section>Section => inline-block</section>
<section>Section => inline-block</section>
<section>Section => inline-block</section>
```

```css
section {
  display: inline-block;
  background: #636363;
  width: 400px;
}
```

![Inline block](Images/Inline%20block.png)
