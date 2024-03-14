How to make a Double Door Animation 

  

Firstly import your models of your doors or get two cubes and scale them up to make doors 

  

Next create an empty object and name it Door and then put the two doors within that game object 

  ![Tutorial 3 - 1](https://github.com/huckerE/University-work/assets/146854478/734cb20c-90ee-4bcd-8170-4fed1e697b17)



After that click on the Door object and then add a box collider and then set that as the trigger (this should be the parent not the children) 

  
![Tutorial 3 - 2](https://github.com/huckerE/University-work/assets/146854478/67702d81-7ea9-446c-9f21-bb862e1c3646)

  

once that has been done add a mesh collider for each of the doors and set them to convex and to provide contacts 

  ![Tutorial 3 - 3](https://github.com/huckerE/University-work/assets/146854478/c8377560-4ae3-47e8-be7b-b992353f7a0f)


when that is done you want to start doing your animation of your doors opening (make sure the animation is set on the parented object not the children) this can be anything you want it to be. ( when your finished the animation make sure you turn off "loop time".) 

  
![Tutorial 3 - 4](https://github.com/huckerE/University-work/assets/146854478/d9a89d54-bcb1-45a4-8b6d-e7cf7f872102)

  

the next thing you need to do is go to the animator window and then create a new state (right click and hover over create state and click empty) and name is "Idle". once done you make that the default state and then you make a transition from the idle to the Door Open. 

  ![Tutorial 3 - 5](https://github.com/huckerE/University-work/assets/146854478/6c761590-109b-4dce-94f9-a1b34bdc8129)
![Tutorial 3 - 6](https://github.com/huckerE/University-work/assets/146854478/7c23753d-fe61-48ed-8cc2-184ead4ffda3)


Next you go to the parameters and add a trigger parameter and call it "DoorOpen". Once done click on the transition between idle and Door Open and then under conditions, add the condition called "DoorOpen". 

  ![Tutorial 3 - 7](https://github.com/huckerE/University-work/assets/146854478/656609aa-bd17-4e27-9d5c-c4af921144e6)

![Tutorial 3 - 8](https://github.com/huckerE/University-work/assets/146854478/a911927c-67da-4421-aeae-04ca2b25af29)

  

After that create a new script called "DoorOpen" and copy the code below:
```
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour

{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Key") && Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("DoorOpen");
            DestroyKey();
        }
    }

    private void DestroyKey()
    {
        EquipItem item = FindAnyObjectByType<EquipItem>();
        Destroy(item.gameObject);
    }
}
```

  

Once done, drag and drop the DoorOpen script into the Door Object (parent) 

  ![Tutorial 3 - 10](https://github.com/huckerE/University-work/assets/146854478/694573db-1041-4d95-8f47-f6d7ee07cf41)


Lastly drag and drop the Door (parent) into the animator under the DoorOpen script. 

  ![Tutorial 3 - 11](https://github.com/huckerE/University-work/assets/146854478/52c2d0d7-cafb-43b4-9963-42acf3dbac5a)


  

  
