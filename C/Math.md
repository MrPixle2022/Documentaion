# Math:

in c we have the `math.h` header file which includes a lot of useful math related methods.

include it using:

```c
#include <math.h>
```

now you have access to it's method.

> [!NOTE]
> recommend using `-lm` on the gcc command.

---

## sqrt(x):

the `sqrt` returns the square root of `x`:

```c
float x = sqrt(4); // returns the square root of 4
```

---

## cbrt(X):

the `cbrt` returns the cubic root of `x`

```c
float y = cbrt(8); // returns the cubic root of 8
```

---

## pow(base, power):

the `pow` raises the `base` to the power of `power`:

```c
float a = pow(3, 2); // raises 3 to the power of 2
```

---

## log(x):

returns the neutral log of `x` aka `ln` of `x`:

```c
float b = log(2.19); // log of e -> 0.8
```

---

## round(x):

the `round` rounds the `x` to the nearest int

```c
float r = round(3.2); // round 3.2 -> 3
```

---

## floor(x):

the `floor` rounds to the nearest lowest integer to `x`:

```c
float c = ceil(12.3); // ceils 12.3 -> 13
```

---

## ceil(x):

the `ceil` rounds to the nearest greater integer to `x`:

```c
float c = ceil(12.3); // ceils 12.3 -> 13
```

---

## abs(x):

the `abs` returns the absolute value of `x`:

```c
float ab = abs(-10); // returns the absolute value
```
