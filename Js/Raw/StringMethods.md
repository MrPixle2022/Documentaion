# String Methods:
---

navigation:
- [toUpperCase](#touppercase)
- [toLowerCase](#tolowercase)
- [trim](#trim)
- [repeat](#repeatnumber)
- [substring](#substringstart-end)
- [replace](#replacetarget-replacer)
- [replaceAll](#replacealltarget-replacer) 

>[!NOTE]
>String is considered an array so the array methods also applies to it

### toUpperCase:
```javascript
let str = "amr yasser";
let newStr = str.toUpperCase();
console.log(newStr); //AMR YASSER
```
the [**toUpperCase**] method is used to returns a new version of the string with all letters in upper case.

---

### toLowerCase:
```javascript
let str = "AMR YASSER";
let newStr = str.toLowerCase();
console.log(newStr); //amr yasser
```
the [**toLowerCase**] method is used to returns a new version of the string with all letters in lower case.

---

### trim:
```javascript
let str = "   amr yasser   ";
let newstr = str.trim();
console.log(newstr); //amr yasser
```
the [**trim**] method returns a new string after it removes the white space from the string

---

### repeat(number):

```javascript
let str = 'hi ';
console.log(str.repeat(4)) //hi hi hi hi
```

the [**repeat**] method returns a new version of the string by after repeating it's content a `number` number of times.

---

### substring(start, end):
```javascript
let str = "amr yasser awad";
let newStr = str.substring(0,5);
console.log(newStr); //"amr ya"
```
the [**substring**] method takes two parameters start index and end index and returns that part of the string

---

### replace(target, replacer):
> [!NOTE]
> the replace method only replaces the first target only
```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yasser awad"
```
the [**replace**] takes two parameters the first is the what you want to replace and the second is what you want to replace it with

---

### replaceAll(target, replacer):
```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yasser awad"
```
the [**replaceAll**] takes two parameters the first is the what you want to replace and the second is what you want to replace it with

---

