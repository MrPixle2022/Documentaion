# console
<hr>
the console object is used to interact with the console

### methods:
#### log:  
```javascript
console.log(msg);
```
the log function is used to show output in the console

<hr>

#### warn:  
```javascript
console.warn(msg);
```
the warn function is used to show a warning massage in the console

<hr>

#### error:
```javascript
console.error(msg) 
```
the error function is used to show an error massage in the console

<hr>

#### table:
```javascript
console.table(obj);
```
the table function is used to display an object as table in the console

##### example:
```javascript
let obj = {
    key1: "value1",
    key2: "value2",
    key3: "value3"
}
console.table(obj);
```
##### output:

    |(index)  |(value)  |
    |---------|---------|
    |key1     | "value1"|
    |Row2     | "value2"|
    |Row3     | "value3"|

<hr>

#### clear:
```javascript
console.clear(); 
```
clears the console