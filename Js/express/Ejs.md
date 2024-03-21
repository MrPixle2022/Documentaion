# Ejs with express:

navigation:

- [setup](#setup)
- [render and pass params](#renderpath-params-errfunc)
- [ejs](#ejs-syntax)

---
---

# setup:

to setup ejs for express first install it by using:

```powershell
npm install ejs
```

then replace your views files `.html` extension with `.ejs` and replace the `sendFile` by `render` function.

---
---


# render('path', {params}, errFunc):

to pass data to ejs pass them in the `render` function.

```javascript
app.get('/getName/:name', (req,res) => {
    res.render("mainPage.ejs", {
        name: req.params.name
    })
})
```

this code will send param named `name` to the ejs file stored in the `views` folder.

---
---

# ejs syntax:

ejs allows you to write html and use special tags in it to put data and other stuff similar to django for example.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>main page</title>
</head>
<body>
    <h1>hello iam <%= name %> the full stack dev</h1>
</body>
</html>
```

the `<%= name %> ` means that we are using the value of name which is passed to the file via the `render` function in the app.js file.

you still can use loop and if statement in ejs for example.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>main page</title>
</head>
<body>
    <% if(name === "amr") {%>
        <div>
            the best dev is me
        </div>
    <% } %>
</body>
</html>
```
