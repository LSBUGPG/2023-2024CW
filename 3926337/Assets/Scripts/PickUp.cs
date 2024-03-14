using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject pickUpText;
    private bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyPr")
        {
            pickUpText.SetActive(true);
            inReach = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "KeyPr")
        {
            pickUpText.SetActive(false);
            inReach = false;
        }
        if (Input.GetButtonDown("Interact") && inReach)
        {
           
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
