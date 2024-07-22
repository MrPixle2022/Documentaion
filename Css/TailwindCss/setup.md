# Setup:

first install `tailwindcss`, `autoprefixer` & `postcss`:

```powershell
pnpm i tailwindcss autoprefixer postcss -D
```

then initialize tailwind using:

```powershell
pnpm tailwindcss init -p
```

this will create the config files for tailwind(`tailwind.config.js`) & for postcss(`postcss.config.js`)

now in the `tailwind.config.js` file you will find:

```javascript
/** @type {import('tailwindcss').Config} */
export default {
  content: [],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

the `content` is what matters now since it sets what files should tailwind target.

for example:

```javascript
/** @type {import('tailwindcss').Config} */
export default {
  content: content: [
    "./index.html", //the index.html file in the project root
    "./src/**/*.{js,ts,jsx,tsx}", //all files in the src directory that ends with .js, .jsx, .ts or .tsx
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

```

now the last step is in the main css file add:

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

now you are ready to use tailwind