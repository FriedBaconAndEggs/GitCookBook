# GitCookbook
## Table of contents
- [GitCookbook](#GitCookbook)
    * [Table of contents](#Table-of-contents)
    * [Recipes](#Recipes)
        + [Diff commits or a particular file](#Diff-commits-or-a-particular-file)
        + [View commit history](#View-commit-history)
        + [View file](#View-file)
        + [Bring local folder to a remote repo](#Bring-local-folder-to-a-remote-repo)
        + [Commit and push](#Commit-and-push)
        + [Untrack folder](#Untrack-folder)
        + [Get remote repo](#Get-remote-repo)
        + [Discard all local changes](#Discard-all-local-changes)
        + [Remove last local commit](#Remove-last-local-commit)
        + [Reset single file to the latest commit from another branch](#Reset-single-file-to-the-latest-commit-from-another-branch)
        + [Remove untracked files from working tree](#Remove-untracked-files-from-working-tree)
        + [Untrack files after updating .gitignore](#Untrack-files-after-updating-.gitignore)
        + [View staged and non-staged files](#View-staged-and-non-staged-files)
        + [View branches](#View-branches)
        + [Branching and merging/rebasing/squashing](#Branching-and-merging/rebasing/squashing)
        + [Change user name and email](#Change-user-name-and-email)
        + [Get remote changes](#Get-remote-changes)
        + [Clone repo to non-empty directory](#Clone-repo-to-non-empty-directory)
        + [Disable push to fork remote](#Disable-push-to-fork-remote)
## Recipes
### Diff commits or a particular file
```bash
git diff HEAD^ HEAD # diff between last version and current
git difftool HEAD^ HEAD # diff between last version and current - only if you configured a diff tool
git diff @{upstream} # diff local branch with the upstream branch (if you're on the branch)
git diff <remote-tracking branch> <local branch> [<file>] # diff remote file with the local one
```
### View commit history
```bash
git log --oneline # show commits in a concise form
git log --all --decorate --oneline --graph # show commit graph including branches (a dog - woof!)
```
### View file
```bash
git show HEAD:<file> # view file in head revision
git show origin/master:<file> # view file in remote branch
git log -p --follow <filename> # show file history through the commit history;
                               # --follow - include renames, -p - also diff
```
### Bring local folder to a remote repo
```bash
git init # create .git stuff
git add . # add all the files
git commit -m "First commit"
git remote add <name (usually origin)> <url> # connect to remote
git push -u origin master # set remote branch and push changes (-u is the same as --set-upstream)
```
### Commit and push
```bash
git add <untracked files> # add untracked files - 'commit -a' doesn't stage new files
git commit -am "message" # -a == -all - automatically stage files that have been modified and deleted,
                         # but new files you have not told Git about are not affected
git push
```
### Untrack folder
```bash
# remove hidden .git folder
```
### Get remote repo
```bash
git clone https://github.com/<user/organization>/<repo-name>.git
```
### Discard all local changes
```bash
git reset --hard # get back to the last commit
```
### Remove last local commit
```bash
git reset HEAD^
```
### Reset single file to the latest commit from another branch
```bash
git checkout <branch> -- <file> # in local repo
git checkout <usually origin>/<branch> -- <file> # in remote repo
```
### Remove untracked files from working tree
```bash
git clean -f -d -x # -f files, -d dirs, -x ignored and non-ignored, -X ignored,
                   # add -n to see which files will be deleted
```
### Untrack files after updating .gitignore
```bash
git rm -r --cached . # remove files from index; -r - recursive removal,
                     # --cached - only index (without working tree), add -n to preview removal first.
```
### View staged and non-staged files
```bash
git status
```
### View branches
```bash
git branch # show local branches
git branch -v # show local branches along with latest commit
git branch --all # show all branches (local and remote)
git branch -vv # same as above but local and corresponding upstream remote is printed on one line
```
### Branching and merging/rebasing/squashing
```bash
git branch -vv # show all branches
git checkout -b newBranch # create a new branch from the active one and switch to it at the same time
git commit -a -m "newBranch finished and tested."
git push -u origin newBranch # push the newBranch branch to the remote repository and set it as upstream
git checkout master # return to the master branch
# merge
git merge newBranch # merge the newBranch branch back into the master branch
git commit -m "merged with newBranch" # you need to commit if the merge was fast-forward
# or merge --squash
git merge --squash newBranch # squash commits in newBranch into a single commit
git commit -m "squashed commit"
# or rebase
git rebase newBranch # linearize the commit history
git push -u origin master # set remotes/origin/master as upstream (if not set yet) and push
git push origin --delete newBranch # delete the remote branch
git branch -d newBranch # delete the local branch because there's no further need for it
git log --all --decorate --oneline --graph # show the branch graph
```
### Change user name and email
```bash
git config --global user.name 'Anonymous'
git config --global user.email '<>'
```
### Get remote changes
```bash
git fetch # download objects and refs from remote
git diff HEAD remotes/origin/HEAD # diff local HEAD with just fetched remote HEAD
git merge [remotes/origin/HEAD] # merge with what was fetched
# or just
git pull # equivalent of git fetch and git merge
```
### Clone repo to non-empty directory
```bash
git clone --no-checkout repo-to-clone existing-dir/existing-dir.tmp # clone remote repo to tmp folder
mv existing-dir/existing-dir.tmp/.git existing-dir/ # move the .git folder to the directory with the files
                                                    # - this makes `existing-dir` a git repo.
rmdir existing-dir/existing-dir.tmp # delete the temporary directory
cd existing-dir
git checkout # download existing files
```
### Disable push to fork remote
```bash
git remote set-url --push upstream no_push # set the push url of upstream remote to "no_push",
                                           # thus preventing unwanted pushing
                                           # Note: 'upstream' is a common name for the fork source
```