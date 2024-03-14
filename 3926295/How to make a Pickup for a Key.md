How to make a Pick Up for a Key 

  

First Create a cube or load in your model of a Key if you already have one and call it "Key" and then create a material and drag and drop it onto the key. 

  ![Tutorial 2](https://github.com/huckerE/University-work/assets/146854478/6b5d45e9-302b-459f-b910-627a2873e549)


Next Thing to do is to give the cube a mesh collider what you will need to do is to go down to "Add Component" and add a mesh Collider and then turn on convex 

  ![tutorial 2 - 1](https://github.com/huckerE/University-work/assets/146854478/0fb94dea-d61e-474d-8fde-7924e2c49704)


once thats done do the same with a Box Collider but instead of convex turn on "Is Trigger" 

  ![tutorial 2 - 2](https://github.com/huckerE/University-work/assets/146854478/0c9ed964-8973-41fa-9016-6fd395d64afd)


After that is done is go to add component and then add a "RigidBody" 

 ![tutorial 2 - 3](https://github.com/huckerE/University-work/assets/146854478/ef8bc868-abad-4b6d-b6cf-3a1c149a7a71)


Next create a Empty Object and name it ItemParent and then move the object to where you would like the item to be held. (Make sure this is infront of the camera where the player is looking) 

  ![tutorial 2 - 4](https://github.com/huckerE/University-work/assets/146854478/6de479ae-e2b7-4c62-9ee6-cb2c5a2c5c44)
![tutorial 2 - 5](https://github.com/huckerE/University-work/assets/146854478/870f775e-36c2-4fcf-8d83-fa1642ba0e00)


Create a new script and name it EquipItem and the copy the code below. 

  ![tutorial 2 - 6](https://github.com/huckerE/University-work/assets/146854478/6565e6a2-bcfb-4275-afe8-33850d189b40)
```
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject Key;
    public Transform ItemParent;
	[SerializeField] private LayerMask PickupMask;
	[SerializeField] private Camera PlayerCamera;
	[SerializeField] private Transform PickupTarget;
	[Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
	
    void Start()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;
    }

    
    void Update()
    {
       if(Input.GetKey(KeyCode.F))
        {
            Drop();
        } 
    }

    void Drop()
    {
        ItemParent.DetachChildren();
        Key.transform.eulerAngles = new Vector3(Key.transform.position.x, Key.transform.position.z, Key.transform.position.y);
        Key.GetComponent<Rigidbody>().isKinematic = false;
        Key.GetComponent<MeshCollider>().enabled = true;
    }

    void Equip()
    {
        Key.GetComponent<Rigidbody>().isKinematic = true;

        Key.transform.position = ItemParent.transform.position;
        Key.transform.rotation = ItemParent.transform.rotation;

        Key.GetComponent<MeshCollider>().enabled = false;

        Key.transform.SetParent(ItemParent);
    }

    private void OnTriggerStay(Collider other)
    {
        
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(CurrentObject)
                {
                    CurrentObject.useGravity = true;
                    CurrentObject = null;
                    return;
                }
                
                Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if(Physics.Raycast(CameraRay, out RaycastHit Hitinfo, PickupRange, PickupMask))
                {
                    Equip();
                    CurrentObject = Hitinfo.rigidbody;
                    Debug.Log (Hitinfo.transform);
                    CurrentObject.useGravity = false;
                }
            }
        }
    }

    internal bool IsEquipped()
    {
        return !Key.GetComponent<MeshCollider>().enabled;
    }
}
```

Next of all We need to go to the key object and go to the layer drop down and select add layer and name it "Pickup" and then assign the key object so it now has the "Pickup" layer. 

  ![tutorial 2 - 8](https://github.com/huckerE/University-work/assets/146854478/176f623d-f7d9-4a2d-a4c8-c198cb1ba9c4)

![tutorial 2 - 9](https://github.com/huckerE/University-work/assets/146854478/c9c53efb-ea5a-4ba2-a0db-4e9ef5239644)

  ![tutorial 2 - 10](https://github.com/huckerE/University-work/assets/146854478/89967930-b39b-4068-acaa-c24010ce105f)


Lastly get the EquipItem script and drag and drop it under the key object and then drag and drop to assign each of the variables to the correct places which will be: 

  ![tutorial 2 - 7](https://github.com/huckerE/University-work/assets/146854478/fe4370a8-40cc-47e6-96f4-73f9ec658cc9)

![tutorial 2 - 11](https://github.com/huckerE/University-work/assets/146854478/178653ec-eee3-4df6-9927-f69c89ad1ade)


Key - Key Object 

Item Parent - ItemParent (Transform) 

Pickup Mask - Pickup 

Player Camera – Main Camera (Camera) 

Pickup Target - Key (Transform) 

Pickup Range - 5 

 

 
