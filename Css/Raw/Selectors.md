# Selector:

selector allow you to target html elements and apply style to them they vary depending on how many elements they target and their level of specificity, their forms are:

- [general selector](#general-selector)
- [tag selector](#tag-selector)
- [class and id selectors](#class-and-id-selectors)
- [children selector](#children-selector)
- [direct child selector](#direct-child-selector)
- [next sibling selector](#next-sibling-selector)
- [attribute selector](#attr-selector)

---

## general selector:

the `general selector` ro the `*` is used to reset the style on all elements, it has a lower specificity then other selectors.

**specificity**: (0, 0, 0) -> 0

```css
*{
    padding: 0;
    margin: 0;
}
```

---

## tag selector:

the `tag selector` is used to target all html elements of a specified type, defined by `tag-name` directly it has a low specificity.

**specificity** :(0, 0, 1) -> 1

```css
p{
    font-weight: 900;
}
```

---

## class and id selectors:

### **class**: 
the class selector is used to target all elements with a specific class name, defined by `.class-name` it has a higher specificity than the **[general selector](#general-selector)**

**specificity**: (0, 1, 0) -> 10

```css
.className{
    color: blue;
    font-size: 10px;
}
```

### **id**:
the id selector is used to target a single element with a specific id, defined by `#id-name` it has a higher specificity.

**specificity**: (1, 0, 0) -> 100

```css
#id-name{
    background-color:gold;
}
```

to add more specificity to the `class` or the `id` selectors they can be attached to an `tag` selector like 

```css
tag-name.class-name{
    color:blue;
}
```
**specificity of the example**: (0,1,1) -> 11

or use:
```css
tag-name#id-name{
    color:blue;
}
```

**specificity of the example**: (1,0,1) -> 101

---

## children selector:

the `children selector` is used to target elements that are direct or indirect children to a selector, defined by `selector-one selector-two` the **space** in between must be present, it has a high level of specificity.

**specificity**: sum of all selectors

for example:

```css
div#id pre.class{
    color:blue
}
```
**specificity of the example**: (1,1,2) -> 112

this will look for every `div` with `id = 'id'` and then target all `pre` elements in it with `class = 'class`

> [!NOTE]
> not only limited to two you can combine as many selectors an needed.

---

## direct child selector:

the `direct child` selector is identical to the `children selector` but the difference that it only works for the ***direct children of the selector***,

**specificity**: sum of all selectors

for example:

```css
div > *{
    color:blue
}
```

this will target only the elements that are a direct children to the `div` element.

**specificity of the example**: (0,0,1) ->1

---

## next sibling selector:

the `next sibling` selector is used to target the next direct sibling to the element, defined by `selector-one + selector-2`, where the `s.selector-2` is the target

**specificity**: sum of all selectors

for example:

```css
div + p
{
    padding: 0;
    margin: 0;
}
```

**specificity of the example**: (0,0,2) -> 2

---

## general sibling selector:

the `general sibling selector` is used to target all direct siblings to the element, defined by `selector1 ~ selector2`, where `selector2` is the target.

**specificity**: sum of all selectors

```css
div ~ section{
    border: 1px solid black;
}
```
**specificity**: sum of all selectors

this will target all `section` elements that are direct siblings to it

> [!IMPORTANT]
> the siblings selectors can only target elements that comes after the first selector

---

## attr selector:

the `attr selector` is used to target elements based on an attribute they have and it's value, defined by `[attr]` it has many forms

**specificity standalone**: (0,1,0) -> 10

```css
[attr]/*target all elements with this attribute (attr) */

[attr = 'val']/*target all elements with this attribute (attr) set to (val) */

[attr ^= 'val']/*target all elements with this attribute (attr) and it's value starts with (val) */

[attr $= 'val']/*target all elements with this attribute (attr) and it's value ends with (val) */

[attr *= 'val']/*target all elements with this attribute (attr) and it's value contains (val) */

[attr ~= 'val']/*target all elements with this attribute (attr) and it's value contains (val) as a separate word */
```

also it can be attached to other selectors increasing it's specificity like:

```css
elm[attr = 'val'] /*target all (elm) where their attribute (attr) = (val)
```

**specificity of the example**: (0,1,1) -> 11

> [!TIP]
> add an `i` to before the `]` to make the value case insensitive