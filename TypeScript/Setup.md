setting up typescript requires installing `tsc` compiler and `typescript` to install both globally use:

```powershell-interactive
npm i -g tsc

npm i -g typescript
```

after that in the folder your working in it's recommended to create `src` folder for your `.ts` files and a `dist` folder for the final `.js` files.


after that use:

```powershell
tsc --init
```

which will create a new `tsconfig.json` to set up your configs.

then you can use `tsc` only when you want to compile your files or use `tsc --watch` to automatically compile any changes you made on save.
