# Routing:

navigation:

- [Link](#Link)
- [redirect](#redirect)
- [useRouter](#userouter)

---

## Link:

to navigate between pages in next you use the `Link` component.

it's superior to the `a` tag since it overwrites the default behavior of the `anchor` tag.

the `anchor` tag will reload the entire page while the `Link` component won't

the `Link` takes same **attributes** as the `anchor` tag.

```javascript
import Link from "next/link"

export default HomePage(){
  return <div>
    { /* the prefetch is optional but sets wether the href page will be preloaded or not. */ }
    <Link href='/about' prefetch = {false} >About</Link>
  </div>
}
```

this is the most basic form.

---

## redirect:

the `redirect` is a function that allows you to redirect the user from code.

it's import from the `next/navigation`

```javascript
import { redirect } from "next/navigation";
```

and can be used in both:

- Server side components
- Client side components

for example:

```javascript
function AllUsers({params}){
  if (params.name[0] == 'amr')
    redirect('/about')
  return <div>
      <h1 className="text-blue-600">{params.name.at(-1)}</h1>
    </div>
}
```

in this example i have a dynamic `catch all route`, then i look if the first user is `amr` i will redirect the user to the `about` page.

---

## useRouter:

read [useRouter](NextHooks.md#userouter)