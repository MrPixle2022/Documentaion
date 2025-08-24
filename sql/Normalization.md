# Normalization:

the more normalized the database the better it is, reducing data redundancy and ensuring data integrity.

normalization has some forms.

---

## 1st Normal Form:

the `1st normal form` states that:

1. every row must have a unique primary key
1. there can't be nested tables

---

## 2nd Normal Form:

the `2nd normal form` states that:

1. apply the `1st normal form`
1. all columns that aren't part of the primary key must depend on the primary key

---

## 3rd Normal Form:

the `3rd normal form` states that:

1. apply the `2nd normal form`

---

## Boyce-Codd Normal Form:

a column that is part of the primary key must not depend on a column that is not a part of the primary key.
