<!-- @format -->

# Setup

to use the `vue` without build tools create a normal html file, then in the head tag create a script tag with the src attribute:

```html
<script src="https://unpkg.com/vue@3/dist/vue.global.js"></script>
```

then create a script tag -recommend putting it below the body- and in it use the following.

```html
<script>
	//creates an app instance mounted on the element with id app
	Vue.createApp().mount("#app");
</script>
```

the `createApp` allows you to create an app instance -you can have more than one- and then mount it to an html element by passing the selector to the `.mount`.
