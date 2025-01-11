<!-- @format -->

# Signing in and Out

to signIn the user use the exported `signIn`(from `auth.ts`) to signin in the server action.

```typescript
async function serverAction(---){
  await signIn("provider", {options});
}
```

for example when using credentials:

```typescript
export async function login(formData: FormData) {
	const { email, password } = Object.fromEntries(formData);

	try {
		await signIn("credentials", {
			callbackUrl: "/",
			redirect: false,
			email,
			password,
		});
	} catch (error) {
		const authError = error as CredentialsSignin;
		console.log(authError.cause);
	}
	redirect(finalUrl);
}
```

and when using `github` for example:

```typescript
async function serverAction(---){
  await signIn("github", {options?});
}
```

---

## signout

to signout the user use the exported `signOut`(from `auth.ts`) to signout the server action.

```typescript
async function serverAction(---){
  await signOut({options?});
}
```
