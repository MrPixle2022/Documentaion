<!-- @format -->

# Box model:

the box model is the main theory behind css, it controls layout and positioning.

the box model represents each and every element as a rectangle that is divided into 4 parts:

- content -> the size of the element this includes the width and height
- padding -> the space between the content and the border -is a part of the element-
- border -> the line surrounding the element and is part of the element
- margin -> the spacing beyond the border

---

## Width & Height:

the `width` and `height` represents the dimensions of an element's content, the default values differ between block and inline elements.

block -by default- takes up the entire width of it's parent and the height is just enough for the content.

inline -by default- takes enough space for it's content both horizontally and vertically.

the dimensions of an element can be controlled by using:

```css
/* not for inline */
selector {
	width: _value_; /*for inline like behavior use `fit-content`*/
	height: _value_; /*for inline like behavior use `fit-content`*/
}
```
