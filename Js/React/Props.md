# Props:

---

props are properties that are set as a parameter in the component that can be passed to it later by another component think of them like html attributes

> [!NOTE]
> using the props is condsidered a js expression that has to be used with in ``{ }`` in the jsx


example:

![Example](Imgs/PROPSEXAMPLE0.5.png)

here i am creating a new component named ``User`` that takes a prop so i can get the name and age of the user

![Example2](Imgs/PROPSEXAMPLE01.png)

here i am passing the value of name and age to that ``User`` componenet so it could be rendered properly

output:

![OutPut](Imgs/PROPSOUTPUT01.png)

---

# Props destructuring:

![Example2](Imgs/PROPSEXAMPLE02.png)

here i am destructuring the props into name and age so i can use them directly instead of ``props.name`` or ``props.age``

---

# Children prosps:

![Example](Imgs/PROPSEXAMPLE03-1.png)

here and i changed the ``User`` component tag form
``<User />`` to ``<User> </User>`` to be able to worl with children props, in this case it's ``<p> just a children prop``

![Example](Imgs/PROPSEXAMPLE03.png)

children props are delt with as other props and at the end you render them in therir place in beteween ``{ } ``