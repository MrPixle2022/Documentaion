<!-- @format -->

# Referencing html elements:

using the `useTemplateRef` we can create a new reference

```javascript
const reference = useTemplateRef("ref-name");
```

the `ref-name` is the value of the `ref` attribute in the html element

```html
<div ref="my-element">
	<p>Hello</p>
</div>
```

```javascript
import { useTemplateRef } from "vue";

const myRef = useTemplateRef("my-element");
```

[!IMPORTANT]> the `reference` value will be `null` and won't be initialized until the component is mounted

when the value is initialized you can access the element via the `.value`.
