# Colors:

working with colors in css is quite easy their different forms are:


## rgb:
```css
.target{
  color: rgb(<red>, <green>, <blue>);
}
```

---

## rgba:
```css
.target{
  color: rgba(<red>, <green>, <blue>, <alpha>)
}
```

---

## linear-gradient:
```css
.target{
  background-image: linear-gradient(to <direction: [left, right, top, bottom]>, 
  <color1> <morphAtWidth>, <color2> <morphAtWidth>);
  
}

.target2{
  background-image: linear-gradient(to <direction1: [left, right, top, bottom]> <direction2: [left, right, top, bottom]>, <color1> <morphAtWidth>, <color2> <morphAtWidth>);
}

.target3{
  background-image: linear-gradient(<deg> deg, <color1> <morphAtWidth>,<color2>  <morphAtWidth>);
}
```

---

## radial-gradient:
```css
.target{
background-image: radial-gradient(<shape: [ellipse, circle]> <size>, <color1> <morphAtWidth>, <color2> <morphAtWidth>)
}
```

