# Functions:

functions are reusable blocks of code that can take arguments, we define a function as follows:

```c
type name(type param){
    return valueOfType;
}
```

if the type is `void` then the function won't use a `return` statement.

then we can use the function as follows:


```c
name(var);
```

> [!IMPORTANT]
> you can't use a function before it's declaration line

let's create an example:

```c
void logTSum(int x, int y) { printf("logSum = %d\n", x + y); }

int main() {
    logTSum(12,3); // will log the message and 15
    return 0;
}
```

---

## Function prototypes:

function prototypes allows you to predefine a function without it's body, it includes the return type and arguments & can be used to help organize functions and make them more readable specially with huge ones.

another thing is when we want to use a function that is defined after the `main`, normally we can't do that but we can do that using prototypes.

a prototype looks like:

```c
//the prototype
int sumTwo(int x1, int x2);
```

then you reuse this signature but with a body.

let's give a real example

```c
//function-prototype
void greetUser(char name[], int age);

int main()
{
    greetUser("amr", 12);
    return 0;
}

//the function
void greetUser(char name[], int age) {
  printf("Hello %s\n", name);
  printf("You are %d years old", age);
}

```
