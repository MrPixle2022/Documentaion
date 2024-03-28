# Middlewares:

middlewares allow you to run code between operations, in **mongoose** you use either `pre` to run before the operation or `post` to run afterwards.

## using a middleware:

to use a middleware the syntax looks like:

```javascript
schemaName.pre('operationName like find,save,etc..', function(thisDoc,next){---; next()})
schemaName.post('operationName like find,save,etc..', function(thisDoc,next){---; next()})
```

the `next` allows you to move to the next step or the next middleware, it will work automatically when the specified `operationName` is run. 