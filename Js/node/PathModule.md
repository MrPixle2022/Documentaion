# Path Module

---

> [!Note]
> must have the package.json in the project can be created via the npm and set the type to module in it

#### to use:

```javascript
import path from 'path';
```

---

#### basename(path, suffix):

```javascript
let ans = path.basename('c:\\users\\Desktop\\Main.js');
console.log(ans) //Main.js

let ans2 = path.basename('c:\\users\\Desktop\\Main.js', '.js');
console.log(ans2) //Main
```

the [**basename**] method returns the name of the file at the end of the given path, if the suffix is give it will be removed from the end of the result

---

#### dirname(path):

```javascript
let ans = path.dirname('c:\\users\\Desktop\\Main.js');
console.log(ans) //Desktop
```

the [**dirname**] method returns the last folder in the path  given

---

#### extname(path):

```javascript
let ans = path.extname('c:\\users\\Desktop\\Main.js');
console.log(ans) //.js
```

the [**extname**] method returns the extension of the file at the end of the path

---

#### join( string[] ):

```javascript
let ans = path.join('c:','\\users','\\Desktop\\');
console.log(ans) //c:\\users\\Desktop\\
```

the [**join**] method takes can take an infinite number of string arguments and joins them into a path

---

#### normalize(path):

```javascript
let ans = path.normalize('c:\\\\useres\\\\\\Desktop');
console.log(ans) //c:\users\Desktop
```

the [**normalize**] method is used to format the path string

---

#### parse(path):

```javascript
let obj = path.parse("c:\\users\\Desktop\\Main.js")
console.log(obj.root) //c:\\
```

the [**parse**] method takes a path and returns an object holding data about the path

the object keys:


|key  |usage  |
|---------|---------|
|root     |the root of the path [it's start]|
|dir      |the path to the folder|
|base     |name + extension|
|ext     |extension|
|name     |file name|
