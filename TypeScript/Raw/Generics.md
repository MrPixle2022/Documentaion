# Generics:

generics allow you to pass a type as a parameter on call in like function and classes,
they give your code flexibility because the result of the code will vary depending on the type give.

```typescript
function takeSome<T>(params:T):T 
{
    return params;
}

takeSome<string>("amr yasser")
```

here the function `takeSome` takes a type since we don't know what it is we called it `T` and assigned it to the parameters, then we provided the function with the type of `string` so the type of `params` is set to `string` so is the return type. 
