# Initialize a repo:

to create a new local repo on your device use:

```bash
git init
```

this will create a hidden `.git` folder at the current path your are in, the `.git` can be removed to remove git from your project so that folder is no longer a repo.

if you have files or a folder within your repo that you don't want to include create `.gitignore` file and in it put all paths to any file/folder you want to ignore

---
# Setting the user:

to set your git username(the name that will be attached to any commit you make) use:

```bash
git config --global user.name "your name"
```

and to set your email use:

```bash
git config --global user.email "your email"
```

both values are changeable any time you want

---

# Staging:

to stage files (track there changes) use the `add` command either for all like

```bash
git add .
```

the `.` means all at this current directory, or use stage a specific file like:

```bash
git add filename
```
> [!NOTE]
> to stage multiple files separate each file with a space

---

# Unstage:

if you mistakenly staged a file you don't want to stage use:

```bash
git reset .
```

which will reset all changes (ignore them) or replace the `.` with the file or the path you want to unstage within the project

---

# Status:

the `status` command shows whether there is a change or not and the current brach 

use it with:

```bash
git status
```


---
# Commit:

to finally apply any changes you 've staged to the repo use the `commit` command followed by your message[**needed**] between `" "` like:

```bash
git commit -m "your message"
```

---

# Log:

the `log` command displays all the commits made in this repo with the name and email of who ever commited them and a commit hash code to return to this specific commit and the date of the commit.

to log the data use:

```bash
git log
```

> [!IMPORTANT]
> after the log you won't be able to use the terminal until you press `q` to exit the log

---

# Restoring the file:

if you edited a file then you wanted to cancel those changes use:

```bash
git restore filename
```

---

# Returning to an old commit:

to return to a previous commit you need it's `hash code` that is displayed in it's log, then use:

```bash
git checkout GitCommitHashCode
```
> [!CAUTION]
> after returning to the commit you will automatically be moved to a different branch
