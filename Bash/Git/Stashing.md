<!-- @format -->

# Stashing:

while working on a project you might want to save your work and return to it later but your work isn't ready to be committed nor staged or you just want to change branches without loosing your work to return to them late, well unless you `stash` the changes git will abort your branch-switch and will ask you to commit or stash your work so it may not be overwritten -deleted or removed-.

to stash a branch's changes use the command:

```bash
#stashed the current branch's changes
git stash
```

however if you return to your stashed branch you will see that changes are apparently removed, actually they have been stored and require you to restore them.

```bash
#restores the latest stash and removes it from the stash list
git stash pop
```

or if you want to not remove the stash after restoring it use:

```bash
git stash apply
#or retrieve a specific stash using
git stash apply stash@{-number-}
#the stash name -> stash@{number} can be found in the stash list
```

to list the stashed changes use:

```bash
git stash list
```

this will display the list of stashes and the branches on which they have been restored or stashed.

> [!IMPORTANT] Stashes aren't branch-limited they can be restored on any branch.
