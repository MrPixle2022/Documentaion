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

accessing parents and siblings in js can be done by accessing the values of:

- parentElement => direct parent
- children => all children
- nextElementSibling => the sibling after
- previousElementSibling => the sibling before

for example:

```javascript
head1.nextElementSibling; //will return the values of head2, head3
```
