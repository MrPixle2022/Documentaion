<!-- @format -->

# Packages:

in java packages are used to organize projects by separating the source files into directories/folders this is the package.

even further we can add the path of the package in each class in that directory:

```java
// src/utils/Car.java
package src.utils;
```

later on we can import the content of the package using:

```java
import src.utils.*;//import all direct files in utils
import src.utils.MyClass; //import the MyClass
```

a popular habit in the java community is to use the project name in a reverse-domain:

```java
package com.projectName;
```
