<!-- @format -->

# Filters:

navigation:

- [Contrast](#contrast)
- [Brightness](#brightness)
- [Grayscale](#gray-scale)
- [Hue Rotation](#hue-rotation)
- [Saturation](#saturation)
- [Blur](#blur)
- [Other filters](#other-filters)

---

## Contrast:

using the `contrast-{value}` class you set the contrast of an image, the `contrast` can also accept arbitrary values.

```html
<h1 class="mx-3 text-3xl">Contrast</h1>
<br />
<div class="flex gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-0" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-50" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-75" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-100" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-125" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-150" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 contrast-200" />
</div>
```

![Contrast](Images/Contrast.png)

---

## Brightness:

using the `brightness-{value}` class you can adjust the brightness level of an image

```html
<h1 class="mx-3 text-3xl">brightness</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-0" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-50" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-75" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-90" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-95" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-100" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-105" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-110" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-125" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-150" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 brightness-200" />
</div>
```

![Brightness](Images/Brightness.png)

---

## Gray scale:

using the `grayscale-{value}` class you can adjust if the image should be rendered on the grayscale or the full colors scale

```html
<h1 class="mx-3 text-3xl">grayscale</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 grayscale-0" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 grayscale" />
</div>
```

![Grayscale](Images/Grayscale.png)

---

## Hue rotation:

using the `hue-rotate-{value}` you can adjust the hue rotation of an image

```html
<h1 class="mx-3 text-3xl">Hue Rotation</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 hue-rotate-0" />

	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 hue-rotate-15" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 hue-rotate-30" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 hue-rotate-60" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 hue-rotate-90" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 -hue-rotate-180" />
</div>
```

![Hue Rotation](Images/Hue-Rotation.png)

---

## Saturation:

the saturation of an image can be adjusted via the `saturate-{value}` class

```html
<h1 class="mx-3 text-3xl">saturation</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 saturate-0" />

	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 saturate-50" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 saturate-100" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 saturate-150" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 saturate-200" />
</div>
```

![Saturation](Images/Saturation.png)

---

## Blur:

you can add blur to an image using the `blur-{size}` property, this may take an arbitrary value as well

```html
<h1 class="mx-3 text-3xl">Blur</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-none" />

	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-0" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-[4px]" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-sm" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-md" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-lg" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-xl" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-2xl" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 blur-3xl" />
</div>
```

![Blur](Images/Blur.png)

---

## Other filters:

there are some other filters that can be used as well, all of these have a `{filter}-0` to remove the effect

```html
<h1 class="mx-3 text-3xl">Other filters</h1>
<br />
<div class="flex flex-wrap gap-10 p-10 m-10 border">
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40" />
	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 invert" />

	<img
		src="/MyProfilePic.png"
		class="w-40 h-40 sepia" />
</div>
```

![OtherFilters](Images/OtherFilters.png)