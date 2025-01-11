<!-- @format -->

# Float

them float rule allows you to make other element **flow** on the right, left sides of the element or both sides.

this allows you to align content.

```html
<div class="parent">
	<div>1</div>
	<div>2</div>
	<div>3</div>
	<div>4</div>
</div>
```

with no css applied this is how it will appear:

![NoFloat](Images/NoFloat.png)

now lets apply the float and allow the elements to flow to the left of their prev sibling and add a paragraph after the div.

```css
.parent div {
	padding-top: 10px;
	padding-bottom: 10px;
	text-align: center;
	background: #eee;
	width: 20%;
	float: left;
}
```

![FloatLeft](Images/FloatLeft.png)

we will see that the elements aligned next to each other, but the elements next to them will also flow, to fix this we can either make it so the children cover all the parent's width, or use the `clear` rule on an element, for this case an empty div will do the job

```html
<div class="parent">
	<div>1</div>
	<div>2</div>
	<div>3</div>
	<div>4</div>
</div>
<div class="clear"></div>
<p>lorem</p>
```

```css
.clear {
	clear: both; /* this will stop the float on both sides of the div */
}
```

![ClearBoth](image.png)
