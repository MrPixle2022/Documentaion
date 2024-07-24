<!-- @format -->

# Transition, Animations & Transforms:

navigation:

---

## transition:

using the `transition` class you can add transition to a lot of properties like `color`, `scale`, etc...

also you can translate a specific type of properties like colors using `transition-color` or `transition-transform` to create a transition for the transform poperies

you can control the duration using `duration-{value}`, timing function like `ease-{function}` & delay using `delay-{value}`

```html
<h1 class="text-2xl">With transition</h1>
<button
	class="p-5 text-white bg-blue-500 hover:bg-blue-700 transition-colors ease-linear duration-150 delay-75">
	Click me
</button>
```

---

## transform

with the transform classes like rotation, scale & position.

using `rotate-{angle}`, `scale-{value}` & `translate-{x,y}-{value}`

```html
<h1 class="text-2xl">transform</h1>
<button
	class="p-5 ml-5 text-white bg-blue-500 transition ease-in-out delay-150 duration 1000 hover:-translate-y-1 hover:scale-110">
	Click me
</button>
```

---

## animation:

tailwind provides some built-in animations like `bing`, `pulse`, `bounce & `spin`

using the `animate-{name}` you can animate the element

```html
<h1 class="text-2xl">animations</h1>
<div class="flex justify-center">
	<div class="p-20 ml-20 w-20 bg-teal-200 animate-spin">Spin</div>
	<div class="p-20 ml-20 w-20 bg-red-200 animate-ping">ping</div>
	<div class="p-20 ml-20 w-20 bg-green-200 animate-pulse">pulse</div>
	<div class="p-20 ml-20 w-20 bg-amber-200 animate-bounce">bounce</div>
</div>
```
