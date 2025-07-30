# Config:

configuring git can be split into two sections.

- local -> in the `.git/config` file
- global -> stored in the home directory `~/.gitconfig`

you can set, get, update or delete the configs, but get is the default.

you can read all the configs using:

```bash
# getting optically use (--get)
git config --list --local # list all local configs
git config --list # global

# setting use the (--add)
git config --add --global init.defaultBranch main #init.defaultBranch = main
```

it's important to know if their are any duplicates git picks the latest

---

## Adding values:


to add values to your gitconfig -wether locally or globally- you provide them as key-value pairs.

for example:

```bash
# adds Webflyx.cto field with value of `Mr_Pixel` LOCALLY
git config --add --local webflyx.cto Mr_Pixel
```

the `webflyx` is called a section while `cto` is called a field.

---

## Reading keys:

using the `get` flag we can read the values of the given key.

```bash
git config --get webflyx.cto
# the same sense get is the default
git config webflyx.cto
```

---

## Removing keys:

we can use the `unset` flag to **remove** a key:

```bash
git config --unset webflyx.valuation
```

know that if you have duplicate fields that git will pick the last one, and to remove all duplicates use the `unset-all` flag

```bash
# if you have duplicate keys
git config --unset-all section.key
```

---

## Remove sections:

to remove a section use the `remove-section`  flag followed by the section

```bash
git config --remove-section webflyx
```
