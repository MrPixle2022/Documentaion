# Request object:

on the request object you can access:
- `body params`
- `path params`
- `query params`
- `url`
- `request headers`

---

## body params:

accessed via `request.body` but requires the use of `express.json()` middleware to parse JSON body.

---

## path params:

accessed via `request.params` it contains the dynamic path params value, better be destructed

---

## query params:

accessed via `request.query` it contains the query params in the url

---

## headers:

accessed via `request.headers` it contains the headers of the request