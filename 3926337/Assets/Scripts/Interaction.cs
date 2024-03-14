using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float interactionDistance;
    public GameObject interactionText;
    public LayerMask interactionLayer;
    

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactionLayer))
        {
            if (hit.collider.gameObject.GetComponent<ReadNote>())
            {
                interactionText.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.gameObject.GetComponent<ReadNote>().openClosedLetter();
                }
            }
            else
            {
                interactionText.SetActive(false);
            }
            
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

}
