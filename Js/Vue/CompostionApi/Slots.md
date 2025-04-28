<!-- @format -->

# Slots:

`slots` are the vue version of the `children` in react, they allow components to accept other elements -and components- as children.

the slot is a pre-defined component that is ready to use.

in the child component -let's call it ChildWithSlots or cwt for short-:

```html
<template>
	<div>
		<!-- a slot with defined name -->
		<slot name="header"></slot>
		<!-- the name is optional @default default -->
	</div>

	<div>
		<!-- slot with fallback content if no content was provided -->
		<slot name="body">
			<h1>you forget this slot</h1>
		</slot>
	</div>
</template>
```

[!NOTE] slot's name defaults to `default`

then in a parent component use the `template` with the `v-slot:`slotName, or the shorthand `#:`slotName:

```html
<ChildrenWSlot>
	<!-- replace the header slot -->
	<template v-slot:header>
		<!-- inner content -->
	</template>
	<!-- replace the body slot -->
	<template #body>
		<!-- inner content -->
	</template>
</ChildrenWSlot>
```
