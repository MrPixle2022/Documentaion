<!-- @format -->

# Strings:

navigation:

- [string](#creating-strings)
- [appending & concatenation](#appending-and-concatenation)
- [toUpperCase](#touppercase)
- [toLowerCase](#tolowercase)
- [trim](#trim)
- [repeat](#repeatnumber)
- [slice](#slicestart-end)
- [split](#splitseparator)
- [join](#joinjoint)
- [replace](#replacetarget-replacer)
- [replaceAll](#replacealltarget-replacer)

---

## Creating Strings

strings are one of the primitive types of javascript which allows the storage of text.

strings can be defined in three ways:

```javascript
let string1 = "";
let string2 = "";
let string3 = ``;
/*
a string is defined using:
"" -> most used
'' -> usually avoided - liked by nestjs;
`` -> used for multi-line string, dynamic values insertion
*/

const someVal = 12;
console.log(`value: ${someVal}`); //value: 12
```

---

## Appending and concatenation:

strings can be concatenated with one another, append on top of their content and more

```javascript
// appending:
//string1 = "" from the previous snippet
string1 += "text"; // string1 = the content of string 1 and the string of "text"

// concatenation:
string2 = "here is some ";
string3 = string2 + string1; //here is some text
console.log(string3);

string3 = string3.concat(" ,a lot of text"); // here is some text ,a lot of text
console.log(string3);
```

---

## toUpperCase():

the `toUpperCase` returns a new string where all letters into capital letters

```javascript
let str = "amr yasser";
let newStr = str.toUpperCase();
console.log(newStr); //AMR YASSER
```

---

## toLowerCase():

the `toLowerCase` is the opposite of the toUpperCase, it returns a version of the string where all letters are in lowercase

```javascript
let str = "AMR YASSER";
let newStr = str.toLowerCase();
console.log(newStr); //amr yasser
```

---

## trim():

the `trim`, `trimStart` & `trimEnd` are used to remove whitespaces from a text

```javascript
string2 = "       hi         ";
console.log(string2.trim()); //hi
console.log(string2.trimStart()); //hi----
console.log(string2.trimEnd()); //-------hi
```

---

## repeat(number):

the `repeat` methods return a new version of the string after multiplying it by the given number.

```javascript
let str = "hi ";
console.log(str.repeat(4)); //hi hi hi hi
```

---

## slice(start, end):

`slice` is a method used in both arrays and strings allowing you to get a portion of both, it takes a starting index and an ending index -but the last is always excluded-

```javascript
// get the part from index 0 to 1 (because the second number is excluded)
let string4 = string1.slice(0, 2);
console.log(string1, string4); //string1 isn't changed

// from index1 get till the last character(the last will be included)
let string5 = string1.slice(0, -1);
console.log(string5);
```

as shown in the second example using negatives means the they start from the end of whatever you're slicing

---

## split(separator):

## Spiting & Join:

the `split` method is used to split a string into an array of it's self, using a separator to determine when a new element is to be inserted.

```javascript
string1 = "hello code-mate i am a developer";

console.log(string1.split()); // ["hello code-mate i am a developer"]

console.log(string1.split("")); //['h', 'e', 'l', 'l', 'o', ' ', 'c', 'o', 'd', 'e', '-', 'm', 'a', 't', 'e', ' ', 'i', ' ', 'a', 'm', ' ', 'a', ' ', 'd', 'e', 'v', 'e', 'l', 'o', 'p', 'e', 'r']

console.log(string1.split(" ")); // ['hello', 'code-mate', 'i', 'am', 'a', 'developer']
```

## join(joint):

the `join` is used to merge an array and reduce it into a string, inserting the given joint between the elements, note the default joint is ","

```javascript
string1 = "hello code-mate i am a developer";
//hello-code-mate-i-am-a-developer
```

---

## replace(target, replacer):

the `replace` methods replaces the **first** instance of the given target and replaces it with the replacer

```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yasser awad"
```

---

## replaceAll(target, replacer):

the `replaceAll` does the same as the `replace` but replaces all instances with the given replacer

```javascript
let str = "amr yasser awad";
let newStr = str.replace("a", "x");
console.log(newStr); //"xmr yasser awad"
```

---

## includes(target):

using the `includes` allows you to check if the given part exists in the string:

```javascript
string1 = "hello good sir";
console.log(string1.includes("hello")); //true
```
