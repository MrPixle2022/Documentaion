<!-- @format -->

# Setup jest for express js:

to setup jest for a project that uses `es modules` first you will need to install some dependencies:

```powershell
pnpm i -D @babel/core @babel/node @babel/preset-env jest
```

create a `.babelrc` file

```json
{
	"presets": [
		[
			"@babel/preset-env",
			{
				"targets": {
					"node": "current"
				}
			}
		]
	]
}
```

then create a `jsconfig.json` file:

```json
{
  "typeAcquisition": {
    "include": [
      "jest"
    ]
  }
}
```

finally use the:

```powershell
pnpm create jest
```

to initialize jest in your project, this will create a `jest.config.mjs` file, in that file use:

```javascript
const config = {
  clearMocks: true,
  coverageProvider: "v8",
  moduleFileExtensions: [
    "js",
    "mjs",
    "cjs",
    "json",
    "node"
  ],
  transform: {
    "^.+\\.m?js": "babel-jest"
  },
};

export default config;
```

now you can start using jest.