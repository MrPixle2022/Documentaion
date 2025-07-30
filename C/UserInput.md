# User input:

to accept user input in c we can use the `scanf` method, the method takes the FS for our type and an address to store the given value in, getting the address can be done with a pointer or using `&varName` to get the memory address.

```c
int age = 0;

printf("Age -> "); //print prompt
scanf("%d", &age); //scan for an int
```

note that when we press `ENTER` to enter the value, the `\n` -the enter- will be registered into the input buffer, so on the next scan it will be inserted before our next input, though we can avoid that by add a ` ` in the next scanf call.

```c
int age = 0;
float gpa = 0.0f;

printf("Age -> ");
scanf("%d", &age);

printf("GPA -> ");
scanf(" %f", &gpa); //the space before %f ignores the \n
```

---

## fgets:

when handling strings it's recommended to use the `fgets` method instead, to the method we pass the variable, input size & the source which is often stdin.

```c
fgets(name, sizeof(name), stdin);
```

but still we may encounter the `\n` problem again, this time we require another function which is `getchar`.

```c
getchar();//pulls the first char from the input buffer
fgets(name, sizeof(name), stdin);
```

now there is also another `\n` problem, the one after typing the name, this will be inserted into the string & to remove it we require yet another method, but this time it comes from a header file, specifically the `string.h`

```c
#include <string.h>
```

and this file gives us a lot of useful method to handle strings, the one we are using is `strlen` which checks for the length of the given string.

```c
getchar();
fgets(name, sizeof(name), stdin);
name[strlen(name) - 1] = '\0';//replacing the last char `\n` with the null-terminator
```
