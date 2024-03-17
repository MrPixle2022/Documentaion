# URL module
---

### to use it:

```javascript
import {URL} from "url";
```

then create a new url object by calling the URL Constructor.

URL(path):
```javascript
const myURL = new URL("www.some.com:7070/p/a?s=d#x");
```

---

#### hash:

```javascript
console.log(myURL.hash); //#x
```

the [hash] is a property that returns the hash section of the url

---

#### host:

```javascript
console.log(myURL.host); //www.some.com:7070
```

the [host] is a property that returns the host site section of the url

---

#### hostname:

```javascript
console.log(myURL.hostname); //www.some.com
```

the [hostname] is a property that returns the name of the host of the url

---

#### port:

```javascript
console.log(myURL.port); //:7070
```

the [port] is a property that returns the port section of the url

---

#### protocol:

```javascript
console.log(myURL.protocol); //https:
```

the [protocol] is a property that returns the protocol section of the url

---

#### searchParams:

```javascript
console.log(myURL.searchParams); //s=d
```

the [searchParams] is a property that returns the query section of the url
