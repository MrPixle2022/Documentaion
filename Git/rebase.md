<!-- @format -->

# Rebase:

rebasing allows you to move a diverging commits and move them to the tip of the branch they are diverged from.

for example:

```text
      C - D
     /
A - B - E - F
```

rebasing would turn it to:

```text
A - B - E - F - C - D
```

what happened is that we rebased **onto** the main

so basically it move the branch from being branched of B to being branched of F.

it makes the tree simpler & allows for a merge-free history, but must be used with cautious as it may cause to mess up the history.

basically in this case all rebase does is update where the branch points, just moving the merge base.

we rebase using:

```bash
git rebase _ontoWhat_
```
