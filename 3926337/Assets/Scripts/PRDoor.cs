using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRDoor : MonoBehaviour
{
   
    public GameObject PrDoor;

    public bool doorIsOpen;

    void Update()
    {
        if (doorIsOpen == true) 
        {
            PrDoor.transform.Translate(Vector3.up * Time.deltaTime * 5);

        
        }
        if (PrDoor.transform.position.y > 28f) 
        { 
            doorIsOpen = false;

        
        }

    }
    void OnMouseDown()
    {
       doorIsOpen = true;
       
    }


}
