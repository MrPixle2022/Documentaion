<!-- @format -->

# Project setup:

using the command:

```powershell
pnpm crate vite@latest

#or

npm create vite@latest
```

then selecting `react` and either `typescript` or `javascript` you can set up a basic react project.

then `cd` into your project and install all required dependencies:

```powershell
pnpm i

#or

npm i
```

then you can run the vite server via the command:

```powershell
pnpm dev

#or

npm run dev

```

it's possible to also define the port instead of the default `5713` by adding `--port=(port)` after `dev`

---

## file structure:

by default you will have a `public` folder that contains your assets -you will put them there- and a `src` folder that contains your source code.

at the root there is the `index.html` file which is file to which all your code is compiled and added -hence it's called a single page web app-.

in the `src` you find the `main.jsx` file which is the entry point of your code and essentially the app it self since this where the jsx is compiled and put in the `index.html` file.

also there is the `App.jsx` which is just a basic file that is used to hold a component but can be removed.
