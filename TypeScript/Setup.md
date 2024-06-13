# Setup:

## installation:

use :
```powershell
pnpm i typescript -g # the language
pnpm i tsc -g #the compiler
```

create a `<name>.ts` file
then use:

```powershell
tsc --init
```

to create the `tsconfig.json` file.

in that file set:

`rootDir` to the dir where you put the `.ts` files

`outDir` to the dir where you put the compiled `.js` files

`noEmitOnError` to true so that tsc doesn't compile files with type errors.

then use `tsc -w` to start watching the `.ts` files