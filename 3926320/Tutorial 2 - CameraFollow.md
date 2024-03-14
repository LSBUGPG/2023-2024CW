## Tutorial for the 'Camera Follow' component.

This is the 2nd tutorial for a component, this time Camera Following,

In this, we need the camera to follow the player. Make sure you set the Y position of the main camera to 5, and Z to -5.

Create a new script in the folder called Camera Follow. 

Open it in Visual Studio. Here, we need 2 variables, first being a public Transform for the player, and a Vector3 offset.

In the void start, we need the following line. 

`offset = transform.position - player.position`

What this does is calculate the vector difference between our camera and the player, positioning them relative to each other.
In the void update function, put this:

`transform.position = player.position + offset;`

This update the position of the camera, so it maintains a constant offset from the player. Save and goback to unity.

Select the script and drag it on to the Main Camera object. Select it and you will see a slot for the player under the script. 
Drag the player onto it. Now. you can test it. Play and see how the camera follows the player.

However, we want the camera to stay in the middle. Go back to the script.

Replace the transform.position in the update function with Vector3 TargetPos.
Underneath, set the TargetPos to 0, and under that make transform.position = targetPos.

Like this:

![image](https://github.com/mihxi/RunnerGame/assets/146852911/83f296a0-6831-410c-89c9-bddecf0fa53e)

`Vector3 targetPos = player.position + offset;`
`targetPos.x = 0;`
`transform.position = targetPos;`

To break down each line:

`Vector3 targetPos = player.position + offset;` = this is the position of the player object + the vector that represents the difference between the camera and player.

`targetPos.x = 0;` = this sets the x component to 0, alligning the vector with the yz plane while keeping its yz components unchanged. 

`transform.position = targetPos;` = this sets the position of the camera to the modified targetPos, aka it gets repositioned to a new location where x coordinate is 0, while yz coordinates maintain the same position to the player.

Go to the Unity editor and test the game. The camera should now follow the player while staying dead center.

This was the 2nd tutorial, to do with Camera Follow and movement.
