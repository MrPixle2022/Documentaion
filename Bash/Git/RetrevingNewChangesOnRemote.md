<!-- @format -->

# Retrieving New Changes On Remote.

when the remote repo has new changes you would want to get those new changes. for that we use either the `pull` command or the `fetch` command.

`fetch` command gets the changes but doesn't apply them to your local repo. instead you 'll have to manually merge them into your branch

```bash
git fetch -remote_name-
#wait for to download
git merge -remote_name/main-
```

`pull` this command does both `fetch` and `merge` for you when a new change is made to the remote repo.

```bash
git pull
```
