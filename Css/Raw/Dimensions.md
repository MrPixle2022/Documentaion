<!-- @format -->

# Dimensions:

## width:

with the `width` property you can hard code the width of a `block`, `inline-block` element.

```css
selector {
	width: value;
}
```

you can set the `width` to `fit-content` to set the width to the width of the content

---

## min-width:

the `min-width` allows you to make an element dynamically set it's width while not allowing it to shrink more than the given value.

```css
selector {
	min-width: value;
}
```

can also take `fit-content` which is similar to `inline` elements

---

## max-width:

the `max-width` is identical to the `min-width` but in reverse, by allowing an element to dynamically grow and shrink, but stopping it's growth at a certain point.

```css
selector {
	max-width: value | fit-content;
}
```
