<!-- @format -->

# Intervals and Timeouts:

---

## setInterval(handlerFunc, timeout):

the `setInterval` is used to repeatedly run a function aka the `handlerFunc` asynchronously every `timeout` millisecond, after the timeout the function is executed and it will keep running every `timeout` until the interval is cleared using the `clearInterval` function, using the `intervalId` the `setInterval` returns we can store it and use it to clear it.

```javascript
// will run once as we cleared the interval after the very first execution
const id = setInterval(() => {
	console.log("hello");
	clearInterval(id);
}, 100);
console.log("second");
```

this code will log `second` and after 0.1s will log `hello` and exit

---

## setTimeout(handlerFunc, timeout):

the `setTimeout` is used to delay to execution of the `handlerFunc` by `timeout`ms, the delay is async so the app will pass the function until the timeout is passed

```js
//after 4s log "4000"
setTimeout(() => console.log("4000"), 4000);
console.log("first");
// first (4s later) 4000
```
