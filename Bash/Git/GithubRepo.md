<!-- @format -->

# Remote repo:

---

## linking to a remote-repo:

first use the `remote -v` command to list the remote connections of your repo -won't show any thing at first-.

then using the `remote add` command you can pass a `name` -optional but keep as `origin` for convince- and the `url` of the remote repo

```bash
git remote add -name- -url-
#for example
git remote add origin https://github.com/username/repo.git
```

note that a connection can be removed:

```bash
git remote remove -name-
```

or later be renamed

```bash
git remote rename -old_name- -new_name-
```

> [!NOTE] It's recommended to rename the master branch to main using `branch -M main`

---

## Pushing changes:

having done changes to the local repo you can push -upload- them to the remote repo using the `push` command

```bash
git push -remote_name- -branch_name-
#the remote name is `origin` by default if `remote add` didn't receive another one

#or add the -u to set an upstream so that you don't need to specify the remote name and the main branch each time.
git push -u origin main
#then at any latter stage we can use just
git push
```

> [!IMPORTANT] The `-u` links the specified branch only to the upstream

---

## Synchronizing local with remote repo:

to git the latest changes that were committed to the remote repo use:

```bash
git pull origin master
```

which will pull all the new changes that were made to the master branch.
