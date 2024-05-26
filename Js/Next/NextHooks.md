# Next hooks:

---

## useRouter:

---

## usePathname:

imported from `next/navigation` this hook allows you to read the path name after the domain for example:

if the url is `http://localhost:3000/login/users` it will return `/login/users`

```javascript
'use client';

import { usePathname } from "next/navigation";

function Layout({children}){
  const path = usePathname();
  console.log("🚀 ~ Layout ~ path:", path)
  
  return <div>
    {path === '/login/admin'? (<h1>You are an admin</h1>) : (<h1>You are a user</h1>)}
    {children}
  </div>
}

export default Layout
```
