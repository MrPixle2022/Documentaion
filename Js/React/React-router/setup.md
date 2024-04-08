# Setup:

to set up `react-router` for a react project we will have to install it by using:

```powershell
npm i react-router-dom
```

the `react-router-dom` indicates that it's meant for front end projects and not for **react-native**,

---

then in the react project you will have to import the router you will use: 
- `BrowserRouter`: the most used
- `HashBrowser`: add a `/#/` to your url, less commonly used
- `unstable_HistoryRouter`: unstable yet
- `MemoryRouter`: stores the routes in memory but it doesn't affect the url in the browser, best for tests
- `Static`: imported from `react-router-dom/server`, used for server side rendering