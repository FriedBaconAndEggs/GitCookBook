# GitCookBook
Commonly used git bash commands.

```bash
# diff
git diff HEAD^ HEAD # diff between current and last version
git difftool HEAD^ HEAD # diff between current and last version - only if you configured a diff tool
git diff @{upstream} # diff local branch with the upstream branch (if you're on the branch)
git branch -a # show all branches
git diff <remote-tracking branch> <local branch> [<file>] # diff local branch with a remote branch

# view file history
git log -p --follow <filename> # --follow - include renames, -p also diff

# view file in head revision.
git show HEAD:<file>

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

# discard all local changes (get back to the last commit)
git reset --hard

# reset a single file
git checkout <file>

# remove local untracked files from the current Git branch
git clean -f -d -x # -f files, -d dirs, -x ignored and non-ignored, -X ignored, add -n to see which files will be deleted

# view staged and non-staged files
git status

# simple branching and merging
git branch --all # show all branches
git branch -vv # same as above but local and corresponding upstream remote is printed on one line
git checkout -b newBranch # create a new branch from the active one and switch to it at the same time
git commit -a -m "newBranch finished and tested."
git push -u origin newBranch # push the newBranch branch to the remote repository and set it as upstream
git checkout master # return to the master branch
# Note: above command doesn't set the corresponding remote as upstream. For example, git diff @{upstream}
# now compares HEAD with remotes/origin/newBranch instead of remotes/origin/master until you switch upstream
git branch -u remotes/origin/master # set remotes/origin/master as upstream
git merge newBranch # merge the newBranch branch back into the master branch
git commit -a -m "merged with newBranch" # you need to commit if the merge was fast-forward
git push -u origin master # set remotes/origin/master as upstream (if not set yet) and push
git push origin --delete newBranch # delete the remote branch
git branch -d newBranch # delete the local branch because there's no further need for it
git log --all --decorate --oneline --graph # show branching graph

# change user name and email
git config --global user.name 'Anonymous'
git config --global user.email '<>'
```