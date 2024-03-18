# Tsconfig:

the `tsconfig.json` file allows you to set the behavior of the typescript compiler like compiling ts code in a certain file and returning javascript files in different path and the `es` version and so on.

---

### "outDir": "./path":

the `outDir` key allows you to specify the path in which the typescript compiler will put the final javascript file.


---

### "rootDir": "./path":

the `rootDir` allows you to specify the path to the typescript files you created.

---

### "target": "ecma_script_version":

the `target` allows you to set a es version to compile into default is es3 but you can use:

1. es3
1. es5
1. es6/es2015
1. es2016
1. es2017
1. es2018
1. es2019
1. es2020
1. es2021
1. es2022
1. esnext

---

### "lib": ["library1", "library2"]:

the `lib` is used to specify usable api, default is es6, but you can use something like `"dom"` to have access to dom model.