<!-- @format -->

# Shadows:


---

## Shadow:

the `shadow` in tailwind is customizable and can be easily be modified.

```html
<div class="flex flex-row w-screen space-x-3 h-1/2">
	<div class="w-[100px] h-[100px] bg-white shadow-none">none</div>
	<div class="w-[100px] h-[100px] bg-white shadow-sm">sm</div>
	<div class="w-[100px] h-[100px] bg-white shadow">normal</div>
	<div class="w-[100px] h-[100px] bg-white shadow-md">medium</div>
	<div class="w-[100px] h-[100px] bg-white shadow-lg">large</div>
	<div class="w-[100px] h-[100px] bg-white shadow-xl">x large</div>
	<div class="w-[100px] h-[100px] bg-white shadow-2xl">2x large</div>
</div>
```

also you can use `shadow-{color}` to set the color of the shadow

![Shadow](Images/Shadow.png)

---

## Drop shadow

the drop shadow adds a drop shadow effect that is not customizable as `shadow` but it gets the job done.

```html
<div class="flex flex-row w-screen space-x-3 h-1/2">
	<div class="w-[100px] h-[100px] bg-white drop-shadow-none">none</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow-sm">sm</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow">normal</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow-md">medium</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow-lg">large</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow-xl">x large</div>
	<div class="w-[100px] h-[100px] bg-white drop-shadow-2xl">2x large</div>
</div>
```

![Drop shadow](Images/Drop%20shadow.png)

---

## Inner shadow:

by adding `shadow-inner` this will add an inner shadow to the element.

```html
<div class="w-[100px] h-[100px] bg-white shadow-inner shadow-blue-500">
	inner shadow
</div>
```

![Inner shadow](Images/Inner%20shadow.png)
