<!-- @format -->

# console

using the `console` object allows you to display output to the console via some methods like:

- [log](#log) -> display the given arguments to the console (takes any number of arguments)
- [warn](#warn) -> similar to log but displays the msg as a warning
- [error](#error) -> similar to both but displays the msg as an error
- [table](#table) -> displays the give object or array as a table of data
- [clear](#clear) -> to clear the console

---

## log(...args):

the log function is used to show output in the console & accepts any number of arguments

```javascript
console.log(msg);
```

note that the `log` accepts css style to further customize it's appearance:

```javascript
// Styling the console
console.log("%cHello World", "color: red; font-size: 20px;"); //displays a message with the specified style

console.log("%cI %cam %cAmr", "color:red;", "color:green;", "color:blue;"); //displays a message with the specified style

//the text after the directive `%c` is the target of the style & if given multiple directives, the style applies in order
```

---

## warn:

```javascript
console.warn(msg);
```

the warn function is used to show a warning massage in the console

---

## error:

```javascript
console.error(msg);
```

the error function is used to show an error massage in the console

---

## table:

```javascript
console.table(obj);
```

the table function is used to display an object as table in the console, for example:

```javascript
let obj = {
	key1: "value1",
	key2: "value2",
	key3: "value3",
};
console.table(obj);
```

**output**:

    |(index)  |(value)  |
    |---------|---------|
    |key1     | "value1"|
    |Row2     | "value2"|
    |Row3     | "value3"|

---

## clear:

```javascript
console.clear();
```

clears the console on call
