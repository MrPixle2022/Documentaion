<!-- @format -->

# Directives:

## v-for:

similar to react you can use loops to generate content dynamically, while both need the assignment of a `key` to the generated elements, vue -unlike react- doesn't use the `array.map` function, it instead uses a vue directive -custom attribute- to create a `for in loop`.

```html
<script>
	//this app is mounted to the nav element
	Vue.createApp({
		data() {
			return { pageTitle: "app", links: ["about", "contact"] };
		},
	}).mount("nav");
</script>
```

```html
<nav id="nav">
	<ul>
		<!-- this one is hardcoded -->
		<li><a href="#">{{ pageTitle }}</a></li>
		<!-- this one is dynamic -->
		<!-- the v-for directive is used to loop through the links array -->
		<li v-for="link in links">
			<a href="#">{{link}}</a>
		</li>
	</ul>
</nav>
```

[!IMPORTANT] the vue directives turn the string into javascript code, so you cause syntax error so make sure to not use `""` inside them and rely on the `\`\`` or single-quotes.

---

## v-bind:

now what about the `key`? that we talked about in the previous section, will we can easily include the index -like in a map- by just using `(link, index) in links` , but if we try to assign it the key of each element will be the string **"index"**.

this can be solved by yet another directive, the `v-bind` directive, which is used to bind the key to the index given by the loop -v-for-, or the shorthand `:key`.

```html
<li v-for="(link, index) in links">
	<a
		href="#"
		:key="index"
		>{{link}}</a
	>
</li>
```

you will notice the key has `:` before it, this is a shorthand for the `v-bind` directive, which is used to bind the key to the index given by the loop -v-for-.

so it could be written as:

```html
<li
	v-for="(link, index) in links"
	:key="index">
	<a
		href="#"
		v-bind:key="index"
		>{{link}}</a
	>
</li>
```

remember if you want to combine a text and a variable in an attribute use the `binding` and the string template.

```html
<a :href="`https://${link}.com`">{{link}}</a>
```

remember that the `v-bind` directive is used to bind attributes so any attribute can be used with it.

---

## v-on:

handling event in vue has yet another directive, the `@event` -shorthand- for `v-on:event`- directive.

```html
<button @click="console.log(`onClick event triggered`)">Click me</button>
<!-- or -->
<button v-on:click="console.log(`onClick event triggered`)">Click me</button>
```

also you can prevent the default behavior of the event by using `@event.prevent`.

```html
<button @click.prevent="---">Click me</button>
```

---

## v-if:

the `v-if` directive is used to conditionally render a block of code, it will remove the element from the DOM if the condition is not met.

there is also the `v-show` directive that functions similarly but instead or removing the element it will just add the `display: none` style to it.

```html
<div v-if="isVisible">
	<p>This is visible</p>
</div>
<div v-show="isVisible">
	<p>This is visible</p>
</div>
```

note that the `v-if` leaves a comment in the html where the element is supposed to be.

---

## v-else-if:

the `v-else-if` directive is used to conditionally render a block of code, it will render the block of code if the condition is not met but must be used after an element with the `v-if` directive.

```html
<div v-if="isVisible && dark">
	<p>This is visible and dark</p>
</div>
<div v-else-if="!isVisible && dark">
	<p>This is not visible but dark</p>
</div>
```

---

## v-else:

the `v-else` directive is used to conditionally render a block of code, it will render the block of code if the condition is not met but must be used after an element with the `v-if` directive.

```html
<div v-if="isVisible">
	<p>This is visible</p>
</div>
<div v-else>
	<p>This is not visible</p>
</div>
```

---

## v-model:

the `v-model` directive is used to bind the value of an input to a variable creating a two-way binding, so any change in the input will be reflected in the variable and vice versa.

```html
<input v-model="variable" />
```

---

## v-slot:

the `v-slot` is used to define the slot a template goes in, it has a short hand of `#slotName`

```html
<ChildrenWSlot>
	<!-- replace the slot with name header -->
	<template v-slot:header>
		<!-- inner content -->
	</template>
	<!-- replace the slot named body -->
	<template #body>
		<!-- inner content -->
	</template>
</ChildrenWSlot>
```
