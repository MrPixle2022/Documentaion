# Setup:

to set up redux with react first install redux by using npm:

```powershell
npm install @reduxjs/toolkit react-redux
```

then create a file to be your store for example i created `src/app/store.js` then in that file import the `configureStore` from `redux`:

```javascript
import { configureStore } from "@reduxjs/toolkit";

export const store = configureStore({
    reducer: {}
})
```

then in the `main.js` or `main.jsx` import that store alongside the `Provider` from `react-redux`:

```javascript
import { Store } from '@reduxjs/toolkit'
import { Provider } from 'react-redux'

ReactDOM.createRoot(document.getElementById('root')).render(
    <Provider store={Store}>
      <App />
    </Provider>
)
```
