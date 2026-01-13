<!-- @format -->

# Loops:

loops allows for a chunk of code to be repeated as long as a defined condition yields true.

---

## For:

the `for` loop allows a code to loop by using a variable to keep track of the iteration, it's primarily used to loop over values of things like arrays, sets, strings, etc...

```java
for(intitlizer; condition; step){
    //body
}
```

for example:

```java
for(int x = 0; x <= 10; x++){
    // ---
}
```

also when working with arrays we can use java's equivalent to a `foreach` loop:

```java
// the : is like the in keyword
for(type variable : array){

}
```

for example:

```java
int[] arr = {1, 2, 3, 4 ,5, 6, 7};

for(int i: arr) System.out.print(i + " "); //1 2 3 5 6 7
```

---

## While:

the `while` loop runs code as long as the defined condition is true:

```java
while(condition){
    //body
}
```

for example:

```java
int x = 100;
while(x > 0) System.out.printf("x: %d\n", x--);
```

while using a while loop ensure that condition will eventually become false to avoid an infinite loop

---

## Do...while:

the `do while` loop is a while loop that runs the code then validates the condition, meaning that even when the condition is false the block runs at the very least once

```java
do{
//    block
}
while(condition);
```

---

## Special keywords:

in a loop we can use `break` and `continue` to further control looping, `break` will halt the loop and proceed with the program while `continue` will simply skip the current iteration and start the following -if the condition is still met-
