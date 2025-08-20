# Remote:

a remote repo is an external repo whose history matches that of your local one.

---

## Add a remote:

to add a remote repo use the following command:

```bash
git remote add <name> <uri>
```

it's usually named `origin` which is the main stream you work in as it is usually a fork of another repo, while some may be called `upstream` but this is usually left for the actual main one.

> [!TIP]
> The remote can be a local linked to another local repo, all is done via using the path to the other repo as your `uri`

---

## Fetch:

adding a remote doesn't mean that magically we have all the content from the local one, no we have to manually grab those changes & we do that via the `fetch ` command:

```bash
git fetch
```

which brings all the changes from the remote, but the changes are not integrated yet we still don't have the files.

what happens is that `fetch` creates something like a **read-only** branch usually named like:

```bash
<remote>/<remote_branch>
```

and you can view it's content using:

```bash
git show <remote>/<remote_branch>:<path_to_file>
```

when you decide on how to integrate the changes use:

```bash
git merge <remote>/<remote_branch>
# or
git rebase <remote>/<remote_branch>
```

---

## Push:

to push your changes to a remote use the `push` command:

```bash
git push <remote> <local_branch> #local's name == remote's name
git push <remote> <local_branch>:<remote_branch> #push to a remote branch with a different name
git push <remote> :<remote_branch> #pushes an empty branch to a remote one -deletes it-
```

---

## Pull:

the `pull` command allows us th get the changed files from a remote and merge them with the current local branch, not just the **metadata** we get from `fetch`

```bash
git pull
git pull <remote> <local_branch> # when local's name == remote's
git pull <remote>/<remote_branch> <local_branch>
```
