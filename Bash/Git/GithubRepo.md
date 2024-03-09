# Remote:

the `remote -v` command is used to display the connection that this repo has with gitHub.

```bash
git remote -v
```

---

# Clone a remote repo:

to clone a github repo use:

```bash
git remote add origin yourGitHubRepoLink
```

this will clone the gitHub repo at that link you 've passed so you can modify it locally, the origin will later represent the gitHubRepo, you can change the origin name if you wish but not recommended

---

# Rename the main branch:

your main branch might be named to `master` which isn't supported as a main brach by gitHub so you can use

```bash
git branch -m main
```

to rename the `master` to `main`

---

# Push changes:

to push changes (publish them) use:

```bash
git push -u origin master
```
this will publish the master branch to the gitHub repo

or use:

```bash
git push
```

which will push the current branch to the remote repo

---

# Sync local with remote repo:

to git the latest changes that were commited to the remote repo use:

```bash
git pull origin master
```

which will pull all the new changes that were made to the master branch.