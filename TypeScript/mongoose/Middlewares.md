<!-- @format -->

# Middleware:

mongoose allows you to run extra code based on an event like saving a new document, this can be accessed via the `schema.pre` or `schema.post` functions, they accept the `event` a callback function

for example:

```typescript
//this code runs before any new document is saved via mongoose
UserTypeSchema.pre("save", async function (next) {
	//just updates the email on this document to be lowercase.
	this.email.toLowerCase();
	//calls the next operation
	next();
});
```

> [!TIP] the event param has a type so you can use it without having to worry about a typo
