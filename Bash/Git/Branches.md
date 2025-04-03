<!-- @format -->

# Branches:

branches allow you to edit and work on a repo without messing or changing the original one, they take the same files, folders & etc.. from the point where they branch allowing you to start from there and to freely do any work you want

---

## get branches

using the command

```bash
git branch
```

this will display all the branches in the repo and mark the -- with a `*` before the main branch defined in the `.git/HEAD` which is the current active branch

--

## create a new branch

creating another branch can be done in more than one way.

using:

```bash
git branch -name-
#or
git switch -name- -c
#or
git checkout -name- -b
```

this will create a branch but **won't** move you to it.

on creation in the `.git` folder the `refs/heads` folder a new file with the same name as the _new_ branch containing a unique set of numbers & letters to identify that branch

also you can remove the branch using:

```bash
git branch -d -name-
```

## Switching branches:

using:

```bash
git checkout -branch-name-
#or
git switch -branch-name-
```

this will move you to the specified branch and will update what the `HEAD` points to in the `.git/HEAD`

---

## Merging branches:

when working in branches each branch's changes are dealt with separately by git, as long as they aren't merged they don't recognize nor track the changes in the other.

to merge branches make sure you are on the branch to which the changes are coming then call branch with the changes you want to commit to the current.

```bash
git merge -branch_name-
```

---

## branching to a hash

git allows you to return to previous commit by creating a new branch with the commit's hash as it's name.

using the command:

```bash
git checkout -hash-
```

you will be move to branch `-hash-` and the `HEAD` will point to it.

another way to do so is using the `HEAD~`

```bash
#go back one commit
git checkout HEAD~1
```
