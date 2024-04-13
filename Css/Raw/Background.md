# Background:

navigation:



----

## background-color:

the `background-color` allows you to set a chosen color as the background for the element.

```css
.target{
  background-color: blue;/*sets the back ground to blue */
}
```

---

## background-image:

the `background-img` allows you to grab an images via the `url` function and set it to be the main background instead of a static color, or use `linear-gradient` & `radial-gradient` to set a gradient background.

```css
.target1{
  background-image: url('./images/example.png');
}

.target2{
  background-image: linear-gradient(30deg, white, blue);
}

.target3{
  background-image: radial-gradient(circle, white blue);
}
```

---

## background-repeat:

the `background-repeat` allows you to set if the background should repeat to cover the element, or should it do that horizontally or vertically.

```css
.target{
  background-image: url('./images/example.png');
  background-repeat: repeat;
}
```

also it can take values for two axis:

```css
.target{
  background-image: url('./images/example.png');
  background-repeat: <horizontal> <vertical>;
}
```

possible values:

|value  |description  |
|---------|---------|
|repeat     |if used alone it will repeat on both axis, but when used in the two values syntax it affects a single axis|
|repeat-x     |set the repeat to work on the x|
|repeat-y     |set the repeat to work on the y|
|space     |spreads the repeats to spread as much as possible without clapping|
|round     |stretches all repeated images to cover the element leaving no gap|
|no-repeat     |cancels the repeat|

---

## background-attachment:

the `background-attachment` allows you to set the behavior of the background when scrolling.

```css
.target{
  background-image: url('./images/example.png');
  background-attachment: fixed; /*the background is fixed to the viewport and won't move when scrolling */
}
```

possible values:

|value  |description  |
|---------|---------|
|fixed|the background is fixed to the viewport and won't move when scrolling|
|scroll|the background moves against the scroll, normal behavior|
|local|the background is fixed relative to the element|

---

## background-position:

the `background-position` allows you to set the position of the background.

```css
.target{
  background-image: url('./images/example.png');
  background-position: center; /*the background is centered */
}
```

it has different ways of usage like:

```css
background-position: <position> <position>;
background-position: <position> <offset> <position> <offset>;
```

---

## background-size:

the `background-size` allows you set the width and height of the background.

```css
.target{
  background-image: url('./images/example.png');
  background-size: contain; /*the background repeats to cover the entire element*/
}
```

other possible values:


|value  |description  |
|---------|---------|
|contain     |the background repeats to cover the entire element, unless background-repeat is set to no-repeat|
|cover|scales the background to cover to entire element|
|<value>|scales the image to `value` on both axis, it will work similar to contain|
|<valueX> <valueY>|scales the image to `value` on both axis by x,y in order, it will work similar to contain|

