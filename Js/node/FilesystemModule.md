# Filesystem Module

---

> [!Note]
> must have the pacakge.json in the project can be created via the npm and set the type to module in it

### to use the promise falvoured:

```javascript
import * as fs from 'fs/promises';
```

---

#### mkdir(path):

```javascript
await fs.mkdir('C:\\users\\Folder') 
//the file of name folder wil be created at c:\\useres
```
the [**mkdir**] method creates a new folder at a givin path

> [!CAUTION]
> the mkdir by default can't create a new folder with in a none exisiting folder means that the file you want to make must be valid up to the dir before last.

to counter the case above there is a solution:

```javascript
await fs.mkdir('C:\\users\\Folder\\Folder2', {recursive: true}) 
//the file of name folder wil be created at c:\\useres\\Folder
//both Folder and Folder2 never existed
```

---

#### readdir(path):

```javascript
let files = await fs.readdir('C:\\users\\Folder\\') ;

for(const file of files)
{
    console.log(file) //will print all files in {Folder}
}
```

the [**readdir**] method takes a path and reads it's content

---

#### rmdir(path):

```javascript
await fs.rmdir("c:\\users\\Desktop\\Folder");
```
the [**rmdir**] method takes a path and removes it

---

#### writeFile(path, data):

```javascript
await fs.writeFile(".\\main.txt", "Hello");
```

the [**writeFile**] method takes a path and creates a file at this path and adds the data to it

> [!IMPORTANT]
> if the file already exists and has content with in the content will be replaced by the data argument

---

#### readFile(path, encoding):

```javascript
let data = await fs.readFile(".\\main.txt", "utf-8");
console.log(data) //Hello
```

the [**readFile**] method takes a path and retruns the content of the file, the encoder translates the data within the extracted files

--- 

#### appendFile(path, data):

```javascript
await fs.appednFile(".\\main.txt", "Again");
let data = await fs.readFile(".\\main.txt", "utf-8");
console.log(data) //Hello Again
```

the [**appendFile**] method takes a path and adds the data to it

---

#### copyFile(path, finalPath):

```javascript
await fs.copyFile(".\\main.txt", ".\\second.md");
let data = await fs.readFile(".\\main.md", "utf-8");
console.log(data) //Hello Again
```

the [**copyFile**] method takes a file path and copies it's content to another file, it the file doesn't exist it will be created

---

#### stat(path):

```javascript
await fs.stat(".\\main.txt", "Again");
let data = await fs.readFile(".\\main.txt", "utf-8");
console.log(data) //Hello Again
``` 

---
---
---


### to use the callback:

```javascript
import * as fs from 'fs';
```

---
#### it's the same as the promise but all functions take a callback function to be excuted once an error happens

---
---
---

### to use the sync:

```javascript
import * as fs from 'fs';
```


#### add Sync at the end of the function name