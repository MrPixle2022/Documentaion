# Box model properties:

using the box model in css allows you to control the size and position of the element, the box model uses:

- [width](#width)
- [height](#height)
- [border](#border)
- [padding](#padding)
- [margin](#margin)

---

## width:

the width allows you to set how wide can the element be, the width can be set using:

**width**:
```css
.target{
    width: 100px; /*sets the width to be a constant of 100px*/
}
```

**min-width**:
```css
.target{
    min-width: 100px; /*sets the width to be flexible, so it can be any val but can't be lower than 100px*/
}
```

**max-width**:
```css
.target{
    max-width: 100px; /*sets the width to be flexible, so it can't be wider than 100px at max*/
}
```

---

## height:

the height similar functions similar to the `width` property but works on the other axis, it can be set using:

**height**:
```css
.target{
    height: 100px; /*sets the height to be a constant of 100px*/
}
```

**min-height**:
```css
.target{
    min-height: 100px; /*sets the height to be flexible, so it can be any val but can't be lower than 100px*/
}
```

**max-height**:
```css
.target{
    max-height: 100px; /*sets the height to be flexible, so it can't be wider than 100px at max*/
}
```

---

## border:

the border allows you to create a thick outline around the element, but note ***the width of the border is not included in the width calculation by default so if you have a 2px on the border's thickness and the width is 100px, then the total width is 102px***

or reset the box-sizing by using:

```css
*{
    box-sizing: border-box;/*the width of the border will be included in the calculation*/
}
```

the border takes three `required` values but their order doesn't matter:

```css
.target{
    border: thickness style color
}
```

`thickness`: how wide the border
`style`: the type of border like `solid, dotted, wavy`
`color`: the color used by the border

also you have control 

**over each side's border**:
```css
.target{
    border-side: thickness style color
}
```

**over the arc of the border**:
```css
.target{
    border-radius: over-all-radius over-all-2nd-radius;
    border-verticalside-horizontalside-radius: arc1 arc2;
}
```

**spacing between borders**
```css
.target{
    border-space: val;
}
```

---

## padding:

padding allows you to control the space between **the content** and **the border**, it can set by using:

**padding**:
```css
.target{
    padding: padding-around-the-element;
    padding: vertical horizontal;
    padding: top right bottom left;
}
```

**padding-side**:
```css
.target{
    padding-side: size;
}
```

---

## margin:

the margin allows you to set the invisible space around the element out side the border, it's identical in syntax to the padding:

```css
.target{
    margin: margin-around-the-element;
}
```

```css
.target{
    margin: vertical horizontal;
}
```

```css
.target{
    margin: top right bottom left;
}
```