<!-- @format -->

# Text & Typography:

---

## Color:

the `color` property is used to define the color of the text, using named colors, `rgb(r, g, b)`, `rgba(r, g, b, a)`, hexadecimal, `hsl(h, s, l)`, `hsla(h, s, l, a)`, etc...

```css
selector {
	color: #07c9ffff;
}
```

> [!TIP] Pick a base color, then from it make tints -lighter versions- and shades -dark versions- and a gray one

primary colors are to be used on dominant elements, buttons, backgrounds and more, while secondary colors are to add variety.

---

## Font weight:

the `font-weight` property is used to determine the thickness of the text, we can use either named values like `bold`, `bolder`, `normal`, `lighter` or numeric values such as `100`, `200`, ... `900`.

both numeric and named values map to each other, for example:

- 400 -> normal
- 500 -> medium
- 600 -> semi-bold
- 700 -> bold -default for headers-

```css
p {
	font-weight: bold;
	/* also same as */
	/* font-weight: 700; */
}
```

> [!TIP] for headings thickness should be in 500 - 900, and other next 300 - 400

---

## Font style:

the `font-style` sets the style of the text, from `normal`, `italic`, `oblique`, `oblique _deg_`

for example:

```css
selector {
	font-style: oblique 30deg;
}
```

---

## Font size:

the `font-size` is used to set the size of the text:

```css
selector {
	font-size: _value_;
}
```

> [!TIP] keep normal text between 16px to 32px, headings can be > 60px

you usually would want to use a type-scale system to help provide structure to the text

---

## Font family:

the `font-family` is used to set the font family of the text, but before that let's take about somethings:

#### type faces:

type faces are fonts that share a consistent visual characteristic, for example:

- serif: has an extra detail at the end of the stork, usually gives a classic/classy vibes (times)
- sans-serif: has straight ends and lacks tha detail of serif, usually reflects simplicity & clarity (arial)
- monospace: all letters are of same width, for a technical feel, reflects accuracy (courier new)
- cursive: joining strokes or mimicking hand-writing, personal feel, emotional (comic sans ms)
- display: attention-gapping and artistic, wall-breaking, bold (impact)

```css
selector {
	font-family: font1, fallback1, fallback2;
}
```

for example:

```css
h1 {
	font-family: "Thoma", sans-serif;
}
```

> [!NOTE] individual fonts are in `""` or `''` while font groups are not

keep in mind that a font group will use the system's default for that family

---

## Text decoration:

the `text-decoration` is used to add some **decorative lines** to the text, this can be:

- underline (default for anchors)
- line-through
- overline
- none (default)

also we can chose the line's color, style -double, dotted, wavy, solid (default) , dashed-, thickness and

```css
selector {
	/* line-type color style thickness */
	text-decoration: underline blue wavy 2px;
}
```

> [!TIP] remove text-decoration from `a` tags, use them only when needed.

---

## Text transform:

the `text-transform` controls the capitalization of the text, by choosing one of the following values:

- uppercase: all letters to uppercase
- lowercase: all letters to lowercase
- capitalize: first letter of each word is uppercase
- none (default): text appears as it was written

```css
h1 {
	text-transform: uppercase;
}
```

---

## Text align:

the `text-align` is used to define the horizontal alignment of the text within an element:

```css
selector {
	/* default */
	text-align: left;
}
```

the value of the `text-align` property can be:

- left (default)
- right
- center
- justify (each line takes up 100% of the parent)
- start (depends on the direction)
- end (depends on the direction)

---

## Line height:

the `line-height` is used to space lines.

```css
selector {
	line-height: _value_;
}
```

if no unit is provided then the value is multiplied by the `font-size`, for example:

```css
p {
	font-size: 16px;
	/* line height = 16px * 2 -> 32px */
	line-height: 2;
}
```

> [!TIP] usually keep headings line-height < 1.5 and between 1.5 and 2 for normal text

---

## Letter spacing:

the `letter-spacing` is used to space the letters in other words the space in between letters.

```css
selector {
	letter-spacing: _value_;
}
```

> [!TIP] use negative values to move the letters closer together, this is usually done to headings

---

## List style:

the `list-style`: is used to set the style of a list, it can be:

- none (use when the list is for structure only like in nav-bars)
- disc (default for ul)
- circle
- square
- decimal (default for ol)

```css
selector {
	list-style: circle;
}
```

the `list-style` can do more then that, it also allows you to pick an image, and a position for the bullet-point

```css
selector {
	list-style: type position url("url");
}
```

the **position** can either be:

- inside: the point is considered part of the list item and thus follows it's alignment
- outside (default): the bullet-point is left to the list item outside of it's box
