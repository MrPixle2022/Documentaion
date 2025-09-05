<!-- @format -->

# File Structure & App Router:

the file structure in next unlike react specifies the routes, you have your `src/app` which represents the root of your app's url.

to add more routes create a folder in the `app` folder with the name of the new route.

for example to create an about route the structure will be like:

```javascript
/*
app:
|---| help:    -> /help
        |-- page.jsx
|---| users:   -> /users
|      |-- page.jsx
       |-- sign-in    -> /users/sign-in
            |-- page.jsx
*/
```

---

## the `page.` file

in each route (`directory`) you create a `page` file with the extension of `js`,`jsx`, `ts` or `tsx` this file represents the structure of this route & it must export a default component, next only allows `default exports`

for example:

```javascript
/*
app
|---| about    -> /about
|       |--page.jsx
|---| contact  -> /contact
|       |--page.jsx
*/
```

---

## the layouts

in addition to the `page` file you can create a `layout` which is the `UI` parts being shared in multiple files.

layouts allow you to make something once and use it in multiple pages without extra code.

by default your `app` folder has one named `layout.js`, in it you find this component:

```javascript
export default function RootLayout({ children }) {
	return (
		<html lang="en">
			<body className={inter.className}>
				<div>{children}</div>
			</body>
		</html>
	);
}
```

what matters here is the `{children}` prop, this is the placeholder that will be replaced with the actual ui in the any page file exists in the app folder be it a direct or nested child

meaning that all these files:

```javascript
/*
app:
|------|about:
|         |-- page.jsx
|------|contact:
|         |-- page.jsx
*/
```

will share the same ui

so for example if i put:

```javascript
export default function RootLayout({ children }) {
	return (
		<html lang="en">
			<body className={inter.className}>
				<div>
					<p>top</p>
					{children}
					<p>bottom</p>
				</div>
			</body>
		</html>
	);
}
```

all pages in the `app` directory will render between `top` and `bottom`

> [!CAUTION] The `{children}` must be present to render the actual page or the layout will replace the content.

---

> [!IMPORTANT] you can create a layout file foreach route but if a parent route has one it will also be shared so you will have 2 or more layouts.

## dynamic routes:

if you have a dynamic route like displaying a blog depending on it's `id` or any dynamic route the folder must have it's name between `[ ]`.

for example to create a dynamic `id` route for the `users` route the structure will be like:

```javascript
/*
app      -> ----/
|---| users  -> ----/users
        |-- page.jsx
        |--[id] -> ---/users/:id
            |-- page.jsx
*/
```

in the example above if i want to get the `id` i just have to edit the `page.jsx` component to accept `params` like:

```javascript
function GrabId({ params }) {
	return <h1>{params.id}</h1>;
}
```

this will display the `/:id`,

> [!IMPORTANT] Note that the property name is the same as the folder's name

---

## catch all route:

the `catch all route` is a type of dynamic route that allows you to take a multiple routes at once, for example:

```javascript
/*
app      -> ----/
|---| users  -> ----/users
        |-- page.jsx
        |--[name] -> ---/users/:id
            |-- page.jsx
*/
```

you can access a url like: `/users/amr/`

but you can't if it's: `/users/amr/yasser/`

using a normal dynamic route you'll have to either create a route or a new nested dynamic route.

but with `catch all route` it's simple.

to turn the previous example into a `catch all route` i'll just rename it to `[...id]`

```javascript
/*
app      -> ----/
|---| users  -> ----/users
        |-- page.jsx
        |--[name] -> ---/users/:id
            |-- page.jsx
*/
```

now i can access `/users/amr/yasser/` with no problem, and i can access the url's data like a normal dynamic url, the only difference being that the `catch all route` is an **`array`**

---

## special files

there are some files you can create to customize the behavior of you wep app, but their name must be exact:

- **error** : used to set the ui displayed when an error occurs
- **not-found** : the ui displayed when an error `404` happens (page not found)
- **loading** : the ui displayed when loading

you just create the file, make a component with all the code you need and the export it as a **`default export`**

---

# grouping:

to further organize your project you can use grouping to put multiple routes related to each other without changing the route.

to use it the folder's name must be like `(folderName)`.

any folder inside a group won't have it's route changed.

```javascript
/*
app:
|---(pages):
      |-- about:
            |-- page.jsx
      |-- contact:
            |-- page.jsx
      |-- home:
            |-- page.jsx
*/
```

here the concat route is `/contact` & the home & the about routes are `/home`, `/about` in order, **NOTE** that the `(about)` doesn't affect the route.
