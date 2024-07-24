<!-- @format -->

# Background:

---

for this sections below, will be using this html code:

```html
<div class="">
	<h2>Product Title</h2>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
	<p>this is a paragraph</p>
</div>
```

## background-color:

with the `background-color` property you can set a color for the element's background.

```css
background-color: color-name | rbg | rgba | #hex;
```

for instance:

```css
div {
	background-color: red;
}
```

![Background Color](Images/Background%20Color.png)

---

## background-image:

with the `background-image` you can set the element's background to be an image using the `url` function, a gradient using `linear/radial gradient`, etc...

```css
div {
	background-color: red;
	background-image: url("/MyProfilePic.png");
}
```

![Background Image](Images/Background%20Image.png)

---

## background-repeat:

as shown in the previous section, css will repeat the background image if provided to fill the element, this behavior can be controlled with `background-repeat`.

```css
background-repeat: repeat /*default*/ 
  | repeat-x /*only repeat horizontally*/
  | repeat-y /*only repeat vertically*/
  | no-repeat; /*never repeat the image even if it is smaller than the element*/
```

```css
div {
	background: red;
	background-image: url("/MyProfilePic.png");
	background-repeat: no-repeat;
}
```

![Background Repeat](Images/Background%20Repeat.png)