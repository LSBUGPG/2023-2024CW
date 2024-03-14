This tutorial will cover the creation of obstacles for the game. These will serve the purpose of increasing the difficulty for the player, spawning at random points. Once hit, the game will end, and you'll have to restart.

So the first step is to go the prefabs folder, and select the ground tile. Create a new empty game object 
and name it ObstacleSpawnLeft. Then set the position values to X = -3.3, Y = 0.5, Z = 10. 

Duplicate this twice, and name them ObstacleSpawnMiddle and ObstacleSpawnRight respectively. 
For the middle obstacle, the values should be X = 0, Y = 0.5, Z = 10.
For the right obstacle, X = 3.3 and everything else stays the same. 

Exit out the ground tile prefab and create a cube in the hierarchy. Call it obstacle, then right click the transform obstacle and reset. Set its Y position to 0.5 and its X scale to 10/3. Then drag it into the prefabs folder, and delete from scene.

In the script folder, open up the GroundTile script, as we need a new variable:

`public GameObject obstaclePrefab;`

This creates a variable for the type of game object called obstaclePrefab. Now assign the obstacle to the obstacle prefab, which is in the ground tile prefab inspector. 

Back in the script, it's time to create a function for spawning obstacle, which will be `void SpawnObstacle ()`.

Now, write the following lines: 

`int obstacleSpawnIndex = Random.Range(2, 5);` - what this does is generate a random value between 2(inclusive) and 5(excluded), meaning one of the left, middle or right obstacles. 

`Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;` - here, we are trying to access the the child transform of the current object. We are retrieving it using transform.GetChild. The `.transform` is simply used to get the component. 

To spawn the obstacle, we need the following:

`Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);` So, to break down this line:

`Instantiate` creates new instances of the obstacle prefab.

`obstaclePrefab` is our reference for the prefab.

`spawnPoint.Position` specifies the position where the obstacle will be created.

`Quaternion.identity` represents the rotation, however we will not have any.

`transform` specifies the parent of the obstacle.

Finally, at the top, under the start function, we want to call this `SpawnObstacle`. 

We can now go back to Unity, and try out the game. We should be able to see the obstacles spawn. You can optionally increase the speed of the player if it feels too slow. 

You may find that nothing actually happens when we hit the obstacles. To fix, we need to create a new script called Obstacle. Open it up and create a type PlayerMovement variable named playerMovement. Then, in the start function, write the following line.

`playerMovement = GameObject.FindObjectOfType<PlayerMovement>`

In this line we are finding the first active instance of the player movement script and assign it to the variable. 

we also need a function for OnCollisionEnter:

`void onCollisionEnter (Colision collision)`

Head to the PlayerMovement script and add a new variable, type boolean and call it alive.

`bool alive = true;`

Under the fixedUpdate function, add a line stating:

`if (alive) return;` this means if the variable alive is not alive, the function will stop running. So if the player is not alive, it won't move.

Then create a new function called Die in the update function. Under it, set alive = false.

All the way at the top, add the following line:

`usingUnityEngine.SceneManagement;` which will allow us to the use the die function in order to add:

`SceneManager.LoadScene(SceneManager.GetActiveScene().name);` what this does is simply restart the game as we reload the scene. 

Back in the obstacle script, 

`if (collision.gameObject.name == "Player") {
playerMovement.Die();
}`

What this basically does is check whether the player has collided with the obstacle, in which case it will 'die'.

We also want the game to restart when the player falls off the platform. To do this, go back to the player movement script.

In the update function, underneath the horizontal input, we need the following function:

`if (transform.position.y < -5) {
Die(); }`

What this means is, if the position of the player falls beyond -5, it will die and the game will restart.

Save the script and select the obstacle prefab. Add the obstacle script to it in components. 

You can now run and test the game. If you want your obstacles to be textured, you can follow the same steps as we did for the ground texture, as it is the same process. 

That's the tutorial for working obstacles.




