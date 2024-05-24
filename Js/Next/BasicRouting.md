# Routing:

to navigate between pages in next you use the `Link` component.

for example to go from the home page to the about page via a button  you 'll use it like:

```javascript
import Link from "next/link"

export default HomePage(){
  return <div>
    <Link href='/about'>About</Link>
  </div>
}
```

this is the most basic form.