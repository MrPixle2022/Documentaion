<!-- @format -->

# Dom:

the `DOM` or document object module is a global object available on the client side, it gives you access to the page's content html, so you can manipulate the page title, add even listeners, and dynamically adding and removing element

in the dom you have direct access to the `head` and `body` of the page and all their attribute and content for example:

```javascript
document.head;

document.title = "new title"; //overwrite the title of the page
//the body
document.body;

//the document's url
console.log("🚀 ~ document.URL;:", document.URL);
console.log("🚀 ~ document.documentURI:", document.documentURI);
```

---

## Accessing DOM elements:

the document object has a set of methods to pick multiple or a specific element like:

- getELementsByTagName('tag') -> returns an array of all elements of the given tag like `p` or `h1`
- getElementById('id') -> returns the element whose `id` is equal to the given id
- getElementsByClassName('class') -> same as `getELementsByTagName` by uses the class instead of the tag name
- querySelector('selector') -> uses a css selector to find the very first element this selector targets
- querySelectorAll('selector') -> same as `querySelector` but returns all elements in an array

for example lest use this html:

```html
<h1
	class="header"
	id="h1">
	this is header 1
</h1>
<h2
	class="header"
	id="h2">
	this is header 2
</h2>
<h3
	class="header"
	id="h3">
	this is header 3
</h3>
<h4
	class="header"
	id="h4">
	this is header 4
</h4>
<h5
	class="header"
	id="h5">
	this is header 5
</h5>
```

now using those methods:

```javascript
// this reads every h1 in the page, collection containing a single h1
const h1 = document.getElementsByTagName("h1"); // htmlcollection: [h1]
// selects all elements by class header
const allHeaders = document.getElementsByClassName("header"); // htmlcollection: [h1, h2, h3, h4, h5]
// selects the element whose id is h2
const h2_byId = document.getElementById("h2"); // h2
// first element whose class is header
const h1_query = document.querySelector(".header"); // h1
// all elements whose class is header
const all_query = document.querySelectorAll(".header"); //htmlCollection: [h1, h2, h3, h4, h5]
```

---

## Access content:

to access content within an element you have to get it as shown above and then use:

- textContent => the formatted text within the element
- innerHTML => the text and tags within the element
- innerContent => the unformatted text in the element

the `innerText` is used to get the formatted tag-less content of the tag, so for example:

```html
<p id="p">
	<span id="span">hey</span>
	hello
</p>
```

```javascript
const p = document.getElementById("p");
console.log(p.innerText); // hey hello
```

whilst the `textContent` is unformatted and tag-less:

```javascript
const p = document.getElementById("p");
console.log(p.textContent);
/*
  hey
  hello
*/
```

and the `innerHTML` contains all the content of the element but not formatted:

```javascript
const p = document.getElementById("p");
console.log(p.innerHTML);
/*
  <span>hey</span>
  hello
*/
```

those values are mutable and we can change them, for example we can add a button to the paragraph's children using the `innerHTML`:

```javascript
const p = document.getElementById("p");
p.innerHTML += `<button>i am added in js</button>`;
```

---

---

## Html Classes:

foreach element we access using the dom we have a `.class` objects that has every single css property that can be assigned to that very element, plus a `.classList` that includes every class assigned to that element and some methods to control it:

```html
<div
	id="d1"
	class="div1 div2">
	<h1 class="header">hello</h1>
</div>
```

```javascript
const div = document.getElementById("d1");
console.log(div.classList); //div1 div2
```

and we can use some methods to control those classes:

```javascript
div.classList.add("div3"); //adds the class div3
div.classList.remove("div1"); //removes the class div1
div.classList.toggle("div2"); //toggles the class div2 if it exists remove it else add it
div.classList.replace("div3", "div4"); // replaces the class div3 with div4
div.classList.contains("div1"); // returns true if the class div1 exists
```

---

## Setting and getting attributes:

setting or accessing the values of html elements attributes is easy in js, after getting the element in and storing it in a var you can access it directly with `.` or use:

