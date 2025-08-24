# GitIgnore:

the `.gitignore` file is used to define files that are not to be tracked by git in this repo, they won't be included in the repository.

the `.gitignore` doesn't have to be at the root, you can have multiple ones spread all over the project, in this case each `.gitignore` will only effect it's directory and it's sub-directories.

---

## Exclude:

the `.git/info/exclude` file is where you define files that are ignored **only** in your local repo, not ignored for all.

---

## Patterns:

in the `.gitignore` we could use some patterns to make it easier to match files that we want to exclude, we can use things like `*`, `/`:

```text
*.txt -> any file of extension `txt`

/main.js -> file at the same level

*.text
!important.text -> ignore all that have `.text` in their name except the ones named `important.text`
```

you can create a comment with a `#`.
