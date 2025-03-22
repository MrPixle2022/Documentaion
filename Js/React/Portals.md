<!-- @format -->

# Portals

portals are a react feature that allows you to render a component in a different location in the DOM -as a child of another element-, by default all components will be children of the div with the id of `root`, but with portals you can attach components to other elements, this is useful for things like tooltips, modals etc...

to use a portal in a component first decide on the parent element, you can always go to the `index.html` file and add another div for example with a special identifier like a classname or an id.

the following example will show using portals for a simple pop up message for a copy input filed.

```html
<!-- the parent of the new element -->
<div id="pop"></div>
```

start by creating the component for the portal:

```javascript
// createPortal(component, container)
import { createPortal } from "react-dom";

function PopUp({ copied }) {
	// adds the section to the element with id of `pop`
	return createPortal(
		<section>{copied && <div>Copied to clipboard</div>}</section>,
		document.getElementById("pop"),
	);
}

export default PopUp;
```

then create a component for the input field:

```javascript
import { useState } from "react";
import PopUp from "./PopUp";

function CopyInput() {
	const [inputValue, setInputValue] = useState("");
	const [copied, setCopied] = useState(false);

	//just a function that renders the copied message for 2 seconds before hiding it again
	function handleCopy() {
		navigator.clipboard.writeText(inputValue).then(() => {
			setCopied(true);
			setTimeout(() => {
				setCopied(false);
			}, 2000);
		});
	}

	return (
		<div>
			<input
				type="text"
				value={inputValue}
				onChange={(e) => setInputValue(e.target.value)}
			/>
			<button onClick={handleCopy}>Copy</button>
			<PopUp copied={copied} />
		</div>
	);
}

export default CopyInput;
```
