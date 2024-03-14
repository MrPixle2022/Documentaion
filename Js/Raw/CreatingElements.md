# Create elements in js:

creating elements in js allows you to create an element and display it based on a certain condition .

first use `
document.createElement('tag')`

and store it in a var.

```javascript
const e = document.createElement("h1");
```

then use any of these function depending on what you want.


|function  |param  |possible values  |description  |
|---------|---------|---------|---------|
|appendChild|elm|any|insets the elm passed at the end of the element that calls it|
|insertBefore|e1, e2|any|inserts e1 before e2 in the element that calls it|
|insertAfter| e1, e2| any| inserts e1 after e2 in the elements that calls it
|insertAdjacentElement|place, e1| [beforebegin, afterbegin, beforeend, afterend], any| inserts e1 at place in the elements that called it, require that the element is predefined
|insertAdjacentHTML|place, e1| [beforebegin, afterbegin, beforeend, afterend], any| inserts e1 at place in the elements that called it|
|append| elm| any|inserts elm at the end of the elements that calls it|
|prepend| elm| any| inserts elm at the start of the element that calls it


---

# remove elements in js:

to remove a child element in js you can use either `remove()` to remove all or use `remove(element)` to remove a specific element