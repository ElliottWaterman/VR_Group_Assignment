# VR_Group_Assignment
Immersive virtual environment in a ‘health’ context

Chosen Topic: Address phobias - Aerophobia

VR Plan in Google Docs:
https://docs.google.com/document/d/1yWoC3ddMJ6CFyRSNvNOk2qZzEkO5hmNihGi_bhzrsfg/edit?usp=sharing

# Ideas/Links
New Unity UI + OVR Look-Based Input: https://forums.oculusvr.com/developer/discussion/16710/new-unity-ui-ovr-look-based-input-howto
Download: https://www.dropbox.com/s/q8zcylzs1ggt24n/LookInputSampleV6.zip?dl=0

OVR Camera Rig and Hands: https://skarredghost.com/2017/01/03/getting-started-with-oculus-touch-and-avatar-sdk-in-unity/

Interaction: https://unity3d.com/learn/tutorials/topics/virtual-reality/interaction-vr

# Using Git
## Setup
 - Go to a folder for your VR work
 - Click in the address bar (or press ```alt + d```) and type ```cmd```. This brings up the command line interface
 - Copy and paste this command: 
```
git clone https://github.com/ElliottWaterman/VR_Group_Assignment.git 
```
 - You will then have to login to your Github account.
 
 ## Adding files to the Git repository
 - Commit __ALL__ changes in __ALL__ files using the following commands in order: 
```
  git add .
  git commit -m "message"
  git push
```
To commit the changes in only some files (this is also known as  staging), substitute in the following:
```
  git add path_to_file
```
To remove some files from a commit (a.k.a. unstage them):
```
  git reset -- path_to_file
```
Then write the commit message and push as normal.
   - For the commit messages, start the message with one of the following words to ease readability: "Add: ", "Update: ", "Remove: ", "Merge: ", "Fix: ". 
     - For example: ```"Add: icon images, texture files; Update: movement scripts, unity scene; Remove: old unity models."```

##  Branching
To create a new branch with ```name = branch_name```, use: 
```
git checkout -b branch_name
```
This new branch will be branched from the __current branch__, meaning that the new branch will have all of the commits from the old branch.

New branches are created locally. This means that, when pushing this branch to the remote for the *first time*, you should use:
```
git push -u origin branch_name
```
in order to create a new branch on the remote with the same name as your branch and to set the local branch up to track the remote (which is __important__, as if you don't set this up you won't be able to do ```git push``` without specifying which remote to push to, every time you push (which is annoying)). For more info, see: https://stackoverflow.com/questions/1519006/how-do-you-create-a-remote-git-branch#answer-1519032. After this, you can do ```git push``` as normal.

It is __recommended__ that each group member creates at least one branch and that they work exclusively on this branch.

## Merging
Once work on a branch is completed, the branch's changes may be merged with the master branch. However before this, the branch owner should ensure that their changes do not conflict with any other changes that may have been committed to master since they last merged master into their branch (e.g. since their branch was created or since their last ```git merge```). First switch to the master branch to pull any recent changes:
```
git checkout master
git pull
```
Then merge these changes (if any) into the branch you want to merge into master:
```
git checkout branch_name
git merge master
```
It is now that __conflicts__ may emerge, if for example you have edited the same lines in a certain file as someone else who has committed to master. 

It is __your job__ to resolve these changes (because you are the one who wants to commit to master), so please take care to ensure that you __keep both your changes and the changes in master__. Once the conflicts have been resolved and the respective files saved:
```
  git add .
  git commit -m "Merge: resolved conflicts"
  git push
```
>*__Note:__ it is possible that there won't be any merge conflicts. In this case, git will automatically commit the merge changes and you don't need to run the above commands.*

Finally, merge your branch into the master branch to have your changes pushed to master.
```
git checkout master
git merge branch_name
git push
```
Then, to continue working on your branch, simply switch to it again:
```
git checkout branch_name
```

### Authors:
- Rebecca Hough
- Elliott Waterman
