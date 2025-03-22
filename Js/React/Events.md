<!-- @format -->

# Attaching events:

similar to how you would do it to an html tag, events are attached inline and uses expression to link them to a handler function that can optionally take the event as an argument, also inline arrow functions can be used.

event name are in CamelCase, for example `onClick` instead of `onclick`.

```javascript
function EventComponent() {
	const handleMouseEnter = (e) => {
		e.target.innerText = "click me not hover!";
	};

	const handleMouseLeave = (e) => {
		e.target.innerText = "I'm a btn";
	};

	return (
		<div>
			<section>
				<button
					onClick={() => console.clear()}
					onMouseEnter={handleMouseEnter}
					onMouseLeave={handleMouseLeave}>
					I'm a btn
				</button>

				<p
					onCopy={() => {
						console.error("Cant't copy that bro");
					}}>
					Lorem, ipsum dolor sit amet consectetur adipisicing elit. Rem cumque
					commodi libero recusandae, ex ducimus eaque quidem fugit est
					consectetur ipsa quos doloremque sapiente modi in autem? Praesentium,
					blanditiis, autem dolore iste enim nostrum, ipsam consectetur alias et
					fugiat porro consequuntur numquam. Neque est ex eveniet consectetur,
					itaque repellendus at fugit nemo minus ad a cumque quisquam aliquid
					doloribus tempora vel sit! Esse nihil minus aperiam. Cum alias odio
					rem maiores unde odit voluptatibus aperiam autem optio numquam?
					Voluptatum distinctio enim praesentium natus deleniti hic earum
					consequatur quasi odit aperiam perspiciatis totam, eveniet tempora
					dolorem repellat deserunt nulla quis exercitationem?
				</p>
			</section>
		</div>
	);
}
```

this example shows two elements handling multiple events, the **button** has functions that are triggered when the cursor enters, leaves or click, whilst the **paragraph** has a function that is triggered when the paragraph -or part of it- is copied.
