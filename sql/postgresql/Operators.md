<!-- @format -->

# Operators:

---

## Comparison operator:

logical checks can be done easily by providing the condition, the check will return `t` if true `f` otherwise for example:

```sql
-- 1 is equal to 1 -> t
SELECT 1 = 1;
-- 1 is not equal to 1 -> f
SELECT 1 <> 1;
-- 1 is not equal to 1 -> f
SELECT 1 != 1;
-- 1 is bigger than 1 -> f
SELECT 1 > 1;
-- 1 is less than 1 -> f
SELECT 1 < 1;
-- 1 is bigger than or equal 1 -> t
SELECT 1 >= 1;
-- 1 is less than or equal 1 -> t
SELECT 1 <= 1;
```

note you can use them on fields, for example we can check if the role isn't equal to 'admin':

```sql
SELECT * FROM users WHERE u_role <> 'admin';
```
