# Units

units in css are various and crucial, they can be separated into two types:

1. absolute units: fixed sizes regardless of the size of the parent, includes `px`, `pt`, `in`, `cm` and `mm`
1. relative unites: varies in value depending on the size of the parent, includes `%`, `rem`, `em`, `vh` and `vw`

there are more units of course.

---

## Pixels

the `px` unit is to be used for:

- border radius
- borders
- letter spacing
- icons and logo sizes
- max-width
- shadows

---

## Percentage

the `%` is unit that is relative to another value -mostly the parent- and are used with:

- padding and margin
- height and width

---

## Root element

the `rem` is a relative unit whose value is relative the the `font size` of the **root element** aka the `html` tag which is `16px` by default.

usually used with:

- font size
- margins and paddings

of course the value of the root font size can be changed using css.

---

## Element

the `em` is a relative unit that is more context specific.

when used with **typography** the value is relative to the `font size` of the parent, with other elements it becomes relative to the font size of the element itself.

---

## View height/width

the `vw` and `vh` are units that are relative to the width and height of the screen respectively.
