<!-- @format -->

# Colors:

navigation:

- [text color](#text-color)
- [background color](#background-color)
- [text decorations](#text-decoration-color)
- [accent color](#accent-color)
- [arbitrary colors](#arbitrary-colors)
- [gradients](#gradient)

---

## Text color:

in tailwind you can change and modify the text color by using the text utility class with the color & shade like

`text-{color}-{shade}` for example:

```html
<h1 class="text-red-500">Tailwind</h1>
```

![text red](Images/TextRed500.png)

all shades are between `50` -> `900`

---

## Background color:

the background color is done similar to the `text color` but replacing `text` with `bg`

```html
<p class="bg-indigo-500">Tailwind</p>
```

![Background indigo](Images/BackgroundIndigo500.png)

---

## Text decoration color:

tailwind doesn't provide classed to add decoration to text like `line-through`, `overline` or `underline` but it also allows you to change the lines color by using `decoration-` then the color with the shade.

```html
<p class="decoration-indigo-500 underline">Tailwind</p>
```

![Underline indigo 500](Images/UnderlineIndigo500.png)

---

## Accent color:

tailwind allows you to change default style to element like `checkboxes` for example, by using the `accent-` then color + shade you can change the colors of the `checkbox` when checked

```html
<input
	type="checkbox"
	checked
	class="accent-red-500" />
<p>accent-red-500</p>
```

![Accent red](Images/AccentRed500.png)

---

## Arbitrary colors:

in tailwind you can use a specific custom color of your desire using the Arbitrary syntax, the arbitrary syntax is used like `class-[custom value]` requiring the use of `[]`

for example using an arbitrary color for the text:

```html
<span class="text-[#ff0a1d]">Tailwind</span>
```

![text arbitrary](Images/TextArbitraryColor.png)

---

## Gradient:

you can create gradients in tailwind using `bg-gradient-to-{t, b, l,r , {b, t}{l,r}}` to set gradient direction, then use `from-{color}` to set the starting color, `to-{color}` to set the final color & optionally add `via-{color}` to add a color in the middle of the gradient.

```html
<div class="bg-gradient-to-t  w-32 from-red-400 to-green-500">To top</div>
<div class="bg-gradient-to-tr w-32 from-blue-400 to-purple-500">
	To top right
</div>
<div class="bg-gradient-to-tl w-32 from-yellow-400 to-pink-500">
	To top left
</div>
<br />
<div class="bg-gradient-to-b  w-32 from-red-400 to-green-500">To bottom</div>
<div class="bg-gradient-to-br w-32 from-blue-400 to-transparent">
	To bottom right
</div>
<div class="bg-gradient-to-bl w-32 from-yellow-400 to-pink-500">
	To bottom left
</div>
<br />
<div class="bg-gradient-to-r from-transparent w-32 via-yellow-500 to-red-700">
	From , via & to
</div>
```

![Gradient](Images/Gradients.png)
