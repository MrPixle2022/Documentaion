# Blame

the `blame` command is used to keep track of who did what, using blame modifications can be traced to the committer

```bash
git blame <file>
```

the output would be a list of lines which are formatted as follows:

- Hash
- author
- data
- time
- line number
- edit content

we can limit the blame search for a specific line number range using the `-L` flag:

```bash
git blame <file> -L <start>,<end>
```

using the `-l` flag on the other hand will change the format, for example, the hash would be expanded, the content would be more detailed

git blame can be used together with `git log -p <hash>`, as the log command will give the most details about the edit.
