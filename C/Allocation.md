# Allocation:

---

## malloc:

the `malloc` -included in the **stdlib.h**- is used to dynamically allocate memory by bytes, we pass it how many bytes we want to reserve and it returns the address to the allocated bytes.

we can use this for example as follows:

```c
int number = 0;

printf("Enter a number: ");
scanf("%d", &number);

char* grades = malloc(number * sizeof(char));
```

here we are awaiting a user input, based on the given integer we are deciding how many bytes we need by multiplying the `number` by the size of a character type.

> [!IMPORTANT]
> `malloc` may return `NULL`, so make sure to check for that

---

## free:

having reserved memory, we must clear it after usage, this can be done using the `free` method, we pass it the pointer to the data we want to free.

```c
free(grades);
grades = NULL;
```

we reassigned the pointer `grades` to null to avoid dangling pointers.

if we forget using `free` it may cause a memory leak in the heap.

---

## calloc:

the `calloc` behaves similarly to the `malloc` function but it initializes the bytes to 0, it takes 2 arguments:

```c
calloc(numberOfElements, sizeOfEach);
```

it it's also a part of the `stdlib.h` file and behaves just like `malloc`

---

## realloc:

the `realloc` function is used to reallocate memory, it can be used to create dynamic array.

```c
realloc(pointer, nBytes);
```

we can use it as follows:

```c
int number = 0;
printf("How many: ");
scanf(" %d", &number); //getting input

float *prices = malloc(sizeof(float) * number);
if(prices == NULL) return -1; // allocating memory

printf("Enter new number: ");
int newNumber = 0;
scanf(" %d", &newNumber); // getting another input

float* temp = realloc(prices, newNumber * sizeof(float)); //reallocating memory
if(temp == NULL) return -1;
prices = temp; // reassigning the pointer


free(prices); //freeing the memory
temp = NULL;
prices = NULL;
```
