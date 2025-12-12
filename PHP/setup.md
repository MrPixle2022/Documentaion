<!-- @format -->

# Setup:

the setup of php is not as straight forward as a language as python for example as we first have to install `xampp` which will install an **apache server**, **php mysql**, **php** and optionally **perl**, know that the apache server can be used to locally host multiple projects using their build.

having installed xampp install **apache** & **mysql** from the control panel and you can also set them to auto-start by running the xampp control panel as an admin.

now we can say we have finished the setup, now to start using the thing.

open the location of the `xampp`, this can simply done by using the `explorer` button inside the xampp control panel, look for a directory named `htdocs` this will host all your projects, for example let's create a new directory inside to host our new project.

```text
xampp
|-> htdocs
    |-> phpTutorial
      |-> index.php
```

and inside the `index.php` use:

```php
<?php
echo "Hello php!";
```

now this project and all the other ones are accessible at `localhost\{dirName}` -with no port-, for this project it will be `http://localhost/phptutorial/`
