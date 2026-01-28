# Git config

using the `git config` command we can configure a lot of aspects about git on 3 main levels:

1. system
1. global
1. local

each level overwrites the one above it.

```bash
git config --system
git config --global
git config #local as it is the default
```

we can find the config files using:

```bash
git config --list --show-origin
```

the files exist as follows on windows:

1. system -> `[path to git]\etc\gitconfig`
1. global -> `[path to user]\.gitconfig`
1. local -> `.\.git\config`

and we can change the default config file to another one using:

```bash
git config -f <file>
```

as an admin.

---

## Adding values

we can add values to the config by targeting a level and adding a key-value pair, for values already in the configuration file:

```bash
# defining the email and name of this user
git config --global user.email "someone@email.com"
git config --global user.name "someone"

# rename the default branch master -> main
git config --global init.defaultbranch main

# specify which code editor to use when you need to type a message or handle a conflict
git config --global core.editor "path\to\your\editor"
```

> [!NOTE]
> git doesn't warn about duplicate keys, when git encounters them it will use the last value it founds

---

## Viewing values

we can view the configurations using the `--list` option:

```bash
git config --list
git config --list --global #list global config
```

to get a specific value use the key name:

```bash
# reads the current name
git config user.name
```

in the line above `user` is a section and `name` is a key.

---

## Unsetting values

in git we can remove -unset- a value using the `--unset` option, it will find the first key and remove it along with it's value:

```bash
git config --unset section.key
# if you have duplicate keys
git config --unset-all section.key
```

we can also git rid of a section all together:

```bash
git config --remove-section section
```
