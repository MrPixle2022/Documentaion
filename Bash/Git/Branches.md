# Branches:

in git branches are used to create parallel timelines to edit files without corrupting the main or final result,

you can see how many branches you have in your repo by using:

```bash
git branch
```

---

# Creating a new branch:

to create a new branch use:

```bash
git branch branchName
```
then you will have to switch to that branch you made

---

# Switching between branches:

to switch between a branch and another use:

```bash
git checkout brachName
```

---

# Merging branches:

after commiting the files on a branch you will have to merge it with your main branch to save all it's data in the main branch to do that you will have to:

1. switch to the branch you want to apply the final result to
1. merge with the other branch

to merge branches use:

```bash
git merge brachName
```

this command will merger the (branchName) with the current branch so the data in (branchName) will be in the branch your on

