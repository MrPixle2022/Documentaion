<!-- @format -->

# Merging:

when merging two branches together we create what is called a merge-commit, which is a commit with **2** parents, representing the latest commit of both merging branches

we can merge branches using:

```bash
git merge _branch_
# for remote:
git merge _remote_/_branch_
```

know that you are merging -the current branch- with `branch`.

---

## Fast forward merge:

fast-forward merge is automatically made by git when the `merge-base` is the tip of the branch you are merging onto.

for example:

```text
      C (b_1)
     /
A - B (main)
```

in this case `B` is the merge base, so if we try to merge `b_1` onto `main` we get

```text
     / (b_1)
A - B - C (main)
```

so basically what happened is that git just moved the head pointer of main to `C`, and actually `C` will have only one parent
