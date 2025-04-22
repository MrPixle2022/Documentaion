<!-- @format -->

# Event Bus:

an event bus is a central object that allows components to communicate with each other, by providing custom events globally.

start by creating a new file called `eventBus.js`:

```javascript
const events = new Map();

export default {
	// subscribes a new methods to the event
	$on(eventName, func) {
		if (!events.has(eventName)) {
			events.set(eventName, []);
		}
		events.get(eventName).push(func);
	},

	// unsubscribes a method from the event
	$off(eventName, func) {
		if (events.has(eventName)) {
			events.get(eventName).filter((f) => f !== func);
		}
	},

	// emits the event and passes the data to all subscribed methods
	$emit(eventName, data) {
		if (events.has(eventName)) {
			events.get(eventName).forEach((func) => func(data));
		}
	},
};
```

then use the event bus in the main.js file:

```javascript
import eventBus from "./eventBus";

const app = createApp(App);
//using $name indicates that the property is a global property
app.config.globalProperties.$eventBus = eventBus;

app.mount("#app");
```

now you can use the event bus in any component:

```javascript
this.$eventBus.$on("eventName", (data) => {
	console.log(data);
});

this.$eventBus.$emit("eventName", "data");
```
