# Intercepting routes:

intercepting routes allows you to intercept accessing a certain route, on navigating to the target route the interceptor UI will be shown, only on `refresh` will you be redirected to the original target, intercepting route follow a convention like `(level)route` for example, let's assume this is our **app** folder:

```text
app
|--route1
    |--page.tsx
```

to create an intercepting route for `route1` it will look like:

```text
app
|--route1
    |--page.tsx
|--(.)route1 -> at the same level for route named `route1`
    |--page.tsx
```

so if the interceptor was in a parent folder then the level would be `(..)`, etc..

> [!NOTE]
> When using a new interceptor router stop the server and delete the `.next` cache directory

---

## Dynamic interceptors:

let's say this is our app:

```text
app
|--products
    |--[id]
        |--page.tsx
```

and we want to intercept any visit to `/products/{id}`, how can we do that?, well we can use a dynamic intercepting route, by naming the file as `(level)[dynamicRouteName]` we can create an intercepting route that accepts a dynamic route-value, so we will end up with:

```text
app
|--products
    |--[id]
        |--page.tsx
    |--(.)[id] -> intercept `/products/{id}`
        |--page.tsx
```

the `id` value will be passed through the `params` object.

---

## Parallel interceptors:

in some cases we may want to create a popup page on navigation to a certain route, this can be done as follows:

1. create a parallel route
1. create a child interceptor route -level is `.`-
1. add a `layout.tsx` to the parent folder

following the previous example we would have:

```text
app
|--products
    |--layout.tsx
    |--default.tsx
    |--[id]
        |--page.tsx
    |--@id
        |--(.)id
            |--page.tsx
```
