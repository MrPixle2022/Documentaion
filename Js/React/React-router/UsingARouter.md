# Basic of routing:

navigation:

- [routing with the BrowserRouter](#routing-with-the-browserrouter)
- [setting components for different routes](#setting-components-for-different-routes)
- [routing with js objects](#routing-with-js-objects)

---
## routing with the BrowserRouter

to set up the base you will have to import the router you will use and set it to contain the hall app in the main file of the project be it `main` or `index` etc...

```javascript
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import { BrowserRouter } from 'react-router-dom'


ReactDOM.createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <App />
  </BrowserRouter>,
)
```

every thing between `BrowserRouter` has access to the router.

---

## setting components for different routes:

to render a component for a specific url, you will have to add some tags to the `App` component.

first i created 2 new components, `home.jsx` and `about.jsx`, then in the `App,jsx`:

```javascript
import { Link, Route, Routes } from "react-router-dom"
import Home from "./pages/home.jsx"
import About from "./pages/about.jsx"
import NotFound from "./pages/notFound.jsx"

function App() {
  return (
    <>
      <nav>
        <Link to="/" > home </Link>
        <Link to="/about"> about </Link>
      </nav>
      <Routes>
        <Route path="/" element={<Home />}/>
        <Route path="/about" element={<About/>}/>
        <Route path="*" element={<NotFound/>}/>
      </Routes>
    </>
  )
}

export default App
```

the `Routes`: specifies that this section is meant to change depending on the url

the `Route`: specifies the route on which the component passed to the `element` prop will be rendered,


the `Link`: is similar to the `a` tag in html but it only changes the url and the content of the `Routes` component making the navigation much quicker.

> [!NOTE]
> 
> the `element` can take normal html instead of components 
> 
> the `*` in the path means any thing else

you can create nested routes to organize routes that have a common section in them for example if we have three routes:
`/books`,
`/books/new`,
`/books/:id`,

instead of:

```javascript
<Route path="/books" element={<Books />}/>
<Route path="/books/:id" element={<Book />}/>
<Route path="/books/new" element={<NewBook />}/>
```

you could use:

```javascript
<Route path="/books"/>
  <Route index element={<Books />}/>
  <Route path="/new" element={<NewBook />}/>
  <Route path="/:id" element={<Book />}> 
</Route>
```

the `index` means that this has the same url as the parent Route in this case `/books`

> [!IMPORTANT]
> 
> if the parent router is givin the `element` prop, that component will be rendered across all children, meaning it will be present in each nested url to this parent but that shared component must have the `Outlet` component at the end of it to allow other components to render as well, the `outlet` takes a context which is an object that can be accessed by any component that will be rendered in place of the `outlet` by using the `getOutletContext` hook which returns an obj.
> 
> in the parent `route` you could remove the `path` and pass the `element`, this will allow all it's children routes to have completely different routes while sharing the component passed to the `element` prop this is handy for something like a nav bar that will be present across the hall app.

---

## routing with js objects:

another way of creating routes with react-router is with the `useRoutes` hook, it takes an array of object each object represent a route component, each object uses the props names as keys for example:

```javascript
let element = useRoutes([
  {
    index: true,
    element: <Home/>
  },
  {
    path:"about",
    children: <About/>
  },
  {
    path: "*",
    children: <NotFound />
  },
])
```

then in the returned jsx use this element as a js expression:

```javascript
{element}
```
