# Getting path params:

to get path parameters using react-router you will have to create a param first, so following the [using react router](UsingARouter.md):

```javascript
<Route path="/about/:who" element={<About/>}/>
```

then to access that `id` param i will have to use a costume hook called `useParams` which returns an **object** containing all the path params, so in the `about` component i will use:

```javascript
import { useParams } from "react-router-dom"

function about() {
  const params = useParams();
  return (
    <div>about {params.who}</div>
  )
}

export default about
```

