# Accessing the state:

to access a state sent from another component use the `useLocation` hook, it returns an object that contains:

- `pathname`: the path of this page
- `search`: the search params of this page
- `has`: the hash section of the url
- `key`: a unique key used for caching data
- `state`: contains the state sent by other components

for example:
```javascript
<Link state={{name: 'amr'}}>Home</Link>
```

```javascript
const location = useLocation();

return<>
<h1>{location.state.name}</h1>
</>
```
