<!-- @format -->

# Including css:

including css can be done through three main ways:

---

## Inline (not recommended):

`inline` inclusion can be done using the `style` attribute on an html element:

```html
<h1 style="color: blue; text-align: center;">This is inline</h1>
```

---

## Internal (not recommended):

`internal` css is when the styling of the document is done through the `style` element.

```html
<style>
	h1 {
		color: blue;
		text-align: center;
	}
</style>

<h1>This is internal</h1>
```

---

## External (recommended):

`external` styling is when the styling is defined in an independent `.css` file and the file is linked to the page/s via the `link` tag in the head.

```html
<head>
	<!-- linking a style sheet -css file-, the path is: ./style.css -->
	<link
		rel="stylesheet"
		href="style.css" />
</head>

<h1>This is external</h1>
```

```css
h1 {
	color: blue;
	text-align: center;
}
```
