<!-- @format -->

# Git:

---

## Initialize a git repo:

use the init command using:

```bash
git init
```

this will create a hidden `.git` directory which includes all the data about your repo.

if we use:

```bash
ls .git -a
# or even better
find .git/
```

it will display all the files & directories in the `.git`

---

## Repo status:

a file in your repo can have a status of:

- `untracked` -> was never added to the index -the staging area-. the `index` represents the changes in the staging, in brief git doesn't know about the file/directory.

- `unstaged` -> was tracked but the new changes weren't committed.
- `committed` -> all changes has been submitted and committed to the repo.

you can check for the status using:

```bash
git status
```

to stage a file use:

```bash
# stages the given file/s -separate via ' '-
git add -file-
# to unstage
git restore --staged _file_
```

---

## Commit:

git commits are a snapshot of the repo at a time, this is how git keeps track of changes in the repo, we can create a commit using:

```bash
git commit -m "msg"

git commit --amend  -m "NewMsg" #update the last commit's message, but know it updates the hash
```

---

## Logs:

you can check the git log using:

```bash
# n -> how many commits to show -starting from the latest
git log -n -number-
git log --graph # graphs the tree
# or
git log --oneline # more compact and minimalistic
```

the log displays the `commit hash`, the author, the author's mail, date and what was changed along side the commit message

also you can specify other options:

```bash
git log --author someOne #locks for all commits whose author is someOne
git log --graph --all # displays the log history as a graph
```

---

## Hashes:

git creates it's hashes based on some factors:

- commit message
- author name & email
- date & time
- parent -previous commits- hashes

so almost every hash is unique.

hashes can be used to revert, delete commits, etc..

---

## Pluming:

git stores every thing -related to git and tracking- as files hidden in the `.git` directory

on committing i got this hash `4930307838a19dc4a1c5759d713f932f32e8da9c`, if we use:

```bash
find .git/
```

we will see some weird things:

first the `objects` directory has a new directory with the first 2 digits of the hash aka `49` and a file inside with the rest of the hash this is to prevent `INode busting`.

what matters to know is that the very file is the commit.

if we cat the commit:

```bash
cat .git/objects/24/1dbf0a04cee100fbcf4d33d9351c7cf341f2e7
```

we receive some weird data, that's because git compresses the data into raw bytes, we can overcome this using the `xxd` command.

```bash
xxd .git/objects/24/1dbf0a04cee100fbcf4d33d9351c7cf341f2e7
```

but even better we can use git's `cat-file` command:

```bash
git cat-file -p -hash-
```

for example:

```bash
git cat-file -p 4930
```

and we receive:

```bash
# tree e4c16230061934899d04817ed6d8d611ed74c197
# author mr_pixel <mrpixel0010@gmail.com> 1752507966 +0300
# committer mr_pixel <mrpixel0010@gmail.com> 1752508064 +0300
#
# A: add contents.md
```

and if we cat-file the tree's hash

```bash
git cat-file -p e4c1
```

we get:

```bash
# 100644 blob 241dbf0a04cee100fbcf4d33d9351c7cf341f2e7	content.md
```

so just basically consider the tree a directory whilst the blob is a file

---

## Trees and blobs:

the `tree` is git's way of storing directories, while a `blob` is it's way of storing files.

when we log a commit we don't see the file, because it's stored in the tree.

we can read that file by:

```bash
git cat-file -p _hash_
# then
git cat-file -p _tree-hash_
# finally
git cat-file -p _blob-hash_
```

on commit, git saves a reference to each blob -the hash- and it will update the tree and it's hash.

the old blobs still reference the old tree, while new ones reference the new version.
