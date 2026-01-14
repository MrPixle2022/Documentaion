<!-- @format -->

# Packages:

a package in java is the equivalent to namespaces in .net, they help organize your project plus they along side access-modifiers can change the visibility of classes, interfaces, methods, etc...

packages are named in a reverse-domain method like:

```java
package com.example
```

and can be imported as:

```java
import com.example
```

> [!TIP] when importing a package for it's static method, field, etc..., say the `Math.PI` you can make a `static` import:

```java
import static java.lang.Math.PI;
```

this way we have access to the `PI` directly without the need to use `Math.PI`.

also we have a wildcard import `*`:

```java
import com.myPkg.*
```

which will import everything from `myPkg` directly, not the sub-folders, so a package like `com.myPkg.utils` is not included in this import
