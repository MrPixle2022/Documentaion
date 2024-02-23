# String Methods:
<hr>

>[!NOTE]
>String is conidered an array so the array methods also applies to it

#### toUpperCase:
```javascript
let str = "amr yasser";
let newStr = str.toUpperCase();
console.log(newStr); //AMR YASSER
```
the [**toUpperCase**] method is used to returns a new version of the string with all letters in upper case.
<hr>

#### toLowerCase:
```javascript
let str = "AMR YASSER";
let newStr = str.toLowerCase();
console.log(newStr); //amr yasser
```
the [**toLowerCase**] method is used to returns a new version of the string with all letters in lower case.
<hr>

#### trim:
```javascript
let str = "   amr yasser   ";
let newstr = str.trim();
console.log(newstr); //amr yasser
```
the [**trim**] method returns a new string after it removes the white space from the string
<hr>



#### substring(start, end):
```javascript
let str = "amr yasser awad";
let newStr = str.substring(0,5);
console.log(newStr); //"amr ya"
```
the [**substring**] method takes two parameters start index and end index and returns that part of the string
<hr>

#### replace(target, replacer):
> [!NOTE]
> the replace method only replaces the first target only
```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yasser awad"
```
the [**replace**] takes two parameters the first is the what you want to replace and the secnod is what you want to replace it with
<hr>

#### replaceAll(target, replacer):
```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yxsser xwad"
```
the [**replaceAll**] takes two parameters the first is the what you want to replace and the secnod is what you want to replace it with
<hr>

