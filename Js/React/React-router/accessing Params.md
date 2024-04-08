# Using Params and getting them:

navigation:

---

## Path params:

to get path parameters using react-router you will have to create a param first, so following the [using react router](UsingARouter.md):

```javascript
<Route path="/books/:id" element={<Book/>}/>
```

then to access that `id` param i will have to use a costume hook called `useParams` which returns an **object** containing all the path params, so in the `Book` component i will use:

```javascript
import { useParams } from "react-router-dom"

function about() {
  const params = useParams();
  return (
    <div>about {params.book}</div>
  )
}

export default about
```

---

## Search params:

to access and edit the search params use the `useSearchParams` hook, it works similar to the [useState](../Hooks.md#usestateinitialvalue) hook in react, returning a immutable object and a setter function for it and taking an initial value mostly an object holding all the data.

example:

```javascript
import { useSearchParams } from "react-router-dom"

function about() {
  const [params, setParams] = useSearchParams({name:'amr'});
  const name = params.get('name')
  return (
    <h1>about {name}</h1>
  )
}

export default about
```

this wil grab the `name` from the url search params which will look like `/about?name='amr'/`, we use the `.get('param')` to get the value of the param