# OOP:

in js every thing is considered an `obj` and each object has a base it extends called a `prototype` which can be accessed via `object.__proto__`. when calling a property on an object javascript will look for it in the object and in it's prototype chain.

---

### Classes:

classes in js is a form of objects they can inherit and extend each other.

to create a new class use the `class` keyword then create a `constructor` which is a function that creates new object out of this class

```javascript
class NewClass
{
    Constructor(param1, param2, )
    {
        this.param1 = param1
        this.param2 = param2
    }
}
```

to create a new instance of this class use the `new` keyword

```javascript
const newObj = new NewClass(0,1);
```

now you have access to all functions and properties of the `NewClass` class

---

### Inheritance:

js supports class inheritance which allows you to extend the functionality of other classes to use Inheritance use:

```javascript
class AnotherClass extends NewClass
{
    Constructor(param1, param2, param3)
    {
        super(param1, param2);
        this.param3 = param3
    } 
}
```

the `super` function refers to the parent object in this case `NewClass` the `super` function will call the parent class and pass it the data(param1, parm2 in this example) for the parent's constructors

