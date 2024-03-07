# Lists of data

---

to render the data in an array as an html you can use ``.map(callbackfunction)``

exampel: 


```javascript
export default function App()
{
    const nums = [1,2,3,4,5];
    
    return <ul>{nums.map(n => <li>{n}</li>)}</ul>
}
```


output:

![Output](Imgs/LISTOFDATAOUTPUT01.png)

---

another example:


```javascript
export default function App()
{
    const users = [
        {name: 'ali', age: 10},
        {name: 'amr', age: 14},
        {name: 'mohammed', age: 15},
    ];
    
    return <ul>{users.map(n => <li>{n.name} : {n.age}</li>)}</ul>
}
```


here i created an array of object that has name and age of some useres and i used the ``.map(callbackfunction)`` to loop over them and get each object, access it's name and age values and render them out as an unorderd list