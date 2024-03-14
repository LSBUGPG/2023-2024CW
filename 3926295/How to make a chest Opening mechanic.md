How to make a chest Opening mechanic 

  

  

The tutorial shown will show you how to create a chest that you can open by pressing a key 

  

(highly recommended that you import or create the model form a 3D modelling software such as Blender or Maya before you start this and make sure the Top and the Bottom are both separate) 

  

Firstly, import your chest model into the scene and make sure they have both parts under a Parent object 

  ![Tutorial 4](https://github.com/huckerE/University-work/assets/146854478/b1622dd5-5174-4b1b-b535-126481cc3e96)


Next create some materials to give them colour and then drag and drop them in to the places you want them to go 

  

Next give the Top and Bottom pieces of the chest a Mesh collider and give them both convex's and make them provide contacts. 

  ![Tutorial 4 - 1](https://github.com/huckerE/University-work/assets/146854478/ddf437bc-363b-481d-9927-87b984c537c7)


After that, given the parent object a box collider and set that as "is Trigger" and then edit the collider so that it is covering the whole of the chest and a bit extra in front of the chest. 

  ![Tutorial 4 - 2](https://github.com/huckerE/University-work/assets/146854478/5a81554b-663b-40a0-a5da-ea2dd71ce23f)


Time to animate go ahead and start to animate the chest lid opening (make sure the animation is created from the parent object) and make sure that after you create it you turn off "Loop Time". 

  ![Tutorial 4 - 3](https://github.com/huckerE/University-work/assets/146854478/f8abb6d3-ff2f-4efc-8ac1-08e7188fca90)


Next, go into the animator, right click, hover over "Create State", then click "Empty" and name that "Idle". 

  ![Tutorial 4 - 4](https://github.com/huckerE/University-work/assets/146854478/f6ba087f-e599-4801-bf90-e4f9a0d529b4)


Once that has done right click the idle panel and click "Set as Layer Default State" and then make a transition from idle to Chest Open 

  
![Tutorial 4 - 5](https://github.com/huckerE/University-work/assets/146854478/c58e135f-f005-4ebf-9818-aee11b1414a2)

  

After that you go to the parameters tab and then click the plus, select "Trigger", and call it ChestOpen and then go into the transition connecting the "idle" and "Chest Open" together and add a new condition by pressing the plus (this should come up saying ChestOpen as the condition). 

  ![Tutorial 4 - 6](https://github.com/huckerE/University-work/assets/146854478/a7ac1d6f-e1bf-4538-ad93-e554d39b2203)
![Tutorial 4 - 7](https://github.com/huckerE/University-work/assets/146854478/d5374c7d-9baa-48be-a719-b22dbb0e4c91)


Next create a new script and call it ChestOpen and copy the code below:
```
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            animator.SetTrigger("ChestOpen");
        }
    }
}
```
  

Lastly drag and drop the script ChestOpen into the parent Object and the drag and drop the parent Object under Animator inside the ChestOpen script. Finally drag and drop the script ChestOpen into the parent Object and the drag and drop the parent Object under Animator inside the ChestOpen script. 

 ![Tutorial 4 - 9](https://github.com/huckerE/University-work/assets/146854478/aab283e8-7991-4457-a288-1c75357c7780)


 
