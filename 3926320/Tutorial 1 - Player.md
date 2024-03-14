## Tutorial for the 'Player' component.

I will be showing you how to create the player for the game. This is the character that you will be controlling while playing the game, and the first component you would want to create.

Start by creating a Plane object, which you can name 'Ground'. We will then change the respective transform values in order to make it longer, like a platform on which the game is taking place. These are the values.

 ![image](https://github.com/mihxi/RunnerGame/assets/146852911/42552bc3-1391-4be7-ae63-8ca3cb824778)

Then, you should add another 3D object, this time a Capsule, which you will rename 'Player'. This will be our player that we will be controlling. Once the capsule is in, drag it just above the plane, as the capsule will be running on it. However, this capsule won't have physics, 
so we need to add them ourselves, using a component called RigidBody. Select the 'Player' capsule, then scroll down in the inspector and add component, and search for RigidBody. 

![image](https://github.com/mihxi/RunnerGame/assets/146852911/d241a85d-8e00-4ae1-91a7-bcdece3d53c6)

However, you may find that the capsule still falls over, so we need to freeze it and stop it from falling. In order to do this, we go to the RigidBody component, under 'Constraints', and we freeze the rotational axis.

![image](https://github.com/mihxi/RunnerGame/assets/146852911/9e13af88-1381-470d-b97b-54cf871c66f7)

I then recommend you create a new folder for Materials, then inside the folder create a material specific for the player.
You can name it whatever, such as 'Player_Mat', and the colour is up to you. Once created, just drag and drop onto the capsule.
Once this is done, we need to create a new folder for Scripts. In the folder, create a script called Player Movement, then open it.

You can delete the start function, because it won't be used for now. Add a float variable named speed. This is done to declare a
variable. Float tells us to hold a decimal number, which is speed in this case. The number will be 5. Then add public in front of 
float, allowing us to edit it and be accessed from anywhere.

`public float speed = 5;`

Then head back to Unity, and select your PlayerMovement script. Click and drag it down onto the 'Player' object, to assign the script 
to it.
Back in the script, we'll add another public variable, in this case RigidBody, and we'll name it rb.
`public RigidBody rb;` 

These are the two variables needed for player movement.

Create a FixedUpdate void. Void simply means there will be no value returned. 
Inside, we put the following:

`Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;`

`rb.MovePosition(rb.position + forwardMove);`

So what this does is basically move the capsule in its forward direction at a specific speed, while the physics interactions get
taken into account. So, to explain it fully:

`transform.forward` = this represents the forward direction of the object.

`speed` = the variable representing the speed the object is moving

`Time.FixedDeltaTime` = this may sound a bit complicated, but it is used to show the time in seconds it took
to complete the last fixed frame.

So what this amounts to, is the creation of a movement vector(forwardMove), which goes in the forward direction of the object,
while scaled by speed and adjusted for the fixed time step.

`rb.` = this is the reference to the rigidbody component.

`rb.MovePosition` = this sets the position of the rigidbody.

`rb.position` = the current position of it, adding the `forwardMove` line to the current position of the RigidBody.

Save, then head back to Unity for testing. Select the capsule, then scroll down and you'll see a Rb slot in the PlayerMovement script.
Drag the RigidBody in it.

![image](https://github.com/mihxi/RunnerGame/assets/146852911/e046636f-a016-4eb8-b72e-17aba7b8ca54)

Save and hit play. You should see the player moving forward. We'll then add horizontal controls for the player, using legacy controls.

Back in the script, you declare a new float variable, named horizontalInput.
In the update function, insert the following line.

`horizontalInput = Input.GetAxis("Horizontal");`

What this does is simply retrieve input from the horizontal axis, aka your arrow keys. the result will be a number from -1 to 1,
where -1 is left, 0 is no input and 1 is right.

Go back to the FixedUpdate and add a new Vector3 for horizontal move. The line is:

`Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;`

This is similar to the forwardMove, however our input is also taken in. 

In rb.MovePosition, also add a horizontalMove.

Save and test it out in Unity. You should be able to control the capsule now. 

Optionally, if you want the horizonal speed to be bigger than forward one, we can go to the script and do this.

Create a new public float called HorizontalMultiplier.

Line is:

`public float horizontalMultiplier = 2`

What this does is make the horizontal speed twice as much as the forward one. However, if its too fast, click on the player,
then go to the inspector. and under the script you can lower the speed value. I recommend 1.7 as a good speed. 

Finally, we need the camera to follow the player. Make sure you set the Y position of the main camera to 5, and Z to -5.

This was the first tutorial for the 'Player' component.















