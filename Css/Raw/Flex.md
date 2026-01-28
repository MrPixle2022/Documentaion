# Flex

the `flex box` is a type of display applied to an element to make it a `flex container`.

in the flex container we find **flex items**.

---

## Flex container

on your container set the `display` to flex:

```css
selector {
  display: flex;
}
```

## Flex direction

by default a flex container will organize it's items in a row, however we can alter this by using `flex-direction` which is applied to the flex container:

```css
selector {
  display: flex;
  flex-direction: row; /*column, row-reverse, column-reverse*/
}
```

using the `flex-direction` alters the main and cross axis, the **main axis** is the axis that the flex items are organized on, when the direction is `row` it is the `x` and is the `y` when the direction is `columns`, the **cross axis** is the other axis.

---

## Justify content and align items

the `justify-content` property is used on the **container** to control alignment of flex content across the **main axis** while the `align-items` is used to align flex items across the cross axis:

```css
selector {
  display: flex;
  justify-content: flex-start; /*flex-end, center, space-between, space-around, space-evenly*/
  align-items: stretch; /*flex-start, flex-end, center, baseline*/
}
```

> [!NOTE]
> either properties won't work if there is no freespace in the container to move the items on their respective axis.

---

## Gap

the `gap` is a property used on the flex container to place a space between the flex items on the main axis:

```css
selector {
  display: flex;
  gap: 2px;
}
```

---

## Flex shrink/grow

the `flex-grow` and `flex-shrink` are used on flex items to control how the items use the extra space in the parent, the value used for these 2 represents the ratio to other flex items

```css
selector {
  flex-shrink: 0; /*the ration of growth when there is extras space in the parent*/
  flex-grow: 1; /*the ration if shrinking when the container can't fit all items*/
}
```

---

## Align self

the `align-self` is used on the flex item and can be used to overwrite the alignment of the parent container.

```css
selector {
  algin-self: auto; /*stretch, flex-start, flex-end, center, baseline*/
}
```

---

## Order:

the `order` is used on the flex items to overwrite the order of the flex item among it's siblings without changing the html markup.

```css
selector {
  order: 0;
}
```
