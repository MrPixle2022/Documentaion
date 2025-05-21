<!-- @format -->

# Foreign keys and joins:

---

## Foreign keys:

foreign keys allows you to hold a reference to another record in another table for example:

we can define an optional unique reference to a car in the car table from the person table

```sql
CREATE TABLE CAR (
	ID BIGSERIAL NOT NULL PRIMARY KEY,
	MAKE VARCHAR(50),
	MODEL VARCHAR(50),
	PRICE NUMERIC(19, 2)
);

CREATE TABLE PERSON (
	ID BIGSERIAL PRIMARY KEY NOT NULL,
	FIRST_NAME VARCHAR(50),
	LAST_NAME VARCHAR(50),
	COUNTRY_OF_BIRHT VARCHAR(50),
	GENDER VARCHAR(50),
	DATE_OF_BIRTH DATE DEFAULT NOW(),
  -- this means that this field references a car record specifically the id column
	CAR_ID BIGINT REFERENCES CAR (ID),
  -- making sure the car id is unique
	UNIQUE (CAR_ID)
);
```

we can assign the value on insertion or update it using `UPDATE`

---

## Deleting via foreign keys:

---

## Inner Joins:

a way of combining two tables by selecting what is shared between the tow for example selecting supervisors and employees who own a car.

```sql
-- only inner is selected
-- (table1 (inner) table2)
```

```sql
-- select any person whose car_id field matches a car id field
SELECT * FROM person
JOIN car ON person.car_id = car.id;
```

---

## Left & Right joins:

left joins select the entire left table and what is shared in the right one, like selection all persons and their car **if** they have one.

```sql
-- table1 + inner
-- (table1 (inner) table2)
```

```sql
-- select all users and their respective car (person is the left) (car is the right)
SELECT * FROM person LEFT JOIN car ON person.car_id = car.id;
-- select all cars and their respective user (person is the left) (car is the right)
SELECT * FROM person RIGHT JOIN car ON person.car_id = car.id;
```

right joins is the exact same just picks the other table
