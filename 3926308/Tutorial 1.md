Tutorial 1 
 Character movement 


**Basic setup:** 

First thing you would want to do is create an empty. Here you will store all your first person objects such as player mesh and camera. You are going to label this empty as Player. 

Next you'll need to add into the Player a Character controller. This will create a boundary box along with a collider that is fitted to the mesh we will import later. Make sure you set the height to 2 and the radius to 0.5 so that it wraps around the mesh.

Right click the Player and create an object that serves as a placeholder. I will be using a capsule as that's my preference and is the most human-like simple object. The boundary box will automatically follow the player's geometry. 
![1](https://github.com/BravoGeor/univerityWork/assets/146854370/5145d159-e0be-493b-86ed-bade97153220)

Make sure you remove the collider it automatically added as, as mentioned previously, we already have a collider aka the character controller. 

**Camera** 

Locate the world start up camera and drag it into the player empty. Now that this is grouped together, When the empty moves, so will the camera. To make this a first person camera, drag it into your Capsule so that it's positioned where the head would be. Make sure a little gap is left so that the player wont clip into ceilings. 


**Coding**

Code 1: 
Looking around code

Create a new script on the camera named MouseLook. Make sure this variable stays consistent or you may have problems later. 


![2](https://github.com/BravoGeor/univerityWork/assets/146854370/2cc307c1-61a0-4391-8941-f42336c1501c)



Create these two floats as demonstrated in the photo. These will grab the information on the mouse's location. By x the mouse sensitivity, it'll ensure it'll move by how much we want it too. By x by the time too, it'll automatically update to follow the framerate. 

For the ability to control the mouse speed add the following 


![3](https://github.com/BravoGeor/univerityWork/assets/146854370/71c5fca6-eea8-42f2-9ac5-1847b432d531)


Make sure you set it as a public float so that you can change the sensitivity within unity without needing to open the code to change it manually. 


![4](https://github.com/BravoGeor/univerityWork/assets/146854370/86521d42-61a5-439d-a069-81cf077c9557)


The highlighted area is inputting the mouse values and x by the inputted mouse sensitivity along with the frame count. This comes into play on controlling the camera. 

![5](https://github.com/BravoGeor/univerityWork/assets/146854370/488681b5-1c66-4192-b1ce-c36c0858190d)



This code clamps the amount that the player can turn their head up and down. We need this so that the player cannot look all the way behind them and break the character's neck. 

![6 ](https://github.com/BravoGeor/univerityWork/assets/146854370/627a463a-1626-4896-94ff-8605cf37c9f8)


Finally this part will allow the x of your mouse control where you look.
![10](https://github.com/BravoGeor/univerityWork/assets/146854370/5a063e99-a2f1-4718-97b0-3c8e1b56e0f0)

This is what your final code will look like. 


Code 2: character movements. 
This code is responsible for checking the ground on whether the player is in the air, jumping and general movements. 



Create a new script and label it PlayerMovement

First off, you want to create all the floats you'll need. Remember to set them in public if you want to change these later in unity. 
 

What each class does is self explanatory. 


These are specific to the ground checking that the players model will be doing and creating the isGrounded call. 


This section is continuously checking to see if the character is grounded and if they sre not, to add more speed to the falling depending on the gravity. 



This final section creates the movement and jump call. Luckily for us, the jump call is already embedded into unity and is as simple as calling it. 









Your final code should look like this: 

**Setting up ground check:**
 
First thing you're going to want to do is create an empty under PlayerBody. This empty will serve as your ground check. Locate your ground check in the unity world and move it to the bottom of your character. 

![11](https://github.com/BravoGeor/univerityWork/assets/146854370/31eadb69-02d6-4be0-9ab4-c89b07a9880d)
**Assembly:**


Here's the fun part! Putting together all the code so that it works. First thing you're going to want to do is create a character controller for your Playerbody components. This will create a collider. 

You are going to set your tag to the player and drag your character controller into the controller dropdown along with groundcheck into the ground check dropdown. 

Make sure to go to the ground plane and set that too Ground tag. 


 ![12](https://github.com/BravoGeor/univerityWork/assets/146854370/d1df3f0b-a719-4803-8ba2-eaf611cf57b1)




Go to your Players Camera and drag in your mouse look script. Then finally pull in your PlayerBody. 



![13](https://github.com/BravoGeor/univerityWork/assets/146854370/54301a72-2c68-43fc-b1f5-e5ebcee7a232)



That's everything! Make sure you test through your code and adjust things to better suit your game and gravity 

Video in reference: 
https://youtu.be/_QajrabyTJc?si=RqJviEGvVL4UXKFS
