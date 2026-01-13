<!-- @format -->

# System:

system is a java class that is used to interact with the system i.e `System.out` to show output to the terminal

---

## Print:

the `print` function is used to send output to the terminal, it along side it's variations do the same thing in their own way:

```java
System.out.print("text"); //print text as it is, no newline inserted
System.out.printLn("text"); //print text as it is, newline inserted
int x = 100;
System.out.printf("%d is 100", x); // prints formatted text similar in typing to C, no new line inserted
// 100 is 100
```

also another way to show output massages as errors in terminal is by using the `System.err` which has the exact same functions.

---

## Printf():

the `printf` as shown in the example above can be used to display a formatted string which may include a dynamic value through a variable, this part is dedicated to the format.

for formatted text use `%[flag][width][.percission][specifier-char]`, the **specifier character** is used to define what type of data will be inserted here, like:

- d: integer
- f: double
- c: character
- b: boolean
- s: string

for **precision**:

```java
System.out.printf("%d"); //just show an integer
System.out.printf("%.2f"); //shows a douple but only 2 digits after the decimal
```

for the **flags** we can use:

- `+`: adds positive/negative sings before numbers
- `,`: adds a comma every 3 digits
- `(`: encloses all negative numbers in `( )`
- `space`: adds a space before any positive numbers

for **width** add the placeholder then the digits, for example:

```java
System.out.printf("%04d\n", 1);    //0001
System.out.printf("%04d\n", 12);   //0012
System.out.printf("%04d\n", 123); // 0123
```

if we remove the `0` the zeros will become just a space.