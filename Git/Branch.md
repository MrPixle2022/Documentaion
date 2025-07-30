<!-- @format -->

# Branch:

the `branch` is used to change the repo content independently from other branches.

it allows you to test code away from production and then merge them when ready.

check which branch you are on using:

```bash
git branch
```

---

## Rename Branches:

to rename a branch use the `m` flag:

```bash
git branch -m _old-name_ _new-name_
```

---

## Creating a new branch:

to create a branch use either:

```bash
git branch _branch-name-
# or
git switch -c _branch_name-
```

using `switch` will move you to that branch while using `branch` will just create it.

when you create a new branch it will take your current location and that where git will point.

the `HEAD` points to the current commit, but the branch's head -stored in the `.git/refs`- points to the latest commit or the tip of the branch as it is known

---

## Moving between branches:

we can use the `switch` command to move between branches and to commits:

```bash
git switch _hash_
# or
git switch _branch-name_
```

---

## Deleting branches:

to delete a branch use the `git branch` with the `-d` flag:

```bash
git branch -d _branch-name_
```
