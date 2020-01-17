# GitCookBook
Commonly used git bash commands.

```bash
# diff
git diff HEAD^ HEAD # diff between current and last version
git difftool HEAD^ HEAD # diff between current and last version - only if you configured a diff tool
git diff @{upstream} # diff local branch with the upstream branch (if you're on the branch)
git branch -a # show branches
git diff <remote-tracking branch> <local branch> [<file>] # diff local branch with a remote branch

# add existing local repository to the remote one
git init # create .git stuff
git add . # add all the files
git commit -m "first commit"
git remote add <name (usually origin)> <url> # connect to remote
git push -u origin master # -u is the same as --set-upstream

# global commit and push
git commit -a -m "<desc>" # -a == -all - automatically stage files that have been modified and deleted, but new files you have not told Git are not affected
git push

# untrack
# remove hidden .git folder

# get remote repo
git clone <url>

# add README.md
touch README.md

# discard local changes (get back to the last commit)
git reset --hard

# remove local untracked files from the current Git branch
git clean -f -d -x # -f files, -d dirs, -x ignored and non-ignored, -X ignored, add -n to see which files will be deleted

# view file history
git log -p --follow <filename> # --follow - include renames, -p also diff
```