- getAttribute
- setAttribute

| function     | params                |
| ------------ | --------------------- |
| getAttribute | attribute: str        |
| setAttribute | attribute: str, value |

---

## Parents, children and sibling:

on an element we can access it's direct parent, children, prev and next sibling element using the properties of:

- parentElement => the direct parent element
- children -> an array of all children
- nextElementSibling => the sibling element after this element
- previousElementSibling => the sibling before before this element

for example:

```javascript
head1.nextElementSibling; //will return the values of head2, head3
```

> [!TIP] on each of this elements we can access it's parent children, next and pre sibling etc...

---

## Element creation and insertion:

we can create elements in javascript using the `createElement` method on the document:

```javascript
// document.createElement('element')'
const newDiv = document.createElement("div");
// insert some html into it
newDiv.innerHTML = `
  <h1>Welcome to dom insertion</h1>
  <p>We are a group of developers who love to create and share random projects. ;)</p>
`;
```

but when adding the element we have some more options like `append` and `prepend`:

```javascript
// Append the new div to the body at the end
this.document.body.append(newDiv);

// Append the new div to the body at the beginning
this.document.body.prepend(newDiv);

// Insert the new div at the beginning of the body, and before the very first child
//insertBefore(element, BeforeWhichChild);
document.body.insertBefore(newDiv, document.body.firstChild);

// Insert the new div at the beginning of the body, and after the very first child
//insertAdjacentElement(position, element);
// position = beforebegin, afterbegin, beforeend, afterend
document.body.insertAdjacentElement("beforeend", newDiv);
```

now if we want to remove an element:

```javascript
// Remove the body with it's children
document.body.remove();

// removes the newDiv
document.removeChild(newDiv);
```

---

## Add and Remove Events:

events occur when a users interacts with an element, or when the browser does, there are events for when the page loads -DOMContentLoaded- , element is hovered, mouse is clicked & when a key is pressed.

events can be assigned:

**inline**:

```html
<element onEvent="function">children</element>
```

**object notation**:

```javascript
const element = document.querySelector("selector");
element.onevent = function () {};
```

**eventListers**:

```javascript
const element = document.querySelector("selector");
element.addEventListener("event", () => {});
element.removeEventListener("event", () => {});
```

---

## The event object:

for the event function we can get an event object that holds some data and methods to control the behavior of the element.

```javascript
const button = document.querySelector("button");

button.addEventListener("click", (event) => {
	event.target; // the element on which the event occurred, this can be the button or any child element who was clicked
	event.currentTarget; // the button to which the event handler is attached
	event.stopPropagation(); // stop the event from bubbling up to parent elements so it won't trigger click event on parents
	event.preventDefault(); // prevent the default action of the event (e.g., prevent form submission)
	event.stopImmediatePropagation(); // stop the event from bubbling up and prevent other handlers of the same event from executing
});
```

do not forget to remove event listers from each element when you are done with them using `.removeEventListener`

---

## Mouse events:

mouse events include actions related to mouse, like hovering, click , double click, right click, etc...

for example:

- click -> when the user clicks an element
- contentmenu -> right clicked an element
- dbclick -> when the element is double clicked
- mousedown -> when the user presses a mouse button over an element
- mouseenter -> when the mouse pointer moves onto the element
- monseleave -> when the mouse pointer moves out of the element
- mousemove -> when the mouse moves over the element while being on it
- mouseup -> when a mouse key is released over the element

---

## Keyboard events:

keyboard events include actions related to the keyboard like keypress.

- keypress -> when a key is pressed
- keydown -> when a key is only pressed
- keyup -> when a key is only released

```javascript
const input = document.querySelector("input");

input.addEventListener("keypress", (e) => {
	console.log(e.key); //what key is pressed, a A, b B --- (capital and small aren't the same)
	console.log(e.keyCode); //they key code like a -> 97
	console.log(e.ctrlKey); //is the ctrl pressed
	console.log(e.shiftKey); //is the shift pressed
	console.log(e.altKey); //is the alt pressed
});
```
