# Operators

in C, we have many types of operators, this includes:

## Arithmetic operators

- \+
- \-
- \*
- /
- %

they are used for math

## Comparison operators

- ==
- ≠
- \>
- <
- ≥
- ≤

used to compare 2 operands

## Logical operators

- &&
- ||
- !

to combine conditions together, or flip a condition

## Ternary operator

```c
condition ? true_block : false_block;
```

## Bitwise operators

bitwise operators affect the binary representation of data, they require understanding on binary system:

- & → copies a bit to the result if it’s one in both operands (AND)

```c
7 & 5
/*
 7: 00 00 01 11
 5: 00 00 01 01
 --------&-----
 =: 00 00 01 01
*/
//returns 5
```

- | → copies the bit if it exists in one operand (OR)

```c
7 | 5
/*
7: 00 00 01 11
5: 00 00 01 01
------|-------
=: 00 00 01 11 (7)
*/
```

- ^ → returns a bit only if it exists in a single operand but not both (XOR)

```c
7 ^ 5
/*
7: 00 00 01 11
5: 00 00 01 01
--------^-----
=: 00 00 00 10 (2)
*/
```

it can be also used to eliminate duplicate data, for example:

```c
7 ^ 5 ^ 5 //returns 7
```

since both `5` have the same representation the `^` XOR will return 0 for all their fields leaving only the `7`

- ~ (or `!` in rust)→ flips the bits (NOT)

```c
~5
/*
5: 00 00 01 01
~: 11 11 10 10 (250 or -6)
*/
```

- << → shifts all bits to the left by the given number (Left shift)

```c
5 << 2
/*
5: 00 00 01 01
<< by 2
=: 00 01 01 00 (20)
*/
```

- \>> → shifts all bits to the right by the given number (Right shift)

```c
20 >> 2
/*
20: 00 01 01 00
>> by 2
 =: 00 00 01 01 (5)
*/
```
