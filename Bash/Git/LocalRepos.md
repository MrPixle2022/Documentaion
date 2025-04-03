<!-- @format -->

# Basics:

---

### Initialize a repo:

in any folder where you wish to track changes in use the command

```bash
git init
```

which initializes a git repo and creates a hidden `.git` which where all the behind-the-scenes action happens.

---

### Staging:

having finished your changes in the repo, it is times to **stage** them.

staging is the stage before actually committing the changes you've made.

to stage a file -or multiple file- use the command

```bash
# to stage multiple files at once separate each file's name with a space
git add -file-
```

but if you want to stage **all** at once use

```bash
# not recommend unless you are certain as it's better to pick files for staging
git add .
```

how ever if you mistakenly staged a file you don't want to stage use:

```bash
git reset -filename-

#or

rm -filename- --cached
```

which will reset all changes (ignore them) or replace the `.` with the file or the path you want to unstage within the project

---

### Status:

the `status` command displays what files are -and aren't- staged, what changes are ready to be committed and what needs to be staged first.

```bash
git status
```

---

### Commit:

as you finally finished working on the part you were working on, after staging all changes you can commit the changes to git alongside a message -**required**- that describes the changes made by you in this commit

```bash
git commit -m "your msg"
```

---

### Log:

the `log` allows you to show a log of all commits in the current repo each repo is displayed with it's:

- date
- author
- author's email
- hash -the unique id-

after the display press `q` to exit the log.

```bash
git log

#or to format it a little bit
git log --oneline
```

---

### Restoring the file:

if you edited a file then you wanted to cancel those changes use:

```bash
git restore filename
```

---

### Returning to an old commit:

to return to a previous commit you need it's `hash code` that is displayed in it's log, then use:

```bash
git checkout GitCommitHashCode
```

> [!CAUTION] after returning to the commit you will automatically be moved to a different branch

### ignoring files

if you have some files you don't want to include in your repo -like the .env- you can create a file named `.gitignore`. in it you list all files -and directories- you don't want to be tracked via git.
