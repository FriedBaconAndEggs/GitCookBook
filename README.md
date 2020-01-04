# GitCookBook
Commonly used git bash commands.

```bash
# diff between current and last version
git diff HEAD^ HEAD
git difftool HEAD^ HEAD # only if you configured a diff tool

# add existing local repository to the remote one
git init # create .git stuff
git add . # add all the files
git commit -m "first commit"
git remote add <name (usually origin)> <url> # connect to remote
git push -u origin master # -u is the same as --set-upstream

# simple commit and push
git commit -a -m "<desc>" $ -a == -all - automatically stage files that have been modified and deleted, but new files you have not told Git are not affected
git push

# untrack
# remove hidden .git folder

# get remote repo
git clone <url>

# add README.md
touch README.md
```