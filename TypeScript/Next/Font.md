# Font

next js makes it easy to work with fonts, specially those on `google font`, when starting a brand new app the main layout import `Inter` family from google and uses it to set the default font for the app.

so for example if i want to use another family like `Roboto` for instance:

first import `Robots`:

```typescript
import {Roboto} from "next/font/google"
```

then create an instance:

```typescript
// weight: the boldness of the font
// subsets: the sub characters included
const robotoFont = Roboto({weight: '400', subsets: ['latin']})
```
