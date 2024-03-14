# Tutorial 1
In this tutorial we are going to create a "Delivery Point Spawner" that will keep on creating a bunch of a delivery points for the player to collect to win "points" and the delivery points will keep on respawning with a limit of how much there can be at once in the scene with the variable that we will control in the script.
<br/><br/>
Let's start by creating a script called  "DeliveryPointSpawner". We can create an empty object an assign the script to that object as shown in the picture below:
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/abd78101-3a54-4f97-b8c0-93a27389ac21)
<br/><br/>
Now open the script and lets create 3 variables that we will need in order to spawn delivery points around the map:
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/18397308-dfaa-43e3-8d31-31785cf7b019)
<br/><br/>
We will use "void Start" and 2 custom functions which will be called "SpawnDeliveryPoint" and "PickUp"
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/a9246625-3b24-4ae8-9236-2aa77ffad123)

We use the "InvokeRepeating" command to spawn the delivery points every 2 seconds with the first one being spawnped instantly.
We also need instantiate to spawn the prefab clones around the scene in the hierarchy.

After doing this, lets save the script and go back to the scene to see if it works.
Make the ground/plane we have bigger size so xyz being 15 each so that we have a bigger area where the delivery points can respawn.
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/7e53a98a-a1ad-400d-b351-b2a27e665741)

Now we have to create a prefab which will act as our delivery points.
We can do that by right-clicking the hierarchy and select 3D Object>Sphere
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/3df07a01-3f5d-4c22-a850-6d9d48e5a1cb)
Reset it's position to be 0,0,0 on the xyz axises. And scale it bigger by 5,5,5. It will look something like this
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/1e87405e-5bcc-4592-8bd4-1ec66958eaf1)

<br/><br/>
Now you can create a material on by right-clicking on an empty spot in the "Project" section. I will create a transparent green material to assign to the sphere.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/6672b07d-5978-4777-ad40-e0e20ec1a078)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/4ba0ec82-80d4-4da7-84e8-93313790de82)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/c1826643-b81c-49f9-b26a-218cb2c73255)
Dont forget to tick the "Is Trigger" option in the object's collider.
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/77e9d5fe-46c5-40b9-8b97-1b280ca839ab)

<br/><br/>
Now we can name the game object "DeliveryPointPrefab" and drag and drop from the hierarchy into the "Project" section to create a prefab.
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/f15e58fc-f6ec-4294-9275-5757c4b024f2)
Now we drag the prefab into our DeliveryPointSpawnper Script and everything should be working perfectly now with delivery points spawning across the map.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/984f3332-ad7b-46f3-8668-00117229980c)
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/f9133977-2916-4e8b-a075-fb2ec3786ea2)
And thats our first tutorial finished. Well done!
