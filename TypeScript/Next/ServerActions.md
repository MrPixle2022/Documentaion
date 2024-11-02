# Server Actions

`server actions` are async functions that are used on the server allowing you to handle forms, etc...

in most cases they are used to handle form data for login, signup, etc...

```typescript
/** @format */

"use server"

export async function login(data: FormData) {
	"use server";
	const username = data.get("username");
	const password = data.get("password");
	if (username && password) {
		const response = await fetch("http://localhost:3000/api/login", {
			method: "POST",
			body: JSON.stringify({ username, password }),
		});
		if (response.ok) {
			const data = await response.json();
			console.log(data);
		}
	} else {
		console.error("failed, data missing");
	}
}
```

server actions must have the flag `"use server"` either at the top of the page or inside every function.

this will be imported into the file where you want to use it as the action value of a form.

```typescript
"use client";

import { login } from "@/actions/login";
import { useState } from "react";

export default function LoginPage() {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");



  return (
    <div>
      <form className="gap-3 h-100 bg-gray-300 shadow-2xl flex flex-col items-center justify-center" action={login} method="">
        <input type="text" name="username" placeholder="username" value={ username } onChange={e => setUsername(e.target.value)} />
        <input type="password" name="password" placeholder="password" value={ password } onChange={e => setPassword(e.target.value)}/>
        <input type="submit"/>
      </form>
    </div>
  );
}

```
