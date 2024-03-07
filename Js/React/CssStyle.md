# Styling:

---

styling in react can be done via a css file link or inline or as an object var

### inline:


```javascript
function Button()
{
    return <button style={{color:'red'}}>Click me</button>
}

export default function App()
{
  return <Button/>
}
```

output:

![Output](Imgs/STYLINGOUTPUT01.png)


### var styling:

```javascript
export function Button()
{
    const bstyle = {color:'red', padding:'10px'};
    return <button style ={bstyle}>click me</button >
}
```

output:

![Output](Imgs/STYLINGOUTPUT02.png)


### imported:

here i created a new file ``ButtonStyle.css``


![CssFile](Imgs/CssFile01.png)

and in this file i added this:

![Example](Imgs/STYLINGEXAMPLE03.png)


in the ``App.js`` file i imported this file:

![Example](Imgs/STYLINGEXAMPLE04.png)

output:

![Output](Imgs/STYLINGOUTPUT03.png)


---
