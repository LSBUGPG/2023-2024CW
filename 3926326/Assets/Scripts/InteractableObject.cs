using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollideableObject
{
    private bool z_Interacted = false;
    protected override void OnCollided(GameObject collidedobject)
    {
        if (Input.GetAxisRaw("Interact") != 0f)
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        if (z_Interacted == false) //causes item to only be interacted with once. add else condition if item needs to be interacted with multiple times
        {
            z_Interacted=true;
            Debug.Log("Interact with " + name);
        }
        
    }
}
