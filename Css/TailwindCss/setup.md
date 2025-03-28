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
