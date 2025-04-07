<!-- @format -->

# Rebase:

the `rebase` command is an alternative to the `merge`, the `rebase` instead of keeping the commits on the other branch and creating a commit for the merge -like the merge- it will actually rewrite those commits on the other branch as if they were done on the branch you rebase to.

when you use the rebase commend make sure you don't use when you are on the master branch.

when used it rebases the commits from the current branch to the given branch, though it increases the chance of conflicts but it allows for cleaner trees -git graphs- and less commits.

```bash
git rebase -rebase_to_branch-
```
