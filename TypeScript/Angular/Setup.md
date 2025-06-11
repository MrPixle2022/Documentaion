# Setup:

first install `@angular/cli` globally using:

```bash
pnpm i -g @angular/cli
# bun:
bun install -g @angular/cli
```

then you will have access to the `ng` cli which can be used to create a new project:

```bash
ng new -name- --options
# skip installation:
ng new -name- --skip-install
```

there are some options like:

- `inline-style` to use inline styling by default
- `inline-template` to use the template in the component file

which will ask you some questions for configuration and create the app.

but know using either doesn't mean you can use septate files it just means that a new component will use inline style -or template- by default.

and either ways both can be toggled in the `angular.json` file in the `schematics` option, they can be added or toggled.

the `angular.json` is where you can configure your projects and the applectaions contained in the project.

---

## Serve the app:

serve the app by starting the development server using the command:

```bash
pnpm start

bun run start
```

---

## Add Tailwind:

to use tailwind with angular ensure you use `css` as your styling option.

that's for the intellisense only, it will still work with `scss` for example.

first install the required packages:

```bash
pnpm i tailwindcss @tailwindcss/postcss postcss --force
# or
bun i tailwindcss @tailwindcss/postcss postcss --force
```

then at the project root create `.postcssrc.json` file in that file insert:

```json
{
  "plugins": {
    "@tailwindcss/postcss": {}
  }
}
```

now the last step is at the `style.css` the one in the `src` folder directly add to the top of the file:

```css
@import "tailwindcss";
```

now you are ready to use tailwindcss in angular
