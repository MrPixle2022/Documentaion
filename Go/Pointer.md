# Pointers

variables that store the address of another value, just add `*` before the type, by default their value is `nil`:

```go
int i int32
int p *int32 = &i;
```

or we can allocate some memory for the pointer to point to using `new`:

```go
int p *int32 = new(int32);
```

we can dereference the pointer using `*` before it again:

```go
*p = 12; //the value @p -the address not what p contains- becomes 12
```

unpacking is not really needed when using a struct pointer as go will automatically resolve the pointer.
