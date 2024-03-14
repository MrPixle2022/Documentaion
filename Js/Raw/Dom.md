# Dom:

the `DOM` or document object module is an object that gives you access to elements in the page and it's a child of the `window` object.

in the dom you can change some data about the page like changing the title by using:

```javascript
document.title = 'my page'
```

---

# Accessing elements by js:

getting or accessing elements in js can be done by getting:

- tag
- id
- class

to access an element use one of these document methods:

- getElementById
- getElementByTagName
- querySelector
- querySelectorAll

for example:
```html
<h1 id='head1' class='has-class'>content1</h1>
<h1 id='head2' class='head-class has-class'>content2</h1>
<h1 id='head3' class='head-class has-class'>content3</h1>
```

then in js:

```javascript
const head1 = document.getElementById('head1');//<h1 id='head1' class='head-class has-class'>content1</h1>

const head2 = document.querySelector('.head-class')//<h1 id='head2' class='head-class has-class'>content2</h1>

const heads = document.querySelectorAll('.head-class')/*
[<h1 id='head2' class='head-class has-class'>content2</h1>
<h1 id='head3' class='head-class has-class'>content3</h1>]
*/
```

---

# Access content:

to access content within an element you have to get it as shown above and then use:

- innerText => the formatted text within the element
- innnerHTML => the text and tags within the element
- innerContent => the unformatted text in the element

following the example above:

```javascript
head2.innerText = 'hi there'
```

which will replace the `content2` in the element with `hi there`.

also you can add elements to an element via the `innerHTML`

```javascript
head3.innerHTML= `
<button> click me </button>
`
```

which will create a new button in the `head3`

---

# Setting and getting attributes:

setting or accessing the values of html elements attributes is easy in js, after getting the element in and storing it in a var you can access it directly with `.` or use:

- getAttribute
- setAttribute



|function  |params  |
|---------|---------|
|getAttribute|attribute: str|
|setAttribute|attribute: str, value|

---

# Parents, children and sibiling:

accessing parents and sibilings in js can be done by accessing the values of:

- parentElement => direct parent
- children => all children
- nextElementSibiling => the sibiling after
- previousElementSibiling => the sibling before

for example:

```javascript
head1.nextElementSibiling; //will return the values of head2, head3
```
