<!-- @format -->

# Setup:

first install `tailwindcss`.

```powershell
pnpm i tailwindcss @tailwindcss/vite

```

then add tailwind css to the `vite.config.js` file:

```javascript
import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import tailwindcss from "@tailwindcss/vite";

// https://vite.dev/config/
export default defineConfig({
	plugins: [react(), tailwindcss()],
});
```

```javascript
/** @type {import('tailwindcss').Config} */
export default {
	content: [],
	theme: {
		extend: {},
	},
	plugins: [],
};
```

the `content` is what matters now since it sets what files should tailwind target.

for example:

```javascript
/** @type {import('tailwindcss').Config} */
export default {
  content: content: [
    "./index.html", //the index.html file in the project root
    "./src/**/*.{js,ts,jsx,tsx}", //all files in the src directory whose extension is .js, .jsx, .ts or .tsx
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

```

now the last step is in the main css file add:

```css
@import "tailwindcss";
```

now you are ready to use tailwind.

---

## install daisy ui:

```powershell
pnpm add -D daisyui@latest
```

then in the main css file add:

```css
@import "tailwindcss";
@plugin "daisyui";
```

now you are ready to use daisy ui

---

## install radix ui:

install the package

``powershell pnpm add @radix-ui/themes

````

then in the main css file add

```css
@import "@radix-ui/themes/styles.css";
````

the last step is to contain the whole app with the `Theme` context from `@radix-ui/themes`:

```javascript
import { Theme } from "@radix-ui/themes";

createRoot(document.getElementById("root")!).render(
	<Theme>
		<App />
	</Theme>,
);

```
