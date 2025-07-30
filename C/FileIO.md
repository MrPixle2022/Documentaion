# FileIO:

in c the `stdio` file gives us a lot of useful methods and structs for files.

for example we have the `FILE` typedef struct which can be used to point to a file, and also we have method like `fopen` & `fclose`.

---

## Creating a file:

to create a file use a pointer of the `FILE` struct and assign it to the return value of the `fopen` method, this method takes two arguments:

```c
fopen("path", "mode");
```
in case of failure it return `NULL`, so better check for this

for the mode we can use:

- w -> write mode, creates a new file, if one exists it will overwrite the old content
- r -> read, reads the content of an existing file, if the file doesn't exist it return `NULL`
- w+ -> write + read, same behavior as write (creates a new & overwrites) and the allows reading
- r+ -> read + write, same behavior as read(exist or null) and allows overwriting
- a -> append, inserts new content at the end
- a+ -> append + read

```c
FILE* pFile = fopen("./output.txt", "w");
/*what to do*/
fclose(pFile); //important to close the file stream
```

---

## Insert content

to insert text in that file we use the `fprintf` method, this one takes three arguments:

```c
fprintf(FILE *FilePointer, "formatSpecifier", data);
```

so for example:

```c
char text[] = "THIS IS MAD BY C\nC is amazing";
fprintf(pFile, "%s", text);
```

---

## Reading content:

to read the content of a file create a buffer like a string usually a buffer would be `1024` bytes or `1kb` in size, then use the `fgets` method, this method takes:

```c
fgets(buffer, sizeOfBuffer, FILE* pFile);
```

the `fgets` will return `NULL` when it's done, meaning we can use it in a while loop for example.

```c
while (fgets(buffer, sizeof(buffer), pFile) != NULL) {
    printf("%s\n", buffer);
}
```
