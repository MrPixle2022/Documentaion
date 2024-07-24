<!-- @format -->

# Extending tailwind:

to add your own classes to tailwind you have to understand the basic 3 lines you add to the main css file

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

the `base` is the used to set default properties & values like reset rules, etc..

```css
@layer base {
	/*extend the default properties*/
	a {
		@apply text-green-500 underline; /*by default all `a` elements will have green text & have an underline*/
	}
}
```

---

the `components` is class based styles that will overwrite the values via `utilities`

```css
@layer components {
	.customComponent {
		@apply text-2xl bg-blue-500; /*this will create a component called customComponent, any element with class of customComponent will have text-2xl & bg-blue-500 this is a fast way of reusing classes*/
	}
}
```

```html
<button class="customComponent">1</button>
<button class="customComponent">2</button>
```

both these button share same styling

---

the `utilities` are small, single-propose classes that will affect other styles

```css
@layer utilities {
	.text-green-500 {
		color: blue;
	}
}
```

this will overwrite the `text-green-500` class but also you can use it to create a new classes