### cd <path>:

the `cd` command allows you to use change the directory from within the terminal 

```bash
cd ./Desktop
```
here iam starting from the `users` directory then moving into the Desktop

---

### ls

the `ls` command lists all files at the current directory

```bash
ls
```

by default the `ls` command can't read hidden files but it can if you pass it the all flag

```bash
ls -a
```

---

### touch <fileName>:

the `touch` command allows you to create files directly from the terminal

```bash
touch app.js ./files/file.txt
```

here i created `app.js` which will be directly at the current path then created `file.txt` which will be created with in the `files` folder in this path.

---

### mkdir <directoryName>:

the `mkdir` command allows you to create directories(folders) directly from the terminal

```bash
mkdir "files" "./files/useLess/"
```

this command will create two folder one directly at this path named  `files` and another one in it named `useLess`

---

### rmdir <directoryName>:

the `rmdir` command allows you to remove directories(folders) directly from the terminal

```bash
rmdir "files" "./files/useLess/"
```

here iam removing both folders that we created in the last example