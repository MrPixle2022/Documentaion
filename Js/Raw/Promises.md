# Promises:

javascript has an async feature called `promises` which are a cleaner way to create and handle async code using on of the following:

then, catch, finally

to use promises you pass them a callback that takes two arguments `resolve` and `reject` you can name them how you want but it's recommended to name them as above

example:

```javascript
let i = 10
new Promise((resolve, reject) => i > 2? resolve(`yes ${i} is greater than 2`): reject(`no ${i} is less than 2`))
    .then(res => console.log(res))
    .catch(res => console.error(res))
    .finally(() => console.log('goodbye'))
```

here we create a new promise passed it `resolve` and `reject` which will represent the promise state if it's fulfilled or rejected.

after checking for the condition we return either `resolve` with the message of `yes ${i} is greater than 2` or `reject` with the message of `no ${i} is less than 2`.

after that if the promise is fulfilled the promise will call the `then` function and pass it the massage or if it is rejected it will call the `catch` function and pass it the massage of the reject state

the `finally` is called any ways if the promise is fulfilled or rejected.

also promises can be returned via functions like:

```javascript
async function NewPromiseFunc(val1, val2)
{
    return new Promise((resolve, reject) => val1 > val2? resolve(val1): reject(val2))
}

NewPromiseFunc(1,3)
    .then(res => console.log(res))
    .catch(res => console.error(res))
```

> [!TIP]
> you can nest promises 