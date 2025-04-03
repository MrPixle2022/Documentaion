<!-- @format -->

# Diff:

the `dif` command is used to display the difference between two versions of the same file -at different times-, git will represent the pre-staged file's changes with `---` and the post-staged changes -**for the same file**- with `+++`

so by using:

```bash
# to display the diff between the pre-staged and the post-staged changes for each staged file.
git diff --staged
```

to compare two commits -even if the same one- use the command:

```bash
git diff -hash1- -hash2-
#or
git diff -hash1-..-hash2-
```

and in order to compare two branches use the command:

```bash
git diff -branch1- -branch2-
#or
git diff -branch1-..-branch2-
```

> [!NOTE] the first commit or branch represent file a -the one with +++` and last will be the file b -the one with --- -
