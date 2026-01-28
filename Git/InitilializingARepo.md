# Initializing a repo

in any path in the system we can create a new local repo using:

```bash
git init
```

this command will create a hidden `.git` directory which contains the local configuration and all the files needed for git to work properly.

---

## Cloning a repo

if you have an existing repo which you want to clone use the `clone` command:

```bash
git clone <url>
```

---

## Tracking files

having edited a file it becomes modified and is now pending staging for git to note the changes, you can add files to staging using:

```bash
# add more 1 or more specific files
git add <file1> <file2>
# add every thing
git add .
# add every .js file
git add *.js
```

if for any reason you want to unstage a file use:

```bash
git restore --staged <file1> <file2>
```

---

## Repo status

we can check the current state of the repo using the `status` command:

```bash
git status
```

this will log useful info like the current branch, if it's up to date with main, if there are unstaged files, etc...

we can also shorten the output by using:

```bash
gut status -s
```

the result will show file that are not being tracked with `??`, staged files with `A`, modified with `M`.

the output has 2 columns for the mark, the left shows the status of the **staging area**, while the right to the **working tree**, so if a file is modified, staged and them modified again it will have `MM`

---

## Committing

having staged every file needed now you would want to save your progress, till git to take it's snapshot, for this use the `commit` command:

```bash
git commit -m "commit msg"
# update the previous commit msg -alters the commit hash-
git commit --amend -m "new msg"
```

---

## Ignoring files

we can till git to exclude files and directories using a `.gitignore` file, in this file define paths, names, extensions, etc... of flies you don't wish to include in the repo but still have them in the filesystem like `.env` files

inside a `.gitignore`:

1. blank lines and those starting with `#` are ignored
1. define a patter between `\ \`
1. negate a pattern using `!` before the pattern
1. `*` is used as a placeholder for all files
1. `**` is used as a placeholder for all sub-directories
