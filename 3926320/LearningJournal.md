# Learning Journal

#### October 10 2023

Practiced following a tutorial for making a endless runner game. At first it was confusing with visual studio and unity as I don’t really have any proper previous experience. However once I got comfortable following the tutorial, it was easy to see how some of the functions work. The tutorial is very easy to follow, covering both unity and visual studio work.  

So far, as a progress check, I have made the player move left and right while being followed by the camera. Very smooth and works well. Played around with floats, vectors and other functions and stuff. 

I made scripts for a couple components so far, including PlayerMovement and CameraFollowing. For CameraFollow, I used vectors to represent the XYZ position of the camera, then made that use the target position(TarrgetPos) which was player.position + offset. For PlayerMovement, I used public floats, such as the speed being 5, and also gave it a horizontal multiplier of 2. I then also used Vector3 here to show the positioning of the player. 

I did have a issue where the RigidBody component wouldn’t appear under the player movement component for the player capsule, but I went over the script and it was due to a capital letter mistake, as I wrote RigidBody instead of Rigidbody. This fixed it and then the component appear, and I was able to drag it Rigidbody and put it under the script component. Im sure these small capital letter mistakes will be first of many. 

#### October 17th 2023 

Today, I am aiming to get the endless ground spawning and the obstacles done. Will be following the tutorial. I am currently working on the endless ground spawn. 

For the endless ground spawning,  I created an empty game object then named it GroundTile. I then added a Plane as its child. Then I created another child and named it NextSpawnPoint. With that, I created a new folder under assets and named it Prefabs. I dropped the ‘GroundTile’ into that folder, thus creating a prefab. 

I then made a new script called GroundSpawner, where I will program the component. Firstly, needed  2 variables. First was a public GameObject, which was the GroundTile, aswell as a Vector3 named nextSpawnPoint. I then went back to unity and created a component for the GroundSpawner, and linked the GroundSpawner script to it, while adding the GroundTile prefab to it. 

So I did actually encounter an error, where it wouldn’t let me run the game to test it due to an error in one of the components, to do with GroundTile not being recognized. At first I was confused why this was because looking over the code nothing was out of place. However, upon further inspection, I found the error was that I name the variable Groundtile by accident, but later on tried to use it as GroundTile, so the one letter not being capital enabled that error. It was a funny error to see, which was fixed instantly and very easily, then when I tried to test the game, this time it worked, confirming that was the error.  

Another problem, I named the public class GroundSpwaner instead of GroundSpawner, and due to the spelling error, my GroundSpawner class in the GroundTile script was not recognized, until I fixed the error. 

Another error, I had accidentally created 2 GroundTile scripts without realizing, which prevented me from adding the script to the GroundTile prefab. Once I deleted the extra script, I was able to add the proper one to the prefab. 

Another error, inside the GroundSpawn script, I left one of the lines without adding ;. This was the SpawnTile function, which made it not work, since it wasn’t closed. Once I added the ; it worked normally.  

Another problem, the first tile spawning at the same place as the player. To fix this, I selected both the camera and the player, then dragged them about 5 units forward. 

#### October 30th  

Today I am working on the obstacle generation for the game and perhaps even further. I could try finish the game itself today. H pefully I have less of the tiny errors I encountered in the last update. I’ll just have to double check everything and make sure it’s all accurate. So, clearly I didn’t stick to that because I already encountered exactly one of these problems again. Replaced the small letter with its capital counterpart. 

Ok so it seems I have a bigger problem, where the game is not restarting once my character hits and obstacle or falls off, even though I followed the tutorial accurately. Ok, actually it does restart when I fall off the map, so that works properly, but it doesn’t work when I hit an obstacle. It must be something in the obstacle script perhaps. Ok, so the problem was in the Obstacle script, around the if function. Because I put a comment inbetween the lines of code it kinda messed up the positioning of certain brackets, once I did control Z to undo everything was fixed. Now it respawns upon death. I also added my own texture for the obstacles instead of leaving it a basic colour. I then also added my own skybox to it, a nice pink sunset skybox with clouds. This was very easy to do, in the rendering lightning settings. 

I am now also working on the coins for the game. These will be what the user picks up and interacts with, and the goal of the game will be picking up as many coins as possible. The issue so far is I forgot to close one of the {} brackets, so there was an error. However that was quick to figure out, and I closed it and the error was gone. 

A big issure was that I couldn’t drop the ScoreText into the GameManager Score Text. This was weird because I followed the tutorial, and I couldn’t figure it out. After some googling, a helpful forum, I saw that I used a Text Mesh Pro instead of a normal one. To fix this, I added “using TMPro;” at the top then added TMP_ in front of the text variable. I finished the coins and searched for a good fitting gold coin texture and added it into the coin. 
