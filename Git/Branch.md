<!-- @format -->

# Branch

a branch is like a copy of the project, used to modify the project, while still having another version without those changes until the changes are ready to be merged

it allows you to test code away from production and then merge them when ready.

check which branch you are on using:

```bash
git branch
```

the command will list all branches and will highlight current one

---

## Rename Branches

to rename a branch use the `m` flag:

```bash
git branch -m <old-name> <new-name>
```

this is often used with renaming `master` to `main`

---

## Creating a new branch

to create a branch use either:

```bash
git branch <branch-name>
# or
git switch -c <branch_name>
```

using `switch` will move you to that branch while using `branch` will just create it.

when you create a new branch it will take your current location and that where git will point.

the `HEAD` points to the current commit, but the branch's head -stored in the `.git/refs`- points to the latest commit or the tip of the branch as it is known

---

## Moving between branches

we can use the `switch` command to move between branches and to commits:

```bash
git switch <hash>
# or
git switch <branch-name>
```

---

## Deleting branches

to delete a branch use the `git branch` with the `-d` flag:

```bash
git branch -d <branch-name>
```
