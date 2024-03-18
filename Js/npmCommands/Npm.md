# npm Basics
---

#### init:


```powershell
npm init
```
create the package.json file that allows the use of npm in the project

```powershell
npm init -y
```
a quick init that auto fill the field with the path

---

to install a module or a framework via node you use the install command

#### install:

```powershell
npm install packagename
```
or use the shorthand

```powershell
npm i packagename
```

to add install and add to the project

```powershell
npm install packagename --save
```
the [**--save**] adds the package to the project

>[!ALERT]global installation allows you to use the dependencies
>in any file while local installation allows it in a specific project

---

#### install as dev dependencies:

to install a package only to be used in the development process and not to be used in the final build or the product use the save dev flag:

```powershell
npm i packagename --save-dev
```

this will add it under the `"devDependencies"` in the `package.json` file.

---

#### uninstall

```powershell
npm uninstall packagename
```

