# __Aim Trainer Random target spawn__.

### Description

<p>
This tutorial is for spawning objects at random positions.
<br>
And will explore 2 ways of achieving this.<br>
1. (Technically not spawning)Move the object after being hit and update counters as in an Aim trainer.<br>
2. Actually spawning random objects at random locations.<br>
The script for the random positions will be the same so we will do that first and then go ahead with the separate methods.
</p>


## Method 1

### Scene Setup

<p>
To create the bounding box on which the objects will spawn Create an Empty object in unity and add a Box Collider to it.<br>

Then edit the box collider size by clicking the button marked below.
    
![BoxColliderEdit](https://github.com/HemalK1412/GameProgramming/blob/8118eb1e04d78f61544300453a24d50348980172/Tutorials/Images(Tutorials)/Aim%20Trainer/Box%20Collider%20Edit.png)")
    
Clicking the button will enable you to change the collider dimensions by clicking and dragging the dots that have appeared on the collider faces in the scene view.
    
Now if you have already placed the Gameobject where you need it and just need to expand the collider pressing Alt + adjusting the collider will make it expand on opposite sides simultaneously.

![Collider Image](https://github.com/HemalK1412/GameProgramming/blob/8118eb1e04d78f61544300453a24d50348980172/Tutorials/Images(Tutorials)/Aim%20Trainer/Box%20Collider.png)

Then disable the box collider in the inspector. We only need the dimensions of the collider and do not need collision physics enabled on it.
</p>

### Maths

![Coordinate system](https://github.com/HemalK1412/GameProgramming/blob/2d9e40df2c29ab952d2e7e7abc439d7b5741d9c3/Tutorials/Images(Tutorials)/Aim%20Trainer/3D_coordinate_system.jpg)

If the origin marks the center of our collider then we need to find the position of the bounding faces of our collider.


So if the origin is at 0 and the distance of Origin to X = 1.<br>
Then origin to -x = 1 as they are equidistant from the origin.<br>
Then the size of the X-axis would be (-x, X) = 1 + 1 = 2.

> minX = center - (size of the X axis)/2.
> 
>> min X = 0(center) - 2(size of X axis)/2
>> 
>>> = 0 - 1
>>> 
>>>> -1
>>>> 
> minX = -1
<br>

> maxX = center + (size of the X axis)/2.
> 
>> maxX = 0(center) + 2(size of X axis)/2
>> 
>>> = 0 + 1
>>> 
>>>> 1
>>>> 
> maxX = 1
<br>
The range of the x-axis would be (minX, maxX) = (-1, 1).

Same for the Y and Z axes.

### Script

Then add the script for random spawn you can name it anything you want. I have gone with __TargetBounds__.

```.cs
public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider col;
```
Create a public instance of the script so the spawn objects can access the GetRandomPosition() function.
A reference to the Box Collider which is to be dragged and dropped from the inspector to this script.
```.cs

    public Vector3 GetRandomPosition()
    {
        Vector3 centre = col.center + transform.position;
```
This is to ensure the accuracy even if the position of the collider moves.
```.cs

        float minX = centre.x - col.size.x / 2f;
        float maxX = centre.x + col.size.x / 2f;

        float minY = centre.y - col.size.y / 2f;
        float maxY = centre.y + col.size.y / 2f;

        float minZ = centre.z - col.size.z / 2f;
        float maxZ = centre.z + col.size.z / 2f;
```
This is where we implement our calculations.

```.cs
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
        return randomPosition;
    }
}
```
So after we have our ranges for different axes we have the code select a random point on each axis using those minimum and maximum values.
<br>
The randomX coordinate is a random point between minX and maxX.

The randomY coordinate is a random point between minY and maxY.

The randomZ coordinate is a random point between minZ and maxZ.

We store it in a new Vector 3 with the 3 coordinates as the values for the x,y, and z axis.

### How to use: (Aim Trainer)

Say this is the start screen.

![AimTrainer Start](https://github.com/HemalK1412/GameProgramming/blob/cacc1e668291853ddf273b65d5d0776957c5b511/Tutorials/Images(Tutorials)/Aim%20Trainer/Aim%20trainer.png)

If the player hits a target.
The target ONHit will call the GetRamdomPosition() function and get a transform vector3 as a return value.
So on the target, the script would be the following and it would set the new position the same as the return value.

```.cs
public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
```

## Method 2

Another way of achieving the same result is you know the dimensions where the objects are supposed to spawn.
This method does not require any setup for colliders just create an Empty object to place the script on. You also don't need to move this object but it would be preferred for ease of use.

```.cs
        Vector3 randomposition = new Vector3(Random.Range(-5, 5), Random.Range(2, 7), Random.Range(-5, 5));
```

For this script, you will need to calculate between what points on the x, y, and z axes you want the objects to spawn. So just the minimum and maximum values of the axes.
The range values would differ for you according to your world design and spawn points.

## Example scripts

If you want to spawn different types of objects at different locations. 3 different types of zombies.

#### Using Method 1 :

```.cs

public class ZombieSpawner : MonoBehaviour
{
        public GameObject[] zombietypes;

    public static TargetBounds Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider col;


        void update()
        {
        if(Imput.GetKeyDown(KeyCode.Space))
                {
                        int randomzombietype = Random.Range(0, zombietypes.Length);
                        Vector3 SpawnPosition = GetRandomPosition();

                        instantiate(zombietypes[randomzombietype], SpawnPosition, Quaternion.Identity);
                }
        }

    public Vector3 GetRandomPosition()
    {
        Vector3 centre = col.center + transform.position;

        float minX = centre.x - col.size.x / 2f;
        float maxX = centre.x + col.size.x / 2f;

        float minY = centre.y - col.size.y / 2f;
        float maxY = centre.y + col.size.y / 2f;

        float minZ = centre.z - col.size.z / 2f;
        float maxZ = centre.z + col.size.z / 2f;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
        return randomPosition;
    }
}
```
The setup includes referencing the collider from the inspector and adding the types of zombies to the array in the inspector as well.

So on the trigger in the Update() function which is Spacebar press(this can be whatever you want).<br>
The script first selects a random zombie type from the array(The zombie's array index to be specific).<br>
Then it grabs a SpawnPosition from the GetRandomPosition() function and instantiates the zombie at the random position and keeps the zombie rotation as it is in the prefab.

#### Using Method 2 :

```.cs

public class ZombieSpawner : MonoBehaviour
{
        public GameObject[] zombietypes;

        void update()
        {
        if(Imput.GetKeyDown(KeyCode.Space))
                {
                        int randomzombietype = Random.Range(0, zombietypes.Length);

                        Vector3 randomposition = new Vector3(Random.Range(-5, 5), Random.Range(2, 7), Random.Range(-5, 5));

                        
                        instantiate(zombietypes[randomzombietype], randomposition, Quaternion.Identity);
                }
        }
}
```

This script on pressing Spacebar will select a random zombie from the array and instantiate it at a random position from the values set out.<br>

Also, another use for the script described in the aim trainer section is that the script can be used anywhere you need to get random positions even if no new game object is created.
