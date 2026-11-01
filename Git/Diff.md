# Diff

the `diff` command in get is used to get the modification done to a file, between the current file and the previous version, this will tell you what has been deleted and what has been added

```bash
git diff <v1> <v2>
# for example (previous vs current)
git diff HEAD README.md
# or compare all changes between hashes
git <hash1> <hash2>
# or compare between branches (main vs branch2)
git diff main branch2
```
