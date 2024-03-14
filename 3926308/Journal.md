# journal


 
 **10/10/22**
 An issue I am already running across is that GitHub has no autocorrect. This is a big deal to me due to my dyslexia. A way I will go about this problem is by typing in Word first, Then pasting into GitHub. 

 
 **12/10/22** 

 First problem i have ran into is that Directly importing a model in from blender to Unity, There are missing walls. A way I have found to fix this is by researching into the sitation and finding out Unity does not show/render backwards faces. To fix this, i have returned to Bldender and reflipped the faces so that they are facing the right way


Another issue i have ran across in the main roation of the maze, is that, in the spectator, I struggled to identify What way it would rotate in each Axis. After trail and error, I worked out it spins horazontally on the Z axis. This has been noted for future referance. 


**4/11/22**

I ran into several errors in my look code. With these two errors on going, the program will not work 

How I fixed it:
I looked through the code along with a friend. The error was then located and realized. There were some missing capital errors. With these fixed, It now works. 


![1](https://github.com/BravoGeor/univerityWork/assets/146854370/6e16302f-1ca8-4e10-a3b3-7f6d42fa45a9)

**12/11/22**

 It appears I may have missed something from my code. I have spent over half an hour trying to find it but i have narrowed it down to an area.

How I fixed it: 
Turns out as stated, I was missing an {
**15/11/22**
I have begun working on the door code and everything appears to work but…the door. No errors come up for the code itself but instead for the animator. I have gone through all names and code associated with the animator. It must not be a large problem due to the game continuing to function correctly without it running, however, it appears to be stuck in a loop/ 

![4](https://github.com/BravoGeor/univerityWork/assets/146854370/0e1243e8-537d-4c1f-9565-b7ba0b63cd6d)

How I fixed it:
Turned out I had mislabelled the animator and Had missed a capital letter off of the beginning of the name. 

**20/11/22**
With my door now in place, I have uncovered a new problem. When I type in the code to enter, it appears the turn radius is too large and makes it swivel out of its door frame. It is not good for what I need and would only work if I wanted the door to disappear. I know in order to fix this, I will have to reanimate it. 


https://github.com/BravoGeor/univerityWork/assets/146854370/1ebb0c31-bd2a-49a2-8f05-5a220fb1a7f2


How I fixed it:
Despite my many attempts of moving the origin, none of it worked. Despite this temporary setback, I have changed it to a sliding door. I have come to like this idea far more than an opening hinge door. Fits the theme better. However, It still does not slide on the right spot. 



https://github.com/BravoGeor/univerityWork/assets/146854370/f19c562f-749f-4458-ba11-a73f33ae530e


Update:
With further tweaking, it now slides on the correct spot!



**8/12/22**
Despite following my example closely, it appears to not be working. Whenever I walk into my ‘Death’ zone, I just walk through it.This is not supposed to happen. What is meant to happen, is that when the player touches it, they move to the respawn translations. 

 I have gone through it a few times and cannot find the issue. I will take another look tomorrow. 


https://github.com/BravoGeor/univerityWork/assets/146854370/0db1b155-d83c-4948-ad66-90729625d21f


How I fixed it: 
After leaving it for a day and taking a relook, I still could not find the error. However, i found the solution to my problem in the comments. Turns out in order for the code to work, I had to turn on an option in the settings. It now works perfectly. I have logged this in my tutorial. 


![55](https://github.com/BravoGeor/univerityWork/assets/146854370/9ba48f2b-28df-476f-a0f2-d08cd9c35cf4)




**12/12/22**
Whenever an object touches the lava, the player respawns. This will not help the game was the palaver will need to throw objects in the lava in order to cross it.

How did I fix this?

Turns out I did not specify what touching the lava made the player respawn. So, to fix this, I have added two extra lines of code that specifies the player. 
![5](https://github.com/BravoGeor/univerityWork/assets/146854370/307e1b6e-a5a2-4b66-a842-213235bdf0f5)



