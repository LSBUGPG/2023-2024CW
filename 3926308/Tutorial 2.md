LESSON 2: 

**Picking up Objects**

This tutorial I will be showing you how to pick up objects in unity that are affected by gravity. I will be using this in my game as a way to jump onto platforms. 


First thing your going to want to do is create an empty under camera.  This will serve as your pickup point. Label it as PickupPoint. 

![14](https://github.com/BravoGeor/univerityWork/assets/146854370/c6a500fc-9999-4496-9e89-5eae3a412ee2)


Move this pickup point to where you want your player's hand to be. Mine is at this distance as i am picking up large objects. 

**Code:**


Create a new script under playerBody and label it as PhysicsPickup 

![15](https://github.com/BravoGeor/univerityWork/assets/146854370/3b2f632c-8700-4af0-8842-ce889bb550c3)


These first few lines are essential as they are creating the core aspects of what the code requires. They are set to private as I do not want to edit them within unity. It is also calling in the RigidBody. 

![17](https://github.com/BravoGeor/univerityWork/assets/146854370/cfa6df10-bb9c-46a2-b59f-762c0f3557f9)


This input calls on the code to get the input of E. This means if E is pressed, the code will be triggered to start. 

The next section calls for the object to use gravity; however, if there is no object, the code will end. 

![18](https://github.com/BravoGeor/univerityWork/assets/146854370/09aaabe2-9f21-483a-93f1-aabf8c9b47ae)

This calls on a raycaster from the player camera to the pickup point to see if there is an object there. 

![19](https://github.com/BravoGeor/univerityWork/assets/146854370/cab4fd3c-ef5b-4499-acd8-b0debeaa1a22)



Finally , this section tells the program that, if an object is detected, to move with the direction of the point with the distance it moves. (the point moves automatically with the camera. 


![20](https://github.com/BravoGeor/univerityWork/assets/146854370/f1847281-33ad-4851-958c-cb9e87366681)


This is what your final code should look like. 

**Assembly:**

Return to unity and create your block(s). I made mine red so that it stands out from the ground. 




Create a new layer and label this as pickup.  Assign it to your object. Make sure to add a rigidbody so the player doesn't walk through it.


Last part, assign everything to the correct places 



![21 ](https://github.com/BravoGeor/univerityWork/assets/146854370/e7319c20-39a0-4486-9405-4a7531c78ad9)





That's everything! Have fun throwing blocks around!



Video used in reference:  
[(1395) How to Make a Physics Pickup System in Unity in 3 Minutes - YouTube](https://www.youtube.com/watch?v=zgCV26yFAiU&t=5s)https://www.youtube.com/watch?v=zgCV26yFAiU&t=5s
