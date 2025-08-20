<!-- @format -->

# Reset:

the `git reset` is used to undo commits. it has two types `--soft` will uncommit & stage your changes & `--hard`.

---

## Soft reset:

by using `--soft` git will undo the committed changes and stage them, so it keeps **all** the changes made and stages them.

```bash
git reset --soft _hash_
git reset --soft HEAD~_times_ # how many commits to go back from the HEAD
```

---

## Hard reset:

by using `--hard` git will undo the changes and discard them, it will remove the changes from the branch and move the `HEAD`.

```bash
git reset --hard _hash_
```

> [!NOTE]
> git reset won't affect untracked files

> [!IMPORTANT]
> Hard reset to a previous commit will discard all changes after that very commit.
