## Tutorial for the 'Ground Spawn' component.

This is the tutorial for the endless ground spawning component of the game. This will help you create a platform that will infinitely spawn as you travel on it.

Start by deleting the previously created plane. Then create an empty game object and name it GroundTile. 
Right click on it and add a Plane, which will add it as it's child. Set the position on Z to 5.
Click again on the GroundTile and create an empty object, naming it NextSpawnPoint, with 10 as its Z position, which should match the end of the plane.

Now, create a new folder called Prefabs, and drag n drop the GroundTile in the prefab folder, which will store it.
Delete the GroundTile, since we will spawn them from a script. To do this, create a new script called GroundSpawner.
Delete the update function since we won't need it.
Now, add 2 variables that we will need.

![image](https://github.com/mihxi/RunnerGame/assets/146852911/b262f7f0-d257-4558-9bfe-8955da84afe1)

Back in Unity, create an empty game object and name it Ground Spawner, and add component, this being the Ground Spawner script. Then select the groundtile prefab and drag it onto the GroundTile slot in the script component. 

Back in the script, add a new function called void SpawnTile (). This is void because we won't need an output.
Inside the function, we need the following:

`Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);`

To break it down, `groundTile` is the prefab that we are instantiating, in this case the plane. `nextSpawnPoint` is
the position where the next instance is placed. `Quaternion.identity` represents no rotation, so we will have the same orientation throughout. 
Simply, we will be creating new tiles at the specified location while having them rotationless. 

We need to set the new spawn point, but first we must reference the child of the object. 
To get the reference, add `GameObject temp =` in front of Instantiate. With this, we store a reference to the temp variable.

The next line is:

`nextSpawnPoint = temp.transform.GetChild(1).transform.position;`

What this line does is basically update the next spawn point variable to be the position of the child ata the index 1 of the temp transform. `temp.transform` accesses the transform component of the temp game object. `GetChild(1)` gets the child from the temp at index 1. `transform.position` accesses the position of the child object. In culmination, `nextSpawnPoint` sets the value and updates the spawn point for the next instantiation. 

Next, in the start function, we need to call the function. `SpawnTile();`. If you copy and paste this 4 times, and go back to Unity, you'll see 5 tiles spawning. Meanwhile, you'll want to drag the camera and player forward about 5 units, so they don't start at the edge of the plane. 

Back in the script, we can use a loop instead of the copy and pasted function. This is what it looks like:

`for (int i = 0; i < 15; i++) {
SpawnTile();
}`

![image](https://github.com/mihxi/RunnerGame/assets/146852911/92e61d59-283d-4147-917e-ac2377ecc8dd)

What this line does is iterate the loop 15 times. As long as the value of i is less than 15, the loop will continue reiterating. 

We do however need to keep spawning tiles as we move. 

Go to the Ground Tile prefab and add a Box Collider component. Check the is trigger box. Then change the values to the following, and it should look like:

![image](https://github.com/mihxi/RunnerGame/assets/146852911/2a1e419b-bda6-43b8-96f4-28fa670389c4)

We'll need a new script now. Name it GroundTile. 

Inside it, we'll need a GroundSpawner variable. 
Then set the reference in the start function. 

`groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();`

We then need to create a function called OnTriggerExit. 
`void OnTriggerExit (Collider other)`

This is a method that will be called when something exits the trigger zone. 

Now, we need to go back to the GroundSpawner script and put public in front of the SpawnTile void, so we can access it in the other script. 

Back in the GroundTile script, we need this line:

`groundSpawner.SpawnTile();`
`Destroy(gameObject, 2);`

What these 2 lines do is spawning tiles while serving a 2 second delay before destroying a previous tile, thus we have continuous generation and destruction. That's that for the scripts, so save.

In unity, select the GroundTile and apply the script to it. Exit the prefab view, and test the game. We should now have tiles that spawn ahead, while the previous ones destroy themselves. 

The final optional step, is adding a material to the ground. Find one that you like, then add it to the assets folder. Create a new material and name it. Then, next to albedo in the inspector, there is a circle. Click on it and select your chosen texture. Then, drag and drop it onto the plane, and you have yourself a textured ground.

That's all for this tutorial.